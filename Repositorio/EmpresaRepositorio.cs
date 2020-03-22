using FbDataBase;
using FirebirdSql.Data.FirebirdClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileZillaManager.Repositorio
{
    public class EmpresaRepositorio : FbDataBase.FbRepositorio<Classes.Empresa>
    {
        public EmpresaRepositorio()
            : base(new FbDataBase.FbDataBase(Program.ConnectionString()), "EMPRESA")
        {
            AddPrimaryKey(x => x.Codigo, FbPrimaryKeyType.AutoIncremment);
            AddField(x => x.Codigo, "CODIGO", FbDbType.Integer);
            AddField(x => x.Nome, "NOME", FbDbType.VarChar);
            AddField(x => x.Host, "HOST", FbDbType.VarChar);
            AddField(x => x.Login, "LOGIN", FbDbType.VarChar);
            AddField(x => x.Pass, "PASS", FbDbType.VarChar);
            AddField(x => x.Port, "PORT", FbDbType.Numeric);
            AddField(x => x.Exe7zPath, "PATH7Z", FbDbType.VarChar);
            
        }

        public static string[] DDL()
        {
            return new string[] { @"CREATE GENERATOR GEN_EMPRESA_ID;",
@"CREATE TABLE EMPRESA (
    CODIGO      INTEGER NOT NULL,
    NOME        VARCHAR(100),
    HOST        VARCHAR(128),
    LOGIN        VARCHAR(128),
    PASS        VARCHAR(128),
    PORT        NUMERIC(5)
);",
@"ALTER TABLE EMPRESA ADD CONSTRAINT PK_EMPRESA PRIMARY KEY (CODIGO);",
//@"SET TERM ^ ;",
@"CREATE OR ALTER TRIGGER EMPRESA_BI FOR EMPRESA
ACTIVE BEFORE INSERT POSITION 0
as
begin
  if (new.codigo is null) then
    new.codigo = gen_id(gen_empresa_id,1);
end",
@"ALTER TABLE EMPRESA
ADD PATH7Z VARCHAR(1024);"
            };
        }

    }
}
