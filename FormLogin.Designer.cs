namespace FileZillaManager
{
    partial class FormLogin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormLogin));
            this.cb_Empresa = new System.Windows.Forms.ComboBox();
            this.lb_Empresa = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.bt_Sair = new System.Windows.Forms.Button();
            this.bt_Entrar = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // cb_Empresa
            // 
            this.cb_Empresa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_Empresa.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.cb_Empresa.FormattingEnabled = true;
            this.cb_Empresa.Items.AddRange(new object[] {
            "select *",
            "from empresa"});
            this.cb_Empresa.Location = new System.Drawing.Point(204, 62);
            this.cb_Empresa.Name = "cb_Empresa";
            this.cb_Empresa.Size = new System.Drawing.Size(250, 28);
            this.cb_Empresa.TabIndex = 0;
            // 
            // lb_Empresa
            // 
            this.lb_Empresa.AutoSize = true;
            this.lb_Empresa.BackColor = System.Drawing.Color.Transparent;
            this.lb_Empresa.ForeColor = System.Drawing.Color.IndianRed;
            this.lb_Empresa.Location = new System.Drawing.Point(204, 46);
            this.lb_Empresa.Name = "lb_Empresa";
            this.lb_Empresa.Size = new System.Drawing.Size(112, 13);
            this.lb_Empresa.TabIndex = 4;
            this.lb_Empresa.Text = "Selecione a Empresa";
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label1.ForeColor = System.Drawing.Color.IndianRed;
            this.label1.Location = new System.Drawing.Point(0, 188);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(466, 20);
            this.label1.TabIndex = 6;
            this.label1.Text = "FileZillaManager v1.0 - www.rovann.com.br";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // bt_Sair
            // 
            this.bt_Sair.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.bt_Sair.FlatAppearance.MouseDownBackColor = System.Drawing.Color.IndianRed;
            this.bt_Sair.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.bt_Sair.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt_Sair.ForeColor = System.Drawing.Color.IndianRed;
            this.bt_Sair.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bt_Sair.Location = new System.Drawing.Point(332, 96);
            this.bt_Sair.Name = "bt_Sair";
            this.bt_Sair.Size = new System.Drawing.Size(122, 43);
            this.bt_Sair.TabIndex = 2;
            this.bt_Sair.Text = "Sair";
            this.bt_Sair.UseVisualStyleBackColor = true;
            this.bt_Sair.Click += new System.EventHandler(this.bt_Sair_Click);
            // 
            // bt_Entrar
            // 
            this.bt_Entrar.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.bt_Entrar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.IndianRed;
            this.bt_Entrar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.bt_Entrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt_Entrar.ForeColor = System.Drawing.Color.IndianRed;
            this.bt_Entrar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bt_Entrar.Location = new System.Drawing.Point(204, 96);
            this.bt_Entrar.Name = "bt_Entrar";
            this.bt_Entrar.Size = new System.Drawing.Size(122, 43);
            this.bt_Entrar.TabIndex = 1;
            this.bt_Entrar.Text = "Entrar";
            this.bt_Entrar.UseVisualStyleBackColor = true;
            this.bt_Entrar.Click += new System.EventHandler(this.bt_Entrar_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = global::FileZillaManager.Properties.Resources.filezilla_logo;
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(186, 173);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // FormLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = global::FileZillaManager.Properties.Resources.BackgroundLogin;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(466, 208);
            this.Controls.Add(this.lb_Empresa);
            this.Controls.Add(this.cb_Empresa);
            this.Controls.Add(this.bt_Sair);
            this.Controls.Add(this.bt_Entrar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Roboto", 8.25F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Abertura do Sistema";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.frm_EmpresaSelect_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cb_Empresa;
        private System.Windows.Forms.Button bt_Entrar;
        private System.Windows.Forms.Button bt_Sair;
        private System.Windows.Forms.Label lb_Empresa;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
    }
}