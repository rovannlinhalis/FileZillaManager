using Miracle.FileZilla.Api;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml;

namespace FileZillaManager.Classes
{
    public class ContratoViewModel : IDisposable
    {
        private string pasta;
        private Contrato contrato;
        private FileInfo file;
        private long? folderSize;
        private FileCheck lastFileCheck;
        private ContratoState status = ContratoState.NaoVerificado;
        private bool SubPastas = false;
        List<string> ignorarExtensoes = new List<string>() { ".ini", ".db", ".txt", ".log" };
        private string mensagem = "";
        private string mensagemZip = "";
        private string lastCheckName;
        private long lastCheckSize;
        private DateTime lastCheckDate;
        
        private bool processZipIsRunning = false;
        Task verificaZip;
        Task verificaHash;
        private ZipCheckState integridade = ZipCheckState.NaoVerificado;
        private FTPState ftpState = FTPState.Desconectado;

        public FileSystemWatcher Watcher;

        public ContratoViewModel(Contrato c, string dir, bool subPastas, DateTime _dataRef, Empresa empresa)
        {
            this.Contrato = c;
            this.Empresa = empresa;
            this.DataRef = _dataRef;
            this.Pasta = dir;
            this.SubPastas = subPastas;
            Watcher = new FileSystemWatcher(dir, "*");
            Watcher.IncludeSubdirectories = subPastas;
            Watcher.Changed += Watcher_FileChanged;
            Watcher.Created += Watcher_FileChanged;
            Watcher.Deleted += Watcher_FileChanged;
            Watcher.Renamed += Watcher_FileChanged;
        }

        
        private void Watcher_FileChanged(object sender, FileSystemEventArgs e)
        {
            Watcher.EnableRaisingEvents = false;
            LerDiretorio();
        }

        public Empresa Empresa { get; set; }
        public DateTime DataRef { get; set; }
        public string HashFile { get; set; }
        public Contrato Contrato { get => contrato; set { contrato = value;  } }
        public FileInfo File { get => file; set { file = value; RaisePropertyChanged("File"); } }
        public string Pasta { get => pasta; set { pasta = value; RaisePropertyChanged("Pasta"); } }
        public string TamanhoF { get => Tamanho.HasValue ? Tamanho.Value.ToSizeString() : ""; }
        public FileCheck LastFileCheck { get => lastFileCheck; set { lastFileCheck = value;  } }
        public long? FolderSize { get => folderSize; set { folderSize = value; RaisePropertyChanged("FolderSize"); } }
        public string FolderSizeF { get => FolderSize.HasValue ? FolderSize.Value.ToSizeString() : ""; }
        public string Arquivo { get => file?.Exists ?? false ? file?.Name : null; }
        public long? Tamanho { get => file?.Exists ?? false ? file?.Length : null; }
        public DateTime? LastWrite { get => file?.Exists ?? false ? file?.LastWriteTime : null; }
        public string Login { get => Contrato?.Login; }
        public string Nome { get => Contrato?.Nome; }
        public string Hash { get => LastFileCheck?.Hash; }
        public ContratoState Status { get => status; set { status = value; RaisePropertyChanged("Status"); } }
        public string StatusX { get => Status == ContratoState.Erro ? mensagem : Status.GetEnumDescription(); }
        public bool Visible { get => this.Status != ContratoState.DiretorioVazio; }
        public Color FolderSizeColor { get => Contrato.Armazenamento <= 0 ? Color.White : (FolderSize / 1024 / 1024 / 1024) > Contrato.Armazenamento ? Color.Red : Color.LightBlue; }
        public ZipCheckState Integridade { get => integridade; set { integridade = value; RaisePropertyChanged("Integridade"); } }
        public string IntegridadeX { get => this.Integridade == ZipCheckState.Erro ? mensagemZip : this.Integridade.GetEnumDescription(); }
        public FTPState FtpState { get => ftpState; set { ftpState = value; RaisePropertyChanged("FtpState"); } }
        public DateTime LastLerDiretorio { get; set; } = DateTime.MinValue;
        public DateTime LastHashDate { get; set; } = DateTime.MinValue;
        public DateTime lastIntegrityDate { get; set; } = DateTime.MinValue;

