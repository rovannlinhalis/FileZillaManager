﻿using FileZillaManager.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileZillaManager
{
    public partial class FormPrincipal : FormBase
    {
       Empresa Empresa { get; set; }
        public FormPrincipal(Empresa _empresa)
        {
            this.Empresa = _empresa;
            InitializeComponent();
        }

        private void buttonContratos_Click(object sender, EventArgs e)
        {
            FormContrato form = new FormContrato();
            form.Show();
        }

        private void buttonEmpresa_Click(object sender, EventArgs e)
        {
            FormEmpresa form = new FormEmpresa();
            form.Show();
            using (Repositorio.EmpresaRepositorio rep = new Repositorio.EmpresaRepositorio())
            {
                this.Empresa = rep.SelectAll(null).FirstOrDefault();
            }
        }

        private void buttonAbout_Click(object sender, EventArgs e)
        {
            AboutBox1 form = new AboutBox1();
            form.ShowDialog();
        }

        private void buttonMonitor_Click(object sender, EventArgs e)
        {
            FormMonitor form = new FormMonitor(this.Empresa);
            form.Show();
        }

        private void buttonGrupos_Click(object sender, EventArgs e)
        {
            FormGrupo form = new FormGrupo();
            form.Show();
        }

        private void FormPrincipal_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.Alt && e.KeyCode == Keys.D)
            {
                panelDev.Visible = !panelDev.Visible;
            }
        }

        private void buttonSetSenhaCompactacao_Click(object sender, EventArgs e)
        {
            string sql = "update CONTRATO set SENHACOMPACTACAO = '"+textBoxDevInput.Text+"';";
            FbDataBase.FbDataBase db = new FbDataBase.FbDataBase(Program.ConnectionString());
            int i = db.ExecuteNonQuery(sql);
            MessageBox.Show(i + " Registros alterados");
        }

        private void buttonMonitorarTodos_Click(object sender, EventArgs e)
        {
            string sql = "update CONTRATO set MONITORAR = '1';";
            FbDataBase.FbDataBase db = new FbDataBase.FbDataBase(Program.ConnectionString());
            int i = db.ExecuteNonQuery(sql);
            MessageBox.Show(i + " Registros alterados");
        }
    }
}
