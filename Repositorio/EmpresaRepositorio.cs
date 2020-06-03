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
            AddField(x => x.CorPrimaria, "COR1", FbDbType.VarChar);
            AddField(x => x.CorSecundaria, "COR2", FbDbType.VarChar);
            AddField(x => x.CorTerciaria, "COR3", FbDbType.VarChar);
            AddField(x => x.Logotipo, "LOGO", FbDbType.VarChar);
            AddField(x => x.MinDeleteInvalido, "MIN_DEL_INVALIDO", FbDbType.Integer);
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
ADD PATH7Z VARCHAR(1024);",
@"ALTER TABLE EMPRESA
ADD COR1 VARCHAR(7);",
@"ALTER TABLE EMPRESA
ADD COR2 VARCHAR(7);",
@"ALTER TABLE EMPRESA
ADD COR3 VARCHAR(7);",
@"ALTER TABLE EMPRESA
ADD LOGO VARCHAR(1024);",
@"ALTER TABLE EMPRESA
ADD MIN_DEL_INVALIDO INTEGER;"
            };
        }

    }
}
