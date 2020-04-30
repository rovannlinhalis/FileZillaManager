using FileZillaManager.Classes;
using Miracle.FileZilla.Api;
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
    public partial class FormContrato : FormBase
    {
        List<Contrato> listaCompleta;
        List<Grupo> _grupos;
        public FormContrato()
        {
            InitializeComponent();
            dataGridView1.AutoGenerateColumns = false;
            Funcoes.ColorirObjetos(this);
            Funcoes.TrocaTabPorEnter(this);
        }

        public Task<List<Contrato>> GetRecords()
        {
            return Task.Factory.StartNew<List<Contrato>>(() => {

                List<Contrato> lista;
                using (Repositorio.ContratoRepositorio rep = new Repositorio.ContratoRepositorio())
                {
                    lista = rep.SelectAll(null);
                }

                return lista;

            });
        }
        public Task<List<Grupo>> GetGrupos()
        {
            return Task.Factory.StartNew<List<Grupo>>(() => {

                List<Grupo> lista;
                using (Repositorio.GrupoRepositorio rep = new Repositorio.GrupoRepositorio())
                {
                    lista = rep.SelectAll(null);
                }

                return lista;

            });
        }

        public async void CarregarGrid()
        {
            listaCompleta =  await GetRecords();
            
            Filtrar();
            
        }

        public async void CarregarCombo()
        {
            _grupos = await GetGrupos();

            campoGrupo.DataSource = _grupos;
            campoGrupo.DisplayMember = "Nome";
            campoGrupo.ValueMember = "Codigo";

        }

        private void Filtrar()
        {
            timerFiltro.Enabled = false;
            timerFiltro.Enabled = true;
        }
        private void timerFiltro_Tick(object sender, EventArgs e)
        {
            timerFiltro.Enabled = false;
            if (String.IsNullOrEmpty(textBoxFiltro.Text))
            {
                dataGridView1.DataSource = listaCompleta;
            }
            else
            {
                List<Contrato> listaFiltrada = listaCompleta.Where(x => x.Nome.Contains(textBoxFiltro.Text) || x.Login.Contains(textBoxFiltro.Text)).OrderByDescending(x => x.Nome.StartsWith(textBoxFiltro.Text) || x.Login.StartsWith(textBoxFiltro.Text)).ThenBy(x => x.Login.EndsWith(textBoxFiltro.Text) ||  x.Nome.EndsWith(textBoxFiltro.Text)).ToList();
                dataGridView1.DataSource = listaFiltrada;
            }
        }
        
        private void FormContrato_Load(object sender, EventArgs e)
        {
            lblCodigo.Text = "";
            Funcoes.ClearControl(panelCadastro);
            CarregarCombo();
            CarregarGrid();
        }

        private void SelectContrato(Contrato c )
        {
            lblCodigo.Text = c.Codigo.ToString();
            campoNome.Text = c.Nome;
            campoValor.Text = c.Valor.ToString("C2");
            campoUsuario.Text = c.Login;
            campoSenha.Text = c.Pass;
            campoPasta.Text = c.Pasta;
            campoDataContrato.Value = c.DataContrato;
            campoAtivo.Checked = c.Ativo;
            campoSenhaCompactacao.Text = c.SenhaCompactacao;
            checkBoxMonitorar.Checked = c.Monitorar;
            campoArmazenamento.Value = c.Armazenamento < campoArmazenamento.Minimum ? campoArmazenamento.Minimum : c.Armazenamento > campoArmazenamento.Maximum ? campoArmazenamento.Maximum : c.Armazenamento;
            if (c.GrupoId.HasValue)
                campoGrupo.SelectedValue = c.GrupoId;
            else
                campoGrupo.SelectedIndex = -1;
            if (Enum.TryParse<AccessRights>(c.Permissao, out AccessRights ac))
            {
                FileRead.Checked = (ac & AccessRights.FileRead)!=0;
                FileAppend.Checked = (ac & AccessRights.FileAppend) != 0;
                FileWrite.Checked = (ac & AccessRights.FileWrite) != 0;
                FileDelete.Checked = (ac & AccessRights.FileDelete) != 0;

                DirCreate.Checked = (ac & AccessRights.DirCreate) != 0;
                DirDelete.Checked = (ac & AccessRights.DirDelete) != 0;
                DirList.Checked = (ac & AccessRights.DirList) != 0;
                DirSubDir.Checked = (ac & AccessRights.DirSubdirs) != 0;
            }
            else
            {
                FileRead.Checked = FileWrite.Checked = FileAppend.Checked = FileDelete.Checked = DirList.Checked = DirSubDir.Checked = DirCreate.Checked = DirDelete.Checked = false;
            }
        }

        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            lblCodigo.Text = "";
            Funcoes.ClearControl(panelCadastro);
        }

        private void dataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                List<Contrato> lista = dataGridView1.DataSource as List<Contrato>;
                if (lista != null)
                {
                    Contrato c = lista[e.RowIndex];
                    SelectContrato(c);
                }
            }
        }

        private void buttonGravar_Click(object sender, EventArgs e)
        {
            try
            {

                Funcoes.ValidarCamposObrigatorios(this);

                Contrato c = new Contrato();
                c.Codigo = Funcoes.ToInt(lblCodigo.Text);
                c.Nome = campoNome.Text;
                c.Valor = Funcoes.ToDecimal(campoValor.Text);
                c.Login = campoUsuario.Text;
                c.Pass = campoSenha.Text;
                c.Pasta = campoPasta.Text;
                c.DataContrato = campoDataContrato.Value;
                c.Ativo = campoAtivo.Checked;
                c.GrupoId = campoGrupo.SelectedValue as int?;
                c.SenhaCompactacao = campoSenhaCompactacao.Text;
                c.Monitorar = checkBoxMonitorar.Checked;
                c.Armazenamento = campoArmazenamento.Value;

                AccessRights ac = AccessRights.IsHome;
                if (FileRead.Checked)
                    ac |= AccessRights.FileRead;
                if (FileWrite.Checked)
                    ac |= AccessRights.FileWrite;
                if (FileDelete.Checked)
                    ac |= AccessRights.FileDelete;
                if (FileAppend.Checked)
                    ac |= AccessRights.FileAppend;

                if (DirList.Checked)
                    ac |= AccessRights.DirList;
                if (DirDelete.Checked)
                    ac |= AccessRights.DirDelete;
                if (DirSubDir.Checked)
                    ac |= AccessRights.DirSubdirs;
                if (DirCreate.Checked)
                    ac |= AccessRights.DirCreate;

                c.Permissao = ac.ToString();
                //c.Permissao |= FileWrite.Checked ? Miracle.FileZilla.Api.AccessRights.FileWrite : Miracle.FileZilla.Api.AccessRights.DirCreate; 

                using (Repositorio.ContratoRepositorio rep = new Repositorio.ContratoRepositorio())
                {
                    if (c.Codigo<=0)
                    {
                        rep.Insert(c);
                    }
                    else
                    {
                        rep.Update(c);
                    }
                }
                CarregarGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro ao gravar", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonExcluir_Click(object sender, EventArgs e)
        {
            try
            {
                Contrato c = new Contrato();
                c.Codigo = Funcoes.ToInt(lblCodigo.Text);
                if (c.Codigo > 0)
                {
                    using (Repositorio.ContratoRepositorio rep = new Repositorio.ContratoRepositorio())
                    {


                        rep.Delete(c);
                    }
                    CarregarGrid();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro ao excluir", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void lblCodigo_TextChanged(object sender, EventArgs e)
        {
            campoUsuario.ReadOnly = 
            buttonExcluir.Enabled = !String.IsNullOrEmpty(lblCodigo.Text);

        }

        private void textBoxFiltro_TextChanged(object sender, EventArgs e)
        {
            Filtrar();
        }

        private void buttonProcurarPasta_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog diag = new FolderBrowserDialog())
            {
                diag.RootFolder = Environment.SpecialFolder.MyComputer;
                diag.ShowNewFolderButton = true;
                
                if (diag.ShowDialog() == DialogResult.OK)
                {
                    campoPasta.Text = diag.SelectedPath;
                }
            }
        }

        private void buttonVerSenha_Click(object sender, EventArgs e)
        {
            campoSenha.PasswordChar = campoSenha.PasswordChar == '*' ? '\0' : '*';

        }

        private void campoGrupo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Delete)
                campoGrupo.SelectedIndex = -1;
        }
    }
}
