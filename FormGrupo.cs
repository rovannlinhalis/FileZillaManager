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
    public partial class FormGrupo : FormBase
    {
        List<Classes.Grupo> listaCompleta;

        public FormGrupo()
        {
            InitializeComponent();
            dataGridView1.AutoGenerateColumns = false;
            Funcoes.ColorirObjetos(this);
            Funcoes.TrocaTabPorEnter(this);
        }

        private void FormGrupo_Load(object sender, EventArgs e)
        {
            lblCodigo.Text = "";
            Funcoes.ClearControl(panelCadastro);
            CarregarGrid();
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
                List<Grupo> listaFiltrada = listaCompleta.Where(x => x.Nome.Contains(textBoxFiltro.Text)).OrderByDescending(x => x.Nome.StartsWith(textBoxFiltro.Text)).ThenBy(x => x.Nome.EndsWith(textBoxFiltro.Text)).ToList();
                dataGridView1.DataSource = listaFiltrada;
            }
        }

        public Task<List<Grupo>> GetRecords()
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
            listaCompleta = await GetRecords();
            Filtrar();
        }

        private void Filtrar()
        {
            timerFiltro.Enabled = false;
            timerFiltro.Enabled = true;
        }

        private void buttonGravar_Click(object sender, EventArgs e)
        {
            try
            {

                Funcoes.ValidarCamposObrigatorios(this);

                Grupo c = new Grupo();
                c.Codigo = Funcoes.ToInt(lblCodigo.Text);
                c.Nome = campoNome.Text;
                c.Pasta = campoPasta.Text;
                c.Ativo = campoAtivo.Checked;

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

                using (Repositorio.GrupoRepositorio rep = new Repositorio.GrupoRepositorio())
                {
                    if (c.Codigo <= 0)
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
                Grupo c = new Grupo();
                c.Codigo = Funcoes.ToInt(lblCodigo.Text);
                if (c.Codigo > 0)
                {
                    using (Repositorio.GrupoRepositorio rep = new Repositorio.GrupoRepositorio())
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
        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            lblCodigo.Text = "";
            Funcoes.ClearControl(panelCadastro);
        }

        private void dataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                List<Grupo> lista = dataGridView1.DataSource as List<Grupo>;
                if (lista != null)
                {
                    Grupo c = lista[e.RowIndex];
                    SelectGrupo(c);
                }
            }
        }

        private void SelectGrupo(Grupo c)
        {
            lblCodigo.Text = c.Codigo.ToString();
            campoNome.Text = c.Nome;
            campoPasta.Text = c.Pasta;
            campoAtivo.Checked = c.Ativo;
            if (Enum.TryParse<AccessRights>(c.Permissao, out AccessRights ac))
            {
                FileRead.Checked = (ac & AccessRights.FileRead) != 0;
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

        private void textBoxFiltro_TextChanged(object sender, EventArgs e)
        {
            timerFiltro.Enabled = false;
            timerFiltro.Enabled = true;
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
    }
}
