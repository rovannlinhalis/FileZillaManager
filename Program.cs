using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using FileZillaManager.Classes;
using System.Threading;
using System.Configuration;
using System.IO;
using System.Text;
using System.ServiceProcess;
using System.Diagnostics;

namespace FileZillaManager
{
    
    static class Program
    {
        public static FileInfo fileConfigConnection = new FileInfo(Application.StartupPath + "\\FileZillaManager.ini");
        public const int LimiteCaixa = 3000;
        public static List<Process> listaProcessosMonitor = new List<Process>();
        public static string ConnectionString() => File.ReadAllText(fileConfigConnection.FullName, Encoding.Default).Replace("\r", "").Replace("\n", "");


        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            bool podeCarregar;
            FileInfo exe = new FileInfo(Application.ExecutablePath);
            string nome = exe.Name.Replace(@"\", "").Replace(".exe", "").Replace(".EXE", "");

            System.Threading.Mutex m = new System.Threading.Mutex(true, nome, out podeCarregar);

            if (!podeCarregar)
            {
                MessageBox.Show("O Programa já está sendo executado.", nome, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            CheckConfig();

            try
            {
                BackUp();
            }
            catch { }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            bool updated = false;
            if (args != null)
                if (args.Length > 0)
                    updated = true;

            DialogResult diagUpdate = DialogResult.Yes;
            if (!updated)
            {
                FormUpdate form = new FormUpdate();
                diagUpdate = form.ShowDialog();
            }

            if (diagUpdate == DialogResult.Yes)
            {

                CheckFirebirdInstallation();

                FormLogin frm_emp = new FormLogin();
                if (frm_emp.ShowDialog() == DialogResult.OK)
                {
                    //AppCenter.Start("81bb30ce-49f2-427c-8b93-72c24c55cf40", typeof(Analytics), typeof(Crashes));
                    Application.Run(new FormPrincipal(frm_emp.EmpresaSelecionada));
                }
            }
            else if (diagUpdate == DialogResult.OK)
            {
                System.Diagnostics.Process.Start(Application.StartupPath + "\\FileZillaManagerInstallUpdate.exe");
                Thread.Sleep(800);
                Application.Exit();
            }
            else if (diagUpdate == DialogResult.Retry)
            {
                Application.Restart();
            }
            else
            {
                Application.Exit();
            }
        }

        static void BackUp()
        {
            List<FileInfo> dbs = new List<FileInfo>();
            DirectoryInfo dirBackup = new DirectoryInfo(Application.StartupPath + "\\BackUp");
            if (!dirBackup.Exists)
                dirBackup.Create();

            FileInfo backup = new FileInfo(dirBackup.FullName + "\\" + DateTime.Now.ToString("yyyy-MM-dd") + "_Backup.FileZillaManager");

            bool sucess = false;
            if (!backup.Exists)
            {
               

                        using (FbDataBase.FbDataBase db = new FbDataBase.FbDataBase(ConnectionString()))
                        {
                            FileInfo file = db.GetDatabaseFile();

                            if (file.Exists)
                                dbs.Add(file);
                        }
                  
                if (dbs.Count > 0)
                {
                    using (Ionic.Zip.ZipFile zip = new Ionic.Zip.ZipFile())
                    {
                        zip.Password = "947601";
                        zip.CompressionLevel = Ionic.Zlib.CompressionLevel.BestCompression;

                        int count = 0;
                        foreach (FileInfo file in dbs)
                        {
                            if (file.Exists)
                            {
                                zip.AddFile(file.FullName, "");
                                count++;
                            }
                        }

                        if (count > 0)
                        {
                            if (!dirBackup.Exists)
                                dirBackup.Create();

                            string destino = Path.Combine(dirBackup.FullName, backup.Name);

                            zip.Save(destino);
                            sucess = true;
                        }
                    }
                }
            }

            if (sucess && dirBackup.Exists)
            {
                FileInfo[] files = dirBackup.GetFiles("*.FileZillaManager", SearchOption.TopDirectoryOnly);
                foreach (FileInfo f in files)
                {
                    if (f.LastWriteTime < DateTime.Now.AddDays(-15))
                    {
                        f.Delete();
                    }
                }
            }
        }

        static void CheckConfig()
        {
            //"User=SYSDBA;Password=masterkey;Database=./MANAGER_DB.FDB;Port=3050;Dialect=3;Charset=NONE;Role=;Connection lifetime=0;Connection timeout=15;Pooling=true;MinPoolSize=0;MaxPoolSize=100;Packet Size=8192;ServerType=0;
            string connection = "User=SYSDBA;Password=masterkey;Database=./MANAGER_DB.FDB;Port=3050;Dialect=3;Charset=NONE;Role=;Connection lifetime=0;Connection timeout=15;Pooling=true;MinPoolSize=0;MaxPoolSize=100;Packet Size=8192;ServerType=0;";
            connection = "User=SYSDBA;Password=masterkey;Database=./MANAGER_DB.FDB;DataSource=localhost;Port=3050;Dialect=3;Charset=NONE;Role=;Connection lifetime=0;Connection timeout=15;Pooling=true;MinPoolSize=0;MaxPoolSize=100;Packet Size=8192;ServerType=0;";
                //"<?xml version=\"1.0\" encoding=\"utf-8\"?><configuration><connectionStrings><add name=\"fileZillaManager\" connectionString=\"User=SYSDBA;Password=masterkey;Database=./MANAGER_DB.FDB;Port=3050;Dialect=3;Charset=NONE;Role=;Connection lifetime=0;Connection timeout=15;Pooling=true;MinPoolSize=0;MaxPoolSize=100;Packet Size=8192;ServerType=0;\" providerName=\"FirebirdSql.Data.FirebirdClient\"/>  </connectionStrings><startup><supportedRuntime version=\"v4.0\" sku=\".NETFramework,Version=v4.5\"/></startup></configuration>";



            if (!fileConfigConnection.Exists)
            {
                using (TextWriter tw = new StreamWriter(fileConfigConnection.FullName, false, Encoding.Default))
                {
                    tw.Write(connection);

                    tw.Close();
                }

            }


        }

        static void CheckFirebirdInstallation()
        {

            ServiceController fbService = ServiceController.GetServices()
    .FirstOrDefault(s => s.ServiceName == "FirebirdServerDefaultInstance");

            if (fbService == null)
            {
                FileInfo install = new FileInfo(Application.StartupPath + "\\" + "Firebird-2.5.3.26778_0_Win32.exe");

                if (install.Exists)
                {
                    Process p = Process.Start(install.FullName, "/SILENT");

                    p.WaitForExit();

                    //Application.Restart();
                }
                else
                {
                    MessageBox.Show("Serviço do firebird não está instalado, e não foi encontrada a instalação no caminho: " + install.FullName, "ParkConrol", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Application.Exit();
                }
            }
            else
            {
                while (fbService.Status != ServiceControllerStatus.Running)
                {
                    fbService.Start();
                    Thread.Sleep(1000);
                }


            }

        }

        public static void MatarProcessosMonitor()
        {
            if (Program.listaProcessosMonitor.Count > 0)
                foreach (var p in Program.listaProcessosMonitor)
                {
                    try
                    {
                        Process px = Process.GetProcessById(p.Id);
                        if (!px.HasExited)
                        {
                            px.Kill();
                        }
                    }
                    catch { }
                }
        }
    }
}
