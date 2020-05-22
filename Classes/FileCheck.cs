using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileZillaManager.Classes
{
    public class FileCheck
    {
        //public string NomeHash { get => Nome + Hash; }
        public string Hash { get; set; }
        public string Nome { get; set; }
        public ZipCheckState  State { get; set; }
        public int Contrato { get; set; }
        public DateTime Data { get; set; }

        public DateTime FileData { get; set; }
        public long FileLength { get; set; }
    }
}
