namespace FileZillaManager
{
    partial class FormGrupo
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.ColumnNome = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnPasta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnAtivo = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.textBoxFiltro = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.panelCadastro = new System.Windows.Forms.Panel();
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
            this.buttonProcurarPasta = new System.Windows.Forms.Button();
            this.campoPasta = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.buttonExcluir = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonCancelar = new System.Windows.Forms.Button();
            this.campoNome = new System.Windows.Forms.TextBox();
            this.buttonGravar = new System.Windows.Forms.Button();
            this.lblCodigo = new System.Windows.Forms.Label();
            this.timerFiltro = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel2.SuspendLayout();
            this.panelCadastro.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnNome,
            this.ColumnPasta,
            this.ColumnAtivo});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 250);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            this.dataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(626, 280);
            this.dataGridView1.TabIndex = 6;
            this.dataGridView1.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_RowEnter);
            // 
            // ColumnNome
            // 
            this.ColumnNome.DataPropertyName = "Nome";
            this.ColumnNome.HeaderText = "Nome";
            this.ColumnNome.Name = "ColumnNome";
            this.ColumnNome.ReadOnly = true;
            this.ColumnNome.Width = 62;
            // 
            // ColumnPasta
            // 
            this.ColumnPasta.DataPropertyName = "Pasta";
            this.ColumnPasta.HeaderText = "Pasta";
            this.ColumnPasta.Name = "ColumnPasta";
            this.ColumnPasta.ReadOnly = true;
            this.ColumnPasta.Width = 61;
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
            // panel3
            // 
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 530);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(626, 32);
            this.panel3.TabIndex = 7;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.textBoxFiltro);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 206);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(626, 44);
            this.panel2.TabIndex = 5;
            // 
            // textBoxFiltro
            // 
            this.textBoxFiltro.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxFiltro.Font = new System.Drawing.Font("Roboto", 12.25F);
            this.textBoxFiltro.Location = new System.Drawing.Point(0, 13);
            this.textBoxFiltro.MaxLength = 100;
            this.textBoxFiltro.Name = "textBoxFiltro";
            this.textBoxFiltro.Size = new System.Drawing.Size(626, 27);
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
            // panelCadastro
            // 
            this.panelCadastro.Controls.Add(this.groupBox2);
            this.panelCadastro.Controls.Add(this.groupBox1);
            this.panelCadastro.Controls.Add(this.campoAtivo);
            this.panelCadastro.Controls.Add(this.buttonProcurarPasta);
            this.panelCadastro.Controls.Add(this.campoPasta);
            this.panelCadastro.Controls.Add(this.label5);
            this.panelCadastro.Controls.Add(this.buttonExcluir);
            this.panelCadastro.Controls.Add(this.label1);
            this.panelCadastro.Controls.Add(this.buttonCancelar);
            this.panelCadastro.Controls.Add(this.campoNome);
            this.panelCadastro.Controls.Add(this.buttonGravar);
            this.panelCadastro.Controls.Add(this.lblCodigo);
            this.panelCadastro.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelCadastro.Location = new System.Drawing.Point(0, 0);
            this.panelCadastro.Name = "panelCadastro";
            this.panelCadastro.Size = new System.Drawing.Size(626, 206);
            this.panelCadastro.TabIndex = 4;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.DirSubDir);
            this.groupBox2.Controls.Add(this.DirDelete);
            this.groupBox2.Controls.Add(this.DirCreate);
            this.groupBox2.Controls.Add(this.DirList);
            this.groupBox2.Location = new System.Drawing.Point(254, 107);
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
            this.groupBox1.Location = new System.Drawing.Point(15, 107);
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
            this.campoAtivo.Location = new System.Drawing.Point(552, 118);
            this.campoAtivo.Name = "campoAtivo";
            this.campoAtivo.Size = new System.Drawing.Size(62, 22);
            this.campoAtivo.TabIndex = 17;
            this.campoAtivo.Tag = "+";
            this.campoAtivo.Text = "Ativo";
            this.campoAtivo.UseVisualStyleBackColor = true;
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
            this.buttonProcurarPasta.Location = new System.Drawing.Point(576, 63);
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
            this.campoPasta.Location = new System.Drawing.Point(12, 74);
            this.campoPasta.MaxLength = 100;
            this.campoPasta.Name = "campoPasta";
            this.campoPasta.Size = new System.Drawing.Size(558, 27);
            this.campoPasta.TabIndex = 10;
            this.campoPasta.Tag = "";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Roboto", 8.25F);
            this.label5.Location = new System.Drawing.Point(12, 58);
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
            this.buttonExcluir.Location = new System.Drawing.Point(513, 153);
            this.buttonExcluir.Name = "buttonExcluir";
            this.buttonExcluir.Size = new System.Drawing.Size(107, 43);
            this.buttonExcluir.TabIndex = 16;
            this.buttonExcluir.TabStop = false;
            this.buttonExcluir.Text = "Excluir";
            this.buttonExcluir.UseVisualStyleBackColor = false;
            this.buttonExcluir.Click += new System.EventHandler(this.buttonExcluir_Click);
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
            this.buttonCancelar.Location = new System.Drawing.Point(400, 153);
            this.buttonCancelar.Name = "buttonCancelar";
            this.buttonCancelar.Size = new System.Drawing.Size(107, 43);
            this.buttonCancelar.TabIndex = 15;
            this.buttonCancelar.Text = "Cancelar";
            this.buttonCancelar.UseVisualStyleBackColor = false;
            this.buttonCancelar.Click += new System.EventHandler(this.buttonCancelar_Click);
            // 
            // campoNome
            // 
            this.campoNome.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.campoNome.Font = new System.Drawing.Font("Roboto", 12.25F);
            this.campoNome.Location = new System.Drawing.Point(12, 28);
            this.campoNome.MaxLength = 100;
            this.campoNome.Name = "campoNome";
            this.campoNome.Size = new System.Drawing.Size(602, 27);
            this.campoNome.TabIndex = 1;
            this.campoNome.Tag = "*";
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
            this.buttonGravar.Location = new System.Drawing.Point(287, 153);
            this.buttonGravar.Name = "buttonGravar";
            this.buttonGravar.Size = new System.Drawing.Size(107, 43);
            this.buttonGravar.TabIndex = 14;
            this.buttonGravar.Text = "Gravar";
            this.buttonGravar.UseVisualStyleBackColor = false;
            this.buttonGravar.Click += new System.EventHandler(this.buttonGravar_Click);
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
            // 
            // timerFiltro
            // 
            this.timerFiltro.Interval = 300;
            this.timerFiltro.Tick += new System.EventHandler(this.timerFiltro_Tick);
            // 
            // FormGrupo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(626, 562);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panelCadastro);
            this.Name = "FormGrupo";
            this.Text = "Grupos";
            this.Load += new System.EventHandler(this.FormGrupo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panelCadastro.ResumeLayout(false);
            this.panelCadastro.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox textBoxFiltro;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panelCadastro;
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
        private System.Windows.Forms.CheckBox campoAtivo;
        private System.Windows.Forms.Button buttonProcurarPasta;
        private System.Windows.Forms.TextBox campoPasta;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button buttonExcluir;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonCancelar;
        private System.Windows.Forms.TextBox campoNome;
        private System.Windows.Forms.Button buttonGravar;
        private System.Windows.Forms.Label lblCodigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnNome;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnPasta;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ColumnAtivo;
        private System.Windows.Forms.Timer timerFiltro;
    }
}