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
            //var monitor = Application.OpenForms.OfType<FormMonitor>().Count();
            //if (monitor > 0)
            //{
            //    MessageBox.Show("Feche a janela de Monitor para editar um contrato. Poderá haver erros ao enviar os dados para o servidor FileZilla", "Monitor em Execução", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //}

            FormContrato form = new FormContrato();
            form.Show();
        }

        private void buttonEmpresa_Click(object sender, EventArgs e)
        {
            FormEmpresa form = new FormEmpresa();
            form.ShowDialog();
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
            FormMonitor2 form = new FormMonitor2(this.Empresa);
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

       

        private void buttonApagarHash_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Tem certeza que deseja apagar toda a tabela de hash?","Apagar registros", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                using (Repositorio.FileCheckRepositorio rep = new Repositorio.FileCheckRepositorio())
                {
                    int i = rep.DeleteAll();
                    MessageBox.Show(i + " registros apagados");
                }
            }
        }

        private void buttonSetArmazenamento_Click(object sender, EventArgs e)
        {
            if (decimal.TryParse(textBoxDevInput.Text, out decimal d ))
            {
                string sql = "update CONTRATO set ARMAZENAMENTO = "+d+";";
                FbDataBase.FbDataBase db = new FbDataBase.FbDataBase(Program.ConnectionString());
                int i = db.ExecuteNonQuery(sql);
                MessageBox.Show(i + " Registros alterados");
            }
        }

        private void buttonMonitor2_Click(object sender, EventArgs e)
        {
            FormMonitor2 form = new FormMonitor2(this.Empresa);
            form.Show();
        }

        private void buttonDebugMode_Click(object sender, EventArgs e)
        {
            Program.Debug = true;
        }
    }
}
