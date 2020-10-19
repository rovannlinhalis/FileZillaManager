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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle20 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle17 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle18 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle19 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMonitor2));
            this.panel2 = new System.Windows.Forms.Panel();
            this.panelUpdates = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.labelConexoes = new System.Windows.Forms.Label();
            this.labelStatusServidor = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.labelStatusArquivos = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.checkBoxOcultarPastasVazias = new System.Windows.Forms.CheckBox();
            this.dateTimePickerDataRef = new System.Windows.Forms.DateTimePicker();
            this.checkBoxSubPastasIndividualmente = new System.Windows.Forms.CheckBox();
            this.checkBoxSubPastas = new System.Windows.Forms.CheckBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
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
            this.ColumnLastLerDiretorio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnLastHast = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnLastIntegrity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnHash = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnMensagemZip = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnQtdArquivos = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.timerGetContratos = new System.Windows.Forms.Timer(this.components);
            this.backgroundWorkerProcesso = new System.ComponentModel.BackgroundWorker();
            this.timerResetBinding = new System.Windows.Forms.Timer(this.components);
            this.timerUpdate = new System.Windows.Forms.Timer(this.components);
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.panelHardwareMonitor = new System.Windows.Forms.Panel();
            this.labelHardwareMensagem = new System.Windows.Forms.Label();
            this.timerHardware = new System.Windows.Forms.Timer(this.components);
            this.panel2.SuspendLayout();
            this.panelUpdates.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.panelHardwareMonitor.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panelHardwareMonitor);
            this.panel2.Controls.Add(this.panelUpdates);
            this.panel2.Controls.Add(this.groupBox2);
            this.panel2.Controls.Add(this.groupBox3);
            this.panel2.Controls.Add(this.groupBox1);
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1261, 82);
            this.panel2.TabIndex = 1;
            // 
            // panelUpdates
            // 
            this.panelUpdates.BackColor = System.Drawing.Color.PaleGreen;
            this.panelUpdates.Controls.Add(this.label2);
            this.panelUpdates.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelUpdates.Location = new System.Drawing.Point(998, 0);
            this.panelUpdates.Name = "panelUpdates";
            this.panelUpdates.Size = new System.Drawing.Size(263, 82);
            this.panelUpdates.TabIndex = 8;
            this.panelUpdates.Visible = false;
            // 
            // label2
            // 
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Font = new System.Drawing.Font("Roboto", 14.25F);
            this.label2.ForeColor = System.Drawing.Color.DarkGreen;
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(263, 82);
            this.label2.TabIndex = 5;
            this.label2.Text = "Atualização Disponível";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.labelConexoes);
            this.groupBox2.Controls.Add(this.labelStatusServidor);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox2.Font = new System.Drawing.Font("Roboto", 6.25F);
            this.groupBox2.Location = new System.Drawing.Point(844, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(230, 82);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Status do Servidor";
            // 
            // labelConexoes
            // 
            this.labelConexoes.AutoSize = true;
            this.labelConexoes.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelConexoes.Font = new System.Drawing.Font("Roboto", 8.25F);
            this.labelConexoes.Location = new System.Drawing.Point(3, 37);
            this.labelConexoes.Name = "labelConexoes";
            this.labelConexoes.Size = new System.Drawing.Size(55, 13);
            this.labelConexoes.TabIndex = 7;
            this.labelConexoes.Text = "Conexões";
            // 
            // labelStatusServidor
            // 
            this.labelStatusServidor.AutoSize = true;
            this.labelStatusServidor.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelStatusServidor.Font = new System.Drawing.Font("Roboto", 14.25F);
            this.labelStatusServidor.Location = new System.Drawing.Point(3, 14);
            this.labelStatusServidor.Name = "labelStatusServidor";
            this.labelStatusServidor.Size = new System.Drawing.Size(164, 23);
            this.labelStatusServidor.TabIndex = 4;
            this.labelStatusServidor.Text = "Status do Servidor";
            this.labelStatusServidor.MouseClick += new System.Windows.Forms.MouseEventHandler(this.labelStatusServidor_MouseClick);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.button1);
            this.groupBox3.Controls.Add(this.labelStatusArquivos);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox3.Font = new System.Drawing.Font("Roboto", 6.25F);
            this.groupBox3.Location = new System.Drawing.Point(571, 0);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(273, 82);
            this.groupBox3.TabIndex = 11;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Status dos Arquivos";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(174, 10);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 8;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // labelStatusArquivos
            // 
            this.labelStatusArquivos.AutoSize = true;
            this.labelStatusArquivos.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelStatusArquivos.Font = new System.Drawing.Font("Roboto", 8.25F);
            this.labelStatusArquivos.Location = new System.Drawing.Point(3, 14);
            this.labelStatusArquivos.Name = "labelStatusArquivos";
            this.labelStatusArquivos.Size = new System.Drawing.Size(16, 13);
            this.labelStatusArquivos.TabIndex = 7;
            this.labelStatusArquivos.Text = "---";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.checkBoxOcultarPastasVazias);
            this.groupBox1.Controls.Add(this.dateTimePickerDataRef);
            this.groupBox1.Controls.Add(this.checkBoxSubPastasIndividualmente);
            this.groupBox1.Controls.Add(this.checkBoxSubPastas);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox1.Font = new System.Drawing.Font("Roboto", 6.25F);
            this.groupBox1.Location = new System.Drawing.Point(214, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(357, 82);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Opções";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Roboto", 8.25F);
            this.label1.Location = new System.Drawing.Point(238, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Data de Referência";
            // 
            // checkBoxOcultarPastasVazias
            // 
            this.checkBoxOcultarPastasVazias.AutoSize = true;
            this.checkBoxOcultarPastasVazias.Font = new System.Drawing.Font("Roboto", 8.25F);
            this.checkBoxOcultarPastasVazias.Location = new System.Drawing.Point(7, 18);
            this.checkBoxOcultarPastasVazias.Name = "checkBoxOcultarPastasVazias";
            this.checkBoxOcultarPastasVazias.Size = new System.Drawing.Size(137, 17);
            this.checkBoxOcultarPastasVazias.TabIndex = 1;
            this.checkBoxOcultarPastasVazias.Text = "Ocultar Pastas Vazias";
            this.checkBoxOcultarPastasVazias.UseVisualStyleBackColor = true;
            // 
            // dateTimePickerDataRef
            // 
            this.dateTimePickerDataRef.Checked = false;
            this.dateTimePickerDataRef.Font = new System.Drawing.Font("Roboto", 8.25F);
            this.dateTimePickerDataRef.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePickerDataRef.Location = new System.Drawing.Point(238, 44);
            this.dateTimePickerDataRef.Name = "dateTimePickerDataRef";
            this.dateTimePickerDataRef.ShowCheckBox = true;
            this.dateTimePickerDataRef.Size = new System.Drawing.Size(113, 21);
            this.dateTimePickerDataRef.TabIndex = 5;
            this.dateTimePickerDataRef.ValueChanged += new System.EventHandler(this.dateTimePickerDataRef_ValueChanged);
            // 
            // checkBoxSubPastasIndividualmente
            // 
            this.checkBoxSubPastasIndividualmente.AutoSize = true;
            this.checkBoxSubPastasIndividualmente.Font = new System.Drawing.Font("Roboto", 8.25F);
            this.checkBoxSubPastasIndividualmente.Location = new System.Drawing.Point(7, 54);
            this.checkBoxSubPastasIndividualmente.Name = "checkBoxSubPastasIndividualmente";
            this.checkBoxSubPastasIndividualmente.Size = new System.Drawing.Size(213, 17);
            this.checkBoxSubPastasIndividualmente.TabIndex = 3;
            this.checkBoxSubPastasIndividualmente.Text = "Monitorar Subpastas individualmente";
            this.checkBoxSubPastasIndividualmente.UseVisualStyleBackColor = true;
            // 
            // checkBoxSubPastas
            // 
            this.checkBoxSubPastas.AutoSize = true;
            this.checkBoxSubPastas.Font = new System.Drawing.Font("Roboto", 8.25F);
            this.checkBoxSubPastas.Location = new System.Drawing.Point(7, 36);
            this.checkBoxSubPastas.Name = "checkBoxSubPastas";
            this.checkBoxSubPastas.Size = new System.Drawing.Size(131, 17);
            this.checkBoxSubPastas.TabIndex = 2;
            this.checkBoxSubPastas.Text = "Monitorar Subpastas";
            this.checkBoxSubPastas.UseVisualStyleBackColor = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(214, 82);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 12;
            this.pictureBox1.TabStop = false;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToOrderColumns = true;
            dataGridViewCellStyle11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(244)))), ((int)(((byte)(244)))));
            this.dataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle11;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dataGridView1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle12.BackColor = System.Drawing.Color.IndianRed;
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Roboto", 8.25F);
            dataGridViewCellStyle12.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.Color.Firebrick;
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle12;
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
            this.ColumnContratoStatusFTP,
            this.ColumnLastLerDiretorio,
            this.ColumnLastHast,
            this.ColumnLastIntegrity,
            this.ColumnHash,
            this.ColumnMensagemZip,
            this.ColumnQtdArquivos});
            this.dataGridView1.DataSource = this.bindingSource1;
            dataGridViewCellStyle20.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle20.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle20.Font = new System.Drawing.Font("Roboto", 8.25F);
            dataGridViewCellStyle20.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle20.SelectionBackColor = System.Drawing.Color.Salmon;
            dataGridViewCellStyle20.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle20.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle20;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.EnableHeadersVisualStyles = false;
            this.dataGridView1.GridColor = System.Drawing.Color.Gainsboro;
            this.dataGridView1.Location = new System.Drawing.Point(0, 82);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowTemplate.Height = 32;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(1261, 466);
            this.dataGridView1.TabIndex = 2;
            this.dataGridView1.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentDoubleClick);
            this.dataGridView1.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dataGridView1_CellPainting);
            this.dataGridView1.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dataGridView1_DataError);
            // 
            // ColumnContratoNome
            // 
            this.ColumnContratoNome.DataPropertyName = "Nome";
            dataGridViewCellStyle13.Format = "G";
            dataGridViewCellStyle13.NullValue = null;
            this.ColumnContratoNome.DefaultCellStyle = dataGridViewCellStyle13;
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
            this.ColumnContratoStatusText.DataPropertyName = "StatusX";
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
            this.ColumnFileCheckF.DataPropertyName = "IntegridadeX";
            this.ColumnFileCheckF.HeaderText = "Integridade";
            this.ColumnFileCheckF.Name = "ColumnFileCheckF";
            this.ColumnFileCheckF.ReadOnly = true;
            // 
            // ColumnContratoLastWrite
            // 
            this.ColumnContratoLastWrite.DataPropertyName = "LastWrite";
            dataGridViewCellStyle14.Format = "G";
            dataGridViewCellStyle14.NullValue = null;
            this.ColumnContratoLastWrite.DefaultCellStyle = dataGridViewCellStyle14;
            this.ColumnContratoLastWrite.HeaderText = "Data do Arquivo";
            this.ColumnContratoLastWrite.Name = "ColumnContratoLastWrite";
            this.ColumnContratoLastWrite.ReadOnly = true;
            this.ColumnContratoLastWrite.Width = 110;
            // 
            // ColumnContratoArquivo
            // 
            this.ColumnContratoArquivo.DataPropertyName = "Arquivo";
            this.ColumnContratoArquivo.HeaderText = "Arquivo";
            this.ColumnContratoArquivo.Name = "ColumnContratoArquivo";
            this.ColumnContratoArquivo.ReadOnly = true;
            this.ColumnContratoArquivo.Width = 200;
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
            dataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.ColumnContratoTamanho.DefaultCellStyle = dataGridViewCellStyle15;
            this.ColumnContratoTamanho.HeaderText = "Tamanho";
            this.ColumnContratoTamanho.Name = "ColumnContratoTamanho";
            this.ColumnContratoTamanho.ReadOnly = true;
            // 
            // ColumnContratoFolderSize
            // 
            this.ColumnContratoFolderSize.DataPropertyName = "FolderSizeF";
            dataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.ColumnContratoFolderSize.DefaultCellStyle = dataGridViewCellStyle16;
            this.ColumnContratoFolderSize.HeaderText = "Armazenamento";
            this.ColumnContratoFolderSize.Name = "ColumnContratoFolderSize";
            this.ColumnContratoFolderSize.ReadOnly = true;
            // 
            // ColumnContratoFolderSizeColor
            // 
            this.ColumnContratoFolderSizeColor.DataPropertyName = "FolderSizeColor";
            this.ColumnContratoFolderSizeColor.HeaderText = "CorArmazenamento";
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
            // ColumnLastLerDiretorio
            // 
            this.ColumnLastLerDiretorio.DataPropertyName = "LastLerDiretorio";
            dataGridViewCellStyle17.Format = "G";
            dataGridViewCellStyle17.NullValue = null;
            this.ColumnLastLerDiretorio.DefaultCellStyle = dataGridViewCellStyle17;
            this.ColumnLastLerDiretorio.HeaderText = "Ler Diretorio";
            this.ColumnLastLerDiretorio.Name = "ColumnLastLerDiretorio";
            this.ColumnLastLerDiretorio.ReadOnly = true;
            this.ColumnLastLerDiretorio.Visible = false;
            // 
            // ColumnLastHast
            // 
            this.ColumnLastHast.DataPropertyName = "LastHashDate";
            dataGridViewCellStyle18.Format = "G";
            this.ColumnLastHast.DefaultCellStyle = dataGridViewCellStyle18;
            this.ColumnLastHast.HeaderText = "Last Hash";
            this.ColumnLastHast.Name = "ColumnLastHast";
            this.ColumnLastHast.ReadOnly = true;
            this.ColumnLastHast.Visible = false;
            // 
            // ColumnLastIntegrity
            // 
            this.ColumnLastIntegrity.DataPropertyName = "lastIntegrityDate";
            dataGridViewCellStyle19.Format = "G";
            this.ColumnLastIntegrity.DefaultCellStyle = dataGridViewCellStyle19;
            this.ColumnLastIntegrity.HeaderText = "Last Integrity";
            this.ColumnLastIntegrity.Name = "ColumnLastIntegrity";
            this.ColumnLastIntegrity.ReadOnly = true;
            this.ColumnLastIntegrity.Visible = false;
            // 
            // ColumnHash
            // 
            this.ColumnHash.DataPropertyName = "Hash";
            this.ColumnHash.HeaderText = "Hash";
            this.ColumnHash.Name = "ColumnHash";
            this.ColumnHash.ReadOnly = true;
            this.ColumnHash.Visible = false;
            // 
            // ColumnMensagemZip
            // 
            this.ColumnMensagemZip.DataPropertyName = "MensagemZip";
            this.ColumnMensagemZip.HeaderText = "Msg Zip";
            this.ColumnMensagemZip.Name = "ColumnMensagemZip";
            this.ColumnMensagemZip.ReadOnly = true;
            this.ColumnMensagemZip.Visible = false;
            // 
            // ColumnQtdArquivos
            // 
            this.ColumnQtdArquivos.DataPropertyName = "QtdArquivos";
            this.ColumnQtdArquivos.HeaderText = "Qtd Arquivos";
            this.ColumnQtdArquivos.Name = "ColumnQtdArquivos";
            this.ColumnQtdArquivos.ReadOnly = true;
            this.ColumnQtdArquivos.Visible = false;
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
            // timerResetBinding
            // 
            this.timerResetBinding.Interval = 1000;
            this.timerResetBinding.Tick += new System.EventHandler(this.timerResetBinding_Tick);
            // 
            // timerUpdate
            // 
            this.timerUpdate.Enabled = true;
            this.timerUpdate.Interval = 10800000;
            this.timerUpdate.Tick += new System.EventHandler(this.timerUpdate_Tick);
            // 
            // panelHardwareMonitor
            // 
            this.panelHardwareMonitor.BackColor = System.Drawing.Color.LightCoral;
            this.panelHardwareMonitor.Controls.Add(this.labelHardwareMensagem);
            this.panelHardwareMonitor.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelHardwareMonitor.Location = new System.Drawing.Point(735, 0);
            this.panelHardwareMonitor.Name = "panelHardwareMonitor";
            this.panelHardwareMonitor.Size = new System.Drawing.Size(263, 82);
            this.panelHardwareMonitor.TabIndex = 13;
            this.panelHardwareMonitor.Visible = false;
            // 
            // labelHardwareMensagem
            // 
            this.labelHardwareMensagem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelHardwareMensagem.Font = new System.Drawing.Font("Roboto", 14.25F);
            this.labelHardwareMensagem.ForeColor = System.Drawing.Color.DarkRed;
            this.labelHardwareMensagem.Location = new System.Drawing.Point(0, 0);
            this.labelHardwareMensagem.Name = "labelHardwareMensagem";
            this.labelHardwareMensagem.Size = new System.Drawing.Size(263, 82);
            this.labelHardwareMensagem.TabIndex = 5;
            this.labelHardwareMensagem.Text = "----------";
            this.labelHardwareMensagem.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // timerHardware
            // 
            this.timerHardware.Enabled = true;
            this.timerHardware.Interval = 5000;
            this.timerHardware.Tick += new System.EventHandler(this.timerHardware_Tick);
            // 
            // FormMonitor2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1261, 548);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.panel2);
            this.Font = new System.Drawing.Font("Roboto", 8.25F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormMonitor2";
            this.Text = "Monitor";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMonitor2_FormClosing);
            this.Load += new System.EventHandler(this.FormMonitor2_Load);
            this.panel2.ResumeLayout(false);
            this.panelUpdates.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.panelHardwareMonitor.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.CheckBox checkBoxOcultarPastasVazias;
        private System.Windows.Forms.Timer timerGetContratos;
        private System.ComponentModel.BackgroundWorker backgroundWorkerProcesso;
        private System.Windows.Forms.Timer timerResetBinding;
        private System.Windows.Forms.CheckBox checkBoxSubPastasIndividualmente;
        private System.Windows.Forms.CheckBox checkBoxSubPastas;
        private System.Windows.Forms.Label labelStatusServidor;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dateTimePickerDataRef;
        private System.Windows.Forms.Label labelConexoes;
        private System.Windows.Forms.Panel panelUpdates;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Timer timerUpdate;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label labelStatusArquivos;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.PictureBox pictureBox1;
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
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnLastLerDiretorio;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnLastHast;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnLastIntegrity;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnHash;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnMensagemZip;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnQtdArquivos;
        private System.Windows.Forms.Panel panelHardwareMonitor;
        private System.Windows.Forms.Label labelHardwareMensagem;
        private System.Windows.Forms.Timer timerHardware;
    }
}