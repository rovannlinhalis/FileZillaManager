using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileZillaManager.Classes
{
    public class Grupo
    {
        public int Codigo { get; set; }
        public string Nome { get; set; }
        public string Permissao { get; set; }
        public string Pasta { get; set; }
        public bool Ativo { get; set; }
    }
}
