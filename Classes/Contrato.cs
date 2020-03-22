using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileZillaManager.Classes
{
    public class Contrato
    {
        public int Codigo { get; set; }
        public string Nome { get; set; }
        public string Login { get; set; }
        public string Pass { get; set; }
        public string Pasta { get; set; }
        public decimal Valor { get; set; }
        public bool Ativo { get; set; }
        public DateTime DataContrato { get; set; }
        public string Permissao { get; set; }
        public int? GrupoId { get; set; }
        public bool Monitorar { get; set; } = true;
        public string SenhaCompactacao { get; set; }

        //if (Enum.TryParse<AccessRights>("DirCreate, DirList, FileAppend, FileRead, FileWrite, IsHome", out AccessRights ac))
    }
}
