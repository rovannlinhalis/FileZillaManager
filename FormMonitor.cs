using FileZillaManager.Classes;
using Miracle.FileZilla.Api;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
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
    public partial class FormMonitor : FormBase
    {


        List<ContratoOldViewModel> source = new List<ContratoOldViewModel>();
        
        string erroBkg1;
        int interval = 1000;
        LocalConfig config = new LocalConfig(true, "FileZillaManager");
        IFileZillaApi fileZillaApi = null;
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

            timerServer.Enabled = true;
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
            DateTime dataRef = DateTime.MinValue;
            checkBoxSubPastas.Invoke((MethodInvoker)delegate { subPastas = checkBoxSubPastas.Checked; });
            checkBoxSubPastasIndividuais.Invoke((MethodInvoker)delegate { subPastasIndividuais = checkBoxSubPastasIndividuais.Checked; });
            dateTimePickerDataRef.Invoke((MethodInvoker)delegate { dataRef = dateTimePickerDataRef.Checked ? dateTimePickerDataRef.Value : DateTime.MinValue; });
            //checkBoxOcultarPastasVazias.Invoke((MethodInvoker)delegate { ocultarPastasVazias = checkBoxOcultarPastasVazias.Checked; });

            source.Clear();// = new SortableBindingList<MonitorViewModel>();
            using (Repositorio.ContratoRepositorio rep = new Repositorio.ContratoRepositorio())
            {
                var contratos = rep.SelectAll("ATIVO = 1 AND MONITORAR = 1");
                foreach (var c in contratos)
                {
                    ContratoOldViewModel model;
                    try
                    {
                        if (subPastasIndividuais)
                        {
                            DirectoryInfo dir = new DirectoryInfo(c.Pasta);
                            foreach (DirectoryInfo d in dir.GetDirectories("*", subPastas ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly))
                            {
                                model = new ContratoOldViewModel(c.Nome, c.Login, d.FullName, false, this.Empresa.Exe7zPath, c.SenhaCompactacao, c, dataRef);
                                source.Add(model);
                            }
                            model = new ContratoOldViewModel(c.Nome, c.Login, c.Pasta, false, this.Empresa.Exe7zPath, c.SenhaCompactacao, c, dataRef);
                            source.Add(model);
                        }
                        else
                        {
                            model = new ContratoOldViewModel(c.Nome, c.Login, c.Pasta, subPastas, this.Empresa.Exe7zPath, c.SenhaCompactacao, c, dataRef);
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

                    Color? aux = dataGridView2.Rows[e.RowIndex].Cells[ColumnCor.Name].Value as Color?;
                    Color cBottom = aux.HasValue ? aux.Value : Color.Magenta;

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
                    if (dataGridView2.Rows[e.RowIndex].Cells[ColumnZipValido.Name].Value != null)
                    {
                        ZipCheckState state = (ZipCheckState)dataGridView2.Rows[e.RowIndex].Cells[ColumnZipValido.Name].Value;
                        Color cBottom = state == ZipCheckState.Erro ? Color.Brown : state == ZipCheckState.NaoAplicavel ? Color.Gray : state == ZipCheckState.Valido ? Color.LightGreen : state == ZipCheckState.Invalido ? Color.Red : state == ZipCheckState.GerandoHash ? Color.Purple : state == ZipCheckState.AguardandoProcesso ? Color.Yellow : state == ZipCheckState.AguardandoVerificacao ? Color.Purple : Color.Blue;


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
                else if (dataGridView2.Columns[e.ColumnIndex] == dataGridView2.Columns[ColumnFolderSize.Name])
                {
                    if (dataGridView2.Rows[e.RowIndex].Cells[ColumnArmazenamentoColor.Name].Value != null)
                    {
                        Color cBottom = (Color)dataGridView2.Rows[e.RowIndex].Cells[ColumnArmazenamentoColor.Name].Value;


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

        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            if (source.Any(x => x.VerificandoZip))
            {
                if (MessageBox.Show("Deseja cancelar o processamento atual e iniciar novamente?", "Processar Contratos", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
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
            if (fileZillaApi != null)
            {
                if (fileZillaApi.IsConnected)
                    fileZillaApi.Dispose();
            }

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
            if (e.Cancelled)
            {
                timerRefresh.Enabled = false;
                timerRefresh.Enabled = true;
            }
            else
            {
                //MessageBox.Show("Acabou o primeiro processo, " + (source == null ? "source é null" : " source:: "+ source.Count));

                config.SubPastas = checkBoxSubPastas.Checked;
                config.SubPastasIndividuais = checkBoxSubPastasIndividuais.Checked;
                config.OcultarVazias = checkBoxOcultarPastasVazias.Checked;


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
                        else if (ee.PropertyName == "FolderSize")
                        {
                            toolStripStatusLabelTotalArmazenamento.Text = source.Sum(x => x.FolderSize).ToSizeString();
                        }
                        else if (ee.PropertyName == "Arquivo")
                        {
                            timerVisibleRows.Enabled = false;
                            timerVisibleRows.Enabled = true;
                        }
                    };
                }

                //if (checkBoxOcultarPastasVazias.Checked)
                //    auxSource = source.Where(x => !String.IsNullOrWhiteSpace(x.Arquivo)).ToList();

                dataGridView2.DataSource = source;

                if (e.Error != null)
                {
                    MessageBox.Show(e.Error.Message, "Erro ao carregar contratos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                if (!String.IsNullOrWhiteSpace(erroBkg1))
                    toolStripStatusLabel1.Text = erroBkg1;

                if (!backgroundWorker2.IsBusy)
                    backgroundWorker2.RunWorkerAsync();

                dataGridView2.ResumeLayout();
            }
            
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

                            if (source.Where(x => x.VerificandoHash)?.Count() < 6)
                            {
                                if (!c.VerificandoHash)
                                {
                                    c.VerificarHash();
                                }
                            }

                            if (source.Where(x=>x.VerificandoZip)?.Count() < 3)
                            {
                                if (!c.VerificandoZip && c.ZipValido == ZipCheckState.AguardandoVerificacao)
                                {
                                    c.VerificarIntegridade();
                                    c.UltimoProcessamento = DateTime.Now;
                                }
                            }

                            if (source.Any(x => x.UltimoProcessamento == DateTime.MinValue))
                            {
                                interval = 2000;
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
            //if (checkBoxOcultarPastasVazias.Checked)
            //{
            //    dataGridView2.ClearSelection();
            //    foreach (DataGridViewRow r in dataGridView2.Rows)
            //    {
            //        if (String.IsNullOrWhiteSpace(source[r.Index].Arquivo))
            //            dataGridView2.Rows[r.Index].Visible = false;
            //    }
            //}
            timerVisibleRows.Enabled = false;
            timerVisibleRows.Enabled = true;
        }

        private void dataGridView2_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >=0)
            if (e.ColumnIndex == ColumnAbrirPasta.Index)
            {

                List<ContratoOldViewModel> lista = dataGridView2.DataSource as List<ContratoOldViewModel>;
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
                List<ContratoOldViewModel> lista = dataGridView2.DataSource as List<ContratoOldViewModel>;
                if (lista != null)
                {
                    lista[e.RowIndex].ZipValido = ZipCheckState.AguardandoProcesso;
                    lista[e.RowIndex].ForceCheck = true;
                }
            }
            else if (e.ColumnIndex == ColumnOpenFile.Index)
            {
                List<ContratoOldViewModel> lista = dataGridView2.DataSource as List<ContratoOldViewModel>;
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
            {
                source.Clear();
                dataGridView2.SuspendLayout();
                backgroundWorker1.RunWorkerAsync();
            }
            else
                backgroundWorker1.CancelAsync();
            
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            SetVisibleRows();
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
                else if (strColumnName == "FolderSizeF")
                    strColumnName = "FolderSize";

                SortOrder strSortOrder = getSortOrder(e.ColumnIndex);

                if (strSortOrder == SortOrder.Ascending)
                {
                    source = source.OrderBy(x => typeof(ContratoOldViewModel).GetProperty(strColumnName).GetValue(x, null)).ToList();
                }
                else
                {
                    source = source.OrderByDescending(x => typeof(ContratoOldViewModel).GetProperty(strColumnName).GetValue(x, null)).ToList();
                }
                
               dataGridView2.DataSource = source;
                dataGridView2.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection = strSortOrder;
                timerVisibleRows.Enabled = false;
                timerVisibleRows.Enabled = true;
            }
        }

        


        private void timerServer_Tick(object sender, EventArgs e)
        {
            timerServer.Enabled = false;
            int r = dataGridView2.Rows.Count;
            if (checkBoxOcultarPastasVazias.Checked)
                r = r - source.Where(x => String.IsNullOrWhiteSpace(x.Arquivo)).Count();
            toolStripStatusLabel1.Text = r + " Registros";
            try
            {
                if (fileZillaApi == null)
                {
                    if (IPAddress.TryParse(this.Empresa.Host, out IPAddress ip))
                    {
                        fileZillaApi = new FileZillaApi(ip, this.Empresa.Port);
                    }
                }

                if (!fileZillaApi.IsConnected)
                    fileZillaApi.Connect(this.Empresa.Pass);


                if (fileZillaApi.IsConnected)
                {
                    var connections = fileZillaApi.GetConnections();
                    var state = fileZillaApi.GetServerState();

                    labelStatusServer.Text = "Conectado / " + state;
                    labelStatusServer.ForeColor = Color.Green;
                    labelConexoes.Text = connections.Count + " Conexões ativas";
                    List<ContratoOldViewModel> lista = dataGridView2.DataSource as List<ContratoOldViewModel>;
                    if (lista != null)
                    {
                        foreach (var c in connections)
                        {
                            var contratos = lista.Where(x => x.Login == c.UserName).ToList();
                            contratos.ForEach(x =>
                            {
                                x.Status = c.TransferMode == TransferMode.Receive ? "Recebendo..." : c.TransferMode == TransferMode.Send ? "Enviando..." : "Conectado";
                                x.Cor = Color.Pink;
                                x.Tamanho = c.TotalSize.HasValue ? c.TotalSize.Value : x.Tamanho;
                            });
                        }
                    }
                }
                else
                {
                    labelStatusServer.Text = "Desconectado";
                    labelStatusServer.ForeColor = Color.Red;
                    labelConexoes.Text = String.Empty;
                }
            }
            catch (Exception ex)
            {
                fileZillaApi.Dispose();
                fileZillaApi = null;

                labelStatusServer.Text = ex.Message;
                labelStatusServer.ForeColor = Color.Red;
                labelConexoes.Text = String.Empty;
                timerServer.Interval = 10000;
            }
            timerServer.Enabled = true;
        }

        private void labelStatusServer_DoubleClick(object sender, EventArgs e)
        {
            MessageBox.Show(labelStatusServer.Text,"Status do Servidor", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void timerVisibleRows_Tick(object sender, EventArgs e)
        {
            timerVisibleRows.Enabled = false;
            SetVisibleRows();
            timerVisibleRows.Enabled = false;
        }

        private void SetVisibleRows()
        {
            foreach (DataGridViewRow r in dataGridView2.Rows)
            {
                if (checkBoxOcultarPastasVazias.Checked)
                {
                    if (String.IsNullOrWhiteSpace(r.Cells[ColumnArquivo.Name].Value?.ToString()))
                    {
                        if (dataGridView2.SelectedRows.Count > 0)
                            if (dataGridView2.SelectedRows[0].Index == r.Index)
                            {
                                dataGridView2.ClearSelection();
                                dataGridView2.CurrentCell = null;
                            }
                        r.Visible = false;
                    }
                    else
                        r.Visible = true;
                }
                else
                    r.Visible = true;
            }
        }
    }
}