        private bool lendoDiretorio = false;
        public bool VerificandoIntegridade { get => processZipIsRunning || (verificaZip != null && (verificaZip.Status == TaskStatus.Running || verificaZip.Status == TaskStatus.WaitingToRun)); }
        public bool VerificandoHash { get =>  (verificaHash != null && (verificaHash.Status == TaskStatus.Running || verificaHash.Status == TaskStatus.WaitingToRun)); }
        
        //public event PropertyChangedEventHandler PropertyChanged;
        private void RaisePropertyChanged(string prop)
        {
            //if (PropertyChanged != null)
            //    PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
        public void CheckStatusFTP()
        {

            if (MonitorViewModel.Conexoes.Any(x => x.UserName == this.contrato.Login))// && x.PhysicalFile == file.FullName))
            {
                var con = MonitorViewModel.Conexoes.Where(x => x.UserName == this.contrato.Login && x.PhysicalFile == file.FullName)?.FirstOrDefault();
                if (con != null)
                    this.FtpState = con.TransferMode == TransferMode.Send ? FTPState.Enviando : con.TransferMode == TransferMode.Receive ? FTPState.Recebendo : FTPState.Conectado;
                else
                    this.FtpState = FTPState.Conectado;
            }
            else
                this.FtpState = FTPState.Desconectado;

        }
        public void LerDiretorio()
        {
            if (!lendoDiretorio)
            {
                this.LastLerDiretorio = DateTime.Now;
                lendoDiretorio = true;
                try
                {
                    DirectoryInfo dir = new DirectoryInfo(this.Pasta);

                    if (!dir.Exists)
                    {
                        try
                        {
                            dir.Create();
                            dir.Refresh();
                        }
                        catch { }
                    }

                    if (dir.Exists)
                    {
                        DateTime dataAux = this.DataRef == DateTime.MinValue ? DateTime.Now : this.DataRef;

                        FileInfo[] files = dir.GetFiles("*.*", SubPastas ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly);
                        FileInfo file = files?.Where(x => x.LastWriteTime.Date <= dataAux.Date && !ignorarExtensoes.Contains(x.Extension.ToLower()))?.OrderByDescending(x => x.LastWriteTime)?.FirstOrDefault();
                        
                        this.File = null;

                        if (file != null)
                        {
                            this.File = file;

                            if (!SubPastas)
                            {   this.FolderSize = dir.GetFiles("*", SearchOption.AllDirectories)?.Sum(x => x.Length);
                                //this.FolderSize = files.Sum(x => x.Length);
                            }
                            else
                                this.FolderSize = files.Sum(x => x.Length);



                            if (file.LastWriteTime.Date == dataAux.Date)
                            {
                                this.Status = ContratoState.RecebidoHoje;
                            }
                            else if (file.LastWriteTime.Date >= dataAux.Date.AddDays(-1))
                            {
                                this.Status = ContratoState.Recebido1dia;
                            }
                            else if (file.LastWriteTime.Date >= dataAux.Date.AddDays(-3))
                            {
                                this.Status = ContratoState.Recebido2ou3dias;
                            }
                            else
                            {
                                this.Status = ContratoState.RecebidoMais3dias;
                            }

                            if (this.Integridade == ZipCheckState.NaoVerificado || lastCheckName != file.FullName || lastCheckSize != file.Length || lastCheckDate != file.LastWriteTime)
                                this.Integridade = ZipCheckState.AguardandoProcesso;
                        }
                        else
                        {
                            this.integridade = ZipCheckState.NaoAplicavel;
                            this.Status = ContratoState.DiretorioVazio;
                        }
                    }
                    else
                    {
                        this.Status = ContratoState.Erro;
                        mensagem = "Diretório Inacessível";
                    }
                }
                catch (Exception ex)
                {
                    this.Status = ContratoState.Erro;
                    mensagem = ex.Message;
                }
                lendoDiretorio = false;
                Watcher.EnableRaisingEvents = true;
            }
        }
        public void VerificarHash()
        {
            this.LastHashDate = DateTime.Now;
            verificaHash = Task.Factory.StartNew(() =>
            {

                Watcher.EnableRaisingEvents = false;
                if (!String.IsNullOrEmpty(this.Arquivo) && !String.IsNullOrWhiteSpace(this.Pasta))
                {
                    try
                    {
                        file = new FileInfo(Path.Combine(this.Pasta, this.Arquivo));
                        if (file.Exists)
                        {
                            if (this.integridade == ZipCheckState.AguardandoVerificacao || lastCheckName != file.FullName || lastCheckSize != file.Length || lastCheckDate != file.LastWriteTime)
                            {
                                lastCheckName = file.FullName;
                                lastCheckSize = file.Length;
                                lastCheckDate = file.LastWriteTime;

                                List<string> extensionsCheck = new List<string>() { ".zip", ".rar", ".7z" };
                                if (extensionsCheck.Contains(file.Extension.ToLower()))
                                {
                                    try
                                    {
                                        this.Integridade = ZipCheckState.GerandoHash;
                                        HashFile = Funcoes.SHA1FromFile(file);  //  Funcoes.Md5FromFile(file.FullName);
                                        using (Repositorio.FileCheckRepositorio rep = new Repositorio.FileCheckRepositorio())
                                        {
                                            var filesdb = rep.SelectAll(HashFile, file.FullName);

                                            if (filesdb.Count > 0)
                                                LastFileCheck = filesdb.FirstOrDefault();

                                            if (LastFileCheck == null || HashFile.ToUpper() != LastFileCheck?.Hash.ToUpper() || (LastFileCheck.State != ZipCheckState.Valido))
                                            {
                                                this.Integridade = ZipCheckState.AguardandoVerificacao;
                                            }
                                            else
                                            {
                                                this.Integridade = LastFileCheck.State;
                                                //this.Observacao = "Arquivo validado pelo hash no banco de dados";
                                            }
                                        } 
                                    }
                                    catch (IOException)
                                    {
                                        this.mensagemZip = "Sem acesso ao arquivo";
                                        this.Integridade = ZipCheckState.Erro;
                                    }
                                    catch (Exception ex)
                                    {
                                        this.mensagemZip = ex.Message;
                                        this.Integridade = ZipCheckState.Erro;
                                    }
                                }
                                else
                                {
                                    this.Integridade = ZipCheckState.NaoAplicavel;
                                }
                            }
                        }
                        else
                        {
                            this.Integridade = ZipCheckState.NaoAplicavel;
                        }
                    }
                    catch (Exception ex)
                    {
                        this.mensagemZip = ex.Message;
                        this.Integridade = ZipCheckState.Erro;
                    }
                }
                else
                {
                    this.Integridade = ZipCheckState.NaoAplicavel;
                }
                Watcher.EnableRaisingEvents = true;
            });
        }
        public void VerificarIntegridade()
        {
            this.lastIntegrityDate = DateTime.Now;
            this.Integridade = ZipCheckState.Verificando;
            verificaZip = Task.Factory.StartNew(() =>
            {
                Watcher.EnableRaisingEvents = false;
                processZipIsRunning = true;
                try
                {
                    if (file.Extension.ToLower() == ".zip" && (String.IsNullOrWhiteSpace(this.Empresa.Exe7zPath) || !System.IO.File.Exists(this.Empresa.Exe7zPath)))
                    {
                        this.Integridade = ZipCheckState.Verificando;
                        if (IsZipValid(file.FullName))
                        {
                            this.Integridade = ZipCheckState.Valido;
                        }
                        else
                        {
                            this.Integridade = ZipCheckState.Invalido;
                        }
                    }
                    else
                    {
                        if (!String.IsNullOrWhiteSpace(this.Empresa.Exe7zPath) && System.IO.File.Exists(this.Empresa.Exe7zPath))
                        {
                            this.Integridade = ZipCheckState.Verificando;
                            this.Integridade = Is7zipRarValid(file.FullName);
                        }
                        else
                        {
                            this.mensagemZip = "7z.exe não encontrado";
                            this.Integridade = ZipCheckState.NaoAplicavel;
                        }
                    }

                    using (Repositorio.FileCheckRepositorio rep = new Repositorio.FileCheckRepositorio())
                    {
                        if (LastFileCheck == null)
                            rep.Insert(new FileCheck() { Contrato = this.Contrato.Codigo, Data = DateTime.Now, Hash = HashFile.ToLower(), Nome = file.FullName.ToLower(), State = this.Integridade });
                        else
                        {
                            LastFileCheck.State = this.Integridade;
                            LastFileCheck.Data = DateTime.Now;
                            rep.Update(LastFileCheck);
                        }
                    }

                }
                catch (Exception ex)
                {
                    processZipIsRunning = false;
                    this.mensagemZip = ex.Message;
                    this.Integridade = ZipCheckState.Erro;
                }
                processZipIsRunning = false;
                Watcher.EnableRaisingEvents = true;
            });
            
        }
        private bool IsZipValid(string path)
        {
            try
            {
                using (var zipFile = ZipFile.OpenRead(path))
                {
                    var entries = zipFile.Entries;
                    return true;
                }
            }
            catch (InvalidDataException)
            {
                return false;
            }
        }
        private ZipCheckState Is7zipRarValid(string path)
        {
            processZipIsRunning = true;
            try
            {
                System.Diagnostics.Process p = new System.Diagnostics.Process();
                p.StartInfo.FileName = this.Empresa.Exe7zPath;
                if (!String.IsNullOrWhiteSpace(Contrato.SenhaCompactacao))// && IsPasswordProtected(path))
                {
                    p.StartInfo.Arguments = "t -p" + Contrato.SenhaCompactacao + " \"" + path + "\"";
                }
                else
                {
                    p.StartInfo.Arguments = "t \"" + path + "\"";
                }

                p.StartInfo.UseShellExecute = false;
                p.StartInfo.RedirectStandardOutput = true;
                p.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                p.StartInfo.CreateNoWindow = true;


                if (!Program.listaProcessosMonitor.Any(x => x.StartInfo.Arguments == p.StartInfo.Arguments && !x.HasExited))
                {
                    using (TextWriter tw = new StreamWriter(this.pasta + "\\log.log", false, Encoding.Default))
                    {
                        tw.WriteLine(this.Empresa.Exe7zPath);
                        tw.WriteLine(path);
                        tw.WriteLine("antes Start");
                        tw.WriteLine(p.StartInfo.Arguments);
                        if (p.Start())
                        {
                            tw.WriteLine("True on Start");
                            Program.listaProcessosMonitor.Add(p);
                            StreamReader reader = p.StandardOutput;
                            string r = reader.ReadToEnd();
                            tw.WriteLine("Antes wait for exit");
                            p.WaitForExit();
                            int i = p.ExitCode;
                            tw.WriteLine("Exit code: " + i);
                            try
                            {
                                if (!p.HasExited)
                                    p.Close();
                            }
                            catch { }
                            tw.WriteLine("out: " + r);
                            if (i == 0 || i == 2)
                                return r.Contains("Everything is Ok") ? ZipCheckState.Valido : ZipCheckState.Invalido;
                            else
                                return ZipCheckState.Erro;
                        }
                        else
                        {
                            tw.WriteLine("False on Start");
                            return ZipCheckState.Erro;
                        }
                    }
                }
                else
                {
                    return ZipCheckState.Verificando;
                }
            }
            catch (Exception ex)
            {
                using (TextWriter tw = new StreamWriter(this.pasta + "\\log.log", true, Encoding.Default))
                {
                    tw.WriteLine(ex.Message);
                    tw.WriteLine(ex.StackTrace);
                }
                mensagemZip = ex.Message;
                return ZipCheckState.Erro;
            }
            finally
            {
                processZipIsRunning = false;
            }
        }
        private bool IsPasswordProtected(string filename)
        {
            string _7z = this.Empresa.Exe7zPath;

            bool result = false;
            using (Process p = new Process())
            {
                p.StartInfo.UseShellExecute = false;
                p.StartInfo.RedirectStandardOutput = true;
                p.StartInfo.RedirectStandardError = true;
                //p.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                p.StartInfo.CreateNoWindow = true;
                p.StartInfo.FileName = _7z;
                p.StartInfo.Arguments = $"l -slt \"{filename}\"";
                p.Start();
                //Program.listaProcessosMonitor.Add(p);
                string stdout = p.StandardOutput.ReadToEnd();
                string stderr = p.StandardError.ReadToEnd();
                p.WaitForExit();

                if (stdout.Contains("Encrypted = +"))
                {
                    result = true;
                }
            }

            return result;
        }
        public void Dispose()
        {
            if (Watcher != null)
                try
                {
                    Watcher.Dispose();
                }
                catch { }

        }
    }
}
