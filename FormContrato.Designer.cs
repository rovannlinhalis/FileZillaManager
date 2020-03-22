namespace FileZillaManager
{
    partial class FormContrato
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.campoNome = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.campoUsuario = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.campoSenha = new System.Windows.Forms.TextBox();
            this.lblCodigo = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.campoValor = new System.Windows.Forms.TextBox();
            this.buttonCancelar = new System.Windows.Forms.Button();
            this.buttonGravar = new System.Windows.Forms.Button();
            this.panelCadastro = new System.Windows.Forms.Panel();
            this.campoSenhaCompactacao = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.campoGrupo = new System.Windows.Forms.ComboBox();
            this.buttonVerSenha = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.DirSubDir = new System.Windows.Forms.CheckBox();
            this.DirDelete = new System.Windows.Forms.CheckBox();
            this.DirCreate = new System.Windows.Forms.CheckBox();
            this.DirList = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.FileDelete = new System.Windows.Forms.CheckBox();
            this.FileAppend = new System.Windows.Forms.CheckBox();
            this.FileWrite = new System.Windows.Forms.CheckBox();
            this.FileRead = new System.Windows.Forms.CheckBox();
            this.campoAtivo = new System.Windows.Forms.CheckBox();
            this.campoDataContrato = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.buttonProcurarPasta = new System.Windows.Forms.Button();
            this.campoPasta = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.buttonExcluir = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.textBoxFiltro = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.ColumnLogin = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnDescricao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnValor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnAtivo = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.timerFiltro = new System.Windows.Forms.Timer(this.components);
            this.checkBoxMonitorar = new System.Windows.Forms.CheckBox();
            this.panelCadastro.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Roboto", 8.25F);
            this.label1.Location = new System.Drawing.Point(12, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Descrição";
            // 
            // campoNome
            // 
            this.campoNome.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.campoNome.Font = new System.Drawing.Font("Roboto", 12.25F);
            this.campoNome.Location = new System.Drawing.Point(12, 28);
            this.campoNome.MaxLength = 100;
            this.campoNome.Name = "campoNome";
            this.campoNome.Size = new System.Drawing.Size(301, 27);
            this.campoNome.TabIndex = 1;
            this.campoNome.Tag = "*";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Roboto", 8.25F);
            this.label2.Location = new System.Drawing.Point(12, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Usuário";
            // 
            // campoUsuario
            // 
            this.campoUsuario.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.campoUsuario.Font = new System.Drawing.Font("Roboto", 12.25F);
            this.campoUsuario.Location = new System.Drawing.Point(12, 74);
            this.campoUsuario.MaxLength = 100;
            this.campoUsuario.Name = "campoUsuario";
            this.campoUsuario.Size = new System.Drawing.Size(301, 27);
            this.campoUsuario.TabIndex = 6;
            this.campoUsuario.Tag = "*";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Roboto", 8.25F);
            this.label3.Location = new System.Drawing.Point(319, 58);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Senha";
            // 
            // campoSenha
            // 
            this.campoSenha.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.campoSenha.Font = new System.Drawing.Font("Roboto", 12.25F);
            this.campoSenha.Location = new System.Drawing.Point(319, 74);
            this.campoSenha.MaxLength = 100;
            this.campoSenha.Name = "campoSenha";
            this.campoSenha.PasswordChar = '*';
            this.campoSenha.Size = new System.Drawing.Size(297, 27);
            this.campoSenha.TabIndex = 8;
            this.campoSenha.Tag = "*";
            // 
            // lblCodigo
            // 
            this.lblCodigo.AutoSize = true;
            this.lblCodigo.Location = new System.Drawing.Point(88, 12);
            this.lblCodigo.Name = "lblCodigo";
            this.lblCodigo.Size = new System.Drawing.Size(46, 13);
            this.lblCodigo.TabIndex = 2;
            this.lblCodigo.Text = "_Codigo";
            this.lblCodigo.Visible = false;
            this.lblCodigo.TextChanged += new System.EventHandler(this.lblCodigo_TextChanged);
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Roboto", 8.25F);
            this.label4.Location = new System.Drawing.Point(522, 12);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(33, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Valor";
            // 
            // campoValor
            // 
            this.campoValor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.campoValor.Font = new System.Drawing.Font("Roboto", 12.25F);
            this.campoValor.Location = new System.Drawing.Point(522, 28);
            this.campoValor.MaxLength = 100;
            this.campoValor.Name = "campoValor";
            this.campoValor.Size = new System.Drawing.Size(129, 27);
            this.campoValor.TabIndex = 4;
            this.campoValor.Tag = "v$C2";
            this.campoValor.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // buttonCancelar
            // 
            this.buttonCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCancelar.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonCancelar.BackColor = System.Drawing.SystemColors.Window;
            this.buttonCancelar.FlatAppearance.BorderColor = System.Drawing.Color.IndianRed;
            this.buttonCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonCancelar.Font = new System.Drawing.Font("Roboto", 8.25F, System.Drawing.FontStyle.Bold);
            this.buttonCancelar.ForeColor = System.Drawing.Color.IndianRed;
            this.buttonCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonCancelar.Location = new System.Drawing.Point(431, 198);
            this.buttonCancelar.Name = "buttonCancelar";
            this.buttonCancelar.Size = new System.Drawing.Size(107, 43);
            this.buttonCancelar.TabIndex = 15;
            this.buttonCancelar.Text = "Cancelar";
            this.buttonCancelar.UseVisualStyleBackColor = false;
            this.buttonCancelar.Click += new System.EventHandler(this.buttonCancelar_Click);
            // 
            // buttonGravar
            // 
            this.buttonGravar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonGravar.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonGravar.BackColor = System.Drawing.SystemColors.Window;
            this.buttonGravar.FlatAppearance.BorderColor = System.Drawing.Color.IndianRed;
            this.buttonGravar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonGravar.Font = new System.Drawing.Font("Roboto", 8.25F, System.Drawing.FontStyle.Bold);
            this.buttonGravar.ForeColor = System.Drawing.Color.IndianRed;
            this.buttonGravar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonGravar.Location = new System.Drawing.Point(318, 198);
            this.buttonGravar.Name = "buttonGravar";
            this.buttonGravar.Size = new System.Drawing.Size(107, 43);
            this.buttonGravar.TabIndex = 14;
            this.buttonGravar.Text = "Gravar";
            this.buttonGravar.UseVisualStyleBackColor = false;
            this.buttonGravar.Click += new System.EventHandler(this.buttonGravar_Click);
            // 
            // panelCadastro
            // 
            this.panelCadastro.Controls.Add(this.checkBoxMonitorar);
            this.panelCadastro.Controls.Add(this.campoSenhaCompactacao);
            this.panelCadastro.Controls.Add(this.label9);
            this.panelCadastro.Controls.Add(this.label8);
            this.panelCadastro.Controls.Add(this.campoGrupo);
            this.panelCadastro.Controls.Add(this.buttonVerSenha);
            this.panelCadastro.Controls.Add(this.groupBox2);
            this.panelCadastro.Controls.Add(this.groupBox1);
            this.panelCadastro.Controls.Add(this.campoAtivo);
            this.panelCadastro.Controls.Add(this.campoDataContrato);
            this.panelCadastro.Controls.Add(this.label7);
            this.panelCadastro.Controls.Add(this.buttonProcurarPasta);
            this.panelCadastro.Controls.Add(this.campoPasta);
            this.panelCadastro.Controls.Add(this.label5);
            this.panelCadastro.Controls.Add(this.buttonExcluir);
            this.panelCadastro.Controls.Add(this.label1);
            this.panelCadastro.Controls.Add(this.buttonCancelar);
            this.panelCadastro.Controls.Add(this.campoNome);
            this.panelCadastro.Controls.Add(this.buttonGravar);
            this.panelCadastro.Controls.Add(this.campoUsuario);
            this.panelCadastro.Controls.Add(this.label4);
            this.panelCadastro.Controls.Add(this.label2);
            this.panelCadastro.Controls.Add(this.campoValor);
            this.panelCadastro.Controls.Add(this.campoSenha);
            this.panelCadastro.Controls.Add(this.lblCodigo);
            this.panelCadastro.Controls.Add(this.label3);
            this.panelCadastro.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelCadastro.Location = new System.Drawing.Point(0, 0);
            this.panelCadastro.Name = "panelCadastro";
            this.panelCadastro.Size = new System.Drawing.Size(657, 251);
            this.panelCadastro.TabIndex = 0;
            // 
            // campoSenhaCompactacao
            // 
            this.campoSenhaCompactacao.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.campoSenhaCompactacao.Font = new System.Drawing.Font("Roboto", 12.25F);
            this.campoSenhaCompactacao.Location = new System.Drawing.Point(140, 165);
            this.campoSenhaCompactacao.MaxLength = 100;
            this.campoSenhaCompactacao.Name = "campoSenhaCompactacao";
            this.campoSenhaCompactacao.PasswordChar = '*';
            this.campoSenhaCompactacao.Size = new System.Drawing.Size(187, 27);
            this.campoSenhaCompactacao.TabIndex = 27;
            this.campoSenhaCompactacao.Tag = "";
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Roboto", 8.25F);
            this.label9.Location = new System.Drawing.Point(140, 149);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(125, 13);
            this.label9.TabIndex = 26;
            this.label9.Text = "Senha de Compactação";
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Roboto", 8.25F);
            this.label8.Location = new System.Drawing.Point(319, 12);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(37, 13);
            this.label8.TabIndex = 25;
            this.label8.Text = "Grupo";
            // 
            // campoGrupo
            // 
            this.campoGrupo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.campoGrupo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.campoGrupo.BackColor = System.Drawing.Color.Snow;
            this.campoGrupo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.campoGrupo.Font = new System.Drawing.Font("Roboto", 11.25F);
            this.campoGrupo.FormattingEnabled = true;
            this.campoGrupo.Location = new System.Drawing.Point(319, 28);
            this.campoGrupo.Name = "campoGrupo";
            this.campoGrupo.Size = new System.Drawing.Size(197, 26);
            this.campoGrupo.TabIndex = 24;
            this.campoGrupo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.campoGrupo_KeyDown);
            // 
            // buttonVerSenha
            // 
            this.buttonVerSenha.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonVerSenha.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonVerSenha.BackColor = System.Drawing.SystemColors.Window;
            this.buttonVerSenha.FlatAppearance.BorderColor = System.Drawing.Color.IndianRed;
            this.buttonVerSenha.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonVerSenha.Font = new System.Drawing.Font("Roboto", 8.25F, System.Drawing.FontStyle.Bold);
            this.buttonVerSenha.ForeColor = System.Drawing.Color.IndianRed;
            this.buttonVerSenha.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonVerSenha.Location = new System.Drawing.Point(622, 73);
            this.buttonVerSenha.Name = "buttonVerSenha";
            this.buttonVerSenha.Size = new System.Drawing.Size(29, 29);
            this.buttonVerSenha.TabIndex = 23;
            this.buttonVerSenha.Text = "...";
            this.buttonVerSenha.UseVisualStyleBackColor = false;
            this.buttonVerSenha.Click += new System.EventHandler(this.buttonVerSenha_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.DirSubDir);
            this.groupBox2.Controls.Add(this.DirDelete);
            this.groupBox2.Controls.Add(this.DirCreate);
            this.groupBox2.Controls.Add(this.DirList);
            this.groupBox2.Location = new System.Drawing.Point(413, 145);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(3, 1, 3, 2);
            this.groupBox2.Size = new System.Drawing.Size(238, 34);
            this.groupBox2.TabIndex = 22;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Pastas";
            // 
            // DirSubDir
            // 
            this.DirSubDir.AutoSize = true;
            this.DirSubDir.Dock = System.Windows.Forms.DockStyle.Left;
            this.DirSubDir.Font = new System.Drawing.Font("Roboto", 7.25F);
            this.DirSubDir.Location = new System.Drawing.Point(156, 15);
            this.DirSubDir.Name = "DirSubDir";
            this.DirSubDir.Size = new System.Drawing.Size(81, 17);
            this.DirSubDir.TabIndex = 20;
            this.DirSubDir.Text = "+Sub Pastas";
            this.DirSubDir.UseVisualStyleBackColor = true;
            // 
            // DirDelete
            // 
            this.DirDelete.AutoSize = true;
            this.DirDelete.Dock = System.Windows.Forms.DockStyle.Left;
            this.DirDelete.Font = new System.Drawing.Font("Roboto", 7.25F);
            this.DirDelete.Location = new System.Drawing.Point(98, 15);
            this.DirDelete.Name = "DirDelete";
            this.DirDelete.Size = new System.Drawing.Size(58, 17);
            this.DirDelete.TabIndex = 21;
            this.DirDelete.Text = "Apagar";
            this.DirDelete.UseVisualStyleBackColor = true;
            // 
            // DirCreate
            // 
            this.DirCreate.AutoSize = true;
            this.DirCreate.Dock = System.Windows.Forms.DockStyle.Left;
            this.DirCreate.Font = new System.Drawing.Font("Roboto", 7.25F);
            this.DirCreate.Location = new System.Drawing.Point(52, 15);
            this.DirCreate.Name = "DirCreate";
            this.DirCreate.Size = new System.Drawing.Size(46, 17);
            this.DirCreate.TabIndex = 19;
            this.DirCreate.Text = "Criar";
            this.DirCreate.UseVisualStyleBackColor = true;
            // 
            // DirList
            // 
            this.DirList.AutoSize = true;
            this.DirList.Dock = System.Windows.Forms.DockStyle.Left;
            this.DirList.Font = new System.Drawing.Font("Roboto", 7.25F);
            this.DirList.Location = new System.Drawing.Point(3, 15);
            this.DirList.Name = "DirList";
            this.DirList.Size = new System.Drawing.Size(49, 17);
            this.DirList.TabIndex = 18;
            this.DirList.Text = "Listar";
            this.DirList.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.FileDelete);
            this.groupBox1.Controls.Add(this.FileAppend);
            this.groupBox1.Controls.Add(this.FileWrite);
            this.groupBox1.Controls.Add(this.FileRead);
            this.groupBox1.Location = new System.Drawing.Point(419, 107);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 1, 3, 2);
            this.groupBox1.Size = new System.Drawing.Size(233, 34);
            this.groupBox1.TabIndex = 19;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Arquivos";
            // 
            // FileDelete
            // 
            this.FileDelete.AutoSize = true;
            this.FileDelete.Dock = System.Windows.Forms.DockStyle.Left;
            this.FileDelete.Font = new System.Drawing.Font("Roboto", 7.25F);
            this.FileDelete.Location = new System.Drawing.Point(139, 15);
            this.FileDelete.Name = "FileDelete";
            this.FileDelete.Size = new System.Drawing.Size(58, 17);
            this.FileDelete.TabIndex = 21;
            this.FileDelete.Text = "Apagar";
            this.FileDelete.UseVisualStyleBackColor = true;
            // 
            // FileAppend
            // 
            this.FileAppend.AutoSize = true;
            this.FileAppend.Dock = System.Windows.Forms.DockStyle.Left;
            this.FileAppend.Font = new System.Drawing.Font("Roboto", 7.25F);
            this.FileAppend.Location = new System.Drawing.Point(88, 15);
            this.FileAppend.Name = "FileAppend";
            this.FileAppend.Size = new System.Drawing.Size(51, 17);
            this.FileAppend.TabIndex = 20;
            this.FileAppend.Text = "Editar";
            this.FileAppend.UseVisualStyleBackColor = true;
            // 
            // FileWrite
            // 
            this.FileWrite.AutoSize = true;
            this.FileWrite.Dock = System.Windows.Forms.DockStyle.Left;
            this.FileWrite.Font = new System.Drawing.Font("Roboto", 7.25F);
            this.FileWrite.Location = new System.Drawing.Point(42, 15);
            this.FileWrite.Name = "FileWrite";
            this.FileWrite.Size = new System.Drawing.Size(46, 17);
            this.FileWrite.TabIndex = 19;
            this.FileWrite.Text = "Criar";
            this.FileWrite.UseVisualStyleBackColor = true;
            // 
            // FileRead
            // 
            this.FileRead.AutoSize = true;
            this.FileRead.Dock = System.Windows.Forms.DockStyle.Left;
            this.FileRead.Font = new System.Drawing.Font("Roboto", 7.25F);
            this.FileRead.Location = new System.Drawing.Point(3, 15);
            this.FileRead.Name = "FileRead";
            this.FileRead.Size = new System.Drawing.Size(39, 17);
            this.FileRead.TabIndex = 18;
            this.FileRead.Text = "Ler";
            this.FileRead.UseVisualStyleBackColor = true;
            // 
            // campoAtivo
            // 
            this.campoAtivo.AutoSize = true;
            this.campoAtivo.Checked = true;
            this.campoAtivo.CheckState = System.Windows.Forms.CheckState.Checked;
            this.campoAtivo.Font = new System.Drawing.Font("Roboto", 11.25F);
            this.campoAtivo.Location = new System.Drawing.Point(15, 208);
            this.campoAtivo.Name = "campoAtivo";
            this.campoAtivo.Size = new System.Drawing.Size(62, 22);
            this.campoAtivo.TabIndex = 17;
            this.campoAtivo.Tag = "+";
            this.campoAtivo.Text = "Ativo";
            this.campoAtivo.UseVisualStyleBackColor = true;
            // 
            // campoDataContrato
            // 
            this.campoDataContrato.Font = new System.Drawing.Font("Roboto", 11.25F);
            this.campoDataContrato.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.campoDataContrato.Location = new System.Drawing.Point(12, 166);
            this.campoDataContrato.Name = "campoDataContrato";
            this.campoDataContrato.Size = new System.Drawing.Size(122, 26);
            this.campoDataContrato.TabIndex = 13;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Roboto", 8.25F);
            this.label7.Location = new System.Drawing.Point(12, 150);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(76, 13);
            this.label7.TabIndex = 12;
            this.label7.Text = "Data Contrato";
            // 
            // buttonProcurarPasta
            // 
            this.buttonProcurarPasta.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonProcurarPasta.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonProcurarPasta.BackColor = System.Drawing.SystemColors.Window;
            this.buttonProcurarPasta.FlatAppearance.BorderColor = System.Drawing.Color.IndianRed;
            this.buttonProcurarPasta.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonProcurarPasta.Font = new System.Drawing.Font("Roboto", 8.25F, System.Drawing.FontStyle.Bold);
            this.buttonProcurarPasta.ForeColor = System.Drawing.Color.IndianRed;
            this.buttonProcurarPasta.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonProcurarPasta.Location = new System.Drawing.Point(375, 110);
            this.buttonProcurarPasta.Name = "buttonProcurarPasta";
            this.buttonProcurarPasta.Size = new System.Drawing.Size(38, 38);
            this.buttonProcurarPasta.TabIndex = 11;
            this.buttonProcurarPasta.Text = "...";
            this.buttonProcurarPasta.UseVisualStyleBackColor = false;
            this.buttonProcurarPasta.Click += new System.EventHandler(this.buttonProcurarPasta_Click);
            // 
            // campoPasta
            // 
            this.campoPasta.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.campoPasta.Font = new System.Drawing.Font("Roboto", 12.25F);
            this.campoPasta.Location = new System.Drawing.Point(12, 120);
            this.campoPasta.MaxLength = 100;
            this.campoPasta.Name = "campoPasta";
            this.campoPasta.Size = new System.Drawing.Size(357, 27);
            this.campoPasta.TabIndex = 10;
            this.campoPasta.Tag = "*";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Roboto", 8.25F);
            this.label5.Location = new System.Drawing.Point(12, 104);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(36, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Pasta";
            // 
            // buttonExcluir
            // 
            this.buttonExcluir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonExcluir.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonExcluir.BackColor = System.Drawing.SystemColors.Window;
            this.buttonExcluir.FlatAppearance.BorderColor = System.Drawing.Color.IndianRed;
            this.buttonExcluir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonExcluir.Font = new System.Drawing.Font("Roboto", 8.25F, System.Drawing.FontStyle.Bold);
            this.buttonExcluir.ForeColor = System.Drawing.Color.IndianRed;
            this.buttonExcluir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonExcluir.Location = new System.Drawing.Point(544, 198);
            this.buttonExcluir.Name = "buttonExcluir";
            this.buttonExcluir.Size = new System.Drawing.Size(107, 43);
            this.buttonExcluir.TabIndex = 16;
            this.buttonExcluir.TabStop = false;
            this.buttonExcluir.Text = "Excluir";
            this.buttonExcluir.UseVisualStyleBackColor = false;
            this.buttonExcluir.Click += new System.EventHandler(this.buttonExcluir_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.textBoxFiltro);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 251);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(657, 44);
            this.panel2.TabIndex = 1;
            // 
            // textBoxFiltro
            // 
            this.textBoxFiltro.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxFiltro.Font = new System.Drawing.Font("Roboto", 12.25F);
            this.textBoxFiltro.Location = new System.Drawing.Point(0, 13);
            this.textBoxFiltro.MaxLength = 100;
            this.textBoxFiltro.Name = "textBoxFiltro";
            this.textBoxFiltro.Size = new System.Drawing.Size(657, 27);
            this.textBoxFiltro.TabIndex = 0;
            this.textBoxFiltro.Tag = "";
            this.textBoxFiltro.TextChanged += new System.EventHandler(this.textBoxFiltro_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Dock = System.Windows.Forms.DockStyle.Top;
            this.label6.Font = new System.Drawing.Font("Roboto", 8.25F);
            this.label6.Location = new System.Drawing.Point(0, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(33, 13);
            this.label6.TabIndex = 7;
            this.label6.Text = "Filtro";
            // 
            // panel3
            // 
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 507);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(657, 32);
            this.panel3.TabIndex = 3;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnLogin,
            this.ColumnDescricao,
            this.ColumnValor,
            this.ColumnAtivo});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 295);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            this.dataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(657, 212);
            this.dataGridView1.TabIndex = 2;
            this.dataGridView1.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_RowEnter);
            // 
            // ColumnLogin
            // 
            this.ColumnLogin.DataPropertyName = "Login";
            this.ColumnLogin.HeaderText = "Login";
            this.ColumnLogin.Name = "ColumnLogin";
            this.ColumnLogin.ReadOnly = true;
            this.ColumnLogin.Width = 59;
            // 
            // ColumnDescricao
            // 
            this.ColumnDescricao.DataPropertyName = "Nome";
            this.ColumnDescricao.HeaderText = "Descrição";
            this.ColumnDescricao.Name = "ColumnDescricao";
            this.ColumnDescricao.ReadOnly = true;
            this.ColumnDescricao.Width = 82;
            // 
            // ColumnValor
            // 
            this.ColumnValor.DataPropertyName = "Valor";
            dataGridViewCellStyle1.Format = "C2";
            this.ColumnValor.DefaultCellStyle = dataGridViewCellStyle1;
            this.ColumnValor.HeaderText = "Valor";
            this.ColumnValor.Name = "ColumnValor";
            this.ColumnValor.ReadOnly = true;
            this.ColumnValor.Width = 58;
            // 
            // ColumnAtivo
            // 
            this.ColumnAtivo.DataPropertyName = "Ativo";
            this.ColumnAtivo.FalseValue = "0";
            this.ColumnAtivo.HeaderText = "Ativo";
            this.ColumnAtivo.Name = "ColumnAtivo";
            this.ColumnAtivo.ReadOnly = true;
            this.ColumnAtivo.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColumnAtivo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.ColumnAtivo.TrueValue = "1";
            this.ColumnAtivo.Width = 57;
            // 
            // timerFiltro
            // 
            this.timerFiltro.Interval = 300;
            this.timerFiltro.Tick += new System.EventHandler(this.timerFiltro_Tick);
            // 
            // checkBoxMonitorar
            // 
            this.checkBoxMonitorar.AutoSize = true;
            this.checkBoxMonitorar.Checked = true;
            this.checkBoxMonitorar.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxMonitorar.Font = new System.Drawing.Font("Roboto", 11.25F);
            this.checkBoxMonitorar.Location = new System.Drawing.Point(83, 208);
            this.checkBoxMonitorar.Name = "checkBoxMonitorar";
            this.checkBoxMonitorar.Size = new System.Drawing.Size(93, 22);
            this.checkBoxMonitorar.TabIndex = 28;
            this.checkBoxMonitorar.Tag = "+";
            this.checkBoxMonitorar.Text = "Monitorar";
            this.checkBoxMonitorar.UseVisualStyleBackColor = true;
            // 
            // FormContrato
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(657, 539);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panelCadastro);
            this.Name = "FormContrato";
            this.Text = "Contratos";
            this.Load += new System.EventHandler(this.FormContrato_Load);
            this.panelCadastro.ResumeLayout(false);
            this.panelCadastro.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox campoNome;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox campoUsuario;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox campoSenha;
        private System.Windows.Forms.Label lblCodigo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox campoValor;
        private System.Windows.Forms.Button buttonCancelar;
        private System.Windows.Forms.Button buttonGravar;
        private System.Windows.Forms.Panel panelCadastro;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button buttonExcluir;
        private System.Windows.Forms.Button buttonProcurarPasta;
        private System.Windows.Forms.TextBox campoPasta;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxFiltro;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DateTimePicker campoDataContrato;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Timer timerFiltro;
        private System.Windows.Forms.CheckBox campoAtivo;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox DirSubDir;
        private System.Windows.Forms.CheckBox DirDelete;
        private System.Windows.Forms.CheckBox DirCreate;
        private System.Windows.Forms.CheckBox DirList;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox FileDelete;
        private System.Windows.Forms.CheckBox FileAppend;
        private System.Windows.Forms.CheckBox FileWrite;
        private System.Windows.Forms.CheckBox FileRead;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnLogin;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnDescricao;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnValor;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ColumnAtivo;
        private System.Windows.Forms.Button buttonVerSenha;
        private System.Windows.Forms.ComboBox campoGrupo;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox campoSenhaCompactacao;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.CheckBox checkBoxMonitorar;
    }
}