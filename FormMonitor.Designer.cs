namespace FileZillaManager
{
    partial class FormMonitor
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.checkBoxOcultarPastasVazias = new System.Windows.Forms.CheckBox();
            this.checkBoxSubPastasIndividuais = new System.Windows.Forms.CheckBox();
            this.checkBoxSubPastas = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.buttonRefresh = new System.Windows.Forms.Button();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.ColumnNome = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnLogin = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnLastWrite = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnZipValido = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnMsgIntegridade = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnRechckIntegrity = new System.Windows.Forms.DataGridViewImageColumn();
            this.ColumnArquivo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnOpenFile = new System.Windows.Forms.DataGridViewImageColumn();
            this.ColumnPasta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnAbrirPasta = new System.Windows.Forms.DataGridViewImageColumn();
            this.ColumnCor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnTamanho = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnUltimoProcessamento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnFileHash = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnFileObservacao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.backgroundWorker2 = new System.ComponentModel.BackgroundWorker();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.labelUltimaVerificacao3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabelTamanhoArquivos = new System.Windows.Forms.ToolStripStatusLabel();
            this.timerRefresh = new System.Windows.Forms.Timer(this.components);
            this.dataGridViewImageColumn1 = new System.Windows.Forms.DataGridViewImageColumn();
            this.dataGridViewImageColumn2 = new System.Windows.Forms.DataGridViewImageColumn();
            this.panel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.buttonRefresh);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 74);
            this.panel1.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.checkBoxOcultarPastasVazias);
            this.groupBox2.Controls.Add(this.checkBoxSubPastasIndividuais);
            this.groupBox2.Controls.Add(this.checkBoxSubPastas);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox2.Location = new System.Drawing.Point(379, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(269, 74);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Opções";
            // 
            // checkBoxOcultarPastasVazias
            // 
            this.checkBoxOcultarPastasVazias.AutoSize = true;
            this.checkBoxOcultarPastasVazias.Dock = System.Windows.Forms.DockStyle.Top;
            this.checkBoxOcultarPastasVazias.Location = new System.Drawing.Point(3, 51);
            this.checkBoxOcultarPastasVazias.Name = "checkBoxOcultarPastasVazias";
            this.checkBoxOcultarPastasVazias.Size = new System.Drawing.Size(263, 17);
            this.checkBoxOcultarPastasVazias.TabIndex = 2;
            this.checkBoxOcultarPastasVazias.Text = "Ocultar Pastas Vazias";
            this.checkBoxOcultarPastasVazias.UseVisualStyleBackColor = true;
            this.checkBoxOcultarPastasVazias.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // checkBoxSubPastasIndividuais
            // 
            this.checkBoxSubPastasIndividuais.AutoSize = true;
            this.checkBoxSubPastasIndividuais.Dock = System.Windows.Forms.DockStyle.Top;
            this.checkBoxSubPastasIndividuais.Location = new System.Drawing.Point(3, 34);
            this.checkBoxSubPastasIndividuais.Name = "checkBoxSubPastasIndividuais";
            this.checkBoxSubPastasIndividuais.Size = new System.Drawing.Size(263, 17);
            this.checkBoxSubPastasIndividuais.TabIndex = 1;
            this.checkBoxSubPastasIndividuais.Text = "Monitorar SubPastas Individualmente";
            this.checkBoxSubPastasIndividuais.UseVisualStyleBackColor = true;
            this.checkBoxSubPastasIndividuais.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // checkBoxSubPastas
            // 
            this.checkBoxSubPastas.AutoSize = true;
            this.checkBoxSubPastas.Dock = System.Windows.Forms.DockStyle.Top;
            this.checkBoxSubPastas.Location = new System.Drawing.Point(3, 17);
            this.checkBoxSubPastas.Name = "checkBoxSubPastas";
            this.checkBoxSubPastas.Size = new System.Drawing.Size(263, 17);
            this.checkBoxSubPastas.TabIndex = 0;
            this.checkBoxSubPastas.Text = "Monitorar SubPastas";
            this.checkBoxSubPastas.UseVisualStyleBackColor = true;
            this.checkBoxSubPastas.CheckedChanged += new System.EventHandler(this.checkBoxSubPastas_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(379, 74);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filtrar";
            this.groupBox1.Visible = false;
            // 
            // buttonRefresh
            // 
            this.buttonRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonRefresh.ForeColor = System.Drawing.Color.IndianRed;
            this.buttonRefresh.Location = new System.Drawing.Point(671, 16);
            this.buttonRefresh.Name = "buttonRefresh";
            this.buttonRefresh.Size = new System.Drawing.Size(117, 35);
            this.buttonRefresh.TabIndex = 2;
            this.buttonRefresh.Text = "Atualizar";
            this.buttonRefresh.UseVisualStyleBackColor = true;
            this.buttonRefresh.Visible = false;
            this.buttonRefresh.Click += new System.EventHandler(this.buttonRefresh_Click);
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerReportsProgress = true;
            this.backgroundWorker1.WorkerSupportsCancellation = true;
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowUserToAddRows = false;
            this.dataGridView2.AllowUserToDeleteRows = false;
            this.dataGridView2.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(244)))), ((int)(((byte)(244)))));
            this.dataGridView2.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView2.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnNome,
            this.ColumnLogin,
            this.ColumnStatus,
            this.ColumnLastWrite,
            this.ColumnZipValido,
            this.ColumnMsgIntegridade,
            this.ColumnRechckIntegrity,
            this.ColumnArquivo,
            this.ColumnOpenFile,
            this.ColumnPasta,
            this.ColumnAbrirPasta,
            this.ColumnCor,
            this.ColumnTamanho,
            this.ColumnUltimoProcessamento,
            this.ColumnFileHash,
            this.ColumnFileObservacao});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Roboto", 8.25F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.MistyRose;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView2.DefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridView2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView2.Location = new System.Drawing.Point(0, 74);
            this.dataGridView2.MultiSelect = false;
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.ReadOnly = true;
            this.dataGridView2.RowHeadersVisible = false;
            this.dataGridView2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView2.Size = new System.Drawing.Size(800, 354);
            this.dataGridView2.TabIndex = 4;
            this.dataGridView2.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView2_CellContentDoubleClick);
            this.dataGridView2.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dataGridView2_CellPainting);
            this.dataGridView2.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView2_ColumnHeaderMouseClick);
            this.dataGridView2.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dataGridView2_DataBindingComplete);
            this.dataGridView2.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dataGridView2_DataError);
            // 
            // ColumnNome
            // 
            this.ColumnNome.DataPropertyName = "Nome";
            this.ColumnNome.HeaderText = "Nome";
            this.ColumnNome.MinimumWidth = 80;
            this.ColumnNome.Name = "ColumnNome";
            this.ColumnNome.ReadOnly = true;
            this.ColumnNome.Width = 80;
            // 
            // ColumnLogin
            // 
            this.ColumnLogin.DataPropertyName = "Login";
            this.ColumnLogin.HeaderText = "Login";
            this.ColumnLogin.MinimumWidth = 80;
            this.ColumnLogin.Name = "ColumnLogin";
            this.ColumnLogin.ReadOnly = true;
            this.ColumnLogin.Width = 80;
            // 
            // ColumnStatus
            // 
            this.ColumnStatus.DataPropertyName = "Status";
            this.ColumnStatus.HeaderText = "Status";
            this.ColumnStatus.MinimumWidth = 150;
            this.ColumnStatus.Name = "ColumnStatus";
            this.ColumnStatus.ReadOnly = true;
            this.ColumnStatus.Width = 150;
            // 
            // ColumnLastWrite
            // 
            this.ColumnLastWrite.DataPropertyName = "LastWrite";
            this.ColumnLastWrite.HeaderText = "Data do Arquivo";
            this.ColumnLastWrite.MinimumWidth = 110;
            this.ColumnLastWrite.Name = "ColumnLastWrite";
            this.ColumnLastWrite.ReadOnly = true;
            this.ColumnLastWrite.Width = 110;
            // 
            // ColumnZipValido
            // 
            this.ColumnZipValido.DataPropertyName = "ZipValido";
            this.ColumnZipValido.HeaderText = "Integridade Zip";
            this.ColumnZipValido.Name = "ColumnZipValido";
            this.ColumnZipValido.ReadOnly = true;
            this.ColumnZipValido.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColumnZipValido.Visible = false;
            this.ColumnZipValido.Width = 107;
            // 
            // ColumnMsgIntegridade
            // 
            this.ColumnMsgIntegridade.DataPropertyName = "MsgZipValido";
            this.ColumnMsgIntegridade.HeaderText = "Integridade";
            this.ColumnMsgIntegridade.Name = "ColumnMsgIntegridade";
            this.ColumnMsgIntegridade.ReadOnly = true;
            this.ColumnMsgIntegridade.Width = 88;
            // 
            // ColumnRechckIntegrity
            // 
            this.ColumnRechckIntegrity.HeaderText = "";
            this.ColumnRechckIntegrity.Image = global::FileZillaManager.Properties.Resources.edit_undo;
            this.ColumnRechckIntegrity.MinimumWidth = 18;
            this.ColumnRechckIntegrity.Name = "ColumnRechckIntegrity";
            this.ColumnRechckIntegrity.ReadOnly = true;
            this.ColumnRechckIntegrity.Width = 18;
            // 
            // ColumnArquivo
            // 
            this.ColumnArquivo.DataPropertyName = "Arquivo";
            this.ColumnArquivo.HeaderText = "Arquivo";
            this.ColumnArquivo.Name = "ColumnArquivo";
            this.ColumnArquivo.ReadOnly = true;
            this.ColumnArquivo.Width = 69;
            // 
            // ColumnOpenFile
            // 
            this.ColumnOpenFile.HeaderText = "";
            this.ColumnOpenFile.Image = global::FileZillaManager.Properties.Resources.quickopen_file;
            this.ColumnOpenFile.MinimumWidth = 18;
            this.ColumnOpenFile.Name = "ColumnOpenFile";
            this.ColumnOpenFile.ReadOnly = true;
            this.ColumnOpenFile.Width = 18;
            // 
            // ColumnPasta
            // 
            this.ColumnPasta.DataPropertyName = "Pasta";
            this.ColumnPasta.HeaderText = "Pasta";
            this.ColumnPasta.MinimumWidth = 80;
            this.ColumnPasta.Name = "ColumnPasta";
            this.ColumnPasta.ReadOnly = true;
            this.ColumnPasta.Width = 80;
            // 
            // ColumnAbrirPasta
            // 
            this.ColumnAbrirPasta.HeaderText = "";
            this.ColumnAbrirPasta.Image = global::FileZillaManager.Properties.Resources.folder_red;
            this.ColumnAbrirPasta.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.ColumnAbrirPasta.MinimumWidth = 18;
            this.ColumnAbrirPasta.Name = "ColumnAbrirPasta";
            this.ColumnAbrirPasta.ReadOnly = true;
            this.ColumnAbrirPasta.Width = 18;
            // 
            // ColumnCor
            // 
            this.ColumnCor.DataPropertyName = "Cor";
            this.ColumnCor.HeaderText = "Cor";
            this.ColumnCor.Name = "ColumnCor";
            this.ColumnCor.ReadOnly = true;
            this.ColumnCor.Visible = false;
            this.ColumnCor.Width = 49;
            // 
            // ColumnTamanho
            // 
            this.ColumnTamanho.DataPropertyName = "TamanhoF";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.ColumnTamanho.DefaultCellStyle = dataGridViewCellStyle2;
            this.ColumnTamanho.HeaderText = "Tamanho";
            this.ColumnTamanho.MinimumWidth = 50;
            this.ColumnTamanho.Name = "ColumnTamanho";
            this.ColumnTamanho.ReadOnly = true;
            this.ColumnTamanho.Width = 78;
            // 
            // ColumnUltimoProcessamento
            // 
            this.ColumnUltimoProcessamento.DataPropertyName = "UltimoProcessamento";
            dataGridViewCellStyle3.Format = "G";
            dataGridViewCellStyle3.NullValue = null;
            this.ColumnUltimoProcessamento.DefaultCellStyle = dataGridViewCellStyle3;
            this.ColumnUltimoProcessamento.HeaderText = "Último Processamento";
            this.ColumnUltimoProcessamento.Name = "ColumnUltimoProcessamento";
            this.ColumnUltimoProcessamento.ReadOnly = true;
            this.ColumnUltimoProcessamento.Visible = false;
            this.ColumnUltimoProcessamento.Width = 134;
            // 
            // ColumnFileHash
            // 
            this.ColumnFileHash.DataPropertyName = "HashFile";
            this.ColumnFileHash.HeaderText = "Hash";
            this.ColumnFileHash.Name = "ColumnFileHash";
            this.ColumnFileHash.ReadOnly = true;
            // 
            // ColumnFileObservacao
            // 
            this.ColumnFileObservacao.DataPropertyName = "Observacao";
            this.ColumnFileObservacao.HeaderText = "Observação";
            this.ColumnFileObservacao.Name = "ColumnFileObservacao";
            this.ColumnFileObservacao.ReadOnly = true;
            // 
            // backgroundWorker2
            // 
            this.backgroundWorker2.WorkerReportsProgress = true;
            this.backgroundWorker2.WorkerSupportsCancellation = true;
            this.backgroundWorker2.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker2_DoWork);
            this.backgroundWorker2.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker2_ProgressChanged);
            // 
            // statusStrip1
            // 
            this.statusStrip1.BackColor = System.Drawing.SystemColors.Control;
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripStatusLabel2,
            this.labelUltimaVerificacao3,
            this.toolStripStatusLabel3,
            this.toolStripStatusLabelTamanhoArquivos});
            this.statusStrip1.Location = new System.Drawing.Point(0, 428);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(800, 22);
            this.statusStrip1.TabIndex = 5;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(17, 17);
            this.toolStripStatusLabel1.Text = "--";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(134, 17);
            this.toolStripStatusLabel2.Text = "    /    Última Verificação:";
            // 
            // labelUltimaVerificacao3
            // 
            this.labelUltimaVerificacao3.Name = "labelUltimaVerificacao3";
            this.labelUltimaVerificacao3.Size = new System.Drawing.Size(20, 17);
            this.labelUltimaVerificacao3.Text = "-:-";
            // 
            // toolStripStatusLabel3
            // 
            this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            this.toolStripStatusLabel3.Size = new System.Drawing.Size(148, 17);
            this.toolStripStatusLabel3.Text = "  /  Tamanho dos Arquivos:";
            // 
            // toolStripStatusLabelTamanhoArquivos
            // 
            this.toolStripStatusLabelTamanhoArquivos.Name = "toolStripStatusLabelTamanhoArquivos";
            this.toolStripStatusLabelTamanhoArquivos.Size = new System.Drawing.Size(32, 17);
            this.toolStripStatusLabelTamanhoArquivos.Text = "--GB";
            // 
            // timerRefresh
            // 
            this.timerRefresh.Interval = 300;
            this.timerRefresh.Tick += new System.EventHandler(this.timerRefresh_Tick);
            // 
            // dataGridViewImageColumn1
            // 
            this.dataGridViewImageColumn1.HeaderText = "";
            this.dataGridViewImageColumn1.Image = global::FileZillaManager.Properties.Resources.folder_red;
            this.dataGridViewImageColumn1.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.dataGridViewImageColumn1.Name = "dataGridViewImageColumn1";
            this.dataGridViewImageColumn1.Width = 5;
            // 
            // dataGridViewImageColumn2
            // 
            this.dataGridViewImageColumn2.HeaderText = "";
            this.dataGridViewImageColumn2.Image = global::FileZillaManager.Properties.Resources.folder_red;
            this.dataGridViewImageColumn2.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.dataGridViewImageColumn2.MinimumWidth = 24;
            this.dataGridViewImageColumn2.Name = "dataGridViewImageColumn2";
            this.dataGridViewImageColumn2.Width = 24;
            // 
            // FormMonitor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.panel1);
            this.Name = "FormMonitor";
            this.Text = "Monitor";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMonitor_FormClosing);
            this.Load += new System.EventHandler(this.FormMonitor_Load);
            this.panel1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.CheckBox checkBoxSubPastas;
        private System.Windows.Forms.CheckBox checkBoxSubPastasIndividuais;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Button buttonRefresh;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.ComponentModel.BackgroundWorker backgroundWorker2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn1;
        private System.Windows.Forms.Timer timerRefresh;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripStatusLabel labelUltimaVerificacao3;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn2;
        private System.Windows.Forms.CheckBox checkBoxOcultarPastasVazias;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnNome;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnLogin;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnLastWrite;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnZipValido;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnMsgIntegridade;
        private System.Windows.Forms.DataGridViewImageColumn ColumnRechckIntegrity;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnArquivo;
        private System.Windows.Forms.DataGridViewImageColumn ColumnOpenFile;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnPasta;
        private System.Windows.Forms.DataGridViewImageColumn ColumnAbrirPasta;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnCor;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnTamanho;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnUltimoProcessamento;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnFileHash;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnFileObservacao;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelTamanhoArquivos;
    }
}