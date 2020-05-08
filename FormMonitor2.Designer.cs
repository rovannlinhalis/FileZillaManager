namespace FileZillaManager
{
    partial class FormMonitor2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMonitor2));
            this.panel2 = new System.Windows.Forms.Panel();
            this.checkBoxOcultarPastasVazias = new System.Windows.Forms.CheckBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.ColumnContratoNome = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnContratoLogin = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnContratoStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnContratoStatusText = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnContratoFileCheck = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnFileCheckF = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnContratoLastWrite = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnContratoArquivo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnContratoPasta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnContratoTamanho = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnContratoFolderSize = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnContratoFolderSizeColor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnContratoStatusFTP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.timerGetContratos = new System.Windows.Forms.Timer(this.components);
            this.backgroundWorkerProcesso = new System.ComponentModel.BackgroundWorker();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.checkBoxOcultarPastasVazias);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1111, 71);
            this.panel2.TabIndex = 1;
            // 
            // checkBoxOcultarPastasVazias
            // 
            this.checkBoxOcultarPastasVazias.AutoSize = true;
            this.checkBoxOcultarPastasVazias.Location = new System.Drawing.Point(12, 3);
            this.checkBoxOcultarPastasVazias.Name = "checkBoxOcultarPastasVazias";
            this.checkBoxOcultarPastasVazias.Size = new System.Drawing.Size(137, 17);
            this.checkBoxOcultarPastasVazias.TabIndex = 1;
            this.checkBoxOcultarPastasVazias.Text = "Ocultar Pastas Vazias";
            this.checkBoxOcultarPastasVazias.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(244)))), ((int)(((byte)(244)))));
            this.dataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dataGridView1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.IndianRed;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Roboto", 8.25F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Firebrick;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.ColumnHeadersHeight = 32;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnContratoNome,
            this.ColumnContratoLogin,
            this.ColumnContratoStatus,
            this.ColumnContratoStatusText,
            this.ColumnContratoFileCheck,
            this.ColumnFileCheckF,
            this.ColumnContratoLastWrite,
            this.ColumnContratoArquivo,
            this.ColumnContratoPasta,
            this.ColumnContratoTamanho,
            this.ColumnContratoFolderSize,
            this.ColumnContratoFolderSizeColor,
            this.ColumnContratoStatusFTP});
            this.dataGridView1.DataSource = this.bindingSource1;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Roboto", 8.25F);
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.Salmon;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle7;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.EnableHeadersVisualStyles = false;
            this.dataGridView1.GridColor = System.Drawing.Color.Gainsboro;
            this.dataGridView1.Location = new System.Drawing.Point(0, 71);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowTemplate.Height = 32;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(1111, 477);
            this.dataGridView1.TabIndex = 2;
            this.dataGridView1.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentDoubleClick);
            this.dataGridView1.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dataGridView1_CellPainting);
            this.dataGridView1.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dataGridView1_DataError);
            // 
            // ColumnContratoNome
            // 
            this.ColumnContratoNome.DataPropertyName = "Nome";
            dataGridViewCellStyle3.Format = "G";
            dataGridViewCellStyle3.NullValue = null;
            this.ColumnContratoNome.DefaultCellStyle = dataGridViewCellStyle3;
            this.ColumnContratoNome.HeaderText = "Nome";
            this.ColumnContratoNome.Name = "ColumnContratoNome";
            this.ColumnContratoNome.ReadOnly = true;
            this.ColumnContratoNome.Width = 200;
            // 
            // ColumnContratoLogin
            // 
            this.ColumnContratoLogin.DataPropertyName = "Login";
            this.ColumnContratoLogin.HeaderText = "Login";
            this.ColumnContratoLogin.Name = "ColumnContratoLogin";
            this.ColumnContratoLogin.ReadOnly = true;
            this.ColumnContratoLogin.Width = 180;
            // 
            // ColumnContratoStatus
            // 
            this.ColumnContratoStatus.DataPropertyName = "Status";
            this.ColumnContratoStatus.HeaderText = "Status";
            this.ColumnContratoStatus.Name = "ColumnContratoStatus";
            this.ColumnContratoStatus.ReadOnly = true;
            this.ColumnContratoStatus.Visible = false;
            // 
            // ColumnContratoStatusText
            // 
            this.ColumnContratoStatusText.DataPropertyName = "StatusF";
            this.ColumnContratoStatusText.HeaderText = "Status";
            this.ColumnContratoStatusText.Name = "ColumnContratoStatusText";
            this.ColumnContratoStatusText.ReadOnly = true;
            // 
            // ColumnContratoFileCheck
            // 
            this.ColumnContratoFileCheck.DataPropertyName = "Integridade";
            this.ColumnContratoFileCheck.HeaderText = "Integridade";
            this.ColumnContratoFileCheck.Name = "ColumnContratoFileCheck";
            this.ColumnContratoFileCheck.ReadOnly = true;
            this.ColumnContratoFileCheck.Visible = false;
            // 
            // ColumnFileCheckF
            // 
            this.ColumnFileCheckF.DataPropertyName = "IntegridadeF";
            this.ColumnFileCheckF.HeaderText = "Integridade";
            this.ColumnFileCheckF.Name = "ColumnFileCheckF";
            this.ColumnFileCheckF.ReadOnly = true;
            // 
            // ColumnContratoLastWrite
            // 
            this.ColumnContratoLastWrite.DataPropertyName = "LastWrite";
            dataGridViewCellStyle4.Format = "G";
            dataGridViewCellStyle4.NullValue = null;
            this.ColumnContratoLastWrite.DefaultCellStyle = dataGridViewCellStyle4;
            this.ColumnContratoLastWrite.HeaderText = "Data do Arquivo";
            this.ColumnContratoLastWrite.Name = "ColumnContratoLastWrite";
            this.ColumnContratoLastWrite.ReadOnly = true;
            this.ColumnContratoLastWrite.Width = 110;
            // 
            // ColumnContratoArquivo
            // 
            this.ColumnContratoArquivo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ColumnContratoArquivo.DataPropertyName = "Arquivo";
            this.ColumnContratoArquivo.HeaderText = "Arquivo";
            this.ColumnContratoArquivo.Name = "ColumnContratoArquivo";
            this.ColumnContratoArquivo.ReadOnly = true;
            this.ColumnContratoArquivo.Width = 67;
            // 
            // ColumnContratoPasta
            // 
            this.ColumnContratoPasta.DataPropertyName = "Pasta";
            this.ColumnContratoPasta.HeaderText = "Pasta";
            this.ColumnContratoPasta.Name = "ColumnContratoPasta";
            this.ColumnContratoPasta.ReadOnly = true;
            this.ColumnContratoPasta.Width = 200;
            // 
            // ColumnContratoTamanho
            // 
            this.ColumnContratoTamanho.DataPropertyName = "TamanhoF";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.ColumnContratoTamanho.DefaultCellStyle = dataGridViewCellStyle5;
            this.ColumnContratoTamanho.HeaderText = "Tamanho";
            this.ColumnContratoTamanho.Name = "ColumnContratoTamanho";
            this.ColumnContratoTamanho.ReadOnly = true;
            // 
            // ColumnContratoFolderSize
            // 
            this.ColumnContratoFolderSize.DataPropertyName = "FolderSizeF";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.ColumnContratoFolderSize.DefaultCellStyle = dataGridViewCellStyle6;
            this.ColumnContratoFolderSize.HeaderText = "Armazenamento";
            this.ColumnContratoFolderSize.Name = "ColumnContratoFolderSize";
            this.ColumnContratoFolderSize.ReadOnly = true;
            // 
            // ColumnContratoFolderSizeColor
            // 
            this.ColumnContratoFolderSizeColor.DataPropertyName = "FolderSizeColor";
            this.ColumnContratoFolderSizeColor.HeaderText = "Column1";
            this.ColumnContratoFolderSizeColor.Name = "ColumnContratoFolderSizeColor";
            this.ColumnContratoFolderSizeColor.ReadOnly = true;
            this.ColumnContratoFolderSizeColor.Visible = false;
            // 
            // ColumnContratoStatusFTP
            // 
            this.ColumnContratoStatusFTP.DataPropertyName = "FtpState";
            this.ColumnContratoStatusFTP.HeaderText = "FTP";
            this.ColumnContratoStatusFTP.Name = "ColumnContratoStatusFTP";
            this.ColumnContratoStatusFTP.ReadOnly = true;
            // 
            // bindingSource1
            // 
            this.bindingSource1.AllowNew = false;
            this.bindingSource1.Filter = "Visible=True";
            // 
            // timerGetContratos
            // 
            this.timerGetContratos.Tick += new System.EventHandler(this.timerGetContratos_Tick);
            // 
            // backgroundWorkerProcesso
            // 
            this.backgroundWorkerProcesso.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerProcesso_DoWork);
            // 
            // FormMonitor2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1111, 548);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.panel2);
            this.Font = new System.Drawing.Font("Roboto", 8.25F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormMonitor2";
            this.Text = "Monitor";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMonitor2_FormClosing);
            this.Load += new System.EventHandler(this.FormMonitor2_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.CheckBox checkBoxOcultarPastasVazias;
        private System.Windows.Forms.Timer timerGetContratos;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnContratoNome;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnContratoLogin;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnContratoStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnContratoStatusText;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnContratoFileCheck;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnFileCheckF;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnContratoLastWrite;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnContratoArquivo;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnContratoPasta;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnContratoTamanho;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnContratoFolderSize;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnContratoFolderSizeColor;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnContratoStatusFTP;
        private System.ComponentModel.BackgroundWorker backgroundWorkerProcesso;
    }
}