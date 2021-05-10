using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using System.Threading;

namespace FileZillaManagerInstallUpdate
{
    static class Program
    {
        /// <summary>
        /// 13/10/2017 - Rovann
        /// </summary>
        [STAThread]
        static void Main()
        {
            Thread.Sleep(500);

            {
                bool podeCarregar;
                FileInfo exei = new FileInfo(Application.ExecutablePath);
                string nome = exei.Name.Replace(@"\", "").Replace(".exe", "").Replace(".EXE", "");

                System.Threading.Mutex m = new System.Threading.Mutex(true, nome, out podeCarregar);

                if (!podeCarregar)
                {
                    MessageBox.Show("O Programa já está sendo executado.", nome, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            DirectoryInfo dir = new DirectoryInfo(Application.StartupPath + "\\Update\\");
            FileInfo exe = new FileInfo(Application.ExecutablePath);

            try
            {
                

                if (dir.Exists)
                {


                    DialogResult diag = DialogResult.Retry;
                    bool sucess = false;
                    while (diag == DialogResult.Retry && !sucess)
                    {
                        try
                        {
                            Process[] ps = Process.GetProcessesByName("FileZillaManager");

                            while (ps.Length > 0)
                            {
                                //MessageBox.Show("A aplicação FileZillaManager será finalizada.", "Instalar Atualização", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                foreach (Process p in ps)
                                {
                                    p.Kill();
                                    Thread.Sleep(500);
                                }

                                ps = Process.GetProcessesByName("FileZillaManager");
                            }
                        }
                        catch 
                        { }

                        try
                        {
                            DirectoryInfo[] subDirs = dir.GetDirectories("*", SearchOption.AllDirectories);
                            foreach (DirectoryInfo sdir in subDirs)
                            {
                                try
                                {
                                    if (!sdir.Exists)
                                    {
                                        sdir.Create();
                                    }
                                }
                                catch { }
                            }

                            FileInfo[] files = dir.GetFiles("*", SearchOption.AllDirectories);
                            FileInfo local;
                            foreach (FileInfo file in files)
                            {
                                try
                                {
                                    string fUpdate = dir.FullName;
                                    fUpdate = fUpdate.EndsWith("\\") ? fUpdate : fUpdate + "\\";
                                    string xdir = Application.StartupPath;
                                    xdir = xdir.EndsWith("\\") ? xdir : xdir + "\\";

                                    FileInfo newFile = new FileInfo(file.FullName.Replace(fUpdate, xdir));

                                    if (!newFile.Directory.Exists)
                                        newFile.Directory.Create();

                                    if (newFile.Exists)
                                        newFile.Delete();

                                    file.CopyTo(newFile.FullName, true);

                                    try
                                    {
                                        file.Delete();
                                    }
                                    catch (Exception exx)
                                    { }
                                }
                                catch (Exception ex)
                                { }

                                Thread.Sleep(100);
                            }
                            sucess = true;
                        }
                        catch (Exception ex)
                        {
                            diag = MessageBox.Show(new Form() { TopMost = true }, ex.Message, "Erro ao atualizar arquivo", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                            sucess = false;
                        }
                    }
                    try
                    {
                        dir.Delete(true);
                    }
                    catch { }
                }
            }
            catch  (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace,  "Erro ao atualizar aplicação.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (exe.Exists)
            {
                System.Diagnostics.Process.Start(Application.StartupPath + "\\FileZillaManager.exe", "updated");
                Application.Exit();
            }
            else
            {
                MessageBox.Show("Aplicativo FileZillaManager.exe não foi encontrado.", "Erro ao iniciar aplicação.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
