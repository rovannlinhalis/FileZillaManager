using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Drawing.Printing;
using System.Globalization;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace FileZillaManager
{
    public static class Funcoes
    {

        public static List<Thread> ListaThreads = new List<Thread>();

        public static bool Ativado()
        {
            string winDir = Environment.GetEnvironmentVariable("SystemRoot");
            string md5 = Md5FromString("integra");
            FileInfo file = new FileInfo(winDir+"\\system32\\"+ md5+".dat");
            return file.Exists;
        }

        public static string ToSizeString(this long length)
        {
            string[] sizes = { "B", "KB", "MB", "GB", "TB" };
            double len = length;
            int order = 0;
            while (len >= 1024 && order < sizes.Length - 1)
            {
                order++;
                len = len / 1024;
            }

            // Adjust the format string to your preferences. For example "{0:0.#}{1}" would
            // show a single decimal place, and no space.
            string result = String.Format("{0:0.##} {1}", len, sizes[order]);
            return result;
        }
     
        public static void Ativar(string conteudo)
        {
            string winDir = Environment.GetEnvironmentVariable("SystemRoot");
            string md5 = Md5FromString("integra").ToLower();
            FileInfo file = new FileInfo(winDir + "\\system32\\" + md5 + ".dat");

            TextWriter tw = new StreamWriter(file.FullName, false, Encoding.Default);
            tw.Write(conteudo);
            tw.Close();
        }

        public static bool IsPlacaVeiculo(string value)
        {
            Regex regex = new Regex(@"^[a-zA-Z]{3}\-\d{4}$");
            Regex regex2 = new Regex(@"^[a-zA-Z]{3}\d{4}$");

            if (regex.IsMatch(value) || regex2.IsMatch(value))
            {
                return true;
            }

            return false;
        }

        public static string WrapString(this string texto, int chars, bool lastRight)
        {
            List<string> aux = new List<string>();
            for (int i = 0; i < texto.Length; i += chars)
                aux.Add(texto.Substring(i, Math.Min(chars, texto.Length - i)));

            string r = "";

            for (int i = 0; i < aux.Count - 1; i++)
            {
                r += aux[i] + "\r\n";
            }

            r += (lastRight && aux.Count > 1) ? aux[aux.Count - 1].PadLeft(chars, ' ') : aux[aux.Count - 1];


            return r;
        }

        /// <summary>
        /// Adiciona uma linha em branco ao combobox (só utilizar depois de definido um datasource para o mesmo)
        /// </summary>
        /// <param name="cb"></param>
        public static void AddRowComboBox(ComboBox cb)
        {
            AddRowComboBox(cb, "");
        }

        /// <summary>
        /// Adiciona uma linha em branco ao combobox (só utilizar depois de definido um datasource para o mesmo)
        /// </summary>
        /// <param name="cb"></param>
        public static void AddRowComboBox(ComboBox cb, string texto)
        {
            DataTable dt = (DataTable)cb.DataSource;
            DataRow r = dt.NewRow();
            for (int i = 0; i < dt.Columns.Count; i++)
            {
                if (dt.Columns[i].DataType.ToString() == "System.Int32" || dt.Columns[i].DataType.ToString() == "System.Int64" || dt.Columns[i].DataType.ToString().ToLower() == "system.decimal")
                    r[i] = 0;
                else if (dt.Columns[i].DataType.ToString().ToLower() == "system.string")
                    r[i] = texto;
            }
            dt.Rows.InsertAt(r, 0);
            cb.DataSource = dt;
        }
        public static void AddRowDataTable(ref DataTable dt, string texto)
        {
            DataRow r = dt.NewRow();
            for (int i = 0; i < dt.Columns.Count; i++)
            {
                if (dt.Columns[i].DataType.ToString() == "System.Int32" || dt.Columns[i].DataType.ToString() == "System.Int64" || dt.Columns[i].DataType.ToString().ToLower() == "system.decimal")
                    r[i] = 0;
                else if (dt.Columns[i].DataType.ToString().ToLower() == "system.string")
                    r[i] = texto;
            }
            dt.Rows.InsertAt(r, 0);
        }

        /// <summary>
        /// Adiciona uma linha em branco ao combobox (só utilizar depois de definido um datasource para o mesmo)
        /// </summary>
        /// <param name="cb"></param>
        public static void AddRowComboBox(ComboBox cb, string texto, object valor)
        {
            DataTable dt = (DataTable)cb.DataSource;
            DataRow r = dt.NewRow();

            if (valor == null)
                r[cb.ValueMember] = DBNull.Value;
            else if (dt.Columns[cb.ValueMember].DataType.ToString() == "System.Int32" || dt.Columns[cb.ValueMember].DataType.ToString() == "System.Int64" || dt.Columns[cb.ValueMember].DataType.ToString().ToLower() == "system.decimal")
                r[cb.ValueMember] = Funcoes.ToDecimal(valor.ToString());
            else if (dt.Columns[cb.ValueMember].DataType.ToString().ToLower() == "system.string")
                r[cb.ValueMember] = valor;

            r[cb.DisplayMember] = texto;

            dt.Rows.InsertAt(r, 0);
            cb.DataSource = dt;
        }
        public static void AddRowComboBox(DataGridViewComboBoxColumn cb, string texto, object valor)
        {
            DataTable dt = (DataTable)cb.DataSource;
            DataRow r = dt.NewRow();

            if (valor == null)
                r[cb.ValueMember] = DBNull.Value;
            else if (dt.Columns[cb.ValueMember].DataType.ToString() == "System.Int32" || dt.Columns[cb.ValueMember].DataType.ToString() == "System.Int64")
                r[cb.ValueMember] = Funcoes.ToInt(valor.ToString());
            else if (dt.Columns[cb.ValueMember].DataType.ToString().ToLower() == "system.double" || dt.Columns[cb.ValueMember].DataType.ToString().ToLower() == "system.decimal")
                r[cb.ValueMember] = Funcoes.ToDecimal(valor.ToString());
            else if (dt.Columns[cb.ValueMember].DataType.ToString().ToLower() == "system.string")
                r[cb.ValueMember] = valor;
            else
                r[cb.ValueMember] = valor;


            r[cb.DisplayMember] = texto;

            dt.Rows.InsertAt(r, 0);
            cb.DataSource = dt;
        }

        public static void CheckTodos(DataGridView d, int cellIndex)
        {

            foreach (DataGridViewRow r in d.Rows)
                r.Cells[cellIndex].Value = true;// !Funcoes.ConvertStringToBool(r.Cells[0].Value.ToString());
        }
        public static void CheckNenhum(DataGridView d, int cellIndex)
        {
            foreach (DataGridViewRow r in d.Rows)
                r.Cells[cellIndex].Value = false;// !Funcoes.ConvertStringToBool(r.Cells[0].Value.ToString());
        }
        public static void CheckInverter(DataGridView d, int cellIndex)
        {
            foreach (DataGridViewRow r in d.Rows)
            {
                r.Cells[cellIndex].Value = r.Cells[cellIndex].Value == null ? false : !Funcoes.ConvertStringToBool(r.Cells[cellIndex].Value.ToString());
            }
        }

        /// <summary>
        /// Percorre os controles da controlcollection e limpa
        /// </summary>
        /// <param name="cl">ControlCollection</param>
        public static void ClearControl(Control ctrl)
        {
            foreach (Control c in ctrl.Controls)
            {
                string tag = c.Tag == null ? "" : c.Tag.ToString();

                if (tag.Contains("x"))
                    continue;

                if (c is TextBox)
                {
                    //ValorPadrao(((TextBox)c));
                    ((TextBox)c).Text = "";
                }
                else if (c is RichTextBox)
                {
                    ((RichTextBox)c).Text = "";
                }
                else if (c is ComboBox)
                {
                    if (((ComboBox)c).DropDownStyle == ComboBoxStyle.DropDown || ((ComboBox)c).DropDownStyle == ComboBoxStyle.Simple)
                        ((ComboBox)c).Text = "";
                    else
                    {
                        if (tag.Contains("*") && ((ComboBox)c).Items.Count > 0)
                            ((ComboBox)c).SelectedIndex = 0;
                        else
                            ((ComboBox)c).SelectedIndex = -1;
                    }
                }
                else if (c is CheckBox)
                {
                    ((CheckBox)c).Checked = tag.Contains("+");
                }
                else if (c is RadioButton)
                {
                    ((RadioButton)c).Checked = tag.Contains("+");
                }
                else if (c is DateTimePicker)
                {
                    string teste2 = c.Name;
                    ((DateTimePicker)c).MinDate = new DateTime(1900, 1, 1);
                    ((DateTimePicker)c).MaxDate = new DateTime(2100, 1, 1);
                    ((DateTimePicker)c).Value = DateTime.Now.Date < ((DateTimePicker)c).MinDate ? ((DateTimePicker)c).MinDate : DateTime.Now.Date > ((DateTimePicker)c).MaxDate ? ((DateTimePicker)c).MaxDate : DateTime.Now.Date;
                    if (((DateTimePicker)c).ShowCheckBox)
                        ((DateTimePicker)c).Checked = false;

                    string teste = c.Name;
                }
                else if (c is NumericUpDown)
                {
                    ((NumericUpDown)c).Value = 0 < ((NumericUpDown)c).Minimum ? ((NumericUpDown)c).Minimum : 0 > ((NumericUpDown)c).Maximum ? ((NumericUpDown)c).Maximum : 0;// ((NumericUpDown)c).Minimum;
                }
                else if (c is PictureBox)
                {
                    ((PictureBox)c).Image = null;
                }
                else if (c is MaskedTextBox)
                {
                    ((MaskedTextBox)c).Text = "";
                }
                else if (c is Label)
                {
                    if (tag.Contains("l"))
                    {
                        ((Label)c).Text = "";
                    }
                }
                else if (c is DataGridView)
                {

                    if (tag.Contains("l"))
                    {
                        string teste = c.Name;

                        if (((DataGridView)c).DataSource is DataTable)
                        {
                            DataTable dt = (DataTable)((DataGridView)c).DataSource;
                            if (dt != null)
                            {
                                if (dt.Rows.Count != 0)
                                    dt.Rows.Clear();

                                ((DataGridView)c).DataSource = dt;
                            }
                            //((DataGridView)c).Rows.Clear();
                            //((DataGridView)c).DataSource = null;
                        }
                    }

                }
                else if (c is TrackBar)
                    ((TrackBar)c).Value = ((TrackBar)c).Minimum;
                else if (c.HasChildren)
                {

                    if (c is TabControl)
                        ((TabControl)c).SelectedIndex = 0;

                    ClearControl(c);
                }
            }
        }

        /// <summary>
        /// Limpa o datasource de um DataGridView mantendo as colunas.
        /// (Deleta linhas de um datatable)
        /// </summary>
        /// <param name="dgv"></param>
        public static void ClearDataGridMantendoColunas(DataGridView dgv)
        {
            if (dgv.DataSource != null)
            {
                DataTable d = ((DataTable)dgv.DataSource).Clone();
                d.Rows.Clear();
                /*foreach (DataRow r in d.Rows)
                {
                    r.Delete();
                }*/
                dgv.DataSource = d;
            }
        }

        /// <summary>
        /// Adiciona aos eventos Enter / Leave a função de colorir.
        /// Quando o Objeto esta em foco, aplica-se uma cor a ele.
        /// Quando não esta em foco, volta a cor padrão.
        /// Funciona para TextBox / MaskedTextBox / ComboBox
        /// </summary>
        /// <param name="objeto">Controle que contém os objetos. Obs. Controles Filhos serão afetados.</param>
        public static void ColorirObjetos(Control objeto)
        {
            foreach (Control controle_filho in objeto.Controls)
            {

                string tag = "";
                if (controle_filho.Tag != null)
                {
                    tag = controle_filho.Tag.ToString();
                }

                if (tag.Contains("?"))
                    continue;

                //if (!(controle_filho is Button))

                //if (!(controle_filho is RichTextBox) && !(controle_filho is GroupBox))
                //    controle_filho.ForeColor = System.Drawing.SystemColors.ControlText;


                if (tag.Contains("#"))
                    controle_filho.Enabled = false;

                if (tag.Contains("r"))
                {
                    if (controle_filho is MaskedTextBox)
                        ((MaskedTextBox)controle_filho).ReadOnly = true;
                    else if (controle_filho is TextBox)
                    {
                        ((TextBox)controle_filho).ReadOnly = true;
                    }
                    else if (controle_filho is DateTimePicker || controle_filho is CheckBox)
                        controle_filho.Enabled = false;

                    controle_filho.TabStop = false;
                    ControleReadyOnly(controle_filho);
                }
                else
                {


                    /*if (controle_filho is NumericUpDown)
                    {
                        if (((NumericUpDown)controle_filho).DecimalPlaces > 0)
                            controle_filho.KeyPress += new KeyPressEventHandler(TextBoxNumericDecimalKeyPress);
                        else
                            controle_filho.KeyPress += new KeyPressEventHandler(TextBoxNumericKeyPress);

                        controle_filho.Enter += new EventHandler(TextBoxEnter);
                        controle_filho.Leave += new EventHandler(TextBoxLeave);
                        controle_filho.TextChanged += new EventHandler(TextBoxTextChange);

                    }
                    else*/
                    if (controle_filho is TextBox)
                    {
                        //controle_auxiliar = controle_filho;
                        controle_filho.Enter += new EventHandler(TextBoxEnter);
                        controle_filho.Leave += new EventHandler(TextBoxLeave);
                        controle_filho.TextChanged += new EventHandler(TextBoxTextChange);

                        /* if (tag.Contains("*"))
                         {

                             ((TextBox)controle_filho).Validated += new EventHandler(TextBoxValidate);
                         }*/

                        if (tag.ToLower().Contains("v"))
                        {

                            ((TextBox)controle_filho).TextAlign = HorizontalAlignment.Right;
                            controle_filho.KeyPress += new KeyPressEventHandler(TextBoxValoresKeypress);
                            /* if (tag.ToLower().Contains("p"))
                             {
                                 ((TextBox)controle_filho).MaxLength = 13;
                             }
                             else
                             {
                                 ((TextBox)controle_filho).MaxLength = 13;
                               
                                 //controle_filho.KeyPress += new KeyPressEventHandler(TextBoxNumericComPontosKeyPress);

                                 //controle_filho.KeyPress += new KeyPressEventHandler(textBoxValor_KeyPress);
                                 // controle_filho.KeyDown += new KeyEventHandler(textBoxValor_KeyDown);
                             }*/

                            controle_filho.Leave += new EventHandler(TextBoxValoresLeave);
                            controle_filho.Enter += new EventHandler(TextBoxValoresEnter);
                        }
                        else if (((TextBox)controle_filho).TextAlign == HorizontalAlignment.Right)
                        {
                            controle_filho.KeyPress += new KeyPressEventHandler(TextBoxNumericKeyPress);
                        }
                        //controle_filho.Click += new EventHandler(TextBoxNumericClick);


                        /*if (((TextBox)controle_filho).Name.ToLower().Contains("cep"))
                        {
                            ((TextBox)controle_filho).Text = "00000-000";
                            controle_filho.KeyPress += new KeyPressEventHandler(TextBoxCep_KeyPress);
                        }
                        else if (((TextBox)controle_filho).Name.ToLower().Contains("cnpj"))
                        {
                            ((TextBox)controle_filho).Text = "00.000.000/0000-00";
                            controle_filho.KeyPress += new KeyPressEventHandler(TextBoxCnpj_KeyPress);
                        }
                        else if (((TextBox)controle_filho).Name.ToLower().Contains("numero"))
                        {
                            ((TextBox)controle_filho).Text = "000000";
                            controle_filho.KeyPress += new KeyPressEventHandler(TextBoxNumero_KeyPress);
                        }*/

                    }
                    else if (controle_filho is MaskedTextBox)
                    {
                        controle_filho.Enter += new EventHandler(MaskedTextBoxEnter);
                        controle_filho.Leave += new EventHandler(MaskedTextBoxLeave);
                        controle_filho.KeyPress += new KeyPressEventHandler(MaskedTextBoxKeyPress);
                        controle_filho.TextChanged += new EventHandler(MaskedTextBoxTextChange);
                    }
                    else if (controle_filho is ComboBox)
                    {
                        controle_filho.Enter += new EventHandler(ComboBoxEnter);
                        controle_filho.Leave += new EventHandler(ComboBoxLeave);
                        controle_filho.KeyDown += new KeyEventHandler(ComboBoxKeyDown);
                    }
                    else if (controle_filho is DateTimePicker)
                    {
                        //controle_filho.Enter += new EventHandler(DateTimePickerEnter);
                        //controle_filho.Leave += new EventHandler(DateTimePickerLeave);
                    }
                    else if (controle_filho is DataGridView)
                    {
                        //controle_filho.MouseWheel += new MouseEventHandler(DataGridView_MouseWheel);
                        //controle_filho.Leave += new EventHandler(DateTimePickerLeave);
                    }
                    else if (controle_filho is RichTextBox)
                    {
                        controle_filho.Enter += new EventHandler(RichTextBoxEnter);
                        controle_filho.Leave += new EventHandler(RichTextBoxLeave);
                    }
                    else
                    {
                        ColorirObjetos(controle_filho);
                    }
                }

            }
        }

        /// <summary>
        /// Evento Enter de um ComboBox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void ComboBoxEnter(object sender, EventArgs e)
        {

            string tag = ((Control)sender).Tag == null ? "" : ((Control)sender).Tag.ToString();


            ((ComboBox)sender).BackColor = SiCoresSistema.corFundoObjetoFoco;
            ((ComboBox)sender).SelectAll();

            if (tag.Contains("/"))
            {
                ((ComboBox)sender).Parent.BackColor = SiCoresSistema.corFundoObjetoFoco;
            }


        }

        /// <summary>
        /// Evento KeyDown dos combobox para abrir e fechar com a tecla espaço
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void ComboBoxKeyDown(object sender, KeyEventArgs e)
        {
            if (((ComboBox)sender).Enabled)
            {
                if (((ComboBox)sender).DropDownStyle == ComboBoxStyle.DropDownList)
                {
                    if (e.KeyData == Keys.Space)
                    {
                        ((ComboBox)sender).DroppedDown = !((ComboBox)sender).DroppedDown;
                    }
                }
                else
                {
                    if (e.KeyData == Keys.Space && e.Control)
                    {
                        ((ComboBox)sender).DroppedDown = !((ComboBox)sender).DroppedDown;
                    }
                }
            }
        }

        /// <summary>
        /// Evento Leave de um ComboBox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void ComboBoxLeave(object sender, EventArgs e)
        {
            string tag = ((Control)sender).Tag == null ? "" : ((Control)sender).Tag.ToString();

            ((ComboBox)sender).BackColor = SiCoresSistema.corFundoObjetoPadrao;

            if (tag.Contains("/"))
            {
                ((ComboBox)sender).Parent.BackColor = System.Drawing.Color.Empty;
            }
        }

        /// <summary>
        /// Define o controle informado com  a cor de fundo de um controle somente leitura
        /// </summary>
        /// <param name="c"></param>
        private static void ControleReadyOnly(Control c)
        {
            string tag = c.Tag == null ? "" : c.Tag.ToString();



            if (tag.Contains("cor"))
            {
                if (String.IsNullOrEmpty(c.Text))
                {
                    c.BackColor = SiCoresSistema.corFundoReadOnly;
                }
                else
                {
                    c.BackColor = Funcoes.ConverteColorFromHex(c.Text);
                    c.ForeColor = Funcoes.GetForeColor(Funcoes.ConverteColorFromHex(c.Text));
                }
            }
            else
            {
                if (!(c is CheckBox))
                    c.BackColor = SiCoresSistema.corFundoReadOnly;
            }

            //if ((c.BackColor == SiCoresSistema.corFundoReadOnly || c.BackColor== System.Drawing.Color.Empty || c.BackColor == SiCoresSistema.corFundoObjetoPadrao)&&tag.Contains("r") && !tag.Contains("cor"))

        }

        /// <summary>
        /// Evento para rolagem de um datagridview com mouse
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void DataGridView_MouseWheel(object sender, MouseEventArgs e)
        {

            int currentIndex = ((DataGridView)sender).FirstDisplayedScrollingRowIndex;
            int scrollLines = 2;// SystemInformation.MouseWheelScrollLines;

            scrollLines = scrollLines > ((DataGridView)sender).Rows.Count ? ((DataGridView)sender).Rows.Count - 1 : scrollLines;


            if (e.Delta > 0)
            {
                try
                {
                    ((DataGridView)sender).FirstDisplayedScrollingRowIndex = Math.Max(0, currentIndex - scrollLines);
                }
                catch { }
            }
            else if (e.Delta < 0)
            {
                int aux = currentIndex + scrollLines;

                aux = aux > ((DataGridView)sender).Rows.Count ? ((DataGridView)sender).Rows.Count - 1 : aux;
                try
                {
                    ((DataGridView)sender).FirstDisplayedScrollingRowIndex = currentIndex + scrollLines;
                }
                catch { }

            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="_ronly"></param>
        /// <param name="dgv"></param>
        /// <param name="colunas"></param>
        public static void DataGridViewReadOnly(bool _ronly, ref DataGridView dgv, List<DataGridViewColumn> colunas)
        {
            foreach (DataGridViewColumn c in dgv.Columns)
            {
                if (colunas != null)
                {
                    if (colunas.Contains(c))
                    {
                        dgv.Columns[c.Name].ReadOnly = _ronly;
                    }
                    else
                    {
                        dgv.Columns[c.Name].ReadOnly = !_ronly;
                    }
                }
                else
                {
                    dgv.Columns[c.Name].ReadOnly = _ronly;
                }
            }
        }
        /// <summary>
        /// Define as propriedades AllowUserToAddRows AllowUserToDeleteRows e ReadOnly de um datagridview
        /// </summary>
        /// <param name="dgv"></param>
        /// <param name="ronly"></param>
        public static void DataGridViewReadOnly(DataGridView dgv, bool ronly)
        {
            dgv.AllowUserToAddRows = !ronly;
            dgv.AllowUserToDeleteRows = !ronly;
            dgv.ReadOnly = ronly;
        }

        /// <summary>
        /// Pinta a celula de um datagridview, de forma gradiente vertical
        /// </summary>
        /// <param name="e"></param>
        /// <param name="Top"></param>
        /// <param name="Down"></param>
        public static void DataGridViewCellGradientPaint(DataGridView sender, DataGridViewCellPaintingEventArgs e, Color Top, Color Down)
        {
            Brush gradientBrush = new System.Drawing.Drawing2D.LinearGradientBrush(
                      e.CellBounds, Top, Down,
                      System.Drawing.Drawing2D.LinearGradientMode.Vertical);
            e.Graphics.FillRectangle(gradientBrush, e.CellBounds);
            gradientBrush.Dispose();

            // paint rest of cell
            e.Paint(e.CellBounds, DataGridViewPaintParts.Border |
            DataGridViewPaintParts.ContentForeground);

            sender.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.SelectionBackColor = Down;
            sender.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.SelectionForeColor = Funcoes.GetForeColor(Down);
            sender.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.ForeColor = Funcoes.GetForeColor(Down);
        }

        /// <summary>
        /// Evento Enter de um DateTimePicker
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void DateTimePickerEnter(object sender, EventArgs e)
        {
            ((DateTimePicker)sender).BackColor = SiCoresSistema.corFundoObjetoFoco;
        }

        /// <summary>
        /// Evento Leave de um DateTimePicker
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void DateTimePickerLeave(object sender, EventArgs e)
        {
            ((DateTimePicker)sender).BackColor = SiCoresSistema.corFundoObjetoPadrao;
        }

        /// <summary>
        /// Retorna um bitmap em formato de circulo, na cor informada
        /// </summary>
        /// <param name="color"></param>
        /// <returns></returns>
        public static Bitmap DrawCircle(string color, int size)
        {

            Color c = Funcoes.ConverteColorFromHex(color);

            Brush b = new SolidBrush(c);
            Bitmap flag = new Bitmap(size, size);
            Graphics g = Graphics.FromImage(flag);

            g.FillEllipse(b, 0, 0, size - 2, size - 2);
            g.DrawEllipse(new Pen(Color.Black), 0, 0, size - 2, size - 2);

            return flag;
        }
        public static Bitmap DrawCircle(string color)
        {
            return DrawCircle(color, 21);
        }

        /// <summary>
        /// Retorna um bitmap em formato de circulo, na cor informada
        /// </summary>
        /// <param name="color"></param>
        /// <returns></returns>
        public static Graphics DrawCircle(ref Bitmap bx, string color)
        {
            Color c = Funcoes.ConverteColorFromHex(color);

            Brush b = new SolidBrush(c);
            Bitmap flag = bx;

            Graphics g = Graphics.FromImage(flag);
            g.Clear(Color.Empty);

            g.FillEllipse(b, 0, 0, 19, 19);
            g.DrawEllipse(new Pen(Color.Black), 0, 0, 19, 19);

            return g;
        }

        /// <summary>
        /// Seleciona o valor de um combobox pelo seu texto
        /// </summary>
        /// <param name="cb"></param>
        /// <param name="texto"></param>
        public static void FindComboBoxItem(ComboBox cb, string texto)
        {
            if (!String.IsNullOrEmpty(texto))
            {
                try
                {
                    cb.SelectedIndex = cb.FindStringExact(texto);

                    if (cb.SelectedIndex == -1)
                    {
                        cb.SelectedValue = texto;
                    }
                }
                catch
                {
                    cb.SelectedIndex = -1;
                }

            }
            else
                cb.SelectedIndex = -1;
        }

        /// <summary>
        /// Formata o valor de um textbox como valor de moeda R$ -> Se SO configurado para Brasil
        /// Deve estar especificado na TAG do controle, qual formato desejado, se não formata para C4
        /// </summary>
        /// <param name="tb"></param>
        public static void FormataValor(TextBox tb)
        {
            string tag = "";
            if (tb.Tag != null)
            {
                tag = tb.Tag.ToString();
            }
            string sTexto = Funcoes.RemoverLetrasePontos(tb.Text);
            decimal valor = sTexto.Length == 0 ? 0 : decimal.Parse(sTexto);

            if (tag.Contains("$"))
            {
                if (tag.Contains("C2"))
                    tb.Text = valor.ToString("C2");
                else if (tag.Contains("C3"))
                    tb.Text = valor.ToString("C3");
                else if (tag.Contains("C0"))
                    tb.Text = valor.ToString("C0");
                else // if (tag.Contains("C4"))
                    tb.Text = valor.ToString("C4");
            }
            else if (tag.Contains("%"))
            {
                if (tag.Contains("P4"))
                    tb.Text = valor.ToString("###,###,##0.0000") + " %";
                else if (tag.Contains("P3"))
                    tb.Text = valor.ToString("###,###,##0.000") + " %";
                else
                    tb.Text = valor.ToString("###,###,##0.00") + " %";
            }
            else
            {
                if (String.IsNullOrEmpty(sTexto))
                    tb.Text = "";
                else
                {
                    if (tag.Contains("D3"))
                        tb.Text = valor.ToString("###,###,##0.000");
                    else if (tag.Contains("D4"))
                        tb.Text = valor.ToString("###,###,##0.0000");
                    else if (tag.Contains("D0"))
                        tb.Text = valor.ToString("###,###,###,##0");
                    else if (tag.Contains("D2"))
                        tb.Text = valor.ToString("###,###,##0.00");
                    else
                        tb.Text = valor.ToString("###,###,##0.00");
                }
            }

        }

        /// <summary>
        /// Seleciona um controle pelo seu id de forma recursiva.
        /// </summary>
        /// <param name="nome"></param>
        /// <param name="c"></param>
        /// <returns>Controle</returns>
        public static Control GetControl(string nome, Control c)
        {
            Control ctl = c.Controls[nome];
            if (ctl == null)
            {
                foreach (Control cl in c.Controls)
                {
                    if (ctl == null)
                    {
                        if (cl.Name == nome)
                            ctl = cl;
                        else if (cl.HasChildren)
                            ctl = GetControl(nome, cl);
                        else
                            ctl = null;
                    }
                    else break;
                }
            }
            return ctl;
        }

        /// <summary>
        /// Retorna qual o Form é pai do controle informado
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static Form GetFormParent(Control obj)
        {
            if (obj.Parent != null)
            {
                if (obj.Parent is Form)
                {
                    return (Form)obj.Parent;
                }
                else
                {
                    return GetFormParent(obj.Parent);
                }
            }
            else
                return null;
        }

        /// <summary>
        /// Evento Enter de um MaskedTextBox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void MaskedTextBoxEnter(object sender, EventArgs e)
        {
            string tag = "";
            if (((MaskedTextBox)sender).Tag != null)
                tag = ((MaskedTextBox)sender).Tag.ToString();

            if (tag.Contains("ERRO"))
                ((MaskedTextBox)sender).BackColor = SiCoresSistema.corBackErro;
            else
                if (tag.Contains("*"))
                    ((MaskedTextBox)sender).BackColor = SiCoresSistema.corFundoObjetoObrigatorioFoco;
                else
                    ((MaskedTextBox)sender).BackColor = SiCoresSistema.corFundoObjetoFoco;

            //((MaskedTextBox)sender).SelectAll();
        }

        /// <summary>
        /// Evento keypress de todos os maskedtextbox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void MaskedTextBoxKeyPress(object sender, KeyPressEventArgs e)
        {
            /*if(!((MaskedTextBox)sender).ReadOnly)
            {
                if (((MaskedTextBox)sender).SelectionLength >= ((MaskedTextBox)sender).Text.Length)
                {
                    if (char.IsNumber(e.KeyChar))
                    {
                        ((MaskedTextBox)sender).Text = "";// e.KeyChar.ToString();

                    }
                }
            }*/
        }
        /// <summary>
        /// Evento Leave de um MaskedtextBox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void MaskedTextBoxLeave(object sender, EventArgs e)
        {
            string tag = "";
            if (((MaskedTextBox)sender).Tag != null)
                tag = ((MaskedTextBox)sender).Tag.ToString();

            if (tag.Contains("ERRO"))
                ((MaskedTextBox)sender).BackColor = SiCoresSistema.corBackErro;
            else
                if (tag.Contains("*"))
                    ((MaskedTextBox)sender).BackColor = SiCoresSistema.corFundoObjetoObrigatorioPadrao;
                else
                    ((MaskedTextBox)sender).BackColor = SiCoresSistema.corFundoObjetoPadrao;

        }

        /// <summary>
        /// Evento Textchange dos maskedtextbox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void MaskedTextBoxTextChange(object sender, EventArgs e)
        {
            string tag = "";
            if (((MaskedTextBox)sender).Tag != null)
                tag = ((MaskedTextBox)sender).Tag.ToString();

            if (tag.Contains("ERRO"))
            {
                ((MaskedTextBox)sender).BackColor = SiCoresSistema.corBackErro;
            }
            else
            {
                if (((MaskedTextBox)sender).Focused)
                {
                    ((MaskedTextBox)sender).BackColor = SiCoresSistema.corFundoObjetoFoco;
                }
                else
                {
                    if (tag.Contains("*"))
                        ((MaskedTextBox)sender).BackColor = SiCoresSistema.corFundoObjetoObrigatorioPadrao;
                    else
                        ((MaskedTextBox)sender).BackColor = SiCoresSistema.corFundoObjetoPadrao;
                }
            }
        }

        /// <summary>
        /// Retorna uma lista de nodes a partir de uma nodecollection
        /// </summary>
        /// <param name="nodes"></param>
        /// <param name="lista"></param>
        public static void TreeNodeToList(TreeNodeCollection nodes, List<TreeNode> lista)
        {
            foreach (TreeNode n in nodes)
            {
                lista.Add(n);
                if (n.Nodes.Count != 0)
                    Funcoes.TreeNodeToList(n.Nodes, lista);
            }
        }

        /// <summary>
        /// Utilize esta função para permitir apenas números no evento KeyPress
        /// </summary>
        /// <param name="e">e</param>
        public static void PermitirApenasNumeros(KeyPressEventArgs e)
        {

            if (char.IsLetter(e.KeyChar) || //Letras

                char.IsSymbol(e.KeyChar) || //Símbolos

                char.IsWhiteSpace(e.KeyChar) || //Espaço

                char.IsPunctuation(e.KeyChar)) //Pontuação

                e.Handled = true; //Não permitir
        }

        public static void PermitirApenasNumerosEVirgulas(KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar) || char.IsSymbol(e.KeyChar) || char.IsWhiteSpace(e.KeyChar) || char.IsPunctuation(e.KeyChar))
            {
                e.KeyChar = e.KeyChar == (char)46 ? (char)44 : e.KeyChar;

                if ((e.KeyChar != (char)44))
                {
                    e.Handled = true; //Não permitir
                }

            }
        }

        public static void PreencherControles(object obj, Control ctrl, bool continueOnError)
        {
            PreencherControles(obj, ctrl, continueOnError, "siCampo");
        }
        /// <summary>
        /// Percorre todos os controles (controlcollection) do Control informado, e preenche os campos com os valores das propriedades do objeto informado.
        /// </summary>
        /// <param name="obj">objeto que contem as propriedades com os valores a serem inseridos nos controles</param>
        /// <param name="ctrl">controle que contém os controles a serem preechidos (ex: Form1)</param>
        /// <returns>True (se foi preenchido corretamente)</returns>
        public static void PreencherControles(object obj, Control ctrl, bool continueOnError, string prefixoObjeto)
        {
            if (obj != null)
            {
                foreach (System.Reflection.PropertyInfo pr in obj.GetType().GetProperties())
                {
                    try
                    {
                       

                            //PropertyInfo[] p2 = pr.GetType().GetProperties();
                            Control ct1 = GetControl(prefixoObjeto + pr.Name, ctrl);


                            if (ct1 != null && pr != null)
                            {

                                object oValor = pr.GetValue(obj, null);

                                if (oValor == null)
                                    continue;

                                string tag = "";
                                if (ct1.Tag != null)
                                    tag = ct1.Tag.ToString();

                                if (ct1 is Label)
                                {
                                    if (!tag.Contains("NN"))
                                        ((Label)ct1).Text = pr.GetValue(obj, null).ToString();
                                }
                                else if (ct1 is MaskedTextBox)
                                {

                                    string temp = pr.GetValue(obj, null).ToString();
                                    try
                                    {
                                        double num = double.Parse(Funcoes.RemoverPontuacao(temp));
                                        if (num == 0)
                                        {
                                            ((MaskedTextBox)ct1).Text = "";
                                        }
                                        else
                                            ((MaskedTextBox)ct1).Text = temp;
                                    }
                                    catch
                                    {
                                        ((MaskedTextBox)ct1).Text = temp;
                                    }
                                }
                                else if (ct1 is TextBox)
                                {
                                    string valor = pr.GetValue(obj, null).ToString();

                                    if (!String.IsNullOrEmpty(valor))
                                    {

                                        if (pr.PropertyType.ToString() == "System.DateTime")
                                        {
                                            DateTime d = DateTime.Parse(valor);
                                            if (d == new DateTime())
                                                ((TextBox)ct1).Text = "";
                                            else
                                            {
                                                if (tag.Contains("long"))
                                                    ((TextBox)ct1).Text = d.ToLongDateString();
                                                else if (tag.Contains("short"))
                                                    ((TextBox)ct1).Text = d.ToShortDateString();
                                                else
                                                    ((TextBox)ct1).Text = d.ToString();

                                            }
                                        }
                                        else
                                        {
                                            if (tag.Contains("cor"))
                                            {
                                                System.Drawing.Color c = Funcoes.ConverteColorFromHex(valor);
                                                ((TextBox)ct1).Text = valor;
                                                ((TextBox)ct1).ForeColor = Funcoes.GetForeColor(c);
                                                ((TextBox)ct1).BackColor = c;
                                            }
                                            else
                                            {
                                                if (((TextBox)ct1).TextAlign == HorizontalAlignment.Right)
                                                {

                                                    /* if (double.Parse(Funcoes.RemoverPontuacao(valor)) == 0)
                                                         ValorPadrao(((TextBox)ct1));
                                                     else
                                                     {*/


                                                    ((TextBox)ct1).Text = valor;
                                                    if (tag.Contains("v") && !tag.Contains("p"))
                                                    {
                                                        Funcoes.FormataValor(((TextBox)ct1));
                                                    }
                                                    // }

                                                }
                                                else
                                                {
                                                    ((TextBox)ct1).Text = valor;
                                                }
                                            }
                                        }
                                    }
                                    else
                                        ((TextBox)ct1).Text = "";

                                }
                                else if (ct1 is RichTextBox)
                                {
                                    string valor = pr.GetValue(obj, null).ToString();

                                    if (!String.IsNullOrEmpty(valor))
                                    {
                                        if (tag.Contains("F") && valor.Contains("{\\rtf"))
                                            ((RichTextBox)ct1).Rtf = valor;
                                        else
                                            ((RichTextBox)ct1).Text = valor;
                                    }
                                    else
                                        ((RichTextBox)ct1).Text = "";
                                }
                          
                                else if (ct1 is ComboBox)
                                {
                                    string valor = pr.GetValue(obj, null).ToString();
                                    // ((ComboBox)ct1).Refresh();
                                    Funcoes.FindComboBoxItem(((ComboBox)ct1), valor);

                                }
                           
                                else if (ct1 is CheckBox)
                                    ((CheckBox)ct1).Checked = Funcoes.ConvertStringToBool(pr.GetValue(obj, null).ToString());
                                else if (ct1 is DateTimePicker)
                                {
                                    DateTime dt = DateTime.Parse(pr.GetValue(obj, null).ToString());
                                    if (dt == new DateTime())
                                    {

                                        ((DateTimePicker)ct1).Value = DateTime.Now;
                                        ((DateTimePicker)ct1).Checked = false;
                                    }
                                    else
                                    {
                                        if (((DateTimePicker)ct1).ShowCheckBox)
                                            ((DateTimePicker)ct1).Checked = true;

                                        ((DateTimePicker)ct1).Value = dt > ((DateTimePicker)ct1).MaxDate ? ((DateTimePicker)ct1).MaxDate : (dt < ((DateTimePicker)ct1).MinDate ? ((DateTimePicker)ct1).MinDate : dt);

                                        //((DateTimePicker)ct1).Value = dt;
                                    }

                                }
                                else if (ct1 is RadioButton)
                                    ((RadioButton)ct1).Checked = Funcoes.ConvertStringToBool(pr.GetValue(obj, null).ToString());
                                else if (ct1 is NumericUpDown)
                                {
                                    decimal valor = decimal.Parse(pr.GetValue(obj, null).ToString());
                                    ((NumericUpDown)ct1).Value = valor > ((NumericUpDown)ct1).Maximum ? ((NumericUpDown)ct1).Maximum : (valor < ((NumericUpDown)ct1).Minimum ? ((NumericUpDown)ct1).Minimum : valor);
                                }
                                else if (ct1 is PictureBox)
                                {
                                    try
                                    {
                                        if (pr.GetValue(obj, null) != new byte[0])
                                            ((PictureBox)ct1).Image = Funcoes.ConvertByteToImage((byte[])pr.GetValue(obj, null));
                                    }
                                    catch
                                    {
                                        ((PictureBox)ct1).Image = null;
                                    }
                                }
                              
                                else if (ct1 is DataGridView)
                                {
                                    bool aux = ((DataGridView)ct1).AutoGenerateColumns;
                                    //((DataGridView)ct1).AutoGenerateColumns = true;

                                    DataTable dt = (DataTable)pr.GetValue(obj, null);
                                    if (dt != null)
                                        ((DataGridView)ct1).DataSource = dt;
                                    else
                                        ClearDataGridMantendoColunas(((DataGridView)ct1));


                                    ((DataGridView)ct1).AutoGenerateColumns = aux;

                                }
                                else if (ct1 is TrackBar)
                                {
                                    ((TrackBar)ct1).Value = int.Parse(pr.GetValue(obj, null).ToString());

                                }


                            }
                        
                    }
                    catch (Exception ex)
                    {
                        if (!continueOnError)
                            throw ex;
                    }
                }

            }
            else
                throw new Exception("Objeto nulo. Impossível preencher controles.");
        }

        /// <summary>
        /// Preencher uma treeview por um datatable (Colunas: 'nome' 'pai' 'img' 'simg' 'texto' 'tag' 'nivel' 'ordem')
        /// onde: 
        /// nome=nome unico do node
        /// pai=nome do node pai, se nao existir, informe null
        /// img=index da imagem do node
        /// simg=index da imagem do node, quando selecionado
        /// texto=texto que vai aparecer no node
        /// tag=dado associado ao node
        /// ordem=ordem que o node deve ser exibido
        /// nivel=nivel do node (0 = raiz)
        /// </summary>
        /// <param name="dtMenu">Datatable com as colunas especificadas</param>
        /// <param name="tree">treeview destino</param>
        public static void PreencherMenu(DataTable dtMenu, TreeView tree, MenuStrip menu)
        {
            if (tree != null)
                tree.Nodes.Clear();

            if (menu != null)
                menu.Items.Clear();

            //DataRow[] rows = dtMenu.Select("", "nivel, ordem");

            dtMenu.DefaultView.Sort = "nivel, ordem";
            dtMenu = dtMenu.DefaultView.ToTable();

            string resultado = "";
            foreach (DataRow r in /*rows*/ dtMenu.Rows)
            {

                foreach (DataColumn c in dtMenu.Columns)
                {
                    resultado += r[c.ColumnName].ToString() + " | ";
                }
                resultado += "\r\n";

                string nome = r["nome"].ToString();
                string pai = r["pai"].ToString();



                TreeNode t = null;
                ToolStripItem m = null;

                if (tree != null)
                {
                    t = new TreeNode(r["texto"].ToString());
                    t.ImageKey = r["img"].ToString();
                    t.SelectedImageKey = r["simg"].ToString();
                    t.Name = r["nome"].ToString();
                    t.Text = r["texto"].ToString();
                    //if (Funcoes.ConvertDataRowToInt(r["nivel"]) == 0)
                    //t.NodeFont = new System.Drawing.Font(tree.Font.Name, tree.Font.Size, System.Drawing.FontStyle.Bold);

                    t.Tag = String.IsNullOrEmpty(r["tag"].ToString()) ? null : r["tag"].ToString();
                }

                if (menu != null)
                {
                    m = new ToolStripMenuItem();
                    m.Text = r["texto"].ToString();
                    m.Name = nome;

                    if (tree != null && tree.ImageList != null && tree.ImageList.Images.Count > 0)
                        m.Image = tree.ImageList.Images[r["img"].ToString()];

                    //m.ImageKey = ;
                    m.Tag = String.IsNullOrEmpty(r["tag"].ToString()) ? null : r["tag"].ToString();
                }

                if (String.IsNullOrEmpty(pai))
                {
                    if (tree != null)
                        tree.Nodes.Add(t);

                    if (menu != null)
                        menu.Items.Add(m);

                }
                else
                {
                    if (tree != null)
                    {
                        TreeNode[] parent = tree.Nodes.Find(pai, true);
                        if (parent.Length != 0)
                        {
                            parent[0].Nodes.Add(t);
                        }
                        else
                        {
                            //tree.Nodes.Add(t);
                        }
                    }

                    if (menu != null)
                    {
                        ToolStripItem[] parent = menu.Items.Find(pai, true);
                        if (parent.Length != 0)
                        {
                            ((ToolStripMenuItem)parent[0]).DropDownItems.Add(m);
                        }

                    }
                }
            }
            string x = resultado;
        }

        public static string StructTreeView(TreeView t)
        {
            //dt.Rows.Add(new object[] { "cadastro", null, 0, 0, "Cadastro", null, 0, 2 });
            string r = "";
            foreach (TreeNode n in t.Nodes)
            {
                r += DataNode(n);
            }

            return r;
        }
        public static string DataNode(TreeNode n)
        {
            string retorno = "";
            string pai = n.Parent == null ? "null" : n.Parent.Name;
            string nivel = n.Parent == null ? "0" : "1";

            retorno = "dt.Rows.Add(new object[] {" + '"' + n.Name + '"' + "," + '"' + pai + '"' + "," + n.ImageKey.ToString() + "," + '"' + n.Text + '"' + "," + "0" + "," + nivel + "});" + System.Environment.NewLine;
            if (n.Nodes != null)
                foreach (TreeNode t in n.Nodes)
                    retorno += DataNode(t);

            return retorno;

        }

        public static void PreencherPropriedades(object obj, Control ctrl)
        {
            PreencherPropriedades(obj, ctrl, "siCampo");
        }
        /// <summary>
        /// Percorre o controle informado preenchendo as propriedades do objeto com os valores.
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="ctrl"></param>
        /// <returns></returns>
        public static void PreencherPropriedades(object obj, Control ctrl, string prefixoComparacao)
        {
            if (obj != null)
            {
                foreach (System.Reflection.PropertyInfo pr in obj.GetType().GetProperties())
                {
                    if (pr.CanWrite)
                    {


                        PreencherPropertyInfo(prefixoComparacao, pr, ctrl, obj);

                    }

                }
            }
            else
                throw new Exception("Objeto nulo. Impossível preencher propriedades.");

        }

        private static void PreencherPropertyInfo(string prefixoComparacao, System.Reflection.PropertyInfo pr, Control ctrl, object obj)
        {
            //PropertyInfo[] p2 = pr.GetType().GetProperties();
            Control ct1 = GetControl(prefixoComparacao + pr.Name, ctrl);
            //string tipo = ct1.GetType().ToString();
            string tag = "";
            if (ct1 != null)
            {
                if (ct1.Tag != null)
                    tag = ct1.Tag.ToString();

                if (ct1 != null)
                {

                    if (ct1 is Label)
                    {
                        if (pr.PropertyType.FullName == "System.Decimal")
                            pr.SetValue(obj, Funcoes.ToDecimal(((Label)ct1).Text), null);
                        else if (pr.PropertyType.FullName == "System.Int32")
                            pr.SetValue(obj, Funcoes.ToInt(((Label)ct1).Text), null);
                        else if (pr.PropertyType.FullName == "System.Int64")
                            pr.SetValue(obj, Funcoes.ToInt(((Label)ct1).Text), null);
                        else if (pr.PropertyType == typeof(double))
                            pr.SetValue(obj, Funcoes.ToDouble(((Label)ct1).Text), null);
                        else
                            pr.SetValue(obj, ((Label)ct1).Text, null);
                    }
                    else if (ct1 is MaskedTextBox)
                    {
                        pr.SetValue(obj, ((MaskedTextBox)ct1).Text.ToString(), null);

                    }
                    else if (ct1 is TextBox)
                        if (((TextBox)ct1).TextAlign == HorizontalAlignment.Right)
                        {
                            if (pr.PropertyType.FullName != "System.String")
                            {
                                if (((TextBox)ct1).Text.Length == 0)
                                    ((TextBox)ct1).Text = "0";

                                if (pr.PropertyType.FullName == "System.Int64")
                                    pr.SetValue(obj, Int64.Parse(Funcoes.RemoverLetrasePontos(((TextBox)ct1).Text)), null);
                                else if (pr.PropertyType.FullName == "System.Single")
                                    pr.SetValue(obj, float.Parse(Funcoes.RemoverLetrasePontos(((TextBox)ct1).Text)), null);
                                else if (pr.PropertyType.FullName == "System.Decimal")
                                    pr.SetValue(obj, decimal.Parse(Funcoes.RemoverLetrasePontos(((TextBox)ct1).Text)), null);
                                else if (pr.PropertyType.FullName == "System.Int32")
                                    pr.SetValue(obj, int.Parse(Funcoes.RemoverLetrasePontos(((TextBox)ct1).Text)), null);
                                else if (pr.PropertyType == typeof(double))
                                    pr.SetValue(obj, Funcoes.ToDouble(Funcoes.RemoverLetrasePontos(((TextBox)ct1).Text)), null);
                                else if (pr.PropertyType.FullName == "System.DateTime")
                                {
                                    string vl = ((TextBox)ct1).Text;
                                    if (String.IsNullOrEmpty(vl) || vl == "0")
                                        pr.SetValue(obj, new DateTime(), null);
                                    else
                                        pr.SetValue(obj, DateTime.Parse(vl), null);
                                }
                                else
                                    pr.SetValue(obj, ((TextBox)ct1).Text, null);
                            }
                            else
                                pr.SetValue(obj, ((TextBox)ct1).Text, null);

                        }
                        else
                            pr.SetValue(obj, ((TextBox)ct1).Text, null);
                    else if (ct1 is RichTextBox)
                    {
                        if (tag.Contains("F"))
                        {
                            if (!String.IsNullOrEmpty(((RichTextBox)ct1).Text.Trim()))
                                pr.SetValue(obj, ((RichTextBox)ct1).Rtf, null);
                            else
                                pr.SetValue(obj, null, null);
                        }
                        else
                            pr.SetValue(obj, ((RichTextBox)ct1).Text, null);
                    }
                    else if (ct1 is ComboBox)
                    {
                        if (((ComboBox)ct1).DataSource == null)
                        {
                            pr.SetValue(obj, ((ComboBox)ct1).Text, null);
                        }
                        else
                        {
                            if (((ComboBox)ct1).DropDownStyle == ComboBoxStyle.Simple || (tag.Contains("TXT") && ((ComboBox)ct1).DropDownStyle == ComboBoxStyle.DropDown))
                                pr.SetValue(obj, ct1.Text, null);
                            else if (((ComboBox)ct1).DropDownStyle == ComboBoxStyle.DropDown && ((ComboBox)ct1).SelectedValue == null && !String.IsNullOrEmpty(((ComboBox)ct1).Text))
                            {
                                pr.SetValue(obj, ct1.Text, null);
                            }
                            else
                            {
                                string xvalor = ((ComboBox)ct1).SelectedValue == null ? "" : ((ComboBox)ct1).SelectedValue.ToString();

                                /*if (((ComboBox)ct1).Name.ToLower().Contains("bairro") && ((ComboBox)ct1).SelectedValue == null)
                                    pr.SetValue(obj, "", null);
                                else*/

                                if (pr.PropertyType == typeof(Int32))
                                {
                                    pr.SetValue(obj, (String.IsNullOrEmpty(xvalor) ? 0 : Funcoes.ToInt(xvalor)), null);
                                }
                                else
                                {
                                    pr.SetValue(obj, xvalor, null);
                                }

                            }
                        }
                    }
                    else if (ct1 is CheckBox)
                        pr.SetValue(obj, ((CheckBox)ct1).Checked, null);
                    else if (ct1 is DateTimePicker)
                    {

                        if (((DateTimePicker)ct1).ShowCheckBox)
                        {
                            if (((DateTimePicker)ct1).Checked)
                                pr.SetValue(obj, ((DateTimePicker)ct1).Value, null);
                            else
                                pr.SetValue(obj, null, null);
                        }
                        else
                            pr.SetValue(obj, ((DateTimePicker)ct1).Value, null);
                    }
                    else if (ct1 is RadioButton)
                        pr.SetValue(obj, ((RadioButton)ct1).Checked, null);
                    else if (ct1 is NumericUpDown)
                    {
                        if (pr.PropertyType.FullName == "System.Int64")
                            pr.SetValue(obj, Int64.Parse(((NumericUpDown)ct1).Value.ToString()), null);
                        else if (pr.PropertyType.FullName == "System.Single")
                            pr.SetValue(obj, float.Parse(((NumericUpDown)ct1).Value.ToString()), null);
                        else if (pr.PropertyType.FullName == "System.Int32")
                            pr.SetValue(obj, int.Parse(((NumericUpDown)ct1).Value.ToString()), null);
                        else if (pr.PropertyType == typeof(double))
                            pr.SetValue(obj, Funcoes.ToDouble(((NumericUpDown)ct1).Value.ToString()), null);
                        else
                            pr.SetValue(obj, ((NumericUpDown)ct1).Value.ToString(), null);
                    }
                    else if (ct1 is PictureBox)
                    {
                        if (((PictureBox)ct1).Image != null)
                            pr.SetValue(obj, Funcoes.ConvertImageToByte(((PictureBox)ct1).Image), null);
                        else
                            pr.SetValue(obj, new byte[0], null);
                    }
                 
                    else if (ct1 is DataGridView)
                    {
                        if (((DataGridView)ct1).DataSource != null)
                            pr.SetValue(obj, ((DataTable)((DataGridView)ct1).DataSource).Copy(), null);
                        else
                            pr.SetValue(obj, null, null);
                    }
                    else if (ct1 is TrackBar)
                    {
                        if (pr.PropertyType.FullName == "System.Int32")
                            pr.SetValue(obj, int.Parse(((TrackBar)ct1).Value.ToString()), null);
                        else
                            pr.SetValue(obj, ((TrackBar)ct1).Value.ToString(), null);
                    }


                }
            }
            else
            {
                if (pr.PropertyType.FullName == "System.String")
                {
                    pr.SetValue(obj, "", null);
                }
                else if (pr.PropertyType.FullName == "System.DateTime")
                {
                    pr.SetValue(obj, new DateTime(), null);
                }
            }
        }

        private static void RichTextBoxEnter(object sender, EventArgs e)
        {
            string tag = ((RichTextBox)sender).Tag == null ? "" : ((RichTextBox)sender).Tag.ToString();
            if (tag.Contains("ERRO"))
                ((RichTextBox)sender).BackColor = SiCoresSistema.corBackErro;
            else
                if (tag.Contains("*"))
                    ((RichTextBox)sender).BackColor = SiCoresSistema.corFundoObjetoObrigatorioFoco;
                else
                    ((RichTextBox)sender).BackColor = SiCoresSistema.corFundoObjetoFoco;


            ((RichTextBox)sender).Select(((RichTextBox)sender).TextLength, 0);
        }
        private static void RichTextBoxLeave(object sender, EventArgs e)
        {
            string tag = ((RichTextBox)sender).Tag == null ? "" : ((RichTextBox)sender).Tag.ToString();

            if (tag.Contains("ERRO"))
                ((RichTextBox)sender).BackColor = SiCoresSistema.corBackErro;
            else
                if (tag.Contains("*"))
                    ((RichTextBox)sender).BackColor = SiCoresSistema.corFundoObjetoObrigatorioPadrao;
                else
                    ((RichTextBox)sender).BackColor = SiCoresSistema.corFundoObjetoPadrao;


            //((RichTextBox)sender).Select(((RichTextBox)sender).TextLength, 0);
        }

        /// <summary>
        /// Define a cor de fundo de um mdi container
        /// </summary>
        /// <param name="_ctrl">controle</param>
        /// <param name="cor">cor</param>
        public static void SetBackGroundColorOfMDIForm(Control _ctrl, System.Drawing.Color cor)
        {
            foreach (Control ctl in _ctrl.Controls)
            {
                if ((ctl) is MdiClient)
                {
                    ctl.BackColor = cor;
                }
            }
        }

        /// <summary>
        /// Percorre o control collection informado definindo a propriedade Enabled pelo valor informado.
        /// </summary>
        /// <param name="ctrl"></param>
        /// <param name="enabled"></param>
        public static void SetEnableControl(Control.ControlCollection ctrl, bool enabled)
        {
            foreach (Control c in ctrl)
            {
                if (c.HasChildren)
                    SetEnableControl(c.Controls, enabled);
                else
                {
                    string tag = c.Tag == null ? "" : c.Tag.ToString();

                    if (tag.Contains("x"))
                        continue;

                    if (!tag.Contains("r"))
                        c.Enabled = enabled;

                }
            }
        }

        /// <summary>
        /// Evento Enter de um textbox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void TextBoxEnter(object sender, EventArgs e)
        {
            string tag = ((TextBox)sender).Tag == null ? "" : ((TextBox)sender).Tag.ToString();

            if (tag.Contains("COR"))
            {
                if (!String.IsNullOrEmpty(((TextBox)sender).Text) && ((TextBox)sender).Text.Length == 7 && ((TextBox)sender).Text.Contains("#"))
                {
                    try
                    {
                        ((TextBox)sender).BackColor = Funcoes.ConverteColorFromHex(((TextBox)sender).Text);
                        ((TextBox)sender).ForeColor = Funcoes.GetForeColor(Funcoes.ConverteColorFromHex(((TextBox)sender).Text));
                    }
                    catch
                    {
                        if (tag.Contains("*"))
                            ((TextBox)sender).BackColor = SiCoresSistema.corFundoObjetoObrigatorioFoco;
                        else
                            ((TextBox)sender).BackColor = SiCoresSistema.corFundoObjetoFoco;

                        ((TextBox)sender).ForeColor = SiCoresSistema.corFonteObjetoPadrao;// SiCoresSistema.corFonteObjetoPadrao;
                    }
                }
                else
                {
                    if (tag.Contains("*"))
                        ((TextBox)sender).BackColor = SiCoresSistema.corFundoObjetoObrigatorioFoco;
                    else
                        ((TextBox)sender).BackColor = SiCoresSistema.corFundoObjetoFoco;

                    ((TextBox)sender).ForeColor = SiCoresSistema.corFonteObjetoPadrao;//SiCoresSistema.corFonteObjetoPadrao;
                }
            }
            else
            {
                if (tag.Contains("ERRO"))
                    ((TextBox)sender).BackColor = SiCoresSistema.corBackErro;
                else
                    if (tag.Contains("*"))
                        ((TextBox)sender).BackColor = SiCoresSistema.corFundoObjetoObrigatorioFoco;
                    else
                        ((TextBox)sender).BackColor = SiCoresSistema.corFundoObjetoFoco;
            }

            ((TextBox)sender).SelectAll();
        }

        /// <summary>
        /// Evento Leave de um textbox
        /// </summary>
        private static void TextBoxLeave(object sender, EventArgs e)
        {
            string tag = ((TextBox)sender).Tag == null ? "" : ((TextBox)sender).Tag.ToString();

            if (tag.Contains("COR"))
            {
                if (!String.IsNullOrEmpty(((TextBox)sender).Text) && ((TextBox)sender).Text.Length == 7 && ((TextBox)sender).Text.Contains("#"))
                {
                    try
                    {
                        ((TextBox)sender).BackColor = Funcoes.ConverteColorFromHex(((TextBox)sender).Text);
                        ((TextBox)sender).ForeColor = Funcoes.GetForeColor(Funcoes.ConverteColorFromHex(((TextBox)sender).Text));
                    }
                    catch
                    {
                        if (tag.Contains("*"))
                            ((TextBox)sender).BackColor = SiCoresSistema.corFundoObjetoObrigatorioPadrao;
                        else
                            ((TextBox)sender).BackColor = SiCoresSistema.corFundoObjetoPadrao;
                        ((TextBox)sender).ForeColor = SiCoresSistema.corFonteObjetoPadrao;
                    }
                }
                else
                {

                    if (tag.Contains("*"))
                        ((TextBox)sender).BackColor = SiCoresSistema.corFundoObjetoObrigatorioPadrao;
                    else
                        ((TextBox)sender).BackColor = SiCoresSistema.corFundoObjetoPadrao;
                    ((TextBox)sender).ForeColor = SiCoresSistema.corFonteObjetoPadrao;
                }
            }
            else
            {
                if (tag.Contains("ERRO"))
                    ((TextBox)sender).BackColor = SiCoresSistema.corBackErro;
                else
                    if (tag.Contains("*"))
                        ((TextBox)sender).BackColor = SiCoresSistema.corFundoObjetoObrigatorioPadrao;
                    else
                        ((TextBox)sender).BackColor = SiCoresSistema.corFundoObjetoPadrao;
            }

        }

        /// <summary>
        /// Evento Textchange dos maskedtextbox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void TextBoxTextChange(object sender, EventArgs e)
        {
            /*string tag = "";
            if (((TextBox)sender).Tag != null)
                tag = ((TextBox)sender).Tag.ToString();
            if (tag.Contains("ERRO"))
                ((TextBox)sender).BackColor = SiCoresSistema.corBackErro;
            else
            {
                if (((TextBox)sender).Focused)
                {
                    ((TextBox)sender).BackColor = SiCoresSistema.corFundoObjetoFoco;
                }
                else
                {
                    ((TextBox)sender).BackColor = SiCoresSistema.corFundoObjetoPadrao;
                }
            }*/
        }

        private static void TextBoxValidate(object sender, EventArgs e)
        {
            ControlPaint.DrawBorder(((TextBox)sender).CreateGraphics(), ((TextBox)sender).ClientRectangle, System.Drawing.Color.Red, ButtonBorderStyle.Solid);
        }

        /// <summary>
        /// Evento KeyPress de um TextBox que só permite números
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void TextBoxNumericKeyPress(object sender, KeyPressEventArgs e)
        {
            if (sender is NumericUpDown)
            {
                if (((NumericUpDown)sender).DecimalPlaces > 0)
                {
                    PermitirApenasNumerosEVirgulas(e);
                }
                else
                    PermitirApenasNumeros(e);

            }
            else
                PermitirApenasNumeros(e);
        }
        private static void TextBoxNumericDecimalKeyPress(object sender, KeyPressEventArgs e)
        {
            PermitirApenasNumerosEVirgulas(e);
        }

        /// <summary>
        /// Percorre um controle e seus controles filhos, buscando TextBox
        /// e define sua propriedade ReadyOnly
        /// </summary>
        /// <param name="ctrl">Controle a ser percorrido</param>
        /// <param name="ronly">bool para a propriedade ReadyOnly</param>
        public static void TextBoxReadyOnly(Control ctrl, bool ronly)
        {
            foreach (Control controle_filho in ctrl.Controls)
            {
                string tag = controle_filho.Tag == null ? "" : controle_filho.Tag.ToString();

                if (tag.Contains("x"))
                    continue;

                if (controle_filho is TextBox)
                {
                    if (controle_filho.Tag != null)
                    {
                        if (tag.Contains("r"))
                        {
                            ((TextBox)controle_filho).ReadOnly = true;
                            // controle_filho.Enabled = false;
                            ((TextBox)controle_filho).BackColor = SiCoresSistema.corFundoReadOnly;
                            controle_filho.TabStop = false;
                        }
                        else
                        {
                            ((TextBox)controle_filho).ReadOnly = ronly;
                            if (tag.Contains("*"))
                                ((TextBox)controle_filho).BackColor = SiCoresSistema.corFundoObjetoObrigatorioPadrao;
                            else
                                ((TextBox)controle_filho).BackColor = SiCoresSistema.corFundoObjetoPadrao;

                        }
                    }
                    else
                    {
                        ((TextBox)controle_filho).ReadOnly = ronly;
                        if (tag.Contains("*"))
                            ((TextBox)controle_filho).BackColor = SiCoresSistema.corFundoObjetoObrigatorioPadrao;
                        else
                            ((TextBox)controle_filho).BackColor = SiCoresSistema.corFundoObjetoPadrao;
                    }
                }
                else if (controle_filho is RichTextBox)
                {
                    if (controle_filho.Tag != null)
                    {
                        if (controle_filho.Tag.ToString().Contains("r"))
                        {
                            ((RichTextBox)controle_filho).ReadOnly = true;
                            // controle_filho.Enabled = false;
                            ((RichTextBox)controle_filho).BackColor = SiCoresSistema.corFundoReadOnly;
                            controle_filho.TabStop = false;
                        }
                        else
                        {
                            ((RichTextBox)controle_filho).ReadOnly = ronly;
                            if (tag.Contains("*"))
                                ((RichTextBox)controle_filho).BackColor = SiCoresSistema.corFundoObjetoObrigatorioPadrao;
                            else
                                ((RichTextBox)controle_filho).BackColor = SiCoresSistema.corFundoObjetoPadrao;
                        }
                    }
                    else
                    {
                        ((RichTextBox)controle_filho).ReadOnly = ronly;
                        if (tag.Contains("*"))
                            ((RichTextBox)controle_filho).BackColor = SiCoresSistema.corFundoObjetoObrigatorioPadrao;
                        else
                            ((RichTextBox)controle_filho).BackColor = SiCoresSistema.corFundoObjetoPadrao;
                    }
                }
                else if (controle_filho is MaskedTextBox)
                {
                    if (controle_filho.Tag != null)
                    {
                        if (controle_filho.Tag.ToString().Contains("r"))
                        {
                            ((MaskedTextBox)controle_filho).ReadOnly = true;
                            // controle_filho.Enabled = false;
                            ((MaskedTextBox)controle_filho).BackColor = SiCoresSistema.corFundoReadOnly;
                            controle_filho.TabStop = false;
                        }
                        else
                        {
                            ((MaskedTextBox)controle_filho).ReadOnly = ronly;
                            if (tag.Contains("*"))
                                ((MaskedTextBox)controle_filho).BackColor = SiCoresSistema.corFundoObjetoObrigatorioPadrao;
                            else
                                ((MaskedTextBox)controle_filho).BackColor = SiCoresSistema.corFundoObjetoPadrao;
                        }
                    }
                    else
                    {
                        ((MaskedTextBox)controle_filho).ReadOnly = ronly;
                        if (tag.Contains("*"))
                            ((MaskedTextBox)controle_filho).BackColor = SiCoresSistema.corFundoObjetoObrigatorioPadrao;
                        else
                            ((MaskedTextBox)controle_filho).BackColor = SiCoresSistema.corFundoObjetoPadrao;
                    }

                }
                else if (controle_filho is CheckBox)
                {
                    if (tag.Contains("r"))
                        ((CheckBox)controle_filho).Enabled = false;
                    else
                        ((CheckBox)controle_filho).Enabled = !ronly;
                }
                else if (controle_filho is NumericUpDown || controle_filho is ComboBox || controle_filho is DateTimePicker || controle_filho is RadioButton || controle_filho is TrackBar)
                {
                    if (tag.Contains("r"))
                        controle_filho.Enabled = false;
                    else
                        controle_filho.Enabled = !ronly;
                }
                else if (controle_filho is Button)
                {
                    if (controle_filho.Tag != null)
                    {
                        if (controle_filho.Tag.ToString().Contains("s"))
                        {
                            controle_filho.Enabled = !ronly;
                        }
                        else if (controle_filho.Tag.ToString().Contains("c"))
                        {
                            controle_filho.Enabled = ronly;
                        }
                    }
                }
                else if (controle_filho.HasChildren)
                    TextBoxReadyOnly(controle_filho, ronly);
            }

        }

        /// <summary>
        /// Evento Enter de um Textbox de valores
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void TextBoxValoresEnter(object sender, EventArgs e)
        {
            ((TextBox)sender).Text = String.IsNullOrEmpty(((TextBox)sender).Text) ? "" : Funcoes.RemoverLetrasePontos(((TextBox)sender).Text);
            ((TextBox)sender).SelectAll();
        }

        /// <summary>
        /// Evento keypress de um textbox que deve ser um valor numérico (moeda, percentual) utilizar TAG = v;
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void TextBoxValoresKeypress(object sender, KeyPressEventArgs e)
        {
            TextBox tb = ((TextBox)sender);

            if (char.IsLetter(e.KeyChar) || char.IsSymbol(e.KeyChar) || char.IsWhiteSpace(e.KeyChar) || char.IsPunctuation(e.KeyChar))
            {
                e.KeyChar = e.KeyChar == (char)46 ? (char)44 : e.KeyChar;

                if ((e.KeyChar != (char)44 || tb.Text.Contains(",")) && !tb.SelectedText.Contains(","))
                {
                    e.Handled = true; //Não permitir
                }

            }
            else
            {
                string tag = tb.Tag == null ? "" : tb.Tag.ToString();


                if (tag.Contains("$"))
                {
                    if (char.IsNumber(e.KeyChar) && tb.Text.Length == 7 && !tb.Text.Contains(","))
                    {
                        ((TextBox)sender).Text = tb.Text + ",";
                        ((TextBox)sender).SelectionStart = ((TextBox)sender).Text.Length;
                    }


                    if (char.IsNumber(e.KeyChar) && tb.Text.Contains(",") && tb.SelectionLength == 0 && tb.SelectionLength != tb.Text.Length)
                    {
                        string[] val = tb.Text.Split(',');

                        int indexV = tb.Text.IndexOf(',');
                        if ((indexV <= tb.Text.Length - 5 && tb.SelectionStart > indexV))
                        {
                            e.Handled = true;
                        }
                        else if (tb.SelectionStart < indexV && val[0].Length >= 7)
                        {
                            e.Handled = true;
                        }
                    }
                }
                else if (tag.Contains("%"))
                {
                    if (char.IsNumber(e.KeyChar) && tb.Text.Length == 3 && !tb.Text.Contains(","))
                    {
                        ((TextBox)sender).Text = tb.Text + ",";
                        ((TextBox)sender).SelectionStart = ((TextBox)sender).Text.Length;
                    }


                    if ((char.IsNumber(e.KeyChar)) && tb.Text.Contains(",") && tb.SelectionLength == 0 && tb.SelectionLength != tb.Text.Length)
                    {
                        string[] val = tb.Text.Split(',');

                        int indexV = tb.Text.IndexOf(',');
                        if ((indexV <= tb.Text.Length - 3 && tb.SelectionStart > indexV))
                        {
                            e.Handled = true;
                        }
                        else if (tb.SelectionStart < indexV && val[0].Length >= 3)
                        {
                            e.Handled = true;
                        }
                    }
                }
                else if (tag.Contains(","))
                {
                    //nao formata. deixa livre para o usuário digitar com virgulas

                }

            }

        }

        /// <summary>
        /// Evento Leave de um TextBox de valores
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void TextBoxValoresLeave(object sender, EventArgs e)
        {
            FormataValor(((TextBox)sender));
        }

        public static void TimeLineAgenda(ref PaintEventArgs e, DataTable dt)
        {
            Brush brHoje = new SolidBrush(Color.FromArgb(178, 110, 0));
            Brush brOther = Brushes.DarkGray;
            Brush backTransp = new SolidBrush(Color.FromArgb(140, 240, 248, 255));

            Graphics eg = e.Graphics;
            DateTime dtHoje = DateTime.Now;
            int yTop = 5;
            int yDown = e.ClipRectangle.Height - 5;
            int xLimite = e.ClipRectangle.Width - 40;
            int xLinha = xLimite - 50;
            int alturaTotal = yDown - yTop;
            int yOntem = 80;
            int yAmanha = alturaTotal - yOntem;
            int diametro = 10;
            float espessura = (float)2.5;
            int alturaHoje = yAmanha - yOntem;
            Font font = new Font("Arial", 10);
            Font fontOther = new Font("Arial", 8);
            Pen pGray = new Pen(Brushes.Gray, espessura);

            eg.DrawLine(pGray, new Point(xLinha, yTop), new Point(xLinha, yDown));

            eg.DrawString((dtHoje.DayOfWeek == DayOfWeek.Monday ? dtHoje.AddDays(-3).ToString("dddd") : dtHoje.AddDays(-1).ToString("dddd")), fontOther, brOther, new PointF(xLinha + 10, yTop));
            eg.DrawString("Hoje"/*dtHoje.ToString("dd/MM/yy")*/, font, brHoje, new PointF(xLinha + 10, yOntem + diametro));
            eg.DrawString((dtHoje.DayOfWeek == DayOfWeek.Friday ? dtHoje.AddDays(3).ToString("dddd") : dtHoje.AddDays(1).ToString("dddd")), fontOther, brOther, new PointF(xLinha + 10, yAmanha + diametro));

            eg.FillEllipse(brOther, xLinha - (diametro / 2), yOntem, diametro, diametro);
            eg.FillEllipse(brOther, xLinha - (diametro / 2), yAmanha, diametro, diametro);

            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {
                    DataRow[] ontem = dt.Select("data < '" + dtHoje.ToShortDateString() + "'", "data desc");
                    DataRow[] hoje = dt.Select("data >= '" + dtHoje.ToShortDateString() + "' and data < '" + dtHoje.AddDays(1).ToShortDateString() + "'", "data");
                    DataRow[] amanha = dt.Select("data >= '" + dtHoje.AddDays(1).ToShortDateString() + "'", "data");

                    if (ontem.Length > 0)
                    {
                        string sOntem = ontem[0]["nome"].ToString();

                        if (ontem.Length > 1)
                            sOntem += "\r\nE mais " + (ontem.Length - 1).ToString();

                        SizeF tamanho = eg.MeasureString(sOntem, font);
                        eg.DrawString(Funcoes.ToTitleCase(sOntem.ToLower()), font, brOther, xLinha - tamanho.Width - 5, yOntem - tamanho.Height - 10 + (diametro / 2));
                    }
                    if (amanha.Length > 0)
                    {
                        string sAmanha = amanha[0]["nome"].ToString();

                        if (amanha.Length > 1)
                            sAmanha += "\r\nE mais " + (amanha.Length - 1).ToString();

                        SizeF tamanho = eg.MeasureString(sAmanha, font);
                        eg.DrawString(Funcoes.ToTitleCase(sAmanha.ToLower()), font, brOther, xLinha - tamanho.Width - 5, yAmanha + 15 - (diametro / 2));
                    }
                    if (hoje.Length > 0)
                    {

                        if (hoje.Length > 2)
                        {
                            //DateTime min = Funcoes.ConvertDataRowToDateTime(hoje[0]["data"]);
                            //DateTime max = Funcoes.ConvertDataRowToDateTime(hoje[hoje.Length - 1]["data"]);
                            //TimeSpan duracao = max - min;
                            //int horas = (int)duracao.TotalHours;
                            int salto = (alturaHoje / (hoje.Length + 1));

                            int y = yOntem - (diametro / 2);

                            int i = 1;
                            foreach (DataRow r in hoje)
                            {
                                y += salto;

                                DateTime data = Funcoes.ConvertDataRowToDateTime(r["data"]);
                                string texto = Funcoes.ToTitleCase(r["nome"].ToString().ToLower()).Trim();
                                SizeF tamanho = eg.MeasureString(texto, font);
                                //eg.DrawString(Funcoes.ToTitleCase(texto.ToLower()), font, Brushes.White, (xLinha - tamanho.Width - 5)+1, y+1);
                                eg.FillRectangle(backTransp, new Rectangle((int)(xLinha - tamanho.Width - 4), y - 1, (int)tamanho.Width + 2, (int)tamanho.Height + 2));
                                eg.DrawString(texto, font, brHoje, (xLinha - tamanho.Width - 5), y);
                                eg.FillEllipse(brHoje, xLinha - (diametro / 2), y, diametro, diametro);
                                eg.DrawString(data.ToString("HH:mm"), font, brHoje, new PointF(xLinha + 10, y));
                                i++;
                            }
                        }
                        else if (hoje.Length == 2)
                        {
                            int y = (alturaHoje / 3) + yOntem - (diametro / 2);

                            {
                                DateTime data = Funcoes.ConvertDataRowToDateTime(hoje[0]["data"]);
                                string texto = Funcoes.ToTitleCase(hoje[0]["nome"].ToString().ToLower()).Trim();
                                SizeF tamanho = eg.MeasureString(texto, font);
                                //eg.DrawString(Funcoes.ToTitleCase(texto.ToLower()), font, Brushes.White, (xLinha - tamanho.Width - 5) + 1, y + 1);
                                eg.FillRectangle(backTransp, new Rectangle((int)(xLinha - tamanho.Width - 4), y - 1, (int)tamanho.Width + 2, (int)tamanho.Height + 2));
                                eg.DrawString(texto, font, brHoje, xLinha - tamanho.Width - 5, y);
                                eg.FillEllipse(brHoje, xLinha - (diametro / 2), y, diametro, diametro);
                                eg.DrawString(data.ToString("HH:mm"), font, brHoje, new PointF(xLinha + 10, y));
                            }
                            {
                                DateTime data = Funcoes.ConvertDataRowToDateTime(hoje[1]["data"]);
                                string texto = Funcoes.ToTitleCase(hoje[1]["nome"].ToString().ToLower()).Trim();
                                SizeF tamanho = eg.MeasureString(texto, font);
                                //eg.DrawString(Funcoes.ToTitleCase(texto.ToLower()), font, Brushes.White, (xLinha - tamanho.Width - 5) + 1, (y*2) + 1);
                                eg.FillRectangle(backTransp, new Rectangle((int)(xLinha - tamanho.Width - 4), y - 1, (int)tamanho.Width + 2, (int)tamanho.Height + 2));
                                eg.DrawString(texto, font, brHoje, xLinha - tamanho.Width - 5, y * 2);
                                eg.FillEllipse(brHoje, xLinha - (diametro / 2), y * 2, diametro, diametro);
                                eg.DrawString(data.ToString("HH:mm"), font, brHoje, new PointF(xLinha + 10, y * 2));
                            }

                        }
                        else
                        {
                            int y = (alturaHoje / 2) - (diametro / 2) + yOntem;

                            DateTime data = Funcoes.ConvertDataRowToDateTime(hoje[0]["data"]);
                            string texto = Funcoes.ToTitleCase(hoje[0]["nome"].ToString().ToLower()).Trim();
                            SizeF tamanho = eg.MeasureString(texto, font);
                            //eg.DrawString(Funcoes.ToTitleCase(texto.ToLower()), font, Brushes.Black, (xLinha - tamanho.Width - 5) - 1, y - 1);
                            //eg.DrawString(Funcoes.ToTitleCase(texto.ToLower()), font, Brushes.White, (xLinha - tamanho.Width - 5) + 1, y + 2);
                            eg.FillRectangle(backTransp, new Rectangle((int)(xLinha - tamanho.Width - 4), y - 1, (int)tamanho.Width + 2, (int)tamanho.Height + 2));
                            eg.DrawString(texto, font, brHoje, xLinha - tamanho.Width - 5, y);
                            eg.FillEllipse(brHoje, xLinha - (diametro / 2), y, diametro, diametro);
                            eg.DrawString(data.ToString("HH:mm"), font, brHoje, new PointF(xLinha + 10, y));
                        }
                    }


                }
            }

        }

        /// <summary>
        /// Ao pressionar ENTER no controle, ele pula para o próximo.
        /// Esta função aplica-se apenas a TextBox (Exceto os Multiline) / MaskedTextBox / ListBox / CheckBox / TabPage / DateTimePicker / ComboBox
        /// Obs. Aplica-se tambem a cor da fonte a estes objetos.
        /// </summary>
        /// <param name="_ctrl">Controle (obs: todos os controles filhos, serão afetados)</param>
        public static void TrocaTabPorEnter(Control _ctrl)
        {
            string tag = _ctrl.Tag == null ? "" : _ctrl.Tag.ToString();


            if (tag.Contains("§"))
                return;


            if (_ctrl.HasChildren)
            {
                foreach (Control _child in _ctrl.Controls)
                {
                    if (_ctrl.HasChildren)
                        TrocaTabPorEnter(_child);
                }
            }
            else
            {


                ///Não funciona para Numeric Up Down   _ctrl is Button ||
                if (_ctrl is RichTextBox || _ctrl is Button || _ctrl is TextBox || _ctrl is MaskedTextBox || _ctrl is ListBox || _ctrl is CheckBox || _ctrl is DateTimePicker || _ctrl is ComboBox || _ctrl is NumericUpDown || _ctrl is TrackBar || _ctrl is RadioButton || _ctrl is TabPage)
                {
                    if (_ctrl is TextBox || _ctrl is MaskedTextBox || _ctrl is ListBox || _ctrl is CheckBox || _ctrl is DateTimePicker || _ctrl is ComboBox || _ctrl is NumericUpDown)
                    {
                        _ctrl.ForeColor = SiCoresSistema.corFonteObjetos;
                    }

                    TextBox tb;
                    if (_ctrl is TextBox)
                    {

                        if (tag.Contains("*"))
                        {
                            ((TextBox)_ctrl).BackColor = SiCoresSistema.corFundoObjetoObrigatorioPadrao;
                        }

                        tb = ((TextBox)_ctrl);
                        if (!tb.Multiline)
                        {
                            /// inibe a ação do Enter para evitar o comportamento de
                            /// Accept em alguns casos
                            _ctrl.KeyDown += delegate(object sender, KeyEventArgs e)
                            {
                                if (e.KeyCode == Keys.Enter)
                                {

                                    /*Form faux = GetFormParent((Control)sender);
                                    bool active = true;
                                    if (faux != null)
                                      active = faux.ContainsFocus;*/



                                    e.SuppressKeyPress = true;

                                    if (tag.Contains("!"))
                                    {
                                        if (tag.Contains("!!") && tag.Contains("v"))
                                        {
                                            decimal valor = decimal.Parse(String.IsNullOrEmpty(((Control)sender).Text) ? "0" : Funcoes.RemoverLetrasePontos(((Control)sender).Text));
                                            if (valor != 0)
                                                _ctrl.FindForm().SelectNextControl(_ctrl, !e.Shift, true, true, true);
                                        }
                                        else
                                        {

                                            if (!String.IsNullOrEmpty(((Control)sender).Text))
                                                _ctrl.FindForm().SelectNextControl(_ctrl, !e.Shift, true, true, true);
                                        }
                                    }
                                    else
                                    {
                                        _ctrl.FindForm().SelectNextControl(_ctrl, !e.Shift, true, true, true);
                                    }
                                }
                            };
                            /// adiciona a tratativa à tecla Enter e envia o TAB para
                            /// promover a navegação
                            /* _ctrl.KeyUp += delegate(object sender, KeyEventArgs e)
                             {
                                 if (e.KeyCode == Keys.Enter)
                                 {
                                     // SendKeys.Send("{TAB}");
                                     _ctrl.FindForm().SelectNextControl(_ctrl, true, true, true, true);
                                 }
                             };*/
                        }
                        else
                        {
                            tb.ScrollBars = ScrollBars.Both;

                            _ctrl.KeyDown += delegate(object sender, KeyEventArgs e)
                            {
                                if (e.KeyCode == Keys.Enter && e.Control)
                                {

                                    /*Form faux = GetFormParent((Control)sender);
                                    bool active = true;
                                    if (faux != null)
                                      active = faux.ContainsFocus;*/
                                    e.SuppressKeyPress = true;

                                    if (tag.Contains("!"))
                                    {
                                        if (tag.Contains("!!") && tag.Contains("v"))
                                        {
                                            decimal valor = decimal.Parse(String.IsNullOrEmpty(((Control)sender).Text) ? "0" : Funcoes.RemoverLetrasePontos(((Control)sender).Text));
                                            if (valor != 0)
                                                _ctrl.FindForm().SelectNextControl(_ctrl, !e.Shift, true, true, true);
                                        }
                                        else
                                        {
                                            if (!String.IsNullOrEmpty(((Control)sender).Text))
                                                _ctrl.FindForm().SelectNextControl(_ctrl, !e.Shift, true, true, true);
                                        }
                                    }
                                    else
                                    {
                                        _ctrl.FindForm().SelectNextControl(_ctrl, !e.Shift, true, true, true);
                                    }
                                }
                            };


                        }

                    }
                    else
                    {

                        if (_ctrl is ComboBox)
                        {
                            _ctrl.KeyDown += delegate(object sender, KeyEventArgs e)
                            {
                                if (e.KeyCode == Keys.Enter)
                                {
                                    e.SuppressKeyPress = true;
                                    //((Control)sender).SelectNextControl(_ctrl, !e.Shift, true, true, true);

                                    if ((((ComboBox)sender).DropDownStyle == ComboBoxStyle.Simple) || (tag.Contains("TXT") && ((ComboBox)sender).DropDownStyle == ComboBoxStyle.DropDown))
                                    {
                                        if (!(tag.Contains("!") && String.IsNullOrEmpty((((ComboBox)sender).Text))))
                                            _ctrl.FindForm().SelectNextControl(_ctrl, !e.Shift, true, true, true);
                                    }
                                    else
                                    {
                                        if (!(tag.Contains("!") && Funcoes.IsZeroOrEmpty((((ComboBox)sender).SelectedValue))))
                                            _ctrl.FindForm().SelectNextControl(_ctrl, !e.Shift, true, true, true);
                                    }
                                }
                            };

                        }
                        else if (_ctrl is RichTextBox)
                        {
                            if (tag.Contains("kh") || ((RichTextBox)_ctrl).ReadOnly)
                                return;

                            _ctrl.KeyDown += delegate(object sender, KeyEventArgs e)
                            {
                                if (e.KeyCode == Keys.Enter && e.Control)
                                {
                                    e.SuppressKeyPress = true;
                                    _ctrl.FindForm().SelectNextControl(_ctrl, !e.Shift, true, true, true);

                                }
                            };
                        }
                        else if (_ctrl is TabPage)
                        {
                            /*_ctrl.KeyDown += delegate(object sender, KeyEventArgs e)
                            {
                                if (e.KeyCode == Keys.Enter)
                                {
                                    e.Handled = true;
                                    e.SuppressKeyPress = true;
                                    SendKeys.Send("TAB");
                                    //_ctrl.FindForm().SelectNextControl(_ctrl, !e.Shift, true, true, true);
                                }
                            };*/
                        }
                        else
                        {

                            /// inibe a ação do Enter para evitar o comportamento de
                            /// Accept em alguns casos
                            _ctrl.KeyDown += delegate(object sender, KeyEventArgs e)
                            {
                                if (e.KeyCode == Keys.Enter)
                                {
                                    e.SuppressKeyPress = true;
                                    //((Control)sender).SelectNextControl(_ctrl, !e.Shift, true, true, true);
                                    _ctrl.FindForm().SelectNextControl(_ctrl, !e.Shift, true, true, true);
                                }
                            };

                        }

                    }
                    /// adiciona a tratativa à tecla Enter e envia o TAB para
                    /// promover a navegação
                    /// 
                    /* _ctrl.KeyUp += delegate(object sender, KeyEventArgs e)
                     {
                         if (e.KeyCode == Keys.Enter)
                         {
                             // SendKeys.Send("{TAB}");
                             _ctrl.FindForm().SelectNextControl(_ctrl, true, true, true, true);
                         }
                     };*/
                    // _ctrl.Anchor = (AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Right | AnchorStyles.Bottom);

                }
            }
        }

        /// <summary>
        /// Orderna os controles filhos do controle informado pela tab index
        /// </summary>
        /// <param name="_ctrl"></param>
        /// <returns></returns>
        public static List<Control> ToControlsSorted(Control _ctrl)
        {
            List<Control> controls = new List<Control>(_ctrl.Controls.Count);
            foreach (Control c in _ctrl.Controls)
            {
                controls.Add(c);
            }

            //var controls = _ctrl.Controls.OfType<Control>().ToList();

            controls.Sort((c1, c2) => c1.TabIndex.CompareTo(c2.TabIndex));
            return controls;
        }

     
        /// <summary>
        /// Percorre os controles informados e verifica se o campo é obrigatório pela tag *.
        /// Se for, verifica se há valor informado, se não houver retorna uma exceção.
        /// </summary>
        /// <param name="ctrl">controle que contém os controles a serem verificados</param>
        public static void ValidarCamposObrigatorios(Control ctrl)
        {
            bool erro = false;
            string controle = "";
            Control objC = new Control();
            List<Control> controles = ToControlsSorted(ctrl);

            foreach (Control c in controles)
            {
                objC = c;
                objC.Parent.Tag = objC.Parent.Tag == null ? "" : objC.Parent.Tag.ToString().Replace("(erro)", "");
                string tag = c.Tag == null ? "" : c.Tag.ToString().ToLower();
                controle = c.Name;
                bool obrigatorio = tag.Contains("*");

                if (c is TextBox || c is MaskedTextBox)
                {
                    if (obrigatorio && (String.IsNullOrEmpty(c.Text) || tag.Contains("v")))
                    {
                        if (tag.Contains("v"))
                        {
                            if (Funcoes.ToDecimal(c.Text) == 0)
                            {
                                erro = true;
                                c.Focus();
                                c.BackColor = SiCoresSistema.corBackErro;
                                break;
                            }
                        }
                        else
                        {
                            erro = true;
                            c.Focus();
                            c.BackColor = SiCoresSistema.corBackErro;
                            break;
                        }
                    }
                }
                else if (c is ComboBox)
                {
                    if (obrigatorio && ((ComboBox)c).SelectedValue == null)
                    {
                        erro = true;
                        c.Focus();
                        c.BackColor = SiCoresSistema.corBackErro;
                        ((ComboBox)c).DroppedDown = true;
                        break;
                    }
                }
                else if (c is DataGridView)
                {
                    if (obrigatorio && ((DataGridView)c).Rows.Count == 0)
                    {
                        erro = true;
                        break;
                    }
                }
                else if (c.HasChildren)
                    ValidarCamposObrigatorios(c);

            }

            if (erro)
            {
                if (objC.Parent is TabPage)
                    objC.Parent.Tag = objC.Parent.Tag == null ? "(erro)" : objC.Parent.Tag.ToString() + "(erro)";

                throw new Exception("Campo " + controle.Substring(7) + " não preenchido, ou inválido. (Campo obrigatório)");
            }
        }

        /// <summary>
        /// Percorre os controles informados e verifica se o valor do campo é válido pela tag informada.
        /// Ex: tag = n campo numérico.
        /// </summary>
        /// <param name="ctrl"></param>
        public static void ValidarCampoTipo(Control ctrl)
        {
            bool erro = false;
            foreach (Control c in ctrl.Controls)
            {
                string tag = c.Tag == null ? "" : c.Tag.ToString().ToLower();
                if (tag.Contains("r"))
                    continue;

                if (c is TextBox || c is MaskedTextBox)
                {
                    string aux = c.Text;
                    if (tag.Contains("v"))
                    {
                        aux = Funcoes.RemoverLetrasePontos(c.Text);
                    }

                    if (tag.Contains("n"))
                    {
                        if (String.IsNullOrEmpty(c.Text))
                        {
                            if (tag.Contains("*"))
                                erro = true;
                        }
                        else
                        {
                            try
                            {
                                float dbx = float.Parse(aux);
                            }
                            catch
                            {
                                erro = true;
                            }
                        }
                    }

                }
                else if (c.HasChildren)
                    ValidarCampoTipo(c);

            }

            if (erro)
                throw new Exception("Valor informado no campo é inválido.");

        }
   
        /// <summary>
        /// Extrair os anos de um datetime
        /// </summary>
        /// <param name="d2">datetime</param>
        /// <returns>int</returns>
        public static int Anos(DateTime d2, DateTime referencia)
        {
            DateTime d1 = referencia;
            //int years, out int months, out int days
            // compute & return the difference of two dates,
            // returning years, months & days
            // d1 should be the larger (newest) of the two dates
            // we want d1 to be the larger (newest) date
            // flip if we need to
            if (d1 < d2)
            {
                DateTime d3 = d2;
                d2 = d1;
                d1 = d3;
            }

            // compute difference in total months
            int months = 12 * (d1.Year - d2.Year) + (d1.Month - d2.Month);
            int days;
            int years;
            // based upon the 'days',
            // adjust months & compute actual days difference
            if (d1.Day < d2.Day)
            {
                months--;
                days = DateTime.DaysInMonth(d2.Year, d2.Month) - d2.Day + d1.Day;
            }
            else
            {
                days = d1.Day - d2.Day;
            }
            // compute years & actual months
            years = months / 12;
            months -= years * 12;

            return years;
        }

        /// <summary>
        /// Compara dois vetores de bytes e retorna se eles são iguais
        /// </summary>
        /// <param name="a1"></param>
        /// <param name="a2"></param>
        /// <returns></returns>
        public static bool ByteArrayCompare(byte[] a1, byte[] a2)
        {
            if (a1 == null && a2 == null)
                return true;
            if (a1 == null && a2 != null)
                return false;
            if (a1 != null && a2 == null)
                return false;

            /*
            fixed (byte* p1 = a1, p2 = a2)
            {
                byte* x1 = p1, x2 = p2;
                int l = a1.Length;
                for (int i = 0; i < l / 8; i++, x1 += 8, x2 += 8)
                    if (*((long*)x1) != *((long*)x2)) return false;
                if ((l & 4) != 0) { if (*((int*)x1) != *((int*)x2)) return false; x1 += 4; x2 += 4; }
                if ((l & 2) != 0) { if (*((short*)x1) != *((short*)x2)) return false; x1 += 2; x2 += 2; }
                if ((l & 1) != 0) if (*((byte*)x1) != *((byte*)x2)) return false;
                return true;
            }*/

            if (a1.Length != a2.Length)
                return false;

            for (int i = 0; i < a1.Length; i++)
                if (a1[i] != a2[i])
                    return false;

            return true;
        }

        /// <summary>
        /// Converte um array de bytes em string
        /// </summary>
        /// <param name="byteArray"></param>
        /// <returns></returns>
        public static string ByteToString(byte[] byteArray)
        {
            return System.Text.Encoding.UTF8.GetString(byteArray);
        }

        /// <summary>
        /// Retorna a idade em anos/meses/dias;
        /// </summary>
        /// <param name="dt">data de nascimento</param>
        /// <returns>string</returns>
        public static string CalcularIdade(DateTime dt, bool month, bool days)
        {
            return CalcularIdade(dt, DateTime.Now, month, days);
        }

        public static string CalcularIdade(DateTime dt, DateTime referencia, bool month, bool days)
        {
            if (dt == new DateTime() || dt > DateTime.Now)
                return "";

            int a, m = 0, d = 0;

            a = Anos(dt, referencia);
            if (month)
                m = Meses(dt, referencia);
            if (days)
                d = Dias(dt, referencia);

            string retorno = "";

            if (a > 0)
                retorno = retorno + a.ToString() + (a <= 1 ? " Ano" : " Anos");
            if (month && m > 0)
                retorno = retorno + (a > 0 ? ", " : "") + m + (m <= 1 ? " Mês" : " Meses");
            if (days && d > 0)
                retorno = retorno + " e " + d + (d <= 1 ? " Dia" : " Dias");

            return retorno;

        }

        public static DataRow CloneDataRow(DataRow rOrigem, DataRow rDestino)
        {
            foreach (DataColumn c in rDestino.Table.Columns)
            {
                foreach (DataColumn cc in rOrigem.Table.Columns)
                {
                    if (c.ColumnName == cc.ColumnName)
                    {
                        rDestino[c.ColumnName] = rOrigem[cc.ColumnName];
                        break;
                    }
                }
            }

            return rDestino;
        }

        /// <summary>
        /// Converte Bytes em GigaBytes
        /// </summary>
        /// <param name="bytes">1073741824 (bytes)</param>
        /// <returns>1 (GB)</returns>
        public static double ConvertBytesToGigabytes(long bytes)
        {
            return ((bytes / 1024f) / 1024f) / 1024f;
        }

        /// <summary>
        /// Converte um array de bytes em um objeto System.Drawing.Image
        /// </summary>
        /// <param name="pic">byte[]</param>
        /// <returns>System.Drawing.Image</returns>
        public static Image ConvertByteToImage(byte[] pic)
        {
            if (pic != null)
            {
                try
                {
                    MemoryStream ImageDataStream = new MemoryStream();
                    ImageDataStream.Write(pic, 0, pic.Length);
                    ImageDataStream.Position = 0;
                    pic = System.Text.UnicodeEncoding.Convert(Encoding.Unicode, Encoding.Default, pic);
                    System.Drawing.Image img = System.Drawing.Image.FromStream(ImageDataStream);
                    return img;
                }
                catch
                {
                    return null;
                }

            }
            else return null;
        }

        /// <summary>
        /// Converte Bytes em KiloBytes
        /// </summary>
        /// <param name="bytes">1024 (bytes)</param>
        /// <returns>1 (KB)</returns>
        public static double ConvertBytesToKilobytes(long bytes)
        {
            return (bytes / 1024f);
        }

        /// <summary>
        /// Converte Bytes em MegaBytes
        /// </summary>
        /// <param name="bytes">1048576 (bytes)</param>
        /// <returns>1 (MB)</returns>
        public static double ConvertBytesToMegabytes(long bytes)
        {
            return (bytes / 1024f) / 1024f;
        }

        /// <summary>
        /// Converter Color para hexadecimal
        /// </summary>
        /// <param name="c"></param>
        /// <returns>string</returns>
        public static string ConverteColorToHex(System.Drawing.Color c)
        {
            string htmlHexColorValueThree = String.Format("#{0:X2}{1:X2}{2:X2}", c.R, c.G, c.B);
            return htmlHexColorValueThree;
            //return ColorTranslator.ToHtml(c);
        }

        /// <summary>
        /// Converts the hex formatted color to a <see cref="Color"/>
        /// </summary>
        /// <param name="hex"></param>
        /// <returns></returns>
        public static Color ConverteColorFromHex(string hex)
        {
            if (String.IsNullOrEmpty(hex))
            {
                return Color.Empty;
            }
            else
            {
                if (hex.StartsWith("#"))
                    hex = hex.Substring(1);

                //if (hex.Length != 6) throw new Exception("Color not valid");
                if (hex.Length != 6)
                {
                    return Color.Empty;
                }
                else
                {
                    return Color.FromArgb(
                        int.Parse(hex.Substring(0, 2), System.Globalization.NumberStyles.HexNumber),
                        int.Parse(hex.Substring(2, 2), System.Globalization.NumberStyles.HexNumber),
                        int.Parse(hex.Substring(4, 2), System.Globalization.NumberStyles.HexNumber));
                }
            }
        }

        /// <summary>
        /// Retorna um valor datetime de uma coluna do banco de dados
        /// </summary>
        /// <param name="r">Qual coluna do banco de dados EX: MyRow[3]</param>
        /// <returns>Datetime / new Datetime</returns>
        public static DateTime ConvertDataRowToDateTime(object r)
        {
            if (r == null)
                return new DateTime();
            else
            {
                return r.ToString().Contains("T") ? DateTime.SpecifyKind(DateTime.Parse(r.ToString()), DateTimeKind.Utc) : String.IsNullOrEmpty(r.ToString()) ? new DateTime() : DateTime.Parse(r.ToString());
            }
        }

        /// <summary>
        /// Retorna um valor decimal de uma coluna do banco de dados
        /// </summary>
        /// <param name="r">Qual coluna do banco de dados EX: MyRow[3]</param>
        /// <returns>Valor Decimal</returns>
        public static decimal ConvertDataRowToDecimal(object r)
        {
            return r == null ? 0 : String.IsNullOrEmpty(r.ToString()) ? 0 : decimal.Parse(r.ToString());
        }
        /// <summary>
        /// Retorna um valor decimal de uma coluna do banco de dados
        /// </summary>
        /// <param name="r">Qual coluna do banco de dados EX: MyRow[3]</param>
        /// <returns>Valor Decimal</returns>
        public static decimal ConvertDataRowToDecimalWithDot(object r)
        {
            return r == null ? 0 : String.IsNullOrEmpty(r.ToString()) ? 0 : decimal.Parse(r.ToString().Replace(",", "").Replace(".", ","));
        }

        /// <summary>
        /// Retorna um valor inteiro de uma coluna do banco de dados
        /// </summary>
        /// <param name="r">Qual coluna do banco de dados EX: MyRow[3]</param>
        /// <returns>Valor Int</returns>
        public static int ConvertDataRowToInt(object r)
        {
            /*if (r == null)
                return 0;
            else
            {
                if (String.IsNullOrEmpty(r.ToString().Trim()))
                {
                    return 0;
                }
                else
                {
                    string val = r.ToString();
                    val = Funcoes.RemoverVirgulaDecimal(Funcoes.RemoverLetrasePontos(val));
                    decimal d = Funcoes.ToDecimal(val);
                    return (int)d;
                }
            }*/
            return r == null ? 0 : String.IsNullOrEmpty(r.ToString().Trim()) ? 0 : int.Parse(Funcoes.RemoverLetrasePontos(r.ToString()));
        }

        /// <summary>
        /// Retorna um valor long (int64) de uma coluna do banco de dados
        /// </summary>
        /// <param name="r">Qual coluna do banco de dados EX: MyRow[3]</param>
        /// <returns>Valor Long</returns>
        public static long ConvertDataRowToLong(object r)
        {
            return r == null ? 0 : String.IsNullOrEmpty(r.ToString().Trim()) ? 0 : long.Parse(Funcoes.RemoverLetrasePontos(r.ToString()));
        }

        /// <summary>
        /// Converte um objeto System.Drawing.Image em um array de bytes
        /// </summary>
        /// <param name="foto">System.Drawing.Image</param>
        /// <returns>byte[]</returns>
        public static byte[] ConvertImageToByte(System.Drawing.Image foto)
        {
            if (foto == null)
                return null;
            Bitmap bmp = new Bitmap(foto);
            MemoryStream stream = new MemoryStream();
            bmp.Save(stream, ImageFormat.Png);
            stream.Flush();
            byte[] pic = stream.ToArray();
            return pic;
        }

        /// <summary>
        /// Converte um valor string para boolean
        /// </summary>
        /// <param name="valor">String</param>
        /// <returns>Empty / null / 0 / False / F -> Falso outros valores, True</returns>
        public static bool ConvertStringToBool(string valor)
        {
            bool rt = true;
            if (String.IsNullOrEmpty(valor) || valor == "0" || valor.ToUpper() == "FALSE" || valor.ToUpper() == "F" || valor.ToLower() == "nao" || valor.ToLower() == "não" || valor.ToLower() == "no")
            {
                rt = false;
            }
            return rt;

        }

        /// <summary>
        /// Copia os valores das propriedades de um objeto para outro
        /// </summary>
        /// <param name="objOrigem"></param>
        /// <param name="ctrl"></param>
        /// <returns></returns>
        public static void CopiarPropriedades(object objOrigem, object objDestino)
        {
            if (objOrigem != null && objDestino != null)
            {
                foreach (System.Reflection.PropertyInfo pr1 in objOrigem.GetType().GetProperties())
                {
                    if (pr1.CanRead)
                    {
                        foreach (System.Reflection.PropertyInfo pr2 in objDestino.GetType().GetProperties())
                        {
                            if (pr2.CanWrite)
                            {
                                if (pr1.Name == pr2.Name)
                                    pr2.SetValue(objDestino, pr1.GetValue(objOrigem, null), null);
                            }
                        }
                    }
                }
            }
            else
                throw new Exception("Objeto nulo. Impossível preencher propriedades.");

        }

        /// <summary>
        /// Retorna o valor do dia da semana
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static int DiaDaSemana(DateTime dt)
        {
            int retorno = 0;
            switch (dt.DayOfWeek)
            {
                case DayOfWeek.Sunday:
                    {
                        retorno = 0;
                    }
                    break;
                case DayOfWeek.Monday:
                    {
                        retorno = 1;
                    }
                    break;
                case DayOfWeek.Tuesday:
                    {
                        retorno = 2;
                    }
                    break;
                case DayOfWeek.Wednesday:
                    {
                        retorno = 3;
                    }
                    break;
                case DayOfWeek.Thursday:
                    {
                        retorno = 4;
                    }
                    break;
                case DayOfWeek.Friday:
                    {
                        retorno = 5;
                    }
                    break;
                case DayOfWeek.Saturday:
                    {
                        retorno = 6;
                    }
                    break;
                default:
                    {
                        retorno = 0;
                    }
                    break;

            }
            return retorno;
        }

        /// <summary>
        /// Extrair os dias de um datetime
        /// </summary>
        /// <param name="d2">datetime</param>
        /// <returns>int </returns>
        public static int Dias(DateTime d2, DateTime referencia)
        {
            DateTime d1 = referencia;
            //int years, out int months, out int days
            // compute & return the difference of two dates,
            // returning years, months & days
            // d1 should be the larger (newest) of the two dates
            // we want d1 to be the larger (newest) date
            // flip if we need to
            if (d1 < d2)
            {
                DateTime d3 = d2;
                d2 = d1;
                d1 = d3;
            }

            // compute difference in total months
            int months = 12 * (d1.Year - d2.Year) + (d1.Month - d2.Month);
            int days;
            int years;
            // based upon the 'days',
            // adjust months & compute actual days difference
            if (d1.Day < d2.Day)
            {
                months--;
                days = DateTime.DaysInMonth(d2.Year, d2.Month) - d2.Day + d1.Day;
            }
            else
            {
                days = d1.Day - d2.Day;
            }
            // compute years & actual months
            years = months / 12;
            months -= years * 12;

            return days;
        }

        /// <summary>
        /// Retorna um datatable com codigo e nome , com os dias da semana, 0 = domingo
        /// </summary>
        /// <returns></returns>
        public static DataTable DiasDaSemana()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("codigo");
            dt.Columns.Add("nome");

            dt.Rows.Add("0", "Domingo");
            dt.Rows.Add("1", "Segunda-Feira");
            dt.Rows.Add("2", "Terça-Feira");
            dt.Rows.Add("3", "Quarta-Feira");
            dt.Rows.Add("4", "Quinta-Feira");
            dt.Rows.Add("5", "Sexta-Feira");
            dt.Rows.Add("6", "Sábado");

            return dt;
        }

        /// <summary>
        /// Retorna se um arquivo esta bloqueado pelo sistema operacional
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        public static bool FileIsLocked(FileInfo file)
        {
            FileStream stream = null;

            try
            {
                stream = file.Open(FileMode.Open, FileAccess.ReadWrite, FileShare.None);
            }
            catch (IOException)
            {
                //the file is unavailable because it is:
                //still being written to
                //or being processed by another thread
                //or does not exist (has already been processed)
                return true;
            }
            finally
            {
                if (stream != null)
                    stream.Close();
            }

            //file is not locked
            return false;
        }

        /// <summary>
        /// Retorna um vetor de Fileinfo
        /// </summary>
        /// <param name="filtros"></param>
        /// <param name="diretorio"></param>
        /// <param name="opcao"></param>
        /// <returns></returns>
        public static FileInfo[] GetFiles(string[] filtros, DirectoryInfo diretorio, SearchOption opcao)
        {
            List<FileInfo> lista = new List<FileInfo>();

            //FileInfo[] retorno = new FileInfo[diretorio.GetFiles("*", SearchOption.AllDirectories).Length];

            foreach (string s in filtros)
            {
                FileInfo[] aux = diretorio.GetFiles(s, opcao);
                foreach (FileInfo f in aux)
                {
                    lista.Add(f);
                }
            }

            return lista.ToArray();
        }

        /// <summary>
        /// Retorna a cor a ser usada na fonte, pela cor informada no fundo.
        /// </summary>
        /// <param name="c">cor de fundo</param>
        /// <returns>cor da fonte</returns>
        public static Color GetForeColor(Color c)
        {
            //float brilho = c.GetBrightness();
            float brilho = ((c.R * 299) + (c.G * 587) + (c.B * 114)) / 1000;

            if (brilho > 84)
                return Color.Black;
            else
                return Color.White;
        }


        /// <summary>
        /// Compara duas imagem e retorna se elas são iguais
        /// </summary>
        /// <param name="bmp1"></param>
        /// <param name="bmp2"></param>
        /// <returns></returns>
        public static bool ImageComparer(Bitmap bmp1, Bitmap bmp2)
        {

            bool equals = true;
            bool flag = true;  //Inner loop isn't broken

            //Test to see if we have the same size of image
            if (bmp1.Size == bmp2.Size)
            {
                for (int x = 0; x < bmp1.Width; ++x)
                {
                    for (int y = 0; y < bmp1.Height; ++y)
                    {
                        if (bmp1.GetPixel(x, y) != bmp2.GetPixel(x, y))
                        {
                            equals = false;
                            flag = false;
                            break;
                        }
                    }
                    if (!flag)
                    {
                        break;
                    }
                }
            }
            else
            {
                equals = false;
            }
            return equals;

        }

        /// <summary>
        /// Inverte a cor informada
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        public static Color InvertColor(Color c)
        {
            return Color.FromArgb(c.ToArgb() ^ 0xffffff);
        }

        /// <summary>
        /// Abreviação do método String.IsNullOrEmpty
        /// </summary>
        /// <param name="texto"></param>
        /// <returns></returns>
        public static bool INoE(string texto)
        {
            return String.IsNullOrEmpty(texto);
        }

        /// <summary>
        /// Retorna se um objeto tem valor null, zero, ou "" 
        /// </summary>
        /// <param name="objeto"></param>
        /// <returns></returns>
        public static bool IsZeroOrEmpty(object objeto)
        {
            if (objeto == null)
            {
                return true;
            }
            else if (objeto.ToString() == "0" || String.IsNullOrEmpty(objeto.ToString()))
            {
                return true;
            }
            else
                return false;
        }

        /// <summary>
        /// Retorna uma string Md5 Hash de um arquivo
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string Md5FromFile(string input)
        {
            using (var md5 = MD5.Create())
            {
                using (var stream = File.OpenRead(input))
                {
                    var hash = md5.ComputeHash(stream);
                    return BitConverter.ToString(hash).Replace("-", "").ToLowerInvariant();
                }
            }

            //System.Security.Cryptography.MD5 md5Hasher = System.Security.Cryptography.MD5.Create();
            //Byte[] bytes = System.IO.File.ReadAllBytes(input);
            //Byte[] data = md5Hasher.ComputeHash(bytes);
            //StringBuilder sBuilder = new StringBuilder();
            //foreach (var valorByte in data)
            //    sBuilder.Append(valorByte.ToString("x2"));
            //return sBuilder.ToString();
        }

        public static string SHA1FromFile(FileInfo input, bool limiteSize = true)
        {
            string hash = null;
            using (FileStream fop = File.OpenRead(input.FullName))
            {
                if (limiteSize)
                {
                    long limite = (1024 * 1024);

                    if (fop.Length > limite)
                    {
                        fop.Position = fop.Length - limite;
                    }
                }
                
                //string chksum = BitConverter.ToString(System.Security.Cryptography.SHA1.Create().ComputeHash(fop));
                using (var cryptoProvider = new SHA1CryptoServiceProvider())
                {
                    hash = BitConverter.ToString(cryptoProvider.ComputeHash(fop));
                    //do something with hash
                }
            }
            return hash;


            //long gb = input.Length;// 1024 * 1024 * 1024;
            //using (var stream = new FileStream(input.FullName, FileMode.Open))
            //{
            //    stream.Position = 2 * gb; // 3rd gb-chunk
            //    byte[] buffer = new byte[32768];
            //    long amount = 1 * gb;

            //    using (var hashAlgorithm = SHA1.Create())
            //    {
            //        while (amount > 0)
            //        {
            //            int bytesRead = stream.Read(buffer, 0,
            //                (int)Math.Min(buffer.Length, amount));

            //            if (bytesRead > 0)
            //            {
            //                amount -= bytesRead;
            //                if (amount > 0)
            //                    hashAlgorithm.TransformBlock(buffer, 0, bytesRead,
            //                        buffer, 0);
            //                else
            //                    hashAlgorithm.TransformFinalBlock(buffer, 0, bytesRead);
            //            }
            //            else
            //                throw new InvalidOperationException();
            //        }
            //        hash = BitConverter.ToString(hashAlgorithm.Hash);
            //    }
            //}

            //return hash;
        }

        //public static string SHA256FromFile(string input)
        //{
        //    string retorno = null;
        //    using (var hashAlgorithm = new SHA256Managed())
        //    using (var fileStream = File.OpenRead(input))
        //    {
        //        fileStream.Position = ...;
        //        long bytesToHash = ...;

        //        var buf = new byte[4 * 1024];
        //        while (bytesToHash > 0)
        //        {
        //            var bytesRead = fileStream.Read(buf, 0, (int)Math.Min(bytesToHash, buf.Length));
        //            hashAlgorithm.TransformBlock(buf, 0, bytesRead, null, 0);
        //            bytesToHash -= bytesRead;
        //            if (bytesRead == 0)
        //                throw new InvalidOperationException("Unexpected end of stream");
        //        }
        //        hashAlgorithm.TransformFinalBlock(buf, 0, 0);
        //        var hash = hashAlgorithm.Hash;
        //        retorno = BitConverter.ToString(hash);
        //    };
        //    return retorno;
        //}

        /// <summary>
        /// Retorna uma string md5 hash de uma string
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string Md5FromString(string input)
        {
            // step 1, calculate MD5 hash from input
            System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create();
            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
            byte[] hash = md5.ComputeHash(inputBytes);

            // step 2, convert byte array to hex string
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("X2"));
            }
            return sb.ToString();
        }

        /// <summary>
        /// Extrair os meses de um datetime
        /// </summary>
        /// <param name="d2">datetime</param>
        /// <returns>int</returns>
        public static int Meses(DateTime d2, DateTime referencia)
        {
            DateTime d1 = referencia;
            //int years, out int months, out int days
            // compute & return the difference of two dates,
            // returning years, months & days
            // d1 should be the larger (newest) of the two dates
            // we want d1 to be the larger (newest) date
            // flip if we need to
            if (d1 < d2)
            {
                DateTime d3 = d2;
                d2 = d1;
                d1 = d3;
            }

            // compute difference in total months
            int months = 12 * (d1.Year - d2.Year) + (d1.Month - d2.Month);
            int days;
            int years;
            // based upon the 'days',
            // adjust months & compute actual days difference
            if (d1.Day < d2.Day)
            {
                months--;
                days = DateTime.DaysInMonth(d2.Year, d2.Month) - d2.Day + d1.Day;
            }
            else
            {
                days = d1.Day - d2.Day;
            }
            // compute years & actual months
            years = months / 12;
            months -= years * 12;

            return months;
        }
        /// <summary>
        /// Calculo de superfície corporal pela fóruma de Mosteller
        /// </summary>
        /// <param name="peso">Peso do paciente em KG</param>
        /// <param name="altura">Altura do paciente em CM</param>
        /// <returns></returns>
        public static double SCMosteller(double peso, int altura)
        {
            return Math.Sqrt((peso * altura) / 3600);
        }

        /// <summary>
        /// Obtem o nome da cidade, quando o nome é de um distrito e o nome da cidade esta entre parenteses ex: Acioli (João Neiva)
        /// </summary>
        /// <param name="nomeCidade">Acioli (João Neiva)</param>
        /// <returns>João Neiva</returns>
        public static string NomeCidadeFromWS(string nomeCidade)
        {
            string cidade;
            if (nomeCidade.Contains("("))
            {
                string remover = Funcoes.RemoverBetween(nomeCidade.ToString().Trim(), '(', ')');
                cidade = nomeCidade.Replace(remover, string.Empty).Replace("(", "").Replace(")", "");
                cidade = Funcoes.RemoverAcentos(cidade);
            }
            else
            {
                cidade = Funcoes.RemoverAcentos(nomeCidade.Trim());
            }
            return cidade;
        }

        /// <summary>
        /// Obtem o nome da cidade, quando o nome é de um distrito e o nome da cidade esta entre parenteses ex: Acioli (João Neiva)
        /// </summary>
        /// <param name="nomeCidade">Acioli (João Neiva)</param>
        /// <returns>João Neiva</returns>
        public static string NomeCidadeFromWS(string nomeCidade, ref string Complemento)
        {
            string cidade;
            if (nomeCidade.Contains("("))
            {
                string remover = Funcoes.RemoverBetween(nomeCidade.ToString().Trim(), '(', ')');
                Complemento = remover.Trim();
                cidade = nomeCidade.Replace(remover, string.Empty).Replace("(", "").Replace(")", "");
                cidade = Funcoes.RemoverAcentos(cidade);
            }
            else
            {
                cidade = Funcoes.RemoverAcentos(nomeCidade.Trim());
            }
            return cidade;
        }

        /// <summary>
        /// Retorna o nome do dia da semana
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static string NomeDiaSemana(DateTime dt)
        {
            // using System.Globalization
            CultureInfo culture = new CultureInfo("pt-BR");
            DateTimeFormatInfo dtfi = culture.DateTimeFormat;
            return dtfi.GetDayName(dt.DayOfWeek);
        }

        /// <summary>
        /// Retorna o status de um ping em um endereço url
        /// </summary>
        public static int PingServidor(string xurl)
        {
            System.Net.NetworkInformation.Ping pingSender = new System.Net.NetworkInformation.Ping();
            System.Net.NetworkInformation.PingOptions options = new System.Net.NetworkInformation.PingOptions();
            options.DontFragment = true;
            string data = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";
            byte[] buffer = Encoding.ASCII.GetBytes(data);
            //int timeout = 1000;
            int retorno;
            try
            {
                //System.Net.NetworkInformation.PingReply reply = pingSender.Send(xurl, timeout, buffer, options);
                System.Net.NetworkInformation.PingReply reply = pingSender.Send(xurl);
                switch (reply.Status)
                {
                    case System.Net.NetworkInformation.IPStatus.Success:
                        {
                            retorno = 1;
                        }
                        break;
                    case System.Net.NetworkInformation.IPStatus.TimedOut:
                        {
                            retorno = 2;
                        }
                        break;
                    case System.Net.NetworkInformation.IPStatus.BadDestination:
                        {
                            retorno = 3;
                        }
                        break;
                    default:
                        {
                            retorno = 0;
                        }
                        break;
                }
            }
            catch (Exception ex)
            {
                string teste = ex.Message;
                retorno = 4;
            }

            return retorno;
        }

        /// <summary>
        /// Retorna o status de um ping em um endereço url, com o timeout informado.
        /// </summary>
        public static int PingServidor(string xurl, int timeout)
        {
            System.Net.NetworkInformation.Ping pingSender = new System.Net.NetworkInformation.Ping();
            System.Net.NetworkInformation.PingOptions options = new System.Net.NetworkInformation.PingOptions();
            options.DontFragment = true;
            string data = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";
            byte[] buffer = Encoding.ASCII.GetBytes(data);
            //int timeout = 1000;
            int retorno;
            try
            {
                //System.Net.NetworkInformation.PingReply reply = pingSender.Send(xurl, timeout, buffer, options);
                System.Net.NetworkInformation.PingReply reply = pingSender.Send(xurl, timeout);
                switch (reply.Status)
                {
                    case System.Net.NetworkInformation.IPStatus.Success:
                        {
                            retorno = 1;
                        }
                        break;
                    case System.Net.NetworkInformation.IPStatus.TimedOut:
                        {
                            retorno = 2;
                        }
                        break;
                    case System.Net.NetworkInformation.IPStatus.BadDestination:
                        {
                            retorno = 3;
                        }
                        break;
                    default:
                        {
                            retorno = 0;
                        }
                        break;
                }
            }
            catch (Exception ex)
            {
                string teste = ex.Message;
                retorno = 4;
            }

            return retorno;
        }

        /// <summary>
        /// Lê o Html da pagina do IBGE e retorna um datatable encontrado no site
        /// </summary>
        /// <param name="tableHtml"></param>
        /// <returns></returns>
        public static DataTable ReadHtmlTableCodIBGE(string tableHtml)
        {
            // inicializa a tabela...
            System.Data.DataTable result = new System.Data.DataTable();
            result.Columns.Add("UF", typeof(string));
            result.Columns.Add("IBGE", typeof(string));
            result.Columns.Add("Cidade", typeof(string));
            // procura as linhas da tabela...
            System.Text.RegularExpressions.MatchCollection matches =
             System.Text.RegularExpressions.Regex.Matches(tableHtml, @"<TR.*?>(.*?)</TR>", System.Text.RegularExpressions.RegexOptions.IgnoreCase | System.Text.RegularExpressions.RegexOptions.Singleline);

            // varre os resultados e adiciona na lista...
            foreach (System.Text.RegularExpressions.Match match in matches)
                if (match.Success && match.Groups.Count > 1)
                {
                    string rowText = match.Groups[1].Value;

                    // pega os dados da linha...
                    System.Text.RegularExpressions.MatchCollection matchesTD =
                     System.Text.RegularExpressions.Regex.Matches(rowText, @"<TD.*?>(.*?)</TD>", System.Text.RegularExpressions.RegexOptions.IgnoreCase | System.Text.RegularExpressions.RegexOptions.Singleline);

                    // pega o resultado da linha...
                    List<string> rowValues = new List<string>();
                    foreach (System.Text.RegularExpressions.Match matchTD in matchesTD)
                        if (match.Success && matchTD.Groups.Count > 1)
                            rowValues.Add(matchTD.Groups[1].Value);

                    // preeche o grid...
                    // NESTE PONTO, rowValues contém a lista dos valores dentro de <TR>...
                    result.Rows.Add(rowValues[1], rowValues[2], rowValues[3]);
                }

            return result;
        }

        /// <summary>
        /// Redimensiona um Objeto System.Drawing.Image
        /// </summary>
        /// <param name="img">System.Drawing.Image</param>
        /// <param name="w">int Largura (pixels)</param>
        /// <param name="h">int Altura  (pixels)</param>
        /// <returns>System.Drawing.Image</returns>
        public static System.Drawing.Image oldRedimensionarImagem(System.Drawing.Image img, int w, int h)
        {
            if (img != null)
            {
                int fonteLargura = img.Width;
                int fonteAltura = img.Height;
                Bitmap bmImagem = new Bitmap(w, h, PixelFormat.Format24bppRgb);
                bmImagem.SetResolution(img.HorizontalResolution, img.VerticalResolution);
                Graphics grImagem = Graphics.FromImage(bmImagem);
                grImagem.InterpolationMode = InterpolationMode.HighQualityBicubic;
                grImagem.DrawImage(img, new Rectangle(0, 0, w, h), new Rectangle(0, 0, fonteLargura, fonteAltura), GraphicsUnit.Pixel);
                grImagem.Dispose();
                return bmImagem;
            }
            else return null;
        }

        /// <summary>
        /// Redimensiona uma imagem
        /// </summary>
        public static System.Drawing.Image oldRedimensionarImagem(System.Drawing.Image img, decimal percentual)
        {
            if (img != null)
            {
                int nW = (int)(img.Width * percentual / 100);
                int nH = (int)(img.Height * percentual / 100);
                return RedimensionarImagem(img, nW, nH);
            }
            else return null;

        }

        /// <summary>
        /// Redimensiona uma imagem
        /// </summary>
        public static System.Drawing.Image oldRedimensionarImagem(System.Drawing.Image img, int limite, char c)
        {
            if (c == 'h' || c == 'H')
            {
                if (img.Height > limite)
                {
                    int delta = img.Height - limite;
                    decimal percent = delta * 100 / img.Height;
                    percent = percent < 0 ? percent + 100 : percent;

                    return RedimensionarImagem(img, percent);
                }
                else
                    return img;

            }
            else
            {
                if (img.Width > limite)
                {
                    int delta = img.Width - limite;
                    decimal percent = delta * 100 / img.Width;
                    percent = percent < 0 ? percent + 100 : percent;
                    return RedimensionarImagem(img, percent);
                }
                return img;
            }


        }

        public static System.Drawing.Image RedimensionarImagem(int newSize, char orientacao, System.Drawing.Image srcImage)
        {
            if (srcImage != null)
            {
                if (orientacao == 'w' || orientacao == 'W')
                {
                    int newH = newSize * srcImage.Height / srcImage.Width;
                    return RedimensionarImagem(srcImage, newSize, newH);
                }
                else
                {
                    int newW = newSize * srcImage.Width / srcImage.Height;
                    return RedimensionarImagem(srcImage, newW, newSize);
                }
            }
            else return null;

        }

        public static System.Drawing.Image RedimensionarImagem(System.Drawing.Image srcImage, int newWidth, int newHeight)
        {
            return RedimensionarImagem(srcImage, newWidth, newHeight, PixelFormat.Format24bppRgb);
        }
        /// <summary>
        /// Redimensiona um Objeto System.Drawing.Image
        /// </summary>
        /// <param name="srcImage">System.Drawing.Image</param>
        /// <param name="newWidth">int Largura (pixels)</param>
        /// <param name="newHeight">int Altura  (pixels)</param>
        /// <returns>System.Drawing.Image</returns>
        public static System.Drawing.Image RedimensionarImagem(System.Drawing.Image srcImage, int newWidth, int newHeight, PixelFormat pf)
        {
            /*if (img != null)
            {
                int fonteLargura = img.Width;
                int fonteAltura = img.Height;
                Bitmap bmImagem = new Bitmap(w, h, PixelFormat.Format24bppRgb);
                bmImagem.SetResolution(img.HorizontalResolution, img.VerticalResolution);
                Graphics grImagem = Graphics.FromImage(bmImagem);
                grImagem.InterpolationMode = InterpolationMode.HighQualityBicubic;
                grImagem.DrawImage(img, new Rectangle(0, 0, w, h), new Rectangle(0, 0, fonteLargura, fonteAltura), GraphicsUnit.Pixel);
                grImagem.Dispose();
                return bmImagem;
            }
            else return null;*/

            if (srcImage != null)
            {
                Bitmap newImage = new Bitmap(newWidth, newHeight, pf);
                using (Graphics gr = Graphics.FromImage((Image)newImage))
                {
                    //gr.SmoothingMode = SmoothingMode.HighQuality;
                    gr.InterpolationMode = InterpolationMode.HighQualityBicubic;
                    //gr.PixelOffsetMode = PixelOffsetMode.HighQuality;
                    gr.DrawImage(srcImage, 0, 0, newWidth, newHeight);// new Rectangle(0, 0, newWidth, newHeight));
                    gr.Dispose();
                    return (Image)newImage;
                }
            }
            else
                return null;

        }

        /// <summary>
        /// Redimensiona uma imagem
        /// </summary>
        public static System.Drawing.Image RedimensionarImagem(System.Drawing.Image img, decimal percentual)
        {
            if (img != null)
            {
                int nW = (int)(img.Width * percentual / 100);
                int nH = (int)(img.Height * percentual / 100);
                return RedimensionarImagem(img, nW, nH);
            }
            else return null;

        }

        /// <summary>
        /// Redimensiona uma imagem
        /// </summary>
        public static System.Drawing.Image RedimensionarImagem(System.Drawing.Image img, int limite, char c)
        {
            if (c == 'h' || c == 'H')
            {
                if (img.Height > limite)
                {
                    int delta = img.Height - limite;
                    decimal percent = delta * 100 / img.Height;
                    percent = percent < 0 ? percent + 100 : percent;

                    return RedimensionarImagem(img, percent);
                }
                else
                    return img;

            }
            else
            {
                if (img.Width > limite)
                {
                    int delta = img.Width - limite;
                    decimal percent = delta * 100 / img.Width;
                    percent = percent < 0 ? percent + 100 : percent;
                    return RedimensionarImagem(img, percent);
                }
                return img;
            }


        }
        /// <summary>
        /// Remove os acentos de uma string
        /// </summary>
        /// <param name="texto">ÁÉÍÓÚ</param>
        /// <returns>AEIOU</returns>
        public static string RemoverAcentos(string texto)
        {
            string s = texto.Normalize(NormalizationForm.FormD);

            StringBuilder sb = new StringBuilder();

            for (int k = 0; k < s.Length; k++)
            {
                System.Globalization.UnicodeCategory uc = System.Globalization.CharUnicodeInfo.GetUnicodeCategory(s[k]);
                if (uc != System.Globalization.UnicodeCategory.NonSpacingMark)
                {
                    sb.Append(s[k]);
                }
            }
            return sb.ToString();
        }

        /// <summary>
        /// Remove o valor de uma string que tiver entre dois parâmetros especificados
        /// </summary>
        /// <param name="s">Teste (Remover) OK</param>
        /// <param name="begin">'('</param>
        /// <param name="end">')'</param>
        /// <returns>Teste OK</returns>
        public static string RemoverBetween(string s, char begin, char end)
        {
            System.Text.RegularExpressions.Regex regex = new System.Text.RegularExpressions.Regex(string.Format("\\{0}.*?\\{1}", begin, end));
            return regex.Replace(s, string.Empty);
            // return regex.ToString();
        }

        /// <summary>
        /// Remove espaços de uma string
        /// </summary>
        /// <param name="texto"></param>
        /// <returns></returns>
        public static string RemoverEspacos(string texto)
        {
            return texto.Replace(" ", "");
        }

        /// <summary>
        /// Remove Letras e Pontos de uma string 
        /// </summary>
        /// <param name="texto"></param>
        /// <returns></returns>
        public static string RemoverLetrasePontos(string texto)
        {
            texto = texto.Replace("²", "");
            texto = texto.Replace("³", "");
            string retorno = "";
            foreach (char c in texto)
            {
                if (char.IsNumber(c))
                {
                    if (c >= (char)251 && c >= (char)253)
                        continue;
                    else
                        retorno = retorno + c;
                }
                else if (c == (char)44)
                {
                    retorno = retorno + c;
                }
            }


            return retorno;
        }


        /// <summary>
        /// Remove caracteres numéricos de uma string 0 a 9
        /// </summary>
        /// <param name="texto"></param>
        /// <returns></returns>
        public static string RemoverNumeros(string texto)
        {
            texto = texto.Replace("0", "");
            texto = texto.Replace("1", "");
            texto = texto.Replace("2", "");
            texto = texto.Replace("3", "");
            texto = texto.Replace("4", "");
            texto = texto.Replace("5", "");
            texto = texto.Replace("6", "");
            texto = texto.Replace("7", "");
            texto = texto.Replace("8", "");
            texto = texto.Replace("9", "");
            return texto;
        }

        /// <summary>
        /// Remove a pontuação de uma string
        /// </summary>
        /// <param name="texto">(--Teste--) ; [1.2.3]</param>
        /// <returns>Teste123</returns>
        public static string RemoverPontuacao(string texto)
        {
            string retorno;
            if (texto != null)
            {
                retorno = texto;
                retorno = retorno.Replace("(", "");
                retorno = retorno.Replace(")", "");
                retorno = retorno.Replace("-", "");
                retorno = retorno.Replace(".", "");
                retorno = retorno.Replace(";", "");
                retorno = retorno.Replace(",", "");
                retorno = retorno.Replace("/", "");
                retorno = retorno.Replace(@"\", "");
                retorno = retorno.Replace("'", "");
                retorno = retorno.Replace("*", "");
                retorno = retorno.Replace("+", "");
                retorno = retorno.Replace("[", "");
                retorno = retorno.Replace("]", "");
                retorno = retorno.Replace("{", "");
                retorno = retorno.Replace("}", "");
                retorno = retorno.Replace("º", "");
                retorno = retorno.Replace("ª", "");
                retorno = retorno.Replace("°", "");
                retorno = retorno.Replace("=", "");
                //retorno = retorno.Replace(" ", "");
                retorno = retorno.Replace(":", "");
            }
            else
            {
                retorno = null;
            }
            return retorno;
        }
        /// <summary>
        /// Remove caracteres não permitidos em nomes de arquivos, utilizar somente no nome do arquivo, e não no caminho completo.
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static string RemoverPontuacaoNomeArquivos(string s)
        {
            s = s.Replace("#", "");
            s = s.Replace("%", "");
            s = s.Replace("&", "");
            s = s.Replace("*", "");
            s = s.Replace("|", "");
            s = s.Replace(@"\", "");
            s = s.Replace(":", "");
            s = s.Replace('"', '<');
            s = s.Replace("<", "");
            s = s.Replace(">", "");
            s = s.Replace("?", "");
            s = s.Replace("/", "");

            return s;
        }

        /// <summary>
        /// Remove todos os pontos da string, e troca as virgulas por pontos.
        /// Utilizar quando gravar valores em banco de dados.
        /// </summary>
        /// <param name="texto"></param>
        /// <returns></returns>
        public static string RemoverVirgulaDecimal(decimal valor)
        {
            string texto = valor.ToString();
            texto = texto.Replace(".", "");
            return texto.Replace(",", ".");
        }

        /// <summary>
        /// Remove todos os pontos da string, e troca as virgulas por pontos.
        /// Utilizar quando gravar valores em banco de dados.
        /// </summary>
        /// <param name="texto"></param>
        /// <returns></returns>
        public static string RemoverVirgulaDecimal(string texto)
        {
            texto = texto.Replace(".", "");
            return texto.Replace(",", ".");
        }
        /// <summary>
        /// Salva um vetor de bytes de uma imagem, em um arquivo no caminho informado.
        /// </summary>
        /// <param name="imgb"></param>
        /// <param name="path"></param>
        /// <returns></returns>
        public static string SalvarImagem(byte[] imgb, string path)
        {
            return SalvarImagem(Funcoes.ConvertByteToImage(imgb), path);
        }
        /// <summary>
        /// Salva uma imagem em um arquivo, no caminho informado.
        /// </summary>
        /// <param name="img"></param>
        /// <param name="path"></param>
        /// <returns></returns>
        public static string SalvarImagem(Image img, string path)
        {
            System.IO.FileInfo file = new System.IO.FileInfo(path);
            if (file.Exists)
                file.Delete();

            img.Save(file.FullName);
            return file.FullName;
        }

        /// <summary>
        /// Retorna um token criptografado com a funcao HMACSHA1
        /// </summary>
        /// <param name="value"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string ShaHash(string value, string key)
        {
            byte[] keyBytes = Convert.FromBase64String(key);
            //HMAC mac = HMACSHA1.Create("HmacSHA1");
            HMACSHA1 mac = new HMACSHA1(keyBytes);
            byte[] rawHmac = mac.ComputeHash(Encoding.ASCII.GetBytes(value));

            //byte[] hexBytes = Encoding. new  Hex().encode(rawHmac);

            string aux = Convert.ToBase64String(rawHmac);
            return aux;

            /*using (var hmac = new HMACSHA1(Encoding.ASCII.GetBytes(key)))
            {
                return ByteToString(hmac.ComputeHash(Encoding.ASCII.GetBytes(value)));
            }*/
        }
        /// <summary>
        /// Remove qualquer caractere que não seja número, virgua ou ponto de uma string
        /// </summary>
        /// <param name="texto"></param>
        /// <returns></returns>
        public static string SomenteNumerosVirgulaEPontos(string texto)
        {
            string retorno = "";
            foreach (char c in texto)
            {
                if (char.IsNumber(c))
                {
                    retorno = retorno + c;
                }
                else if (c >= (char)44 && c <= (char)46)
                {
                    retorno = retorno + c;
                }
            }
            return retorno;
        }
        /// <summary>
        /// Converte um valor string em inteiro, tratando os erros
        /// </summary>
        /// <param name="valor"></param>
        /// <returns></returns>
        public static int ToInt(string valor)
        {
            if (int.TryParse(valor, out int i))
            {
                return i;
            }
            else
            {
                if (String.IsNullOrEmpty(valor))
                    return 0;
                try
                {
                    valor = valor.Replace(".", "");
                    valor = valor.Replace(",", ".");

                    valor = Funcoes.SomenteNumerosVirgulaEPontos(valor);

                    decimal d = Funcoes.ToDecimal(valor);

                    //valor = valor.Replace(",", ".");
                    return (int)d;
                }
                catch
                {
                    return -999;
                }
            }
        }

        public static DateTime ToDateTime(string r)
        {
            if (r == null)
                return new DateTime();
            else
            {
                return r.ToString().Contains("T") ? DateTime.SpecifyKind(DateTime.Parse(r.ToString()), DateTimeKind.Utc) : String.IsNullOrEmpty(r.ToString()) ? new DateTime() : DateTime.Parse(r.ToString());
            }
        }

        /// <summary>
        /// Converte um valor string em decimal, tratando os erros
        /// </summary>
        /// <param name="valor"></param>
        /// <returns></returns>
        public static decimal ToDecimal(string valor)
        {
            if (String.IsNullOrEmpty(valor))
                return 0;
            try
            {
                if (valor.Contains(",") && valor.Contains("."))
                {
                    if (valor.IndexOf(',') > valor.IndexOf('.'))
                        valor = valor.Replace(".", "");
                    else
                        valor = valor.Replace(",", "").Replace(".", ",");
                }
                else if (valor.Contains("."))
                {
                    valor = valor.Replace(".", ",");
                }

                if (valor.Contains("-"))
                {

                    valor = Funcoes.RemoverLetrasePontos(valor);
                    valor = "-" + valor;
                }
                else
                    valor = Funcoes.RemoverLetrasePontos(valor);

                //valor = valor.Replace(",", ".");
                return decimal.Parse(valor);
            }
            catch
            {
                return -999;
            }
        }
        /// <summary>
        /// Converte um valor string em decimal, tratando os erros
        /// </summary>
        /// <param name="valor"></param>
        /// <returns></returns>
        public static double ToDouble(string valor)
        {
            if (String.IsNullOrEmpty(valor))
                return 0;
            try
            {
                if (valor.Contains(",") && valor.Contains("."))
                {
                    if (valor.IndexOf(',') > valor.IndexOf('.'))
                        valor = valor.Replace(".", "");
                    else
                        valor = valor.Replace(",", "").Replace(".", ",");
                }
                else if (valor.Contains("."))
                {
                    valor = valor.Replace(".", ",");
                }

                if (valor.Contains("-"))
                {
                    valor = Funcoes.RemoverLetrasePontos(valor);
                    valor = "-" + valor;
                }
                else
                    valor = Funcoes.RemoverLetrasePontos(valor);

                //valor = valor.Replace(",", ".");
                return double.Parse(valor);
            }
            catch
            {
                return -999;
            }
        }

        /// <summary>
        /// Captalize uma string
        /// </summary>
        /// <param name="texto">exemplo de texto</param>
        /// <returns>Exemplo De Texto</returns>
        public static string ToTitleCase(string texto)
        {
            string result = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(texto);
            return result;
        }

        /// <summary>
        /// Traduz um boolean em string PT-BR
        /// </summary>
        /// <param name="s">True / False</param>
        /// <returns>"Sim" / "Não"</returns>
        public static string TraduzirBoolean(bool s)
        {
            return s ? "Sim" : "Não";
        }

        /// <summary>
        /// Retorna a data do ultimo domingo a partir da data de hoje
        /// </summary>
        /// <returns></returns>
        public static DateTime UltimoDomingo()
        {
            return UltimoDomingo(DateTime.Now);
        }

        /// <summary>
        /// retorna a data do ultimo domingo a partir de um datetime informado
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static DateTime UltimoDomingo(DateTime dt)
        {
            DateTime d = dt;
            int offset = d.DayOfWeek - DayOfWeek.Sunday;
            return (d.AddDays(-offset));
        }

        /// <summary>
        /// Retorna a data da ultima segunda feira, à partir da data de hoje
        /// </summary>
        /// <returns></returns>
        public static DateTime UltimaSegunda()
        {
            return UltimaSegunda(DateTime.Now);
        }

        /// <summary>
        /// retorna a data da ultima segunda feira, a partir de um datetime informado
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static DateTime UltimaSegunda(DateTime dt)
        {
            DateTime d = dt;
            int offset = d.DayOfWeek - DayOfWeek.Monday;
            return (d.AddDays(-offset));
        }

        /// <summary>
        /// Valida endereço email (ABC@ABC.ABC)
        /// </summary>
        /// <param name="email">String email</param>
        /// <returns>bool true = Endereço email Válido</returns>
        public static bool ValidarEmail(string email)
        {
            if (String.IsNullOrEmpty(email))
                return true;

            bool validEmail = false;
            int indexArr = email.IndexOf('@');
            if (indexArr > 0)
            {
                int indexDot = email.IndexOf('.', indexArr);
                if (indexDot - 1 > indexArr)
                {
                    if (indexDot + 1 < email.Length)
                    {
                        string indexDot2 = email.Substring(indexDot + 1, 1);
                        if (indexDot2 != ".")
                        {
                            validEmail = true;
                        }
                    }
                }
            }
            return validEmail;
        }

        /// <summary>
        /// Validar Placa de um Veículo
        /// </summary>
        /// <param name="value">string placa Ex: ABC-1234 ou ABC1234</param>
        /// <returns>bool true = Placa Válida</returns>
        public static bool ValidarPlaca(string value)
        {
            if (String.IsNullOrEmpty(value))
                return true;

            value = value.Replace("-", "");
            System.Text.RegularExpressions.Regex regex = new System.Text.RegularExpressions.Regex(@"^[a-zA-Z]{3}\d{4}$");

            if (regex.IsMatch(value))
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Validar uma URL / Site
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public static bool ValidarUrl(string url)
        {
            if (String.IsNullOrEmpty(url))
                return true;
            else
            {
                if (url.ToLower().Contains("http"))
                {
                    System.Text.RegularExpressions.Regex obj = new System.Text.RegularExpressions.Regex(@"(http|https)://([\w-]+\.)+[\w-]+(/[\w- ./?%&=]*)?", System.Text.RegularExpressions.RegexOptions.Singleline | System.Text.RegularExpressions.RegexOptions.Compiled);
                    return obj.IsMatch(url);
                }
                else
                {
                    System.Text.RegularExpressions.Regex obj = new System.Text.RegularExpressions.Regex(@"([\w-]+\.)+[\w-]+(/[\w- ./?%&=]*)?", System.Text.RegularExpressions.RegexOptions.Singleline | System.Text.RegularExpressions.RegexOptions.Compiled);
                    return obj.IsMatch(url);
                }
            }

        }
        /// <summary>
        /// Tenta abrir o arquivo em modo escrita / leitura sem compartilhamento, se ocorrer erro retorna true
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static bool VerificaAberto(string path)
        {
            FileStream stream = null;
            bool isOpen = false;
            try
            {
                stream = File.Open(path, FileMode.Open, FileAccess.ReadWrite, FileShare.None);
            }
            catch (IOException)
            {
                isOpen = true;
                //Show your prompt here.
            }
            finally
            {
                if (stream != null)
                    stream.Close();
            }

            return isOpen;
        }

        /// <summary>
        /// Retorna o número da semana no mês
        /// </summary>
        /// <param name="TargetDate"></param>
        /// <returns></returns>
        public static int WeekNumber(DateTime TargetDate)
        {
            return (TargetDate.Day - 1) / 7 + 1;
        }


        public static string XmlFromDs(DataSet ds)
        {
            return ds.GetXml();
        }

        public static DataSet XmlToDs(string xml)
        {
            DataSet dataSet = new DataSet();
            XmlDocument doc = new XmlDocument();
            Stream stream = new MemoryStream();
            XmlWriter xw = new XmlTextWriter(stream, Encoding.Default);
            doc.WriteContentTo(xw);
            dataSet.ReadXml(stream);
            return dataSet;
        }

        public static byte[] CompressZip(Stream input)
        {
            //var input = ToPng(xinput);

            using (var compressStream = new MemoryStream())
            {
                using (var compressor = new GZipStream(compressStream, CompressionMode.Compress))
                {
                    byte[] data = ReadFully(input);
                    //input.CopyTo(compressor);
                    compressor.Write(data, 0, data.Length);
                    compressor.Close();
                    return compressStream.ToArray();
                }
            }
        }
        public static byte[] CompressZip(byte[] input)
        {
            return CompressZip(ToStream(input));
        }
        public static byte[] DecompressZip(byte[] input)
        {
            return ReadFully(DecompressZipStream(input));
        }
        public static Stream DecompressZipStream(byte[] input)
        {
            var output = new MemoryStream();

            using (var compressStream = new MemoryStream(input))
            using (var decompressor = new GZipStream(compressStream, CompressionMode.Decompress))
            {
                //decompressor.CopyTo(output);
                byte[] data = ReadFully(decompressor);
                output.Write(data, 0, data.Length);
                decompressor.Close();
                output.Position = 0;
                output.Close();
                return output;
            }

        }
        public static byte[] ReadFully(Stream input)
        {
            byte[] buffer = new byte[16 * 1024];
            using (MemoryStream ms = new MemoryStream())
            {
                int read;
                while ((read = input.Read(buffer, 0, buffer.Length)) > 0)
                {
                    ms.Write(buffer, 0, read);
                }
                return ms.ToArray();
            }
        }
        public static Stream ToStream(byte[] input)
        {
            return new MemoryStream(input);
        }
        public static string TitleCase(this string s)
        {
            return Funcoes.ToTitleCase(s.ToLower());
        }

        public static string GetMd5DirFromSite(string dir)
        {
            try
            {
                NameValueCollection nvc;
                nvc = new NameValueCollection();
                nvc.Add("dir", dir);

                ServicePointManager.Expect100Continue = true;
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

                //label1.Visible = true;
                // progressBar1.Visible = true;
                //progressBar1.Enabled = true;
                string r = null;
                using (System.Net.WebClient client = new System.Net.WebClient())
                {
                    string URL = "https://www.rovann.com.br/atualizacao/md5dir2.php";
                    //WebProxy myProxy = new WebProxy();
                    //myProxy.BypassProxyOnLocal = true;
                    //client.Proxy = myProxy;
                    //client.Proxy = WebProxy.GetDefaultProxy();
                    byte[] responseArray = client.UploadValues(URL, nvc);
                    r = new System.Text.ASCIIEncoding().GetString(responseArray);
                }
                return r;
            }
            catch (Exception ex)
            {
                return null;
            }
        }


        /// <summary>
        /// Gera a impressão de um texto
        /// </summary>
        /// <param name="_textoImpressao">string para impressão</param>
        /// <param name="_font">Fonte da impressão</param>
        /// <param name="_impressora">Nome da impressora, informar null ou "" para padrão do windows</param>
        public static void ImprimirString(string _textoImpressao, Font _font, string _impressora)
        {
            string[] linhas = _textoImpressao.Split('\n');
            Queue<string> filaLinhas = new Queue<string>();
            foreach (string l in linhas)
            {
                filaLinhas.Enqueue(l);
            }

            PrintDocument p = new PrintDocument();
            p.PrintPage += delegate(object sender1, PrintPageEventArgs ev)
            {
                Font printFont = _font;
                float linesPerPage = 0;
                float yPos = 0;
                int count = 0;
                float leftMargin = ev.MarginBounds.Left;
                float topMargin = ev.MarginBounds.Top;
                string line = null;

                //Calcular o número de linhas por página
                linesPerPage = ev.MarginBounds.Height /
                   printFont.GetHeight(ev.Graphics);

                // Imprime cada linha do texto
                while (count < linesPerPage && filaLinhas.Count > 0)
                {
                    line = filaLinhas.Dequeue();
                    yPos = topMargin + (count * printFont.GetHeight(ev.Graphics));
                    ev.Graphics.DrawString(line, printFont, Brushes.Black, 0, yPos, new StringFormat());
                    count++;
                }

                // Se existir mais linhas, gera outra página.
                if (line != null && filaLinhas.Count > 0)
                    ev.HasMorePages = true;
                else
                    ev.HasMorePages = false;
            };

            PrintDialog diag = new PrintDialog();
            diag.Document = p;
            diag.PrinterSettings.PrinterName = _impressora;
            if (diag.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                p.Print();
            }
        }

     
    }


    public static class SiCoresSistema
    {
        public static readonly Color corFundoObjetoObrigatorioFoco = Color.White;
        public static readonly Color corFundoObjetoObrigatorioPadrao = Funcoes.ConverteColorFromHex("#FFFAFA");
        public static readonly Color corFundoObjetoFoco = Color.White;
        public static readonly Color corFundoObjetoPadrao = Color.White;
        public static readonly Color corFonteObjetos = Color.Black;// Color.IndianRed;
        public static readonly Color corFonteObjetoPadrao = Color.Black;//Color.IndianRed;
        public static readonly Color corBackErro = Funcoes.ConverteColorFromHex("#BCAC9B"); 
        public static readonly Color corFundoReadOnly = Funcoes.ConverteColorFromHex("#DDC9B4");
        //public static readonly Color corLogoDark = Color.FromArgb(0, 47, 108);
        //public static readonly Color corLogoLight = Color.FromArgb(105, 179, 231);

    }
}

