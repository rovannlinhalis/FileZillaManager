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
        ConcurrentQueue<int> rowsToUpdate = new ConcurrentQueue<int>();
        public FormMonitor2(Empresa emp)
        {
            this.SetStyle(ControlStyles.DoubleBuffer, true);
            Model = new MonitorViewModel(emp);
            InitializeComponent();
            bindingSource1.DataSource = Model.Contratos;
            bindingSource1.Sort = "Login";

            checkBoxOcultarPastasVazias.DataBindings.Add("Checked", Model, "OcultarPastasVazias", false, DataSourceUpdateMode.OnPropertyChanged);

            Model.Contratos.ListChanged += (ss, ee) =>
            {
                //if (!rowsToUpdate.Contains(ee.NewIndex))
                    rowsToUpdate.Enqueue(ee.NewIndex);
            };

            Model.ProcessaContratosEnd += (ss, ee) => {

                if (!backgroundWorkerProcessaDiretorios.IsBusy)
                    backgroundWorkerProcessaDiretorios.RunWorkerAsync();
                 
            };
        }

        private  void FormMonitor2_Load(object sender, EventArgs e)
        {
            timerGetContratos.Enabled = true;
        }

        private void timerGetContratos_Tick(object sender, EventArgs e)
        {
            timerGetContratos.Enabled = false;
            Model.ProcessaContratos();
        }

        private void backgroundWorkerProcessaDiretorios_DoWork(object sender, DoWorkEventArgs e)
        {
            Model.Running = true;
            int interval = 1000;
            while (Model.Running)
            {
                try
                {
                    Model.ProcessarDiretorios();

                }
                catch (Exception ex)
                {
                    string erro = ex.Message;
                }
                Thread.Sleep(interval);
            }
        }
        private void backgroundWorkerProcessaDiretorios_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            timerGetContratos.Enabled = true;
        }
        private void timerUpdateSource_Tick(object sender, EventArgs e)
        {
            timerUpdateSource.Enabled = false;
            try
            {
                if (rowsToUpdate.Count >0)
                {
                    //bindingSource1.ResetBindings(false);
                    
                    if (rowsToUpdate.TryDequeue(out int r))
                    {
                        if (!rowsToUpdate.Contains(r))
                            if (r < bindingSource1.Count && r >= 0)
                            {
                                bindingSource1.ResetItem(r);
                                dataGridView1.InvalidateRow(r);
                            }
                    }
                }
            }
            catch (Exception ex)
            { 
            
            }
            timerUpdateSource.Enabled = true;
        }









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
                else if (dataGridView1.Columns[e.ColumnIndex] == dataGridView1.Columns[ColumnContratoFolderSizeColor.Name])
                {
                    object v = dataGridView1.Rows[e.RowIndex].Cells[ColumnContratoFolderSizeColor.Name].Value;

                    if (v != null)
                    {
                        Color cBottom = (Color)v;


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
        private void FormMonitor2_FormClosing(object sender, FormClosingEventArgs e)
        {
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
            }
        }
    }
}
