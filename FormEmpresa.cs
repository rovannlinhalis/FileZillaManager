using FileZillaManager.Classes;
using Miracle.FileZilla.Api;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileZillaManager
{
    public partial class FormEmpresa : FormBase
    {
        Repositorio.EmpresaRepositorio repositorio;
        public Classes.Empresa ObjEmpresa { get; set; }
        public FormEmpresa()
        {
            InitializeComponent();
            Funcoes.ColorirObjetos(this);
            Funcoes.TrocaTabPorEnter(this);
        }

        private void FormEmpresa_Load(object sender, EventArgs e)
        {
            lblCodigo.Text = "";
            repositorio = new Repositorio.EmpresaRepositorio();
            ObjEmpresa = repositorio.SelectAll(null).FirstOrDefault();

            if (ObjEmpresa != null)
            {
                lblCodigo.Text = ObjEmpresa.Codigo.ToString();
                txbNome.Text = ObjEmpresa.Nome;
                txtHost.Text = ObjEmpresa.Host;
                txtPorta.Text = ObjEmpresa.Port.ToString();
                txbUsuario.Text = ObjEmpresa.Login;
                txbSenha.Text = ObjEmpresa.Pass;
                textBox7ZPath.Text = ObjEmpresa.Exe7zPath;
               
            }
        }

        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            if (this.Modal)
                this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            else
                this.Close();
        }

        private void buttonGravar_Click(object sender, EventArgs e)
        {
            try
            {
                Funcoes.ValidarCamposObrigatorios(this);

                if (this.ObjEmpresa == null)
                    this.ObjEmpresa = new Classes.Empresa();

                this.ObjEmpresa.Nome = txbNome.Text;
                ObjEmpresa.Host = txtHost.Text;
                ObjEmpresa.Port = Funcoes.ToInt(txtPorta.Text);
                ObjEmpresa.Login = txbUsuario.Text;
                ObjEmpresa.Pass = txbSenha.Text;
                ObjEmpresa.Exe7zPath = textBox7ZPath.Text;

                if (String.IsNullOrEmpty(lblCodigo.Text))
                {
                    this.ObjEmpresa.Codigo = repositorio.Insert(this.ObjEmpresa).Codigo;
                }
                else
                {
                    int r = repositorio.Update(this.ObjEmpresa);
                }

                repositorio.Dispose();

                MessageBox.Show("Dados gravados com sucesso!", "Configurações", MessageBoxButtons.OK, MessageBoxIcon.Information);


                if (this.Modal)
                    this.DialogResult = System.Windows.Forms.DialogResult.OK;
                else
                    this.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Configurações", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonTestarConexao_Click(object sender, EventArgs e)
        {
            try
            {
                if (IPAddress.TryParse(txtHost.Text, out IPAddress ip))
                {
                    using (IFileZillaApi fileZillaApi = new FileZillaApi(ip, Funcoes.ToInt(txtPorta.Text)))
                    {
                        fileZillaApi.Connect(txbSenha.Text);
                        if (fileZillaApi.IsConnected)
                        {
                            var state = fileZillaApi.GetServerState();

                            if (state == ServerState.Online)
                            {
                                MessageBox.Show("Conexão estabelecida com sucesso", "Conectar ao FileZilla", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                MessageBox.Show("Servidor OffLine", "Conectar ao FileZilla", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Não foi possível estabelecer uma conexão", "Conectar ao FileZilla", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Não foi possível estabelecer uma conexão. Erro: Endereço Iválido", "Conectar ao FileZilla", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Não foi possível estabelecer uma conexão. Erro: "+ ex.Message, "Conectar ao FileZilla", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonImportar_Click(object sender, EventArgs e)
        {
            try
            {
                if (IPAddress.TryParse(txtHost.Text, out IPAddress ip))
                {
                    using (IFileZillaApi fileZillaApi = new FileZillaApi(ip, Funcoes.ToInt(txtPorta.Text)))
                    {
                        fileZillaApi.Connect(txbSenha.Text);
                        if (fileZillaApi.IsConnected)
                        {
                            var accountSettings = fileZillaApi.GetAccountSettings();
                            int i = 0, g =0;

                            using (Repositorio.GrupoRepositorio gRep = new Repositorio.GrupoRepositorio())
                            {
                                gRep.byPassFileZilla = true;

                                var groupList = gRep.SelectAll(null);

                                foreach (var group in accountSettings.Groups)
                                {
                                    if (groupList.Any(x => x.Nome == group.GroupName))
                                    {
                                        Classes.Grupo c = groupList.Where(x => x.Nome == group.GroupName).FirstOrDefault();
                                        c.Nome = group.GroupName;
                                        c.Pasta = group.SharedFolders?.FirstOrDefault()?.Directory;
                                        c.Ativo = group.Enabled == TriState.Yes;
                                        c.Permissao = group.SharedFolders?.FirstOrDefault()?.AccessRights.ToString();
                                        gRep.Update(c);
                                    }
                                    else
                                    {

                                        Classes.Grupo c = new Classes.Grupo();
                                        c.Nome = group.GroupName;
                                        c.Pasta = group.SharedFolders?.FirstOrDefault()?.Directory;
                                        c.Ativo = group.Enabled == TriState.Yes;
                                        c.Permissao = group.SharedFolders?.FirstOrDefault()?.AccessRights.ToString();
                                        gRep.Insert(c);
                                    }
                                    g++;
                                }

                                groupList = gRep.SelectAll(null);


                                using (Repositorio.ContratoRepositorio rep = new Repositorio.ContratoRepositorio())
                                {
                                    rep.byPassFileZilla = true;
                                    var list = rep.SelectAll(null);

                                    foreach (var user in accountSettings.Users)
                                    {
                                        if (list.Any(x => x.Login == user.UserName))
                                        {
                                            Classes.Contrato c = list.Where(x => x.Login == user.UserName).FirstOrDefault();
                                            c.Nome = String.IsNullOrEmpty(user.Comment) ? user.UserName : user.Comment;
                                            c.Login = user.UserName;
                                            c.DataContrato = DateTime.Now;
                                            c.Pasta = user.SharedFolders?.FirstOrDefault()?.Directory;
                                            c.Ativo = user.Enabled == TriState.Yes;
                                            c.Permissao = user.SharedFolders?.FirstOrDefault()?.AccessRights.ToString();
                                            if (!String.IsNullOrWhiteSpace(user.GroupName))
                                                c.GrupoId = groupList.Where(x => x.Nome == user.GroupName)?.FirstOrDefault()?.Codigo;
                                            else
                                                c.GrupoId = null;

                                            if (String.IsNullOrEmpty(c.Pass))
                                                c.Pass = user.Password;

                                            rep.Update(c);
                                        }
                                        else
                                        {
                                            Classes.Contrato c = new Classes.Contrato();
                                            c.Nome = String.IsNullOrEmpty(user.Comment) ? user.UserName : user.Comment;
                                            c.Login = user.UserName;
                                            c.DataContrato = DateTime.Now;
                                            c.Pasta = user.SharedFolders?.FirstOrDefault()?.Directory;
                                            c.Ativo = user.Enabled == TriState.Yes;
                                            c.Pass = user.Password;
                                            c.Permissao = user.SharedFolders?.FirstOrDefault()?.AccessRights.ToString();

                                            if (!String.IsNullOrWhiteSpace(user.GroupName))
                                                c.GrupoId = groupList.Where(x => x.Nome == user.GroupName)?.FirstOrDefault()?.Codigo;
                                            else
                                                c.GrupoId = null;


                                            rep.Insert(c);
                                        }
                                        i++;
                                    }
                                }

                            }

                            if (i>0)
                            {
                                MessageBox.Show($"{i} Contratos Importados", "Importar Dados", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                                MessageBox.Show("Nenhum registro para importar", "Importar Dados", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Não foi possível estabelecer uma conexão", "Conectar ao FileZilla", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Não foi possível estabelecer uma conexão. Erro: Endereço Iválido", "Conectar ao FileZilla", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Não foi possível estabelecer uma conexão. Erro: " + ex.Message, "Conectar ao FileZilla", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonBrowse7z_Click(object sender, EventArgs e)
        {
            OpenFileDialog diag = new OpenFileDialog();
            diag.Filter= "7z.exe|7z.exe";
            diag.InitialDirectory = "C:\\";
                
            if (diag.ShowDialog() == DialogResult.OK)
            {
                textBox7ZPath.Text = diag.FileName;
            }
        }

        private void buttonEnviarDados_Click(object sender, EventArgs e)
        {
            try
            {
                using (Repositorio.ContratoRepositorio rep = new Repositorio.ContratoRepositorio())
                {
                    var contratos = rep.SelectAll(null);
                    foreach (Contrato c in contratos)
                        rep.ProcessaFileZilla(c);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
