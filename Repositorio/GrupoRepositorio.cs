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
    public class GrupoRepositorio : FbDataBase.FbRepositorio<Classes.Grupo>
    {
        public bool byPassFileZilla = false;
        public GrupoRepositorio()
            : base(new FbDataBase.FbDataBase(Program.ConnectionString()), "GRUPO")
        {
            AddPrimaryKey(x => x.Codigo, FbPrimaryKeyType.AutoIncremment);
            AddField(x => x.Codigo, "CODIGO", FbDbType.Integer);
            AddField(x => x.Nome, "NOME", FbDbType.VarChar);
            AddField(x => x.Permissao, "PERMISSAO", FbDbType.VarChar);
            AddField(x => x.Ativo, "ATIVO", FbDbType.Boolean);
            AddField(x => x.Pasta, "PASTA", FbDbType.VarChar);

        }

        public static string[] DDL()
        {
            return new string[] { @"CREATE GENERATOR GEN_GRUPO_ID;",
@"CREATE TABLE GRUPO (
    CODIGO      INTEGER NOT NULL,
    NOME        VARCHAR(100)
);",
@"ALTER TABLE GRUPO ADD CONSTRAINT PK_GRUPO PRIMARY KEY (CODIGO);",
//@"SET TERM ^ ;",
@"CREATE OR ALTER TRIGGER GRUPO_BI FOR GRUPO
ACTIVE BEFORE INSERT POSITION 0
as
begin
  if (new.codigo is null) then
    new.codigo = gen_id(gen_grupo_id,1);
end",

@"ALTER TABLE GRUPO
ADD PERMISSAO VARCHAR(512);",

@"ALTER TABLE GRUPO
ADD ATIVO SMALLINT;",

@"ALTER TABLE GRUPO
ADD PASTA VARCHAR(512);"
            };
        }

        public override Grupo Insert(Grupo entity, FbConnection connection, FbTransaction transaction)
        {
            var C = base.Insert(entity, connection, transaction);

            ProcessaFileZilla(C);
            return C;
        }

        public override int Update(Grupo entity, FbConnection conexao, FbTransaction transaction)
        {
            var C = base.Update(entity, conexao, transaction);

            ProcessaFileZilla(entity);

            return C;
        }

        public override int Delete(Grupo entity, FbConnection conexao, FbTransaction transaction)
        {
            Grupo C = String.IsNullOrEmpty(entity?.Nome) ? this.Select(entity.Codigo) : entity;

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
                            i += accountSettings.Groups.RemoveAll(x => x.GroupName == C.Nome);
                            fileZillaApi.SetAccountSettings(accountSettings);
                        }
                    }
                }
            }

            return i;
        }

        protected void ProcessaFileZilla(Grupo C)
        {
            if (byPassFileZilla)
                return;

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

                            AccessRights ac;
                            if (!Enum.TryParse<AccessRights>(C.Permissao, out ac))
                            {
                                ac = AccessRights.FileWrite | AccessRights.FileRead | AccessRights.IsHome | AccessRights.FileAppend | AccessRights.DirList | AccessRights.DirCreate;
                            }

                            if (accountSettings.Groups.Any(x => x.GroupName == C.Nome))
                            {
                                Group u = accountSettings.Groups.Where(x => x.GroupName == C.Nome).FirstOrDefault();
                                u.ForceSsl =  TriState.No;
                                u.GroupName = u.Comment = C.Nome;

                                u.Enabled = C.Ativo ? TriState.Yes : TriState.No;
                                u.SharedFolders.Clear();
                                u.SharedFolders.Add(new SharedFolder() { Directory = C.Pasta, AccessRights = ac });
                            }
                            else
                            {
                                Group u = new Group();
                                u.ForceSsl = TriState.No;
                                u.GroupName = u.Comment = C.Nome;
                                u.Enabled = C.Ativo ? TriState.Yes : TriState.No;
                                u.SharedFolders.Clear();
                                u.SharedFolders.Add(new SharedFolder() { Directory = C.Pasta, AccessRights = ac });
                                accountSettings.Groups.RemoveAll(x => x.GroupName == C.Nome);
                                accountSettings.Groups.Add(u);
                            }

                            fileZillaApi.SetAccountSettings(accountSettings);

                        }
                    }
                }

            }

        }

    }
}
