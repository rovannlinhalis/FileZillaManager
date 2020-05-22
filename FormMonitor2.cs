using FileZillaManager.Classes;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileZillaManager
{
    public partial class FormMonitor2 : Form
    {
        MonitorViewModel Model;
        LocalConfig config = new LocalConfig(true, "FileZillaManager");
        Empresa Empresa;
        public FormMonitor2(Empresa emp)
        {
            this.Empresa = emp;
            this.SetStyle(ControlStyles.DoubleBuffer, true);
            Model = new MonitorViewModel(emp);
            InitializeComponent();

            bindingSource1.DataSource = Model.Contratos;
            bindingSource1.Sort = "Login";

            //dataGridView1.AutoGenerateColumns = false;
            //dataGridView1.DataSource = Model.Contratos;

            checkBoxOcultarPastasVazias.DataBindings.Add("Checked", Model, "OcultarPastasVazias", false, DataSourceUpdateMode.OnPropertyChanged);
            checkBoxSubPastas.DataBindings.Add("Checked", Model, "MonitorarSubPastas", false, DataSourceUpdateMode.OnPropertyChanged);
            checkBoxSubPastasIndividualmente.DataBindings.Add("Checked", Model, "MonitorarSubPastasIndividualmente", false, DataSourceUpdateMode.OnPropertyChanged);
            labelStatusServidor.DataBindings.Add("Text", Model, "StatusServidor", false, DataSourceUpdateMode.OnPropertyChanged);
            labelStatusServidor.DataBindings.Add("ForeColor", Model, "ServerColor", false, DataSourceUpdateMode.OnPropertyChanged);
            labelConexoes.DataBindings.Add("Text", Model, "StatusConexoes", false, DataSourceUpdateMode.OnPropertyChanged);


            Model.ProcessaContratosEnd += (ss, ee) => {

                if (!backgroundWorkerProcesso.IsBusy)
                    backgroundWorkerProcesso.RunWorkerAsync();

                bindingSource1.ResetBindings(false);

                timerResetBinding.Enabled = false;
                timerResetBinding.Enabled = true;

            };

            Model.PropertyChanged += (ss, ee) => {

                timerGetContratos.Interval = 100;
                timerGetContratos.Enabled = false;
                timerGetContratos.Enabled = true;
            };

        }
        
        private  void FormMonitor2_Load(object sender, EventArgs e)
        {
            checkBoxOcultarPastasVazias.Checked = config.OcultarVazias;
            checkBoxSubPastas.Checked = config.SubPastas;
            checkBoxSubPastasIndividualmente.Checked = config.SubPastasIndividuais;

            timerGetContratos.Enabled = true;
            FormataColunas();
            SetColors();
            this.Text = "Monitor - " + this.Empresa.Nome + " / Desenvolvido por Rovann Linhalis - rovann.com.br";
        }

        private void timerGetContratos_Tick(object sender, EventArgs e)
        {
            timerGetContratos.Enabled = false;
            timerResetBinding.Enabled = false;
            Model.ProcessaContratos();
            timerGetContratos.Interval = 60000;
            //timerGetContratos.Enabled = true;
        }

        private void SetColors()
        {
            if (!String.IsNullOrWhiteSpace(this.Empresa.CorPrimaria))
            {
                dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Funcoes.ConverteColorFromHex(this.Empresa.CorPrimaria);
                dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Funcoes.GetForeColor(Funcoes.ConverteColorFromHex(this.Empresa.CorPrimaria));
            }
            if (!String.IsNullOrWhiteSpace(this.Empresa.CorSecundaria))
            {
                dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Funcoes.ConverteColorFromHex(this.Empresa.CorSecundaria);
                dataGridView1.AlternatingRowsDefaultCellStyle.ForeColor = Funcoes.GetForeColor(Funcoes.ConverteColorFromHex(this.Empresa.CorSecundaria));
            }
            if (!String.IsNullOrWhiteSpace(this.Empresa.CorTerciaria))
            {
                dataGridView1.DefaultCellStyle.SelectionBackColor = Funcoes.ConverteColorFromHex(this.Empresa.CorTerciaria);
                dataGridView1.DefaultCellStyle.SelectionForeColor = Funcoes.GetForeColor(Funcoes.ConverteColorFromHex(this.Empresa.CorTerciaria));
            }
            if (!String.IsNullOrWhiteSpace(this.Empresa.Logotipo) && File.Exists(this.Empresa.Logotipo))
            {
                pictureBox1.Image = Image.FromFile(this.Empresa.Logotipo);
            }
            else
                pictureBox1.Visible = false;
        }

        #region DataGridView
        private void dataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.Cancel = true;
        }
        private void dataGridView1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if (dataGridView1.Columns[e.ColumnIndex] == dataGridView1.Columns[ColumnContratoStatusText.Name])
                {
                    object v = dataGridView1.Rows[e.RowIndex].Cells[ColumnContratoStatus.Name].Value;

                    if (v != null)
                    {
                        ContratoState aux = (ContratoState)v;
                        Color cBottom = aux.GetColor();
                        if ((e.State & DataGridViewElementStates.Selected) != DataGridViewElementStates.Selected)
                        {
                            Funcoes.DataGridViewCellGradientPaint((DataGridView)sender, e, Color.White, cBottom);
                            e.Handled = true;
                        }
                        else
                        {
                            ((DataGridView)sender).Rows[e.RowIndex].Cells[e.ColumnIndex].Style.SelectionBackColor = cBottom;
                            ((DataGridView)sender).Rows[e.RowIndex].Cells[e.ColumnIndex].Style.SelectionForeColor = Funcoes.GetForeColor(cBottom);
                        }
                    }
                }
                else if (dataGridView1.Columns[e.ColumnIndex] == dataGridView1.Columns[ColumnFileCheckF.Name])
                {
                    object v = dataGridView1.Rows[e.RowIndex].Cells[ColumnContratoFileCheck.Name].Value;

                    if (v != null)
                    {
                        ZipCheckState state = (ZipCheckState)v;
                        Color cBottom = state.GetColor();
                        if ((e.State & DataGridViewElementStates.Selected) != DataGridViewElementStates.Selected)
                        {
                            Funcoes.DataGridViewCellGradientPaint((DataGridView)sender, e, Color.White, cBottom);
                            e.Handled = true;
                        }
                        else
                        {
                            ((DataGridView)sender).Rows[e.RowIndex].Cells[e.ColumnIndex].Style.SelectionBackColor = cBottom;
                            ((DataGridView)sender).Rows[e.RowIndex].Cells[e.ColumnIndex].Style.SelectionForeColor = Funcoes.GetForeColor(cBottom);
                        }
                    }
                }
                else if (dataGridView1.Columns[e.ColumnIndex] == dataGridView1.Columns[ColumnContratoStatusFTP.Name])
                {
                    object v = dataGridView1.Rows[e.RowIndex].Cells[ColumnContratoStatusFTP.Name].Value;

                    if (v != null)
                    {
                        FTPState state = (FTPState)v;
                        Color cBottom = state.GetColor();
                        if ((e.State & DataGridViewElementStates.Selected) != DataGridViewElementStates.Selected)
                        {
                            Funcoes.DataGridViewCellGradientPaint((DataGridView)sender, e, Color.White, cBottom);
                            e.Handled = true;
                        }
                        else
                        {
                            ((DataGridView)sender).Rows[e.RowIndex].Cells[e.ColumnIndex].Style.SelectionBackColor = cBottom;
                            ((DataGridView)sender).Rows[e.RowIndex].Cells[e.ColumnIndex].Style.SelectionForeColor = Funcoes.GetForeColor(cBottom);
                        }
                    }
                }
                else if (dataGridView1.Columns[e.ColumnIndex] == dataGridView1.Columns[ColumnContratoFolderSize.Name])
                {
                    object v = dataGridView1.Rows[e.RowIndex].Cells[ColumnContratoFolderSizeColor.Name].Value;

                    if (v != null)
                    {
                        Color cBottom = (Color)v;

                        if (cBottom != Color.Empty)
                        {
                            if ((e.State & DataGridViewElementStates.Selected) != DataGridViewElementStates.Selected)
                            {
                                Funcoes.DataGridViewCellGradientPaint((DataGridView)sender, e, Color.White, cBottom);
                                e.Handled = true;
                            }
                            else
                            {
                                //((DataGridView)sender).Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor =
                                ((DataGridView)sender).Rows[e.RowIndex].Cells[e.ColumnIndex].Style.SelectionBackColor = cBottom;
                                //((DataGridView)sender).Rows[e.RowIndex].Cells[e.ColumnIndex].Style.ForeColor =
                                ((DataGridView)sender).Rows[e.RowIndex].Cells[e.ColumnIndex].Style.SelectionForeColor = Funcoes.GetForeColor(cBottom);
                            }
                        }
                    }
                }

            }
        }
        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >=0)
            {
                if (e.ColumnIndex == ColumnContratoArquivo.Index)
                {
                    if (Model.Contratos[e.RowIndex].File != null && Model.Contratos[e.RowIndex].File.Exists)
                    {
                        try
                        {
                            ProcessStartInfo pfi = new ProcessStartInfo(Model.Contratos[e.RowIndex].File.FullName);
                            System.Diagnostics.Process.Start(pfi);
                        }
                        catch { }
                    }
                }
                else if (e.ColumnIndex == ColumnContratoPasta.Index)
                {
                    if (Directory.Exists(Model.Contratos[e.RowIndex].Pasta))
                    {
                        string args = null;
                        if (Model.Contratos[e.RowIndex].File == null || !Model.Contratos[e.RowIndex].File.Exists)
                        {
                            string folder = Model.Contratos[e.RowIndex].Pasta;
                            args = string.Format("\"{0}\"", folder);
                        }
                        else
                        {
                            args = string.Format("/Select, \"{0}\"", Model.Contratos[e.RowIndex].File.FullName);
                        }


                        ProcessStartInfo pfi = new ProcessStartInfo("Explorer.exe", args);
                        System.Diagnostics.Process.Start(pfi);
                    }
                }
                else if (e.ColumnIndex == ColumnFileCheckF.Index)
                {
                    if (Model.Contratos[e.RowIndex].File != null && Model.Contratos[e.RowIndex].File.Exists)
                    {
                        Model.Contratos[e.RowIndex].Integridade = ZipCheckState.AguardandoVerificacao;
                    }
                }
                else if (e.ColumnIndex == ColumnContratoLogin.Index || e.ColumnIndex == ColumnContratoNome.Index)
                {
                    try
                    {
                        Contrato c = Model.Contratos[e.RowIndex].Contrato;
                        FormContrato form = new FormContrato(c);
                        form.Show();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Não foi possível abrir o contrato: "+ ex.Message, "Erro", MessageBoxButtons.OK,  MessageBoxIcon.Error);
                    }
                }
            }
        }
        private void FormataColunas()
        {

            if (Program.Debug)
            {
                dataGridView1.Columns[ColumnLastHast.Name].Visible = true;
                dataGridView1.Columns[ColumnLastIntegrity.Name].Visible = true;
                dataGridView1.Columns[ColumnLastLerDiretorio.Name].Visible = true;
                dataGridView1.Columns[ColumnHash.Name].Visible = true;
                dataGridView1.Columns[ColumnMensagemZip.Name].Visible = true;

            }
            foreach (DataGridViewColumn c in dataGridView1.Columns)
            {
                if (this.config.ListaOrdemColunas != null && this.config.ListaOrdemColunas.Count > 0)
                    if (this.config.ListaOrdemColunas.Any(x => x.Nome == c.Name))
                    {
                        int ix = c.DisplayIndex;
                        if (int.TryParse(this.config.ListaOrdemColunas.Where(x => x.Nome == c.Name).FirstOrDefault().Valor.ToString(), out ix))
                            c.DisplayIndex = ix;
                    }

                if (this.config.ListaTamanhoColunas != null && this.config.ListaTamanhoColunas.Count > 0)
                    if (this.config.ListaTamanhoColunas.Any(x => x.Nome == c.Name))
                    {
                        int wx = c.Width;
                        if (int.TryParse(this.config.ListaTamanhoColunas.Where(x => x.Nome == c.Name).FirstOrDefault().Valor.ToString(), out wx))
                            c.Width = wx;
                    }
            }
        }
        private void SalvaColumns()
        {
          

                List<LocalConfigListValue> listaIndex = new List<LocalConfigListValue>();
            List<LocalConfigListValue> listaWidth = new List<LocalConfigListValue>();
            foreach (DataGridViewColumn c in dataGridView1.Columns)
            {
                listaIndex.Add(new LocalConfigListValue() { Nome = c.Name, Valor = c.DisplayIndex });
                listaWidth.Add(new LocalConfigListValue() { Nome = c.Name, Valor = c.Width });

                
            }
            this.config.ListaOrdemColunas = listaIndex;
            this.config.ListaTamanhoColunas = listaWidth;


            


        }
        #endregion
        #region Form
        private void FormMonitor2_FormClosing(object sender, FormClosingEventArgs e)
        {
            SalvaColumns();
            config.OcultarVazias = checkBoxOcultarPastasVazias.Checked ;
            config.SubPastas = checkBoxSubPastas.Checked ;
            config.SubPastasIndividuais= checkBoxSubPastasIndividualmente.Checked ;
            this.Model.Running = false;
            MatarProcessos();
        }
        private void MatarProcessos()
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
        #endregion

        private void backgroundWorkerProcesso_DoWork(object sender, DoWorkEventArgs e)
        {
            Model.Running = true;
            while (Model.Running)
            {
                try
                {
                    Model.ProcessarArquivos();
                }
                catch (Exception ex)
                {
                    string erro = ex.Message;
                }
                Thread.Sleep(1000);
            }
        }

        private void timerResetBinding_Tick(object sender, EventArgs e)
        {
            timerResetBinding.Enabled = false;
            //timerResetBinding.Interval = 5000;
            //bindingSource1.ResetBindings(false);
            dataGridView1.Invalidate();
            labelStatusServidor.Text = Model.StatusServidor;
            labelStatusServidor.ForeColor = Model.ServerColor;
            labelConexoes.Text = Model.StatusConexoes;

            labelStatusArquivos.Text = Model.Contratos?.Count() + " Arquivos";
            labelStatusArquivos.Text += "\r\n" + Model.Contratos?.Where(x => x.Status == ContratoState.RecebidoHoje)?.Count() + " Arquivos Recebidos Hoje";
            labelStatusArquivos.Text += "\r\n" + Model.Contratos?.Where(x => x.Integridade == ZipCheckState.Valido)?.Count() + " Arquivos Validados com sucesso";
            labelStatusArquivos.Text += "\r\n" + "Tamanho dos arquivos: "+ Model.Contratos?.Sum(x=>x.Tamanho).Value.ToSizeString();
            labelStatusArquivos.Text += "\r\n" + "Tamanho das pastas: " + Model.Contratos?.Sum(x => x.FolderSize).Value.ToSizeString();
            timerResetBinding.Enabled = true;
        }

        private void dateTimePickerDataRef_ValueChanged(object sender, EventArgs e)
        {
            Model.DataReferencia = dateTimePickerDataRef.Checked ? dateTimePickerDataRef.Value : DateTime.MinValue;
            Model.ClearAll();
            timerGetContratos.Interval = 100;
            timerGetContratos.Enabled = false;
            timerGetContratos.Enabled = true;
        }

        private void timerUpdate_Tick(object sender, EventArgs e)
        {
            if (DateTime.Now.Hour >= 2 && DateTime.Now.Hour <= 5)
            {
                FormUpdate form = new FormUpdate(false);
                if (form.ShowDialog() == DialogResult.OK)
                {
                    panelUpdates.Visible = true;
                }
                else
                    panelUpdates.Visible = false;
            }
        }

        private void labelStatusServidor_MouseClick(object sender, MouseEventArgs e)
        {
            toolTip1.Show(labelStatusServidor.Text, labelStatusServidor);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormUpdate form = new FormUpdate(false);
            if (form.ShowDialog() == DialogResult.OK)
            {
                panelUpdates.Visible = true;
            }
            else
                panelUpdates.Visible = false;
        }
    }
}
