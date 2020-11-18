using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileZillaManager
{
    public partial class FormLogin : Form
    {
        public Classes.Empresa EmpresaSelecionada;
        public FormLogin()
        {
            InitializeComponent();
        }

        private void bt_Sair_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        private void frm_EmpresaSelect_Load(object sender, EventArgs e)
        {
            
            try
            {

                List<string> commands = new List<string>();
                commands.AddRange(Repositorio.EmpresaRepositorio.DDL());
                commands.AddRange(Repositorio.GrupoRepositorio.DDL());
                commands.AddRange(Repositorio.ContratoRepositorio.DDL());
                commands.AddRange(Repositorio.FileCheckRepositorio.DDL());
                commands.AddRange(Repositorio.MonitorRepositorio.DDL());


                FbDataBase.FbDataBase db = new FbDataBase.FbDataBase(Program.ConnectionString());

                db.CreateDataBaseIfNotExists(commands);

                db.ExecuteDDLs(commands);

                PreencheComboEmpresas();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao inicializar sistema. Conexão com o banco de dados. Mensagem: "+ ex.Message, "Erro FileZilla Manager", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            }
        }

        private void PreencheComboEmpresas()
        {
            Repositorio.EmpresaRepositorio rEmpresa = new Repositorio.EmpresaRepositorio();
            cb_Empresa.DisplayMember = "Nome";

            List<Classes.Empresa> lista = rEmpresa.SelectAll(null);

            while (lista == null || lista.Count == 0 /*|| !Funcoes.Ativado()*/)
            {
                FormEmpresa emp = new FormEmpresa();
                
                if (emp.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    lista = rEmpresa.SelectAll(null);
                }
                else
                {
                    this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
                    break;
                }

            }

            cb_Empresa.DataSource = lista;
            rEmpresa.Dispose();
        }

        private void bt_Entrar_Click(object sender, EventArgs e)
        {
            if (cb_Empresa.SelectedValue != null)
            {
                this.EmpresaSelecionada = cb_Empresa.SelectedValue as Classes.Empresa;
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
            else
                MessageBox.Show("Nenhuma Garagem foi informada.", "Iniciar Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}