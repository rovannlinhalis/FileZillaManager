﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileZillaManager.Classes
{
    public class ContratoOldViewModel : INotifyPropertyChanged
    {
        private string nome;
        private string status;
        private DateTime lastWrite;
        private string arquivo;
        private string pasta;
        private Color cor = Color.Gray;
        private bool subPasta;
        private long tamanho;
        private string login;
        private string exe7z;
        private string msgZipValido;
        private ZipCheckState zipValido = ZipCheckState.AguardandoProcesso;
        private string senhaZip;
        Task verificaZip = null;
        Task verificaHash = null;
        private bool processHashIsRunning = false;
        private bool processZipIsRunning = false;
        private bool processContract = false;
        private string hashAtual = null;
        public DateTime UltimoProcessamento { get; set; } = DateTime.MinValue;
        DateTime DataRef;
        public bool ForceCheck { get; set; } = false;

        List<string> ignorarExtensoes = new List<string>() { ".ini", ".db", ".txt" };

        public ContratoOldViewModel(string nome, string login, string pasta, bool subPastas, string _exe7Z, string _senhaZip, Contrato _contrato, DateTime? _dataRef = null)
        {
            this.Login = login;
            this.Nome = nome;
            this.Pasta = pasta;
            this.subPasta = subPastas;
            this.exe7z = _exe7Z;
            this.senhaZip = _senhaZip;
            this.status = "Aguardando Processamento";
            this.Contrato = _contrato;
            this.DataRef =  _dataRef.HasValue ? _dataRef.Value : DateTime.MinValue;
            Processa();
        }

        public string Nome { get => nome; set { if (nome != value) { nome = value; RaisePropertyChanged("Nome"); } } }
        public string Pasta { get => pasta; set { if (pasta != value) { pasta = value; RaisePropertyChanged("Pasta"); } } }
        public string Arquivo { get => arquivo; set { if (value != arquivo) { arquivo = value; RaisePropertyChanged("Arquivo"); } } }
        public string Status { get => status; set { if (status != value) { status = value; RaisePropertyChanged("Status"); } } }
        public DateTime LastWrite { get => lastWrite; set { if (lastWrite != value) { lastWrite = value; RaisePropertyChanged("LastWrite"); } } }
        public Color Cor { get => cor; set { if (cor != value) { cor = value; RaisePropertyChanged("Cor"); } } }
        public Contrato Contrato { get; set; }
        public bool ProcessandoContrato { get => processContract; }
        public ZipCheckState ZipValido { get => zipValido; set { if (zipValido != value) { zipValido = value; RaisePropertyChanged("ZipValido"); } } }
        public string Login { get => login; set { if (login != value) { login = value; RaisePropertyChanged("Login"); } } }
        public long Tamanho { get => tamanho; set {  { tamanho = value; RaisePropertyChanged("Tamanho"); } } }
        public bool VerificandoZip { get => processZipIsRunning || (verificaZip != null && (verificaZip.Status == TaskStatus.Running || verificaZip.Status == TaskStatus.WaitingToRun)); }
        public bool VerificandoHash { get => processHashIsRunning || (verificaHash != null && (verificaHash.Status == TaskStatus.Running || verificaHash.Status == TaskStatus.WaitingToRun)); }

        public string TamanhoF { get => this.Tamanho.ToSizeString(); }
        public string MsgZipValido { get => ZipValido == ZipCheckState.Erro ? msgZipValido : ZipValido.ToString(); set { msgZipValido = value; RaisePropertyChanged("MsgZipValido"); } }

        public string HashFile { get => hashAtual; set { if (hashAtual != value) { hashAtual = value; RaisePropertyChanged("HashFile"); } } }
        public string Observacao { get => observacao; set { if (observacao != value) { observacao = value; RaisePropertyChanged("Observacao"); } } }
        public long FolderSize { get => folderSize; set { { folderSize = value; RaisePropertyChanged("FolderSize"); } } }
        public string FolderSizeF { get => FolderSize.ToSizeString(); }
        public Color FolderSizeColor { get => Contrato.Armazenamento <=0 ? Color.Empty :  (FolderSize / 1024 / 1024 / 1024) > Contrato.Armazenamento ? Color.IndianRed : Color.LightBlue; }


        public event PropertyChangedEventHandler PropertyChanged;
        private void RaisePropertyChanged(string prop)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

        public void Processa()
        {

            processContract = true;
            try
            {
                DirectoryInfo dir = new DirectoryInfo(this.Pasta);

                if (!dir.Exists)
                {
                    try
                    {
                        dir.Create();
                    }
                    catch { }
                }

                if (dir.Exists)
                {
                    DateTime dataAux = this.DataRef == DateTime.MinValue ? DateTime.Now : this.DataRef;

                    FileInfo[] files = dir.GetFiles("*.*", subPasta ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly);

                    FileInfo file = files?.Where(x => x.LastWriteTime.Date <= dataAux.Date &&  !ignorarExtensoes.Contains(x.Extension.ToLower()))?.OrderByDescending(x => x.LastWriteTime)?.FirstOrDefault();
                    if (file != null)
                    {
                        this.Arquivo = file.Name;
                        this.LastWrite = file.LastWriteTime;
                        this.Tamanho = file.Length;
                        this.FolderSize = files.Sum(x => x.Length);

                        if (file.LastWriteTime.Date == dataAux.Date)
                        {
                            this.Cor = Color.LightGreen;
                            this.Status = "Último arquivo recebido hoje";
                        }
                        else if (file.LastWriteTime.Date >= dataAux.Date.AddDays(-1))
                        {
                            this.Cor = Color.LightBlue;
                            this.Status = "Último arquivo recebido ontem";
                        }
                        else if (file.LastWriteTime.Date >= dataAux.Date.AddDays(-3))
                        {
                            this.Cor = Color.Orange;
                            this.Status = "Último arquivo recebido há 2 ou 3 dias";
                        }
                        else
                        {
                            this.Cor = Color.Red;
                            this.Status = "Último arquivo recebido há mais de 3 dias";
                        }

                        //VerificarCompactacao();

                    }
                    else
                    {
                        this.Arquivo = String.Empty;
                        this.Tamanho = 0;
                        this.ZipValido = ZipCheckState.NaoAplicavel;
                        this.Cor = Color.Gray;
                        Status = "Nenhum arquivo na pasta cliente";
                    }

                }
                else
                {
                    this.Cor = Color.Gray;
                    Status = "Pasta cliente não existe ou é inacessível";
                }

            }
            catch (Exception ex)
            {
                this.Cor = Color.Gray;
                Status = "Erro ao processar contrato. Erro: " + ex.Message;
            }
            finally
            {
                processContract = false;
            }

        }

        string lastCheckName = null;
        long lastCheckSize = -1;
        DateTime lastCheckDate = DateTime.MinValue;
        private string observacao;
        private long folderSize;
        FileCheck fileDb = null;
        FileInfo file;
        public void VerificarIntegridade()
        {
            this.ZipValido = ZipCheckState.Verificando;
            verificaZip = Task.Factory.StartNew(() =>
            {
                processZipIsRunning = true;
                try
                {

                    ForceCheck = false;
                    if (file.Extension.ToLower() == ".zip" && (String.IsNullOrWhiteSpace(this.exe7z) || !File.Exists(this.exe7z)))
                    {
                        this.ZipValido = ZipCheckState.Verificando;
                        if (IsZipValid(file.FullName))
                        {
                            this.ZipValido = ZipCheckState.Valido;
                        }
                        else
                        {
                            this.ZipValido = ZipCheckState.Invalido;
                        }
                    }
                    else
                    {
                        if (!String.IsNullOrWhiteSpace(this.exe7z) && File.Exists(this.exe7z))
                        {
                            this.ZipValido = ZipCheckState.Verificando;
                            this.ZipValido = Is7zipRarValid(file.FullName);
                        }
                        else
                        {
                            this.Observacao =
                            this.MsgZipValido = "7z.exe não encontrado";
                            this.ZipValido = ZipCheckState.NaoAplicavel;
                        }
                    }

                    using (Repositorio.FileCheckRepositorio rep = new Repositorio.FileCheckRepositorio())
                    {
                        if (fileDb == null)
                            rep.Insert(new FileCheck() { Contrato = this.Contrato.Codigo, Data = DateTime.Now, Hash = HashFile.ToLower(), Nome = file.FullName.ToLower(), State = this.ZipValido });
                        else
                        {
                            fileDb.State = this.ZipValido;
                            fileDb.Data = DateTime.Now;
                            rep.Update(fileDb);
                        }
                    }

                }
                catch (Exception ex)
                {
                    processZipIsRunning = false;
                    this.MsgZipValido = ex.Message;
                    File.WriteAllText("zipcheck.log", ex.Message + " / " + ex.StackTrace);
                    this.ZipValido = ZipCheckState.Erro;
                }
                processZipIsRunning = false;
            });
        }

        public void VerificarHash()
        {
            this.Observacao = String.Empty;
            if (!String.IsNullOrEmpty(this.Arquivo) && !String.IsNullOrWhiteSpace(this.Pasta))
            {
                try
                {
                    file = new FileInfo(Path.Combine(this.Pasta, this.Arquivo));
                    if (file.Exists)
                    {
                        if (this.ForceCheck || lastCheckName != file.FullName || lastCheckSize != file.Length || lastCheckDate != file.LastWriteTime)
                        {
                            lastCheckName = file.FullName;
                            lastCheckSize = file.Length;
                            lastCheckDate = file.LastWriteTime;

                            List<string> extensionsCheck = new List<string>() { ".zip", ".rar", ".7z" };
                            if (extensionsCheck.Contains(file.Extension.ToLower()))
                            {

                                if (!this.VerificandoZip)//   verificaZip == null || (verificaZip.Status != TaskStatus.Running && verificaZip.Status != TaskStatus.WaitingToRun))
                                {
                                    verificaHash = Task.Factory.StartNew(() =>
                                  {
                                      processHashIsRunning = true;
                                      try
                                      {
                                          
                                          this.ZipValido = ZipCheckState.GerandoHash;
                                          HashFile = Funcoes.SHA1FromFile(file);  //  Funcoes.Md5FromFile(file.FullName);
                                          using (Repositorio.FileCheckRepositorio rep = new Repositorio.FileCheckRepositorio())
                                          {
                                              var filesdb = rep.SelectAll(HashFile, file.FullName);

                                              if (filesdb.Count > 0)
                                                  fileDb = filesdb.FirstOrDefault();

                                              if (fileDb == null || HashFile.ToUpper() != fileDb?.Hash.ToUpper() || this.ForceCheck || (fileDb.State != ZipCheckState.Valido))
                                              {
                                                  this.ZipValido = ZipCheckState.AguardandoVerificacao;
                                              }
                                              else
                                              {
                                                  this.ZipValido = fileDb.State;
                                                  this.Observacao = "Arquivo validado pelo hash no banco de dados";
                                              }
                                          }
                                      }
                                      catch (IOException)
                                      {
                                          processHashIsRunning = false;
                                          this.MsgZipValido = "Sem acesso ao arquivo";
                                          this.ZipValido = ZipCheckState.Erro;
                                      }
                                      catch (Exception ex)
                                      {
                                          processHashIsRunning = false;
                                          this.MsgZipValido = ex.Message;
                                          File.WriteAllText("zipcheck.log", ex.Message + " / " + ex.StackTrace);
                                          this.ZipValido = ZipCheckState.Erro;
                                      }
                                      processHashIsRunning = false;
                                  });
                                }
                            }
                            else
                            {
                                this.ZipValido = ZipCheckState.NaoAplicavel;
                            }
                        }
                    }
                    else
                    {
                        this.ZipValido = ZipCheckState.NaoAplicavel;
                    }
                }
                catch (Exception ex)
                {
                    this.MsgZipValido = ex.Message;
                    this.ZipValido = ZipCheckState.Erro;
                }
            }
            else
            {
                this.ZipValido = ZipCheckState.NaoAplicavel;
            }
        }

        public bool IsZipValid(string path)
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

        public ZipCheckState Is7zipRarValid(string path)
        {
            processZipIsRunning = true;
            System.Diagnostics.Process p = new System.Diagnostics.Process();
            p.StartInfo.FileName = this.exe7z;
            if (!String.IsNullOrWhiteSpace(this.senhaZip))// && IsPasswordProtected(path))
            {
                p.StartInfo.Arguments = "t -p" + this.senhaZip + " \"" + path + "\"";
            }
            else
            {
                p.StartInfo.Arguments = "t \"" + path + "\"";
            }

            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            p.StartInfo.CreateNoWindow = true;
            p.Start();
            Program.listaProcessosMonitor.Add(p);
            StreamReader reader = p.StandardOutput;
            string r = reader.ReadToEnd();
            p.WaitForExit();
            int i = p.ExitCode;

            p.Close();

            if (i == 0 || i == 2)
                return r.Contains("Everything is Ok") ? ZipCheckState.Valido : ZipCheckState.Invalido;
            else
                return ZipCheckState.Erro;
        }

        private bool IsPasswordProtected(string filename)
        {
            string _7z = this.exe7z;

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

    }


   
}
