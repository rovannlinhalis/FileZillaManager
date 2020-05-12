namespace FileZillaManager
{
    partial class FormEmpresa
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
            this.label1 = new System.Windows.Forms.Label();
            this.txbNome = new System.Windows.Forms.TextBox();
            this.buttonCancelar = new System.Windows.Forms.Button();
            this.buttonGravar = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtHost = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txbUsuario = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txbSenha = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtPorta = new System.Windows.Forms.TextBox();
            this.lblCodigo = new System.Windows.Forms.Label();
            this.buttonTestarConexao = new System.Windows.Forms.Button();
            this.buttonImportar = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox7ZPath = new System.Windows.Forms.TextBox();
            this.buttonBrowse7z = new System.Windows.Forms.Button();
            this.buttonEnviarDados = new System.Windows.Forms.Button();
            this.siColorInput1 = new FileZillaManager.SiColorInput();
            this.siColorInput2 = new FileZillaManager.SiColorInput();
            this.siColorInput3 = new FileZillaManager.SiColorInput();
            this.buttonBrowseLogo = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.textBoxLogotipo = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Roboto", 8.25F);
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Descrição";
            // 
            // txbNome
            // 
            this.txbNome.Font = new System.Drawing.Font("Roboto", 12.25F);
            this.txbNome.Location = new System.Drawing.Point(12, 25);
            this.txbNome.MaxLength = 100;
            this.txbNome.Name = "txbNome";
            this.txbNome.Size = new System.Drawing.Size(340, 27);
            this.txbNome.TabIndex = 1;
            this.txbNome.Tag = "*";
            // 
            // buttonCancelar
            // 
            this.buttonCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonCancelar.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonCancelar.BackColor = System.Drawing.SystemColors.Window;
            this.buttonCancelar.FlatAppearance.BorderColor = System.Drawing.Color.IndianRed;
            this.buttonCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonCancelar.Font = new System.Drawing.Font("Roboto", 8.25F, System.Drawing.FontStyle.Bold);
            this.buttonCancelar.ForeColor = System.Drawing.Color.IndianRed;
            this.buttonCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonCancelar.Location = new System.Drawing.Point(184, 345);
            this.buttonCancelar.Name = "buttonCancelar";
            this.buttonCancelar.Size = new System.Drawing.Size(107, 43);
            this.buttonCancelar.TabIndex = 11;
            this.buttonCancelar.Text = "Cancelar";
            this.buttonCancelar.UseVisualStyleBackColor = false;
            this.buttonCancelar.Click += new System.EventHandler(this.buttonCancelar_Click);
            // 
            // buttonGravar
            // 
            this.buttonGravar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonGravar.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonGravar.BackColor = System.Drawing.SystemColors.Window;
            this.buttonGravar.FlatAppearance.BorderColor = System.Drawing.Color.IndianRed;
            this.buttonGravar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonGravar.Font = new System.Drawing.Font("Roboto", 8.25F, System.Drawing.FontStyle.Bold);
            this.buttonGravar.ForeColor = System.Drawing.Color.IndianRed;
            this.buttonGravar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonGravar.Location = new System.Drawing.Point(71, 345);
            this.buttonGravar.Name = "buttonGravar";
            this.buttonGravar.Size = new System.Drawing.Size(107, 43);
            this.buttonGravar.TabIndex = 10;
            this.buttonGravar.Text = "Gravar";
            this.buttonGravar.UseVisualStyleBackColor = false;
            this.buttonGravar.Click += new System.EventHandler(this.buttonGravar_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Roboto", 8.25F);
            this.label2.Location = new System.Drawing.Point(12, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Host (IP)";
            // 
            // txtHost
            // 
            this.txtHost.Font = new System.Drawing.Font("Roboto", 12.25F);
            this.txtHost.Location = new System.Drawing.Point(12, 71);
            this.txtHost.MaxLength = 100;
            this.txtHost.Name = "txtHost";
            this.txtHost.Size = new System.Drawing.Size(248, 27);
            this.txtHost.TabIndex = 3;
            this.txtHost.Tag = "*";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Roboto", 8.25F);
            this.label3.Location = new System.Drawing.Point(12, 107);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Usuário";
            // 
            // txbUsuario
            // 
            this.txbUsuario.Font = new System.Drawing.Font("Roboto", 12.25F);
            this.txbUsuario.Location = new System.Drawing.Point(12, 123);
            this.txbUsuario.MaxLength = 100;
            this.txbUsuario.Name = "txbUsuario";
            this.txbUsuario.Size = new System.Drawing.Size(167, 27);
            this.txbUsuario.TabIndex = 7;
            this.txbUsuario.Tag = "*";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Roboto", 8.25F);
            this.label4.Location = new System.Drawing.Point(185, 107);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Senha";
            // 
            // txbSenha
            // 
            this.txbSenha.Font = new System.Drawing.Font("Roboto", 12.25F);
            this.txbSenha.Location = new System.Drawing.Point(185, 123);
            this.txbSenha.MaxLength = 100;
            this.txbSenha.Name = "txbSenha";
            this.txbSenha.PasswordChar = '*';
            this.txbSenha.Size = new System.Drawing.Size(167, 27);
            this.txbSenha.TabIndex = 9;
            this.txbSenha.Tag = "*";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Roboto", 8.25F);
            this.label5.Location = new System.Drawing.Point(266, 55);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(34, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Porta";
            this.label5.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txtPorta
            // 
            this.txtPorta.Font = new System.Drawing.Font("Roboto", 12.25F);
            this.txtPorta.Location = new System.Drawing.Point(266, 71);
            this.txtPorta.MaxLength = 100;
            this.txtPorta.Name = "txtPorta";
            this.txtPorta.Size = new System.Drawing.Size(86, 27);
            this.txtPorta.TabIndex = 5;
            this.txtPorta.Tag = "*N0";
            this.txtPorta.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblCodigo
            // 
            this.lblCodigo.AutoSize = true;
            this.lblCodigo.Location = new System.Drawing.Point(305, 9);
            this.lblCodigo.Name = "lblCodigo";
            this.lblCodigo.Size = new System.Drawing.Size(46, 13);
            this.lblCodigo.TabIndex = 12;
            this.lblCodigo.Text = "_Codigo";
            this.lblCodigo.Visible = false;
            // 
            // buttonTestarConexao
            // 
            this.buttonTestarConexao.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonTestarConexao.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonTestarConexao.BackColor = System.Drawing.SystemColors.Window;
            this.buttonTestarConexao.FlatAppearance.BorderColor = System.Drawing.Color.IndianRed;
            this.buttonTestarConexao.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonTestarConexao.Font = new System.Drawing.Font("Roboto", 8.25F);
            this.buttonTestarConexao.ForeColor = System.Drawing.Color.IndianRed;
            this.buttonTestarConexao.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonTestarConexao.Location = new System.Drawing.Point(12, 299);
            this.buttonTestarConexao.Name = "buttonTestarConexao";
            this.buttonTestarConexao.Size = new System.Drawing.Size(95, 28);
            this.buttonTestarConexao.TabIndex = 13;
            this.buttonTestarConexao.Text = "Testar Conexão";
            this.buttonTestarConexao.UseVisualStyleBackColor = false;
            this.buttonTestarConexao.Click += new System.EventHandler(this.buttonTestarConexao_Click);
            // 
            // buttonImportar
            // 
            this.buttonImportar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonImportar.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonImportar.BackColor = System.Drawing.SystemColors.Window;
            this.buttonImportar.FlatAppearance.BorderColor = System.Drawing.Color.IndianRed;
            this.buttonImportar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonImportar.Font = new System.Drawing.Font("Roboto", 8.25F);
            this.buttonImportar.ForeColor = System.Drawing.Color.IndianRed;
            this.buttonImportar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonImportar.Location = new System.Drawing.Point(245, 299);
            this.buttonImportar.Name = "buttonImportar";
            this.buttonImportar.Size = new System.Drawing.Size(107, 28);
            this.buttonImportar.TabIndex = 14;
            this.buttonImportar.Text = "Importar Dados";
            this.buttonImportar.UseVisualStyleBackColor = false;
            this.buttonImportar.Click += new System.EventHandler(this.buttonImportar_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Roboto", 8.25F);
            this.label6.Location = new System.Drawing.Point(12, 153);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 13);
            this.label6.TabIndex = 15;
            this.label6.Text = "Caminho 7z";
            // 
            // textBox7ZPath
            // 
            this.textBox7ZPath.Font = new System.Drawing.Font("Roboto", 12.25F);
            this.textBox7ZPath.Location = new System.Drawing.Point(12, 169);
            this.textBox7ZPath.MaxLength = 100;
            this.textBox7ZPath.Name = "textBox7ZPath";
            this.textBox7ZPath.ReadOnly = true;
            this.textBox7ZPath.Size = new System.Drawing.Size(302, 27);
            this.textBox7ZPath.TabIndex = 16;
            this.textBox7ZPath.Tag = "*";
            // 
            // buttonBrowse7z
            // 
            this.buttonBrowse7z.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonBrowse7z.BackColor = System.Drawing.SystemColors.Window;
            this.buttonBrowse7z.FlatAppearance.BorderColor = System.Drawing.Color.IndianRed;
            this.buttonBrowse7z.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonBrowse7z.Font = new System.Drawing.Font("Roboto", 8.25F);
            this.buttonBrowse7z.ForeColor = System.Drawing.Color.IndianRed;
            this.buttonBrowse7z.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonBrowse7z.Location = new System.Drawing.Point(320, 168);
            this.buttonBrowse7z.Name = "buttonBrowse7z";
            this.buttonBrowse7z.Size = new System.Drawing.Size(32, 28);
            this.buttonBrowse7z.TabIndex = 17;
            this.buttonBrowse7z.Text = "...";
            this.buttonBrowse7z.UseVisualStyleBackColor = false;
            this.buttonBrowse7z.Click += new System.EventHandler(this.buttonBrowse7z_Click);
            // 
            // buttonEnviarDados
            // 
            this.buttonEnviarDados.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonEnviarDados.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonEnviarDados.BackColor = System.Drawing.SystemColors.Window;
            this.buttonEnviarDados.FlatAppearance.BorderColor = System.Drawing.Color.IndianRed;
            this.buttonEnviarDados.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonEnviarDados.Font = new System.Drawing.Font("Roboto", 8.25F);
            this.buttonEnviarDados.ForeColor = System.Drawing.Color.IndianRed;
            this.buttonEnviarDados.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonEnviarDados.Location = new System.Drawing.Point(132, 299);
            this.buttonEnviarDados.Name = "buttonEnviarDados";
            this.buttonEnviarDados.Size = new System.Drawing.Size(107, 28);
            this.buttonEnviarDados.TabIndex = 18;
            this.buttonEnviarDados.Text = "Enviar Dados";
            this.buttonEnviarDados.UseVisualStyleBackColor = false;
            this.buttonEnviarDados.Click += new System.EventHandler(this.buttonEnviarDados_Click);
            // 
            // siColorInput1
            // 
            this.siColorInput1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.siColorInput1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.siColorInput1.Caption = "Cor Primária";
            this.siColorInput1.Cor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.siColorInput1.Description = "siColorInput1";
            this.siColorInput1.FontCaption = new System.Drawing.Font("Roboto", 8.25F);
            this.siColorInput1.ForeColor = System.Drawing.Color.White;
            this.siColorInput1.Location = new System.Drawing.Point(12, 218);
            this.siColorInput1.MaxLength = 7;
            this.siColorInput1.Name = "siColorInput1";
            this.siColorInput1.Obrigatorio = false;
            this.siColorInput1.PlaceHolder = "#000000";
            this.siColorInput1.Size = new System.Drawing.Size(74, 21);
            this.siColorInput1.TabEnter = true;
            this.siColorInput1.TabIndex = 19;
            this.siColorInput1.Tag = "?";
            this.siColorInput1.Text = "#000000";
            // 
            // siColorInput2
            // 
            this.siColorInput2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.siColorInput2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.siColorInput2.Caption = "Cor Secundária";
            this.siColorInput2.Cor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.siColorInput2.Description = "siColorInput1";
            this.siColorInput2.FontCaption = new System.Drawing.Font("Roboto", 8.25F);
            this.siColorInput2.ForeColor = System.Drawing.Color.White;
            this.siColorInput2.Location = new System.Drawing.Point(92, 218);
            this.siColorInput2.MaxLength = 7;
            this.siColorInput2.Name = "siColorInput2";
            this.siColorInput2.Obrigatorio = false;
            this.siColorInput2.PlaceHolder = "#000000";
            this.siColorInput2.Size = new System.Drawing.Size(86, 21);
            this.siColorInput2.TabEnter = true;
            this.siColorInput2.TabIndex = 21;
            this.siColorInput2.Tag = "?";
            this.siColorInput2.Text = "#000000";
            // 
            // siColorInput3
            // 
            this.siColorInput3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.siColorInput3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.siColorInput3.Caption = "Cor Terciária";
            this.siColorInput3.Cor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.siColorInput3.Description = "siColorInput1";
            this.siColorInput3.FontCaption = new System.Drawing.Font("Roboto", 8.25F);
            this.siColorInput3.ForeColor = System.Drawing.Color.White;
            this.siColorInput3.Location = new System.Drawing.Point(184, 218);
            this.siColorInput3.MaxLength = 7;
            this.siColorInput3.Name = "siColorInput3";
            this.siColorInput3.Obrigatorio = false;
            this.siColorInput3.PlaceHolder = "#000000";
            this.siColorInput3.Size = new System.Drawing.Size(85, 21);
            this.siColorInput3.TabEnter = true;
            this.siColorInput3.TabIndex = 23;
            this.siColorInput3.Tag = "?";
            this.siColorInput3.Text = "#000000";
            // 
            // buttonBrowseLogo
            // 
            this.buttonBrowseLogo.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonBrowseLogo.BackColor = System.Drawing.SystemColors.Window;
            this.buttonBrowseLogo.FlatAppearance.BorderColor = System.Drawing.Color.IndianRed;
            this.buttonBrowseLogo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonBrowseLogo.Font = new System.Drawing.Font("Roboto", 8.25F);
            this.buttonBrowseLogo.ForeColor = System.Drawing.Color.IndianRed;
            this.buttonBrowseLogo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonBrowseLogo.Location = new System.Drawing.Point(320, 257);
            this.buttonBrowseLogo.Name = "buttonBrowseLogo";
            this.buttonBrowseLogo.Size = new System.Drawing.Size(32, 28);
            this.buttonBrowseLogo.TabIndex = 27;
            this.buttonBrowseLogo.Text = "...";
            this.buttonBrowseLogo.UseVisualStyleBackColor = false;
            this.buttonBrowseLogo.Click += new System.EventHandler(this.buttonBrowseLogo_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Roboto", 8.25F);
            this.label7.Location = new System.Drawing.Point(12, 242);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(50, 13);
            this.label7.TabIndex = 25;
            this.label7.Text = "Logotipo";
            // 
            // textBoxLogotipo
            // 
            this.textBoxLogotipo.BackColor = System.Drawing.Color.White;
            this.textBoxLogotipo.Font = new System.Drawing.Font("Roboto", 12.25F);
            this.textBoxLogotipo.Location = new System.Drawing.Point(12, 258);
            this.textBoxLogotipo.MaxLength = 100;
            this.textBoxLogotipo.Name = "textBoxLogotipo";
            this.textBoxLogotipo.ReadOnly = true;
            this.textBoxLogotipo.Size = new System.Drawing.Size(302, 27);
            this.textBoxLogotipo.TabIndex = 26;
            this.textBoxLogotipo.Tag = "";
            // 
            // FormEmpresa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(363, 400);
            this.Controls.Add(this.buttonBrowseLogo);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.textBoxLogotipo);
            this.Controls.Add(this.buttonEnviarDados);
            this.Controls.Add(this.buttonBrowse7z);
            this.Controls.Add(this.siColorInput2);
            this.Controls.Add(this.siColorInput3);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.textBox7ZPath);
            this.Controls.Add(this.siColorInput1);
            this.Controls.Add(this.buttonImportar);
            this.Controls.Add(this.buttonTestarConexao);
            this.Controls.Add(this.lblCodigo);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtPorta);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txbSenha);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txbUsuario);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtHost);
            this.Controls.Add(this.buttonCancelar);
            this.Controls.Add(this.buttonGravar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txbNome);
            this.Name = "FormEmpresa";
            this.Text = "Configurações";
            this.Load += new System.EventHandler(this.FormEmpresa_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txbNome;
        private System.Windows.Forms.Button buttonCancelar;
        private System.Windows.Forms.Button buttonGravar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtHost;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txbUsuario;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txbSenha;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtPorta;
        private System.Windows.Forms.Label lblCodigo;
        private System.Windows.Forms.Button buttonTestarConexao;
        private System.Windows.Forms.Button buttonImportar;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBox7ZPath;
        private System.Windows.Forms.Button buttonBrowse7z;
        private System.Windows.Forms.Button buttonEnviarDados;
        private SiColorInput siColorInput1;
        private SiColorInput siColorInput2;
        private SiColorInput siColorInput3;
        private System.Windows.Forms.Button buttonBrowseLogo;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBoxLogotipo;
    }
}