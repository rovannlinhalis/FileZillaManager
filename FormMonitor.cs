using FileZillaManager.Classes;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    public partial class FormMonitor : FormBase
    {

        
        List<MonitorViewModel> source = new List<MonitorViewModel>();
        string erroBkg1;
        int interval = 1000;
        LocalConfig config = new LocalConfig(true, "FileZillaManager");
        Empresa Empresa { get; set; }
        public FormMonitor(Empresa emp)
        {
            this.Empresa = emp;
            this.SetStyle(ControlStyles.DoubleBuffer, true);
           // dataGridView2.SetStyle(ControlStyles.DoubleBuffer, true);
            InitializeComponent();
            dataGridView2.AutoGenerateColumns = false;
        }
        private void FormMonitor_Load(object sender, EventArgs e)
        {
            checkBoxSubPastas.Checked = config.SubPastas;
            checkBoxSubPastasIndividuais.Checked = config.SubPastasIndividuais;
            checkBoxOcultarPastasVazias.Checked = config.OcultarVazias;

            FormataColunas();

            timerRefresh.Enabled = false;
            timerRefresh.Enabled = true;
        }

        private void FormataColunas()
        {
            foreach (DataGridViewColumn c in dataGridView2.Columns)
            {
                if (this.config.ListaOrdemColunas != null && this.config.ListaOrdemColunas.Count > 0)
                if (this.config.ListaOrdemColunas.Any(x => x.Nome == c.Name))
                {
                    int ix = c.DisplayIndex;
                    if (int.TryParse(this.config.ListaOrdemColunas.Where(x => x.Nome == c.Name).FirstOrDefault().Valor.ToString(), out ix))
                        c.DisplayIndex = ix;
                }

                if (this.config.ListaTamanhoColunas != null && this.config.ListaTamanhoColunas.Count > 0)
                    if (this.config.ListaTamanhoColunas.Any(x=>x.Nome == c.Name))
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
            foreach (DataGridViewColumn c in dataGridView2.Columns)
            {
                listaIndex.Add(new LocalConfigListValue() { Nome = c.Name, Valor = c.DisplayIndex });
                listaWidth.Add(new LocalConfigListValue() { Nome = c.Name, Valor = c.Width });
            }
            this.config.ListaOrdemColunas = listaIndex;
            this.config.ListaTamanhoColunas = listaWidth;
                
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            MatarProcessos();

            Program.listaProcessosMonitor = new List<Process>();

            bool subPastas = true, subPastasIndividuais = true;//, ocultarPastasVazias = false;
            checkBoxSubPastas.Invoke((MethodInvoker)delegate { subPastas = checkBoxSubPastas.Checked; });
            checkBoxSubPastasIndividuais.Invoke((MethodInvoker)delegate { subPastasIndividuais = checkBoxSubPastasIndividuais.Checked; });
            //checkBoxOcultarPastasVazias.Invoke((MethodInvoker)delegate { ocultarPastasVazias = checkBoxOcultarPastasVazias.Checked; });

            source.Clear();// = new SortableBindingList<MonitorViewModel>();
            using (Repositorio.ContratoRepositorio rep = new Repositorio.ContratoRepositorio())
            {
                var contratos = rep.SelectAll("ATIVO = 1 AND MONITORAR = 1");
                foreach (var c in contratos)
                {
                    MonitorViewModel model;
                    try
                    {
                        if (subPastasIndividuais)
                        {
                            DirectoryInfo dir = new DirectoryInfo(c.Pasta);
                            foreach (DirectoryInfo d in dir.GetDirectories("*", subPastas ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly))
                            {
                                model = new MonitorViewModel(c.Nome, c.Login, d.FullName, false, this.Empresa.Exe7zPath, c.SenhaCompactacao, c.Codigo);
                                source.Add(model);
                            }
                            model = new MonitorViewModel(c.Nome, c.Login, c.Pasta, false, this.Empresa.Exe7zPath, c.SenhaCompactacao, c.Codigo);
                            source.Add(model);
                        }
                        else
                        {
                            model = new MonitorViewModel(c.Nome, c.Login, c.Pasta, subPastas, this.Empresa.Exe7zPath, c.SenhaCompactacao, c.Codigo);
                            source.Add(model);
                        }
                    }
                    catch (Exception ex)
                    {
                         erroBkg1 = ex.Message;
                    }
                }
            }
        }

        private void dataGridView2_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if ((e.RowIndex != -1))// &&(e.State & DataGridViewElementStates.Selected) !=DataGridViewElementStates.Selected)
            {

                if (dataGridView2.Columns[e.ColumnIndex] == dataGridView2.Columns[ColumnStatus.Name])
                {
                    #region Vencimento

                    Color cBottom = (Color)dataGridView2.Rows[e.RowIndex].Cells[ColumnCor.Name].Value;
                        
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

                    

                    #endregion
                }
                else if (dataGridView2.Columns[e.ColumnIndex] == dataGridView2.Columns[ColumnMsgIntegridade.Name])
                {
                    ZipCheckState state = (ZipCheckState)dataGridView2.Rows[e.RowIndex].Cells[ColumnZipValido.Name].Value;
                    Color cBottom = state == ZipCheckState.Erro ? Color.Brown  :  state == ZipCheckState.NaoAplicavel ? Color.Gray : state == ZipCheckState.Valido ? Color.LightGreen : state == ZipCheckState.Invalido ? Color.Red : state == ZipCheckState.GerandoHash ? Color.Purple : state == ZipCheckState.AguardandoVerificacao ? Color.Yellow :  Color.Blue;


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

        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            if (source.Any(x => x.VerificandoZip))
            {
                if (MessageBox.Show("Deseja cancelar o processamento atual e iniciar novamente?","Processar Contratos", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    timerRefresh.Enabled = false;
                    timerRefresh.Enabled = true;
                }
            }
            else
            {
                timerRefresh.Enabled = false;
                timerRefresh.Enabled = true;
            }
        }

        private void FormMonitor_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (backgroundWorker1.IsBusy)
            backgroundWorker1.CancelAsync();
            if (backgroundWorker2.IsBusy)
                backgroundWorker2.CancelAsync();

            source.Clear();

            SalvaColumns();

            MatarProcessos();

        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            //MessageBox.Show("Acabou o primeiro processo, " + (source == null ? "source é null" : " source:: "+ source.Count));

            config.SubPastas = checkBoxSubPastas.Checked;
            config.SubPastasIndividuais = checkBoxSubPastasIndividuais.Checked;
            config.OcultarVazias  = checkBoxOcultarPastasVazias.Checked;


            foreach (var model in source)
            {
                model.PropertyChanged += (ss, ee) =>
                {
                    dataGridView2.Invalidate();
                    //if (ee.PropertyName == "ZipValido")
                    //{
                    //    if (dataGridView2.Columns.Contains(ColumnMsgIntegridade.Name))
                    //        dataGridView2.InvalidateColumn(dataGridView2.Columns[ColumnMsgIntegridade.Name].Index);
                    //}
                    //else if (ee.PropertyName == "Status")
                    //{
                    //    if (dataGridView2.Columns.Contains(ColumnStatus.Name))
                    //        dataGridView2.InvalidateColumn(dataGridView2.Columns[ColumnStatus.Name].Index);
                    //}
                    //else if (ee.PropertyName == "Arquivo")
                    //{

                    //}

                    if (ee.PropertyName == "Tamanho")
                    {
                        toolStripStatusLabelTamanhoArquivos.Text = source.Sum(x => x.Tamanho).ToSizeString();
                    }
                };
            }

            if (checkBoxOcultarPastasVazias.Checked)
                source = source.Where(x => !String.IsNullOrWhiteSpace(x.Arquivo)).ToList();


            dataGridView2.DataSource = source;


            if (e.Error != null)
            {
                MessageBox.Show(e.Error.Message, "Erro ao carregar contratos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (!String.IsNullOrWhiteSpace(erroBkg1))
                toolStripStatusLabel1.Text = erroBkg1;

            if (!backgroundWorker2.IsBusy)
                backgroundWorker2.RunWorkerAsync();
        }

        private void MatarProcessos()
        {
            if (Program.listaProcessosMonitor.Count >0)
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

        
        private void backgroundWorker2_DoWork(object sender, DoWorkEventArgs e)
        {
            while (!e.Cancel && source != null)
            {
                try
                {
                    interval = 10000;
                    foreach (var c in source.OrderBy(x => x.UltimoProcessamento))
                    {
                        try
                        {
                            if (!c.ProcessandoContrato)
                                c.Processa();

                            if (source.Where(x => x.VerificandoZip)?.Count() < 3)
                            {
                                if (!c.VerificandoZip)
                                {
                                    c.VerificarCompactacao();
                                    c.UltimoProcessamento = DateTime.Now;
                                }
                            }

                            if (source.Any(x => x.UltimoProcessamento == DateTime.MinValue))
                            {
                                interval = 3000;
                            }
                        }
                        catch { }
                    }

                    backgroundWorker2.ReportProgress(0);
                }
                catch
                {
                    interval = 2000;
                }
                Thread.Sleep(interval);
            }
        }

        private void dataGridView2_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            toolStripStatusLabel1.Text = dataGridView2.Rows.Count + " Registros";
        }

        private void dataGridView2_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == ColumnAbrirPasta.Index)
            {

                List<MonitorViewModel> lista = dataGridView2.DataSource as List<MonitorViewModel>;
                if (lista != null)
                {
                    string args = null;
                    if (String.IsNullOrWhiteSpace(lista[e.RowIndex].Arquivo))
                    {
                        string folder = lista[e.RowIndex].Pasta;
                        args = string.Format("\"{0}\"", folder);
                    }
                    else
                    {
                        string fileToSelect = lista[e.RowIndex].Arquivo;
                        args = string.Format("/Select, \"{0}\"", Path.Combine(lista[e.RowIndex].Pasta, fileToSelect));
                    }
                    

                    ProcessStartInfo pfi = new ProcessStartInfo("Explorer.exe", args);
                    System.Diagnostics.Process.Start(pfi);
                }
            }
            else if (e.ColumnIndex == ColumnRechckIntegrity.Index)
            {
                List<MonitorViewModel> lista = dataGridView2.DataSource as List<MonitorViewModel>;
                if (lista != null)
                {
                    lista[e.RowIndex].ZipValido = ZipCheckState.AguardandoVerificacao;
                    lista[e.RowIndex].ForceCheck = true;
                }
            }
            else if (e.ColumnIndex == ColumnOpenFile.Index)
            {
                List<MonitorViewModel> lista = dataGridView2.DataSource as List<MonitorViewModel>;
                if (lista != null)
                {
                    try
                    {
                        ProcessStartInfo pfi = new ProcessStartInfo(Path.Combine(lista[e.RowIndex].Pasta, lista[e.RowIndex].Arquivo));
                        System.Diagnostics.Process.Start(pfi);
                    }
                    catch { }
                }
            }
        }

        private void checkBoxSubPastas_CheckedChanged(object sender, EventArgs e)
        {
            timerRefresh.Enabled = false;
            timerRefresh.Enabled = true;
        }

        private void timerRefresh_Tick(object sender, EventArgs e)
        {
            timerRefresh.Enabled = false;
            if (!backgroundWorker1.IsBusy)
             backgroundWorker1.RunWorkerAsync();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            timerRefresh.Enabled = false;
            timerRefresh.Enabled = true;
        }

        private void backgroundWorker2_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            labelUltimaVerificacao3.Text = DateTime.Now.ToString();
        }

        private void dataGridView2_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.Cancel = true;
        }



        private SortOrder getSortOrder(int columnIndex)
        {
            if (dataGridView2.Columns[columnIndex].HeaderCell.SortGlyphDirection == SortOrder.None ||
                dataGridView2.Columns[columnIndex].HeaderCell.SortGlyphDirection == SortOrder.Descending)
            {
                dataGridView2.Columns[columnIndex].HeaderCell.SortGlyphDirection = SortOrder.Ascending;
                return SortOrder.Ascending;
            }
            else
            {
                dataGridView2.Columns[columnIndex].HeaderCell.SortGlyphDirection = SortOrder.Descending;
                return SortOrder.Descending;
            }
        }

        private void dataGridView2_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            string strColumnName = dataGridView2.Columns[e.ColumnIndex].DataPropertyName;
            if (!String.IsNullOrWhiteSpace(strColumnName))
            {
                if (strColumnName == "TamanhoF")
                    strColumnName = "Tamanho";

                SortOrder strSortOrder = getSortOrder(e.ColumnIndex);

                if (strSortOrder == SortOrder.Ascending)
                {
                    source = source.OrderBy(x => typeof(MonitorViewModel).GetProperty(strColumnName).GetValue(x, null)).ToList();
                }
                else
                {
                    source = source.OrderByDescending(x => typeof(MonitorViewModel).GetProperty(strColumnName).GetValue(x, null)).ToList();
                }
                dataGridView2.DataSource = source;
                dataGridView2.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection = strSortOrder;
            }
        }
    }
}
