using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileZillaManager
{
    public partial class FormUpdate : Form
    {
        //13/10/2017 - Rovann
        Queue<string> log = new Queue<string>();
        DirectoryInfo dirUpdate = new DirectoryInfo(Application.StartupPath + "\\Update\\");
        bool hidden;
        public FormUpdate(bool _hidden = false)
        {
            InitializeComponent();
            hidden = _hidden;
            if (hidden)
            {
                this.ShowInTaskbar = false;
                this.WindowState = FormWindowState.Minimized;
            }
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            if (hidden)
            {
                this.Hide();
                this.ShowInTaskbar = false;
            }

        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            //"http://www.sistemasintegra.com.br/atualizacao/

            if (!dirUpdate.Exists)
                dirUpdate.Create();

            log.Enqueue("Recebendo lista de arquivos...");
            backgroundWorker1.ReportProgress(1);

            Thread.Sleep(200);

            string md5list = Funcoes.GetMd5DirFromSite("FileZillaManager")?.Replace("\n", "")?.Replace("\r", "");

            if (!String.IsNullOrEmpty(md5list))
            {
                string[] files = md5list.Split(';');

                log.Enqueue("Processando lista de arquivos...");
                backgroundWorker1.ReportProgress(2);
                Thread.Sleep(200);
                int downloaded = 0;
                int p = 0;
                foreach (string f in files)
                {
                    string[] fs = f.Split('|');

                    if (fs.Length < 2)
                    {
                        p++;
                        continue;
                    }

                    string nomeHttp = fs[0];
                    string nome = fs[0].Replace("FileZillaManager/", "").Replace("/", "\\");


                    log.Enqueue("Processando arquivo " + nome);
                    backgroundWorker1.ReportProgress(p * 98 / files.Length + 2);
                    Thread.Sleep(100);


                    string md5Site = fs[1];
                    FileInfo file = new FileInfo(Application.StartupPath + "\\" + nome);

                    if (file.Extension.ToLower().EndsWith("fdb"))// || file.Extension.ToLower().EndsWith("config"))
                    {
                        p++;
                        continue;
                    }


                    FileInfo fileUpdate;
                    if (file.Name.ToLower() == "FileZillaManagerInstallUpdate.exe".ToLower())
                        fileUpdate = new FileInfo(Application.StartupPath + "\\" + nome);
                    else
                        fileUpdate = new FileInfo(dirUpdate.FullName + nome);


                    bool download = false;

                    if (!file.Exists)
                    {
                        download = true;
                    }
                    else
                    {
                        string md5Local = Funcoes.Md5FromFile(file.FullName);

                        if (md5Local != md5Site)
                        {
                           

                            if (fileUpdate.Exists)
                            {
                                string md5Update = Funcoes.Md5FromFile(fileUpdate.FullName);
                                if (md5Update != md5Site)
                                {
                                    download = true;
                                }
                                else
                                {
                                    downloaded++;
                                }
                            }
                            else
                            {
                                download = true;
                            }
                        }
                    }

                    if (download && !System.Diagnostics.Debugger.IsAttached)
                    {
                        if (!fileUpdate.Directory.Exists)
                            fileUpdate.Directory.Create();

                        log.Enqueue("Baixando arquivo " + nome);
                        backgroundWorker1.ReportProgress(p * 98 / files.Length + 2);
                        Thread.Sleep(100);
                        string remoteUri = "https://www.rovann.com.br/atualizacao/" + nomeHttp;
                        WebClient myWebClient = new WebClient();

                        myWebClient.DownloadFile(remoteUri, fileUpdate.FullName);

                        fileUpdate.Refresh();

                        if (fileUpdate.Exists)
                        {
                            string md5Download = Funcoes.Md5FromFile(fileUpdate.FullName);

                            if (md5Download != md5Site)
                            {
                                fileUpdate.Delete();
                                throw new Exception("Erro no download do arquivo " + nomeHttp);
                            }
                            else
                            {
                                downloaded++;
                            }
                        }
                        else
                        {
                            throw new Exception("Erro no download do arquivo " + nomeHttp);
                        }
                    }

                    log.Enqueue("Arquivo processado: " + nome);
                    backgroundWorker1.ReportProgress(p * 98 / files.Length + 2);
                    Thread.Sleep(100);

                    p++;
                }

                e.Result = downloaded;
                log.Enqueue("Fim da verificação");
                backgroundWorker1.ReportProgress(100);
                Thread.Sleep(100);
            }
            else
            {
                e.Result = -1;
                log.Enqueue("Nenhuma informação recebida");
            }
        }

        private void FormUpdate_Load(object sender, EventArgs e)
        {
            backgroundWorker1.RunWorkerAsync();
        }
        

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage > progressBar1.Maximum ? progressBar1.Maximum : e.ProgressPercentage < progressBar1.Minimum ? progressBar1.Minimum : e.ProgressPercentage;
            while(log.Count >0)
            {
                labelStatus.Text = log.Dequeue();
            }
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                labelStatus.Text = "Erro ao verificar atualização: " + e.Error.Message;
                aux = System.Windows.Forms.DialogResult.Yes; //YES vai iniciar a aplicação
            }
            else
            {
                if (!System.Diagnostics.Debugger.IsAttached)
                {
                    int d = (int)e.Result;
                    if (d > 0)
                    {
                        aux = System.Windows.Forms.DialogResult.OK; //OK Vai executar o instalador
                    }
                    else
                    {
                        dirUpdate.Refresh();
                        if (dirUpdate.Exists)
                            dirUpdate.Delete(true);
                        aux = System.Windows.Forms.DialogResult.Yes;  //YES vai iniciar a aplicação
                    }
                }
                else
                {
                    aux = System.Windows.Forms.DialogResult.Yes;
                }
            }

            timer1.Enabled = true;
        }
        DialogResult aux;
        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            this.DialogResult = aux;
        }
    }
}
