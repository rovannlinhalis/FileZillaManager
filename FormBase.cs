using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileZillaManager
{
    public partial class FormBase : Form
    {
        public List<Thread> listaThreads = new List<Thread>();
        public bool ClosingForm = false;
        public FormBase()
        {
            InitializeComponent();
        }

        private void FormBase_FormClosing(object sender, FormClosingEventArgs e)
        {
            ClosingForm = true;
            if (listaThreads != null)
            {
                foreach (Thread t in listaThreads)
                {
                    t.Abort();
                    try
                    {
                        t.Join();
                    }
                    catch { }
                }

            }
        }
    }
}
