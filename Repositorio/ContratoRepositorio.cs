using FbDataBase;
using FileZillaManager.Classes;
using FirebirdSql.Data.FirebirdClient;
using Miracle.FileZilla.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace FileZillaManager.Repositorio
{
    public class ContratoRepositorio : FbDataBase.FbRepositorio<Classes.Contrato>
    {
        public bool byPassFileZilla = false;
        public ContratoRepositorio()
            : base(new FbDataBase.FbDataBase(Program.ConnectionString()), "CONTRATO")
        {
            AddPrimaryKey(x => x.Codigo, FbPrimaryKeyType.AutoIncremment);
            AddField(x => x.Codigo, "CODIGO", FbDbType.Integer);
            AddField(x => x.Nome, "NOME", FbDbType.VarChar);
            AddField(x => x.Login, "LOGIN", FbDbType.VarChar);
            AddField(x => x.Pass, "PASS", FbDbType.VarChar);
            AddField(x => x.Pasta, "PASTA", FbDbType.VarChar);
            AddField(x => x.Valor, "VALOR", FbDbType.Numeric);
            AddField(x => x.DataContrato, "DATA_CONTRATO", FbDbType.Date);
            AddField(x => x.Ativo, "ATIVO", FbDbType.Boolean);
            AddField(x => x.Permissao, "PERMISSAO", FbDbType.VarChar);
            AddField(x => x.GrupoId, "GRUPO", FbDbType.Integer);
            AddField(x => x.SenhaCompactacao, "SENHACOMPACTACAO", FbDbType.VarChar);
            AddField(x => x.Monitorar, "MONITORAR", FbDbType.Boolean);
        }

        public static string[] DDL()
        {
            return new string[] { @"CREATE GENERATOR GEN_CONTRATO_ID;",
@"CREATE TABLE CONTRATO (
    CODIGO      INTEGER NOT NULL,
    NOME        VARCHAR(100),
    LOGIN        VARCHAR(128),
    PASS        VARCHAR(128),
    PASTA        VARCHAR(512),
    VALOR        NUMERIC(15,2),
   DATA_CONTRATO    DATE
);",
@"ALTER TABLE CONTRATO ADD CONSTRAINT PK_CONTRATO PRIMARY KEY (CODIGO);",
//@"SET TERM ^ ;",
@"CREATE OR ALTER TRIGGER CONTRATO_BI FOR CONTRATO
ACTIVE BEFORE INSERT POSITION 0
as
begin
  if (new.codigo is null) then
    new.codigo = gen_id(gen_contrato_id,1);
end",

@"ALTER TABLE CONTRATO
ADD ATIVO SMALLINT;",

@"CREATE UNIQUE INDEX CONTRATO_LOGIN_UNK
ON CONTRATO (LOGIN)",

@"ALTER TABLE CONTRATO
ADD PERMISSAO VARCHAR(512);",

@"ALTER TABLE CONTRATO
ADD GRUPO INTEGER;",

@"ALTER TABLE CONTRATO
ADD CONSTRAINT FK_CONTRATO_GRUPO
FOREIGN KEY (GRUPO)
REFERENCES GRUPO(CODIGO)
ON UPDATE CASCADE",

@"ALTER TABLE CONTRATO
ADD SENHACOMPACTACAO VARCHAR(512);",


@"ALTER TABLE CONTRATO
ADD MONITORAR SMALLINT;",

            };
        }


        public override Contrato Insert(Contrato entity, FbConnection connection, FbTransaction transaction)
        {
            var C =  base.Insert(entity, connection, transaction);

            ProcessaFileZilla(C);
            return C;
        }

        public override int Update(Contrato entity, FbConnection conexao, FbTransaction transaction)
        {
            var C = base.Update(entity, conexao, transaction);

            ProcessaFileZilla(entity);

            return C;
        }

        public override int Delete(Contrato entity, FbConnection conexao, FbTransaction transaction)
        {
            Contrato C = String.IsNullOrEmpty(entity?.Login) ? this.Select(entity.Codigo) : entity;

            var i = base.Delete(entity, conexao, transaction);

            using (EmpresaRepositorio rep = new EmpresaRepositorio())
            {
                
                Empresa e = rep.SelectAll(null).FirstOrDefault();

                if (IPAddress.TryParse(e.Host, out IPAddress ip))
                {
                    using (IFileZillaApi fileZillaApi = new FileZillaApi(ip, e.Port))
                    {
                        fileZillaApi.Connect(e.Pass);
                        if (fileZillaApi.IsConnected)
                        {
                            var accountSettings = fileZillaApi.GetAccountSettings();
                            i+= accountSettings.Users.RemoveAll(x => x.UserName == C.Login);
                            fileZillaApi.SetAccountSettings(accountSettings);
                        }
                    }
                }
            }

            return i;
        
        }

        public void ProcessaFileZilla(Contrato C)
        {
            if (byPassFileZilla)
                return;

            using (EmpresaRepositorio rep = new EmpresaRepositorio())
            {
                using (GrupoRepositorio gRep = new GrupoRepositorio())
                {
                    Empresa e = rep.SelectAll(null).FirstOrDefault();

                    if (IPAddress.TryParse(e.Host, out IPAddress ip))
                    {
                        using (IFileZillaApi fileZillaApi = new FileZillaApi(ip, e.Port))
                        {
                            fileZillaApi.Connect(e.Pass);
                            if (fileZillaApi.IsConnected)
                            {
                                var accountSettings = fileZillaApi.GetAccountSettings();

                                AccessRights ac;
                                if (!Enum.TryParse<AccessRights>(C.Permissao, out ac))
                                {
                                    ac = AccessRights.FileWrite | AccessRights.FileRead | AccessRights.IsHome | AccessRights.FileAppend | AccessRights.DirList | AccessRights.DirCreate;
                                }

                                if (accountSettings.Users.Any(x => x.UserName == C.Login))
                                {
                                    User u = accountSettings.Users.Where(x => x.UserName == C.Login).FirstOrDefault();
                                    u.GroupName = C.GrupoId.HasValue ? gRep.Select(C.GrupoId.Value).Nome : null;
                                    u.Comment = C.Nome;
                                    u.ForceSsl =  TriState.No;
                                    u.Enabled = C.Ativo ? TriState.Yes : TriState.No;
                                    u.SharedFolders.Clear();
                                    u.SharedFolders.Add(new SharedFolder() { Directory = C.Pasta, AccessRights = ac });
                                    if (u.Password != C.Pass)
                                        u.AssignPassword(C.Pass, fileZillaApi.ProtocolVersion);
                                }
                                else
                                {
                                    User u = new User();
                                    u.Comment = C.Nome;
                                    u.GroupName = C.GrupoId.HasValue ? gRep.Select(C.GrupoId.Value).Nome : null;
                                    u.Enabled = C.Ativo ? TriState.Yes : TriState.No;
                                    u.ForceSsl = TriState.No;
                                    u.SharedFolders.Clear();
                                    u.SharedFolders.Add(new SharedFolder() { Directory = C.Pasta, AccessRights = ac });
                                    u.UserName = C.Login;
                                    u.AssignPassword(C.Pass, fileZillaApi.ProtocolVersion);
                                    accountSettings.Users.RemoveAll(x => x.UserName == C.Login);
                                    accountSettings.Users.Add(u);
                                }

                                fileZillaApi.SetAccountSettings(accountSettings);

                            }
                        }
                    }
                }
            }

        }

    }
}
