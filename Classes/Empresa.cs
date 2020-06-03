using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileZillaManager.Classes
{
    public class Empresa
    {
        public int Codigo { get; set; }
        public string Nome { get; set; }
        public string Host { get; set; }
        public string Login { get; set; }
        public string Pass { get; set; }
        public int Port { get; set; }
        public string Exe7zPath { get; set; }

        public string CorPrimaria { get; set; } = "#CD5C5C";
        public string CorSecundaria { get; set; } = "#fff4f4";
        public string CorTerciaria { get; set; } = "#FA8072";
        public string Logotipo { get; set; }

        public int MinDeleteInvalido { get; set; } = 0;

    }
}
