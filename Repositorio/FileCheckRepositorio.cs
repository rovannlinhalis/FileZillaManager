﻿using FbDataBase;
using FileZillaManager.Classes;
using FirebirdSql.Data.FirebirdClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileZillaManager.Repositorio
{
    public class FileCheckRepositorio : FbDataBase.FbRepositorio<Classes.FileCheck>
    
    {
        public FileCheckRepositorio()
           : base(new FbDataBase.FbDataBase(Program.ConnectionString()), "FILE_CHECK")
        {
            AddPrimaryKey(x => x.Hash, FbPrimaryKeyType.Manual);
            AddPrimaryKey(x => x.Nome, FbPrimaryKeyType.Manual);

            //AddField(x => x.NomeHash, "NOMEHASH", FbDbType.VarChar);
            AddField(x => x.Hash, "FILEHASH", FbDbType.VarChar);
            AddField(x => x.Nome, "NOME", FbDbType.VarChar);
            AddField(x => x.State, "STATE", FbDbType.Integer);
            AddField(x => x.Contrato, "CONTRATO", FbDbType.Integer);
            AddField(x => x.Data, "DATA", FbDbType.TimeStamp);
            AddField(x => x.FileData, "FILEDATA", FbDbType.TimeStamp);
            AddField(x => x.FileLength, "FILE_TAM", FbDbType.Numeric);

        }

       
        public static string[] DDL()
        {
            return new string[] {
"DROP TABLE FILECHECK",
@"CREATE TABLE FILE_CHECK (
    NOME      VARCHAR(500) NOT NULL,
    STATE     INTEGER,
    CONTRATO  INTEGER,
    DATA      TIMESTAMP,
    FILEHASH  VARCHAR(128) NOT NULL
); ",
@"ALTER TABLE FILE_CHECK ADD CONSTRAINT PK_FILECHECK PRIMARY KEY(NOME, FILEHASH)
USING INDEX PK_FILECHECK_IDX;",

@"ALTER TABLE FILE_CHECK
ADD FILEDATA TIMESTAMP;",
@"ALTER TABLE FILE_CHECK
ADD FILE_TAM NUMERIC(18,0);",

            };
        }

        public List<Classes.FileCheck> SelectAll(string md5Hash, string fileName)
        {
            return this.SelectAll("lower(NOME) = '" + fileName.ToLower() + "' and lower(FILEHASH) = '" + md5Hash.ToLower() + "'");
        }

        public List<Classes.FileCheck> SelectAll(int contrato, DateTime data)
        {
            return this.SelectAll("CONTRATO = " + contrato + " and cast(data as date) = '" + data.ToShortDateString() + "'");
        }

        public int DeleteAll()
        {
            int i = 0;
            string sql = "DELETE FROM FILE_CHECK";
            using (FbConnection conexao = this.Context.CreateConnection())
            {
                conexao.Open();
                i = this.Context.ExecuteNonQuery(conexao, sql);
            }
            return i;
        }
    }
}
