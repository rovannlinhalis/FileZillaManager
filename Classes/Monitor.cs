using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileZillaManager.Classes
{
    public class Monitor
    {
        private string folder;

        /*
CREATE TABLE MONITOR (
FOLDER VARCHAR(260) NOT NULL,
ARQUIVO_STATUS INTEGER,
DATA TIMESTAMP,
FILE_NAME VARCHAR(255),
CONTRATO INTEGER,
FTP_STATUS INTEGER,
INTEGRIDADE INTEGER,
FILE_SIZE NUMERIC(15,0),
ARMAZENAMENTO NUMERIC(15,0),
SUBFOLDER SMALLINT);

ALTER TABLE MONITOR
ADD CONSTRAINT PK_MONITOR
PRIMARY KEY (FOLDER);
*/

        public string Folder { get => folder?.ToLower(); set => folder = value?.ToLower(); }
        public ContratoState ArquivoStatus { get; set; }
        public DateTime Data { get; set; }
        public string FileName { get; set; }
        public int Contrato { get; set; }
        public FTPState FtpStatus { get; set; }
        public ZipCheckState Integridade { get; set; }
        public long? FileSize { get; set; }
        public long? Armazenamento { get; set; }
        public bool IsSubFolder { get; set; }
        public string ContratoFolder { get; set; }
        public DateTime? FileData { get; set; }

    }
}
