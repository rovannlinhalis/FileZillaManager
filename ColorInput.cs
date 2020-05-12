using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileZillaManager
{
    public class SiColorInput : TextBox
    {
        public SiColorInput()
        {
            this.SuspendLayout();
            base.Multiline = false;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ResumeLayout(false);
            Enter += SiTextBox_Enter;
            Leave += SiTextBox_Leave;
            MouseDoubleClick += SiColorInput_MouseDoubleClick;
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SiTextBox_KeyDown);
            ReadOnlyChanged += SiTextBox_ReadOnlyChanged;
            VisibleChanged += Control_VisibleChanged;
            ButtonColorDialog.Click += ButtonColorDialog_Click;
            ButtonColorDialog.BackColor = SystemColors.ControlLight;
            ButtonColorDialog.Text = "#";
            ButtonColorDialog.Font = new Font("Consolas", 10f, FontStyle.Bold);
            ButtonColorDialog.ForeColor = Color.Black;
            ButtonColorDialog.FlatStyle = FlatStyle.Flat;
            this.TextChanged += SiColorInput_TextChanged;
            base.MaxLength = 7;
            this.PlaceHolder = "#000000";
        }

        [Browsable(false)]
        public override int MaxLength { get => 7; }
        private void SiColorInput_TextChanged(object sender, EventArgs e)
        {
            SetBackGroundColor();
        }

        private void ButtonColorDialog_Click(object sender, EventArgs e)
        {
            SelectCor();
        }

        private void SiColorInput_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            SelectCor();
        }

        private void SelectCor()
        {
            ColorDialog diag = new ColorDialog();
            diag.Color = this.Cor;
            if (diag.ShowDialog() == DialogResult.OK)
            {
                this.Cor = diag.Color;
            }
        }

        private void Control_VisibleChanged(object sender, EventArgs e)
        {
            LabelCaption.Visible = this.Visible;
            ButtonColorDialog.Visible = this.Visible && !this.ReadOnly;
        }

        public Label LabelCaption { get; set; } = new Label();

        public Color Cor { get => ConverteColorFromHex(this.Text); set => this.Text = ConverteColorToHex(value); }

        public Button ButtonColorDialog { get; set; } = new Button();

        public string Caption { get => LabelCaption.Text; set => LabelCaption.Text = value; }
        public Font FontCaption { get => LabelCaption.Font; set => LabelCaption.Font = value; }

        public string PlaceHolder { get; set; }

        private void SiTextBox_ReadOnlyChanged(object sender, EventArgs e)
        {
            ButtonColorDialog.Visible = !this.ReadOnly && this.Visible;
            SetBackGroundColor();
        }



        #region BackColor
        private Color defaultForeColor = Color.Empty;
        public void SetBackGroundColor()
        {
            if (this.Cor != Color.Empty)
            {
                this.BackColor = this.Cor;
                if (defaultForeColor == Color.Empty)
                    defaultForeColor = this.ForeColor;

                this.ForeColor = GetForeColor(this.BackColor);
            }
            else
            {
                if (defaultForeColor != Color.Empty)
                    this.ForeColor = defaultForeColor;

                if (this.ReadOnly)
                    this.BackColor = SystemColors.Info;
                else
                {
                    if (this.Focused)
                    {
                        this.BackColor = SiCoresSistema.corFundoObjetoFoco;
                    }
                    else
                    {
                        if (this.Obrigatorio)
                            this.BackColor = SiCoresSistema.corFundoObjetoObrigatorioPadrao;
                        else
                            this.BackColor = SiCoresSistema.corFundoObjetoPadrao;
                    }
                }
            }
        }
        private void SiTextBox_Leave(object sender, EventArgs e)
        {
            SetBackGroundColor();
        }
        private void SiTextBox_Enter(object sender, EventArgs e)
        {
            SetBackGroundColor();
        }
        #endregion
        #region Obrigatorio
        bool _obrigatorio = false;
        /// <summary>
        /// Define se o preenchimento do campo é obrigatório
        /// </summary>
        [Browsable(true)]
        public bool Obrigatorio { get { return _obrigatorio; } set { _obrigatorio = value; SetBackGroundColor(); } }
        #endregion
        private string description;
        [Browsable(true)]
        public string Description
        {
            get { return string.IsNullOrWhiteSpace(description) ? this.Name : description; }
            set { description = value; }
        }
        #region CharType
        
        public string SValue { get => this.Text; }

        private void SetCharType()
        {
            //if (this.CharType == SiTextBoxCharType.Moeda || this.CharType == SiTextBoxCharType.Valores || this.CharType == SiTextBoxCharType.SomenteNumeros)
            //{
            //    this.TextAlign = HorizontalAlignment.Right;
            //}
            //else
            //    this.TextAlign = HorizontalAlignment.Left;

        }


        #endregion

        private void InitializeComponent()
        {
            this.SuspendLayout();

            // 
            // SiTextBox
            // 

            this.ResumeLayout(false);

        }
        /// <summary>
        /// Indica se o enter vai ser utilizado como TAB (Ir para o próximo campo)
        /// </summary>
        public bool TabEnter { get; set; } = true;
        private void SiTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && this.TabEnter)
            {
                string tagg = this.Tag == null ? "" : this.Tag.ToString();
                if (!this.Multiline)
                {
                    e.SuppressKeyPress = true;
                    this.FindForm().SelectNextControl(this, !e.Shift, true, true, true);
                }
                else if (e.Control)
                {
                    e.SuppressKeyPress = true;
                    this.FindForm().SelectNextControl(this, !e.Shift, true, true, true);
                }
            }
        }



        public const int WM_PAINT = 0x000F;

        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case WM_PAINT:
                    {
                        Invalidate();
                        base.WndProc(ref m);
                        if (!ContainsFocus && string.IsNullOrEmpty(Text) && !string.IsNullOrEmpty(this.PlaceHolder))
                        {
                            Graphics gr = CreateGraphics();
                            StringFormat format = new StringFormat();
                            format.Alignment = StringAlignment.Near;
                            format.LineAlignment = this.Multiline ? StringAlignment.Near : StringAlignment.Center;
                            gr.DrawString(this.PlaceHolder, Font, new SolidBrush(Color.FromArgb(70, ForeColor)), ClientRectangle, format);
                        }
                        if (!string.IsNullOrEmpty(this.Caption))
                        {
                            this.LabelCaption.Parent = this.Parent;
                            int currentIndexThis = this.Parent.Controls.GetChildIndex(this);
                            int currentIndexLabel = this.Parent.Controls.GetChildIndex(this.LabelCaption);
                            if (currentIndexThis != currentIndexLabel + 1)
                            {
                                this.Parent.Controls.SetChildIndex(this, currentIndexThis + 1);
                                this.Parent.Controls.SetChildIndex(this.LabelCaption, currentIndexThis);
                            }
                            this.LabelCaption.Anchor = this.Anchor;
                            this.LabelCaption.AutoSize = true;
                            this.LabelCaption.Location = new Point(this.Location.X, this.Location.Y - this.LabelCaption.Height);
                            this.LabelCaption.Visible = true;
                            //this.LabelCaption.BringToFront();
                        }
                        else
                            this.LabelCaption.Visible = false;


                        {
                            this.ButtonColorDialog.Parent = this;
                            this.ButtonColorDialog.Size = new Size(this.Height, this.Height);
                            this.ButtonColorDialog.Location = new Point(this.Width - this.Height, 0);

                        }
                    }
                    break;
                default:
                    base.WndProc(ref m);
                    break;
            }
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            if (LabelCaption.InvokeRequired)
            {
                LabelCaption.BeginInvoke((MethodInvoker)delegate
                {
                    if (!LabelCaption.IsDisposed)
                        LabelCaption.Dispose();
                });

            }
            else
            {
                if (!LabelCaption.IsDisposed)
                    LabelCaption.Dispose();
            }


        }

        [Browsable(false)]
        public override bool Multiline { get => false; }

        public string ConverteColorToHex(System.Drawing.Color c)
        {
            string htmlHexColorValueThree = String.Format("#{0:X2}{1:X2}{2:X2}", c.R, c.G, c.B);
            return htmlHexColorValueThree;
            //return ColorTranslator.ToHtml(c);
        }
        public Color ConverteColorFromHex(string hex)
        {
            if (String.IsNullOrEmpty(hex))
            {
                return Color.Empty;
            }
            else
            {
                try
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
                catch
                {
                    return Color.Empty;
                }
            }
        }
        public Color GetForeColor(Color c)
        {
            //float brilho = c.GetBrightness();
            float brilho = ((c.R * 299) + (c.G * 587) + (c.B * 114)) / 1000;

            if (brilho > 84)
                return Color.Black;
            else
                return Color.White;
        }
    }
}
