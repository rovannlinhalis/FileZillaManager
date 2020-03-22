﻿namespace FileZillaManager
{
    partial class FormPrincipal
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.buttonEmpresa = new System.Windows.Forms.Button();
            this.buttonGrupos = new System.Windows.Forms.Button();
            this.buttonAbout = new System.Windows.Forms.Button();
            this.buttonContratos = new System.Windows.Forms.Button();
            this.buttonMonitor = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panelDev = new System.Windows.Forms.Panel();
            this.textBoxDevInput = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.buttonMonitorarTodos = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panelDev.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.IndianRed;
            this.panel1.Controls.Add(this.buttonEmpresa);
            this.panel1.Controls.Add(this.buttonGrupos);
            this.panel1.Controls.Add(this.buttonAbout);
            this.panel1.Controls.Add(this.buttonContratos);
            this.panel1.Controls.Add(this.buttonMonitor);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.ForeColor = System.Drawing.Color.White;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(119, 474);
            this.panel1.TabIndex = 0;
            // 
            // buttonEmpresa
            // 
            this.buttonEmpresa.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonEmpresa.FlatAppearance.BorderSize = 0;
            this.buttonEmpresa.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonEmpresa.Location = new System.Drawing.Point(0, 173);
            this.buttonEmpresa.Name = "buttonEmpresa";
            this.buttonEmpresa.Size = new System.Drawing.Size(119, 47);
            this.buttonEmpresa.TabIndex = 4;
            this.buttonEmpresa.Text = "Configurações";
            this.buttonEmpresa.UseVisualStyleBackColor = true;
            this.buttonEmpresa.Click += new System.EventHandler(this.buttonEmpresa_Click);
            // 
            // buttonGrupos
            // 
            this.buttonGrupos.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonGrupos.FlatAppearance.BorderSize = 0;
            this.buttonGrupos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonGrupos.Location = new System.Drawing.Point(0, 126);
            this.buttonGrupos.Name = "buttonGrupos";
            this.buttonGrupos.Size = new System.Drawing.Size(119, 47);
            this.buttonGrupos.TabIndex = 3;
            this.buttonGrupos.Text = "Grupos";
            this.buttonGrupos.UseVisualStyleBackColor = true;
            this.buttonGrupos.Click += new System.EventHandler(this.buttonGrupos_Click);
            // 
            // buttonAbout
            // 
            this.buttonAbout.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.buttonAbout.FlatAppearance.BorderSize = 0;
            this.buttonAbout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAbout.Location = new System.Drawing.Point(0, 427);
            this.buttonAbout.Name = "buttonAbout";
            this.buttonAbout.Size = new System.Drawing.Size(119, 47);
            this.buttonAbout.TabIndex = 5;
            this.buttonAbout.Text = "Sobre";
            this.buttonAbout.UseVisualStyleBackColor = true;
            this.buttonAbout.Click += new System.EventHandler(this.buttonAbout_Click);
            // 
            // buttonContratos
            // 
            this.buttonContratos.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonContratos.FlatAppearance.BorderSize = 0;
            this.buttonContratos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonContratos.Location = new System.Drawing.Point(0, 79);
            this.buttonContratos.Name = "buttonContratos";
            this.buttonContratos.Size = new System.Drawing.Size(119, 47);
            this.buttonContratos.TabIndex = 2;
            this.buttonContratos.Text = "Contratos";
            this.buttonContratos.UseVisualStyleBackColor = true;
            this.buttonContratos.Click += new System.EventHandler(this.buttonContratos_Click);
            // 
            // buttonMonitor
            // 
            this.buttonMonitor.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonMonitor.FlatAppearance.BorderSize = 0;
            this.buttonMonitor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonMonitor.Location = new System.Drawing.Point(0, 32);
            this.buttonMonitor.Name = "buttonMonitor";
            this.buttonMonitor.Size = new System.Drawing.Size(119, 47);
            this.buttonMonitor.TabIndex = 1;
            this.buttonMonitor.Text = "Monitor";
            this.buttonMonitor.UseVisualStyleBackColor = true;
            this.buttonMonitor.Click += new System.EventHandler(this.buttonMonitor_Click);
            // 
            // panel2
            // 
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(119, 32);
            this.panel2.TabIndex = 0;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Image = global::FileZillaManager.Properties.Resources.filezilla_logo;
            this.pictureBox1.Location = new System.Drawing.Point(119, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(605, 474);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // panelDev
            // 
            this.panelDev.Controls.Add(this.buttonMonitorarTodos);
            this.panelDev.Controls.Add(this.textBoxDevInput);
            this.panelDev.Controls.Add(this.button1);
            this.panelDev.Location = new System.Drawing.Point(125, 12);
            this.panelDev.Name = "panelDev";
            this.panelDev.Size = new System.Drawing.Size(157, 267);
            this.panelDev.TabIndex = 2;
            this.panelDev.Visible = false;
            // 
            // textBoxDevInput
            // 
            this.textBoxDevInput.Location = new System.Drawing.Point(3, 5);
            this.textBoxDevInput.Name = "textBoxDevInput";
            this.textBoxDevInput.Size = new System.Drawing.Size(151, 21);
            this.textBoxDevInput.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(3, 32);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(151, 35);
            this.button1.TabIndex = 0;
            this.button1.Text = "Definir Senha Compactação";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.buttonSetSenhaCompactacao_Click);
            // 
            // buttonMonitorarTodos
            // 
            this.buttonMonitorarTodos.Location = new System.Drawing.Point(3, 73);
            this.buttonMonitorarTodos.Name = "buttonMonitorarTodos";
            this.buttonMonitorarTodos.Size = new System.Drawing.Size(151, 35);
            this.buttonMonitorarTodos.TabIndex = 2;
            this.buttonMonitorarTodos.Text = "Habilitar Monitorar";
            this.buttonMonitorarTodos.UseVisualStyleBackColor = true;
            this.buttonMonitorarTodos.Click += new System.EventHandler(this.buttonMonitorarTodos_Click);
            // 
            // FormPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(724, 474);
            this.Controls.Add(this.panelDev);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.panel1);
            this.KeyPreview = true;
            this.Name = "FormPrincipal";
            this.Text = "FileZilla Manager - Rovann.com.br";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FormPrincipal_KeyDown);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panelDev.ResumeLayout(false);
            this.panelDev.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button buttonContratos;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button buttonEmpresa;
        private System.Windows.Forms.Button buttonAbout;
        private System.Windows.Forms.Button buttonMonitor;
        private System.Windows.Forms.Button buttonGrupos;
        private System.Windows.Forms.Panel panelDev;
        private System.Windows.Forms.TextBox textBoxDevInput;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button buttonMonitorarTodos;
    }
}

