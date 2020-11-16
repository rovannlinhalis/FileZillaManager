using FbDataBase;
using FirebirdSql.Data.FirebirdClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileZillaManager.Repositorio
{
    public class MonitorRepositorio : FbDataBase.FbRepositorio<Classes.Monitor>
    {
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

        public MonitorRepositorio()
            : base(new FbDataBase.FbDataBase(Program.ConnectionString()), "MONITOR")
        {
            AddPrimaryKey(x => x.Folder, FbPrimaryKeyType.Manual);
            AddField(x => x.Folder, "FOLDER", FbDbType.VarChar);
            AddField(x => x.ArquivoStatus, "ARQUIVO_STATUS", FbDbType.Integer);
            AddField(x => x.Data, "DATA", FbDbType.TimeStamp);
            AddField(x => x.FileName, "FILE_NAME", FbDbType.VarChar);
            AddField(x => x.Contrato, "CONTRATO", FbDbType.Integer);
            AddField(x => x.FtpStatus, "FTP_STATUS", FbDbType.Integer);
            AddField(x => x.Integridade, "INTEGRIDADE", FbDbType.Integer);
            AddField(x => x.FileSize, "FILE_SIZE", FbDbType.Numeric);
            AddField(x => x.Armazenamento, "ARMAZENAMENTO", FbDbType.Numeric);
            AddField(x => x.IsSubFolder, "SUBFOLDER", FbDbType.SmallInt);
        }

        public static string[] DDL()
        {
            return new string[] { 
  @"CREATE TABLE MONITOR (
    FOLDER VARCHAR(260) NOT NULL,
    ARQUIVO_STATUS INTEGER,
    DATA TIMESTAMP,
    FILE_NAME VARCHAR(255),
    CONTRATO INTEGER,
    FTP_STATUS INTEGER,
    INTEGRIDADE INTEGER,
    FILE_SIZE NUMERIC(15,0),
    ARMAZENAMENTO NUMERIC(15,0),
    SUBFOLDER SMALLINT);",

  @"ALTER TABLE MONITOR
    ADD CONSTRAINT PK_MONITOR
    PRIMARY KEY (FOLDER);",
           
            };
        }

        public async Task<int> LimparContrato(int contrato)
        {
            int i = 0;
            string sql = "DELETE FROM MONITOR WHERE CONTRATO = " + contrato;

            using (FbConnection conexao = this.Context.CreateConnection())
            {
                conexao.Open();
                i = await  this.Context.ExecuteNonQueryAsync(conexao, sql);
            }
            return i;
        }

        public Classes.Monitor Select(string folder)
        {
            return this.SelectAll("lower(FOLDER) = '" + folder.ToLower() + "'")?.FirstOrDefault();
        }

    }
}
