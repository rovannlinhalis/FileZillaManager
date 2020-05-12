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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.checkBoxOcultarPastasVazias = new System.Windows.Forms.CheckBox();
            this.checkBoxSubPastas = new System.Windows.Forms.CheckBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.labelConexoes = new System.Windows.Forms.Label();
            this.labelStatusServer = new System.Windows.Forms.Label();
            this.checkBoxSubPastasIndividuais = new System.Windows.Forms.CheckBox();
            this.buttonRefresh = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dateTimePickerDataRef = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
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
            this.ColumnFolderSize = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnArmazenamentoColor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.backgroundWorker2 = new System.ComponentModel.BackgroundWorker();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.labelUltimaVerificacao3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabelTamanhoArquivos = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel4 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabelTotalArmazenamento = new System.Windows.Forms.ToolStripStatusLabel();
            this.timerRefresh = new System.Windows.Forms.Timer(this.components);
            this.dataGridViewImageColumn1 = new System.Windows.Forms.DataGridViewImageColumn();
            this.dataGridViewImageColumn2 = new System.Windows.Forms.DataGridViewImageColumn();
            this.timerServer = new System.Windows.Forms.Timer(this.components);
            this.timerVisibleRows = new System.Windows.Forms.Timer(this.components);
            this.panel1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.checkBoxOcultarPastasVazias);
            this.panel1.Controls.Add(this.checkBoxSubPastas);
            this.panel1.Controls.Add(this.groupBox3);
            this.panel1.Controls.Add(this.checkBoxSubPastasIndividuais);
            this.panel1.Controls.Add(this.buttonRefresh);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(859, 74);
            this.panel1.TabIndex = 0;
            // 
            // checkBoxOcultarPastasVazias
            // 
            this.checkBoxOcultarPastasVazias.AutoSize = true;
            this.checkBoxOcultarPastasVazias.Location = new System.Drawing.Point(335, 10);
            this.checkBoxOcultarPastasVazias.Margin = new System.Windows.Forms.Padding(1);
            this.checkBoxOcultarPastasVazias.Name = "checkBoxOcultarPastasVazias";
            this.checkBoxOcultarPastasVazias.Size = new System.Drawing.Size(137, 17);
            this.checkBoxOcultarPastasVazias.TabIndex = 2;
            this.checkBoxOcultarPastasVazias.Text = "Ocultar Pastas Vazias";
            this.checkBoxOcultarPastasVazias.UseVisualStyleBackColor = true;
            this.checkBoxOcultarPastasVazias.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // checkBoxSubPastas
            // 
            this.checkBoxSubPastas.AutoSize = true;
            this.checkBoxSubPastas.Location = new System.Drawing.Point(335, 29);
            this.checkBoxSubPastas.Margin = new System.Windows.Forms.Padding(1);
            this.checkBoxSubPastas.Name = "checkBoxSubPastas";
            this.checkBoxSubPastas.Size = new System.Drawing.Size(132, 17);
            this.checkBoxSubPastas.TabIndex = 0;
            this.checkBoxSubPastas.Text = "Monitorar SubPastas";
            this.checkBoxSubPastas.UseVisualStyleBackColor = true;
            this.checkBoxSubPastas.CheckedChanged += new System.EventHandler(this.checkBoxSubPastas_CheckedChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.labelConexoes);
            this.groupBox3.Controls.Add(this.labelStatusServer);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox3.Location = new System.Drawing.Point(0, 0);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(214, 74);
            this.groupBox3.TabIndex = 5;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Servidor";
            // 
            // labelConexoes
            // 
            this.labelConexoes.AutoSize = true;
            this.labelConexoes.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelConexoes.Location = new System.Drawing.Point(3, 40);
            this.labelConexoes.Name = "labelConexoes";
            this.labelConexoes.Size = new System.Drawing.Size(13, 13);
            this.labelConexoes.TabIndex = 1;
            this.labelConexoes.Text = "--";
            // 
            // labelStatusServer
            // 
            this.labelStatusServer.AutoSize = true;
            this.labelStatusServer.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelStatusServer.Font = new System.Drawing.Font("Roboto", 14.25F);
            this.labelStatusServer.Location = new System.Drawing.Point(3, 17);
            this.labelStatusServer.Name = "labelStatusServer";
            this.labelStatusServer.Size = new System.Drawing.Size(20, 23);
            this.labelStatusServer.TabIndex = 0;
            this.labelStatusServer.Text = "--";
            this.labelStatusServer.DoubleClick += new System.EventHandler(this.labelStatusServer_DoubleClick);
            // 
            // checkBoxSubPastasIndividuais
            // 
            this.checkBoxSubPastasIndividuais.AutoSize = true;
            this.checkBoxSubPastasIndividuais.Location = new System.Drawing.Point(335, 48);
            this.checkBoxSubPastasIndividuais.Margin = new System.Windows.Forms.Padding(1);
            this.checkBoxSubPastasIndividuais.Name = "checkBoxSubPastasIndividuais";
            this.checkBoxSubPastasIndividuais.Size = new System.Drawing.Size(214, 17);
            this.checkBoxSubPastasIndividuais.TabIndex = 1;
            this.checkBoxSubPastasIndividuais.Text = "Monitorar SubPastas Individualmente";
            this.checkBoxSubPastasIndividuais.UseVisualStyleBackColor = true;
            this.checkBoxSubPastasIndividuais.CheckedChanged += new System.EventHandler(this.checkBoxSubPastas_CheckedChanged);
            // 
            // buttonRefresh
            // 
            this.buttonRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonRefresh.ForeColor = System.Drawing.Color.IndianRed;
            this.buttonRefresh.Location = new System.Drawing.Point(730, 16);
            this.buttonRefresh.Name = "buttonRefresh";
            this.buttonRefresh.Size = new System.Drawing.Size(117, 35);
            this.buttonRefresh.TabIndex = 2;
            this.buttonRefresh.Text = "Atualizar";
            this.buttonRefresh.UseVisualStyleBackColor = true;
            this.buttonRefresh.Visible = false;
            this.buttonRefresh.Click += new System.EventHandler(this.buttonRefresh_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dateTimePickerDataRef);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Location = new System.Drawing.Point(220, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(111, 36);
            this.panel2.TabIndex = 3;
            // 
            // dateTimePickerDataRef
            // 
            this.dateTimePickerDataRef.Checked = false;
            this.dateTimePickerDataRef.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dateTimePickerDataRef.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePickerDataRef.Location = new System.Drawing.Point(0, 13);
            this.dateTimePickerDataRef.Name = "dateTimePickerDataRef";
            this.dateTimePickerDataRef.ShowCheckBox = true;
            this.dateTimePickerDataRef.Size = new System.Drawing.Size(111, 21);
            this.dateTimePickerDataRef.TabIndex = 1;
            this.dateTimePickerDataRef.ValueChanged += new System.EventHandler(this.checkBoxSubPastas_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Data Ref.";
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
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(244)))), ((int)(((byte)(244)))));
            this.dataGridView2.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView2.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView2.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dataGridView2.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.IndianRed;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Roboto", 8.25F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView2.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView2.ColumnHeadersHeight = 32;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
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
            this.ColumnFileObservacao,
            this.ColumnFolderSize,
            this.ColumnArmazenamentoColor});
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Roboto", 8.25F);
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.MistyRose;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView2.DefaultCellStyle = dataGridViewCellStyle6;
            this.dataGridView2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView2.EnableHeadersVisualStyles = false;
            this.dataGridView2.GridColor = System.Drawing.SystemColors.ControlLight;
            this.dataGridView2.Location = new System.Drawing.Point(0, 74);
            this.dataGridView2.MultiSelect = false;
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.ReadOnly = true;
            this.dataGridView2.RowHeadersVisible = false;
            this.dataGridView2.RowTemplate.Height = 32;
            this.dataGridView2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView2.Size = new System.Drawing.Size(859, 354);
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
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.ColumnTamanho.DefaultCellStyle = dataGridViewCellStyle3;
            this.ColumnTamanho.HeaderText = "Tamanho";
            this.ColumnTamanho.MinimumWidth = 50;
            this.ColumnTamanho.Name = "ColumnTamanho";
            this.ColumnTamanho.ReadOnly = true;
            this.ColumnTamanho.Width = 78;
            // 
            // ColumnUltimoProcessamento
            // 
            this.ColumnUltimoProcessamento.DataPropertyName = "UltimoProcessamento";
            dataGridViewCellStyle4.Format = "G";
            dataGridViewCellStyle4.NullValue = null;
            this.ColumnUltimoProcessamento.DefaultCellStyle = dataGridViewCellStyle4;
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
            this.ColumnFileHash.Visible = false;
            // 
            // ColumnFileObservacao
            // 
            this.ColumnFileObservacao.DataPropertyName = "Observacao";
            this.ColumnFileObservacao.HeaderText = "Observação";
            this.ColumnFileObservacao.Name = "ColumnFileObservacao";
            this.ColumnFileObservacao.ReadOnly = true;
            this.ColumnFileObservacao.Visible = false;
            // 
            // ColumnFolderSize
            // 
            this.ColumnFolderSize.DataPropertyName = "FolderSizeF";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.ColumnFolderSize.DefaultCellStyle = dataGridViewCellStyle5;
            this.ColumnFolderSize.HeaderText = "Armazenamento";
            this.ColumnFolderSize.Name = "ColumnFolderSize";
            this.ColumnFolderSize.ReadOnly = true;
            // 
            // ColumnArmazenamentoColor
            // 
            this.ColumnArmazenamentoColor.DataPropertyName = "FolderSizeColor";
            this.ColumnArmazenamentoColor.HeaderText = "ColorF";
            this.ColumnArmazenamentoColor.Name = "ColumnArmazenamentoColor";
            this.ColumnArmazenamentoColor.ReadOnly = true;
            this.ColumnArmazenamentoColor.Visible = false;
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
            this.toolStripStatusLabelTamanhoArquivos,
            this.toolStripStatusLabel4,
            this.toolStripStatusLabelTotalArmazenamento});
            this.statusStrip1.Location = new System.Drawing.Point(0, 428);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(859, 22);
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
            // toolStripStatusLabel4
            // 
            this.toolStripStatusLabel4.Name = "toolStripStatusLabel4";
            this.toolStripStatusLabel4.Size = new System.Drawing.Size(134, 17);
            this.toolStripStatusLabel4.Text = "/ Total Armazenamento:";
            // 
            // toolStripStatusLabelTotalArmazenamento
            // 
            this.toolStripStatusLabelTotalArmazenamento.Name = "toolStripStatusLabelTotalArmazenamento";
            this.toolStripStatusLabelTotalArmazenamento.Size = new System.Drawing.Size(32, 17);
            this.toolStripStatusLabelTotalArmazenamento.Text = "--GB";
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
            // timerServer
            // 
            this.timerServer.Interval = 1000;
            this.timerServer.Tick += new System.EventHandler(this.timerServer_Tick);
            // 
            // timerVisibleRows
            // 
            this.timerVisibleRows.Interval = 300;
            this.timerVisibleRows.Tick += new System.EventHandler(this.timerVisibleRows_Tick);
            // 
            // FormMonitor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(859, 450);
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.panel1);
            this.Name = "FormMonitor";
            this.Text = "Monitor";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMonitor_FormClosing);
            this.Load += new System.EventHandler(this.FormMonitor_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
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
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn1;
        private System.Windows.Forms.Timer timerRefresh;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripStatusLabel labelUltimaVerificacao3;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn2;
        private System.Windows.Forms.CheckBox checkBoxOcultarPastasVazias;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelTamanhoArquivos;
        private System.Windows.Forms.Timer timerServer;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label labelConexoes;
        private System.Windows.Forms.Label labelStatusServer;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel4;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelTotalArmazenamento;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DateTimePicker dateTimePickerDataRef;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Timer timerVisibleRows;
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
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnFolderSize;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnArmazenamentoColor;
    }
}