using FbDataBase;
using FileZillaManager.Classes;
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
            DefaultIsolationLevel = System.Data.IsolationLevel.ReadCommitted;


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
            AddField(x => x.IsSubFolder, "SUBFOLDER", FbDbType.Boolean);
            AddField(x => x.ContratoFolder, "CONTRATO_FOLDER", FbDbType.VarChar);
            AddField(x => x.FileData, "FILE_DATA", FbDbType.TimeStamp);
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


@"ALTER TABLE MONITOR
ADD CONTRATO_FOLDER VARCHAR(512);",

@"ALTER TABLE MONITOR
ADD FILE_DATA TIMESTAMP;",

            };
        }

        public async Task<Monitor> InsertOrUpdateAsync(Monitor entity, FbConnection connection, FbTransaction transaction)
        {
            int i = await this.Context.ExecuteNonQueryAsync(connection, "SELECT COUNT(*) FROM MONITOR WHERE LOWER(FOLDER) = '" + entity.Folder.ToLower() + "'", null, transaction);

            if (i > 0)
            {
                this.Update(entity, connection, transaction);
                return entity;
            }
            else
            {
                return base.Insert(entity, connection, transaction);
            }
        }

        public async Task<Monitor> InsertOrUpdateAsync(Monitor entity)
        {
            Monitor r;
            using (FbConnection _connection = this.Context.CreateConnection())
            {
                await _connection.OpenAsync();
                using (FbTransaction _transaction = _connection.BeginTransaction(DefaultIsolationLevel))
                {
                    r=  await InsertOrUpdateAsync(entity, _connection, _transaction);
                    _transaction.Commit();
                }
            }

            return r;

        }

        public async Task<int> LimparContrato(int contrato)
        {
            int i = 0;
            string sql = "DELETE FROM MONITOR WHERE CONTRATO = " + contrato;

            using (FbConnection conexao = this.Context.CreateConnection())
            {
                conexao.Open();
                i = await this.Context.ExecuteNonQueryAsync(conexao, sql);
            }
            return i;
        }

        public Classes.Monitor Select(string folder)
        {
            return this.SelectAll("lower(FOLDER) = '" + folder.ToLower() + "'")?.FirstOrDefault();
        }

        public async Task<int> Delete(string folder, int contrato)
        {
            int i = 0;
            string sql = "DELETE FROM MONITOR WHERE lower(FOLDER) = '" + folder.ToLower() + "' and CONTRATO = "+ contrato;

            using (FbConnection conexao = this.Context.CreateConnection())
            {
                conexao.Open();
                i = await this.Context.ExecuteNonQueryAsync(conexao, sql);
            }
            return i;
        }



    }
}
