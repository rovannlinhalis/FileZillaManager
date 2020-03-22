using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FileZillaManager.Classes
{
    public class LocalConfig
    {

        DirectoryInfo diretorio;
        FileInfo fileLocalConfig;
        List<string> mensagemLinha = new List<string>();

        private string mensagem;
        public int status;
        public string statusConfig;
        public string nomeSistema;
        public bool _AutoSave { get; set; } = true;


        public LocalConfig(bool LerArquivo, string xNomeSistema)
        {
            nomeSistema = xNomeSistema;

            diretorio = new DirectoryInfo(System.Environment.GetEnvironmentVariable("APPDATA") + "\\" + nomeSistema + "\\");

            if (!diretorio.Exists)
                diretorio.Create();

            fileLocalConfig = new FileInfo(diretorio.FullName + "\\Config.dat");

            if (fileLocalConfig.Exists && LerArquivo)
                LoadConfig();

            _AutoSave = true;

        }


        bool subPastas, subPastasIndividuais, ocultarVazias;
        public bool SubPastas { get => subPastas; set { subPastas = value;Save();  } }
        public bool SubPastasIndividuais { get => subPastasIndividuais; set { subPastasIndividuais = value; Save();  }
}
        public bool OcultarVazias { get => ocultarVazias; set { ocultarVazias = value; Save(); }}

        private List<LocalConfigListValue> listaOrdemColunas;
        public List<LocalConfigListValue> ListaOrdemColunas { get => listaOrdemColunas; set { listaOrdemColunas = value; Save(); } }

        private List<LocalConfigListValue> listaTamanhoColunas;
        public List<LocalConfigListValue> ListaTamanhoColunas { get => listaTamanhoColunas; set { listaTamanhoColunas = value; Save(); } }

        private void LoadConfig()
        {
            if (fileLocalConfig.Exists)
            {

                try//ler txt dentro da database
                {
                    StreamReader texto = new StreamReader(fileLocalConfig.FullName, Encoding.Default);

                    while ((mensagem = texto.ReadLine()) != null)
                    {
                        mensagemLinha.Add(mensagem.ToString());
                    }

                    texto.Close();

                    LocalConfig obj = new LocalConfig(false, nomeSistema);
                    foreach (System.Reflection.PropertyInfo pr in obj.GetType().GetProperties())
                    {
                        //tw.WriteLine(pr.Name + "=" + pr.GetValue(this, null).ToString());
                        //pr.SetValue(obj, dr[pr.Name].ToString(), null);

                        if (pr.Name[0] == '_')
                            continue;

                        foreach (string s in mensagemLinha)
                        {
                            string[] l = s.Split('=');



                            if (l[0].Contains(";") && pr.PropertyType == typeof(List<LocalConfigListValue>))
                            {
                                //System.Collections.Generic.List`1[[SistemasIntegra.SiLocalConfigListValue, SiLocalConfig, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null]]
                                List<LocalConfigListValue> aux = (List<LocalConfigListValue>)pr.GetValue(this, null);
                                if (aux == null)
                                    aux = new List<LocalConfigListValue>();

                                string[] j = l[0].Split(';');
                                if (j[0] == pr.Name)
                                {
                                    LocalConfigListValue x = new LocalConfigListValue();
                                    x.Nome = j[1];
                                    x.Valor = l[1];
                                    aux.Add(x);
                                }

                                pr.SetValue(this, aux, null);
                            }
                            else
                            {
                                if (pr.Name.Length >= 5)
                                    if (pr.Name.Substring(0, 5).ToLower() == "lista")
                                        continue;

                                if (pr.Name == l[0].ToString())
                                {
                                    if (pr.PropertyType.FullName.ToLower() == "system.decimal")
                                        pr.SetValue(this, String.IsNullOrEmpty(l[1].ToString()) ? 0 : decimal.Parse(l[1].ToString()), null);
                                    else if (pr.PropertyType.FullName.ToLower() == "system.int32")
                                        pr.SetValue(this, String.IsNullOrEmpty(l[1].ToString()) ? 0 : int.Parse(l[1].ToString()), null);
                                    else if (pr.PropertyType.FullName.ToLower() == "system.boolean")
                                        pr.SetValue(this, String.IsNullOrEmpty(l[1].ToString()) ? false : bool.Parse(l[1].ToString()), null);
                                    else
                                        pr.SetValue(this, l[1].ToString(), null);
                                }
                            }
                        }
                    }
                    status = 0;
                    statusConfig = "Arquivo Carregado com sucesso!";
                }
                catch (Exception ex)
                {
                    status = 2;
                    statusConfig = "Erro ao ler arquivo. " + ex.Message;
                }
            }
            else
            {
                status = 1;
                statusConfig = "Arquivo de configuração local não existe.";
            }
        }

        public void SaveConfig()
        {
            bool sucesso = false;
            int t = 0;
            while (!sucesso && t < 50)
            {
                try
                {
                    LocalConfig obj = new LocalConfig(false, nomeSistema);
                    TextWriter tw = new StreamWriter(fileLocalConfig.FullName, false, Encoding.Default);

                    foreach (System.Reflection.PropertyInfo pr in obj.GetType().GetProperties())
                    {
                        if (pr.Name[0] == '_')
                            continue;

                        object valor = pr.GetValue(this, null);

                        if (valor is List<LocalConfigListValue>)
                        {
                            foreach (LocalConfigListValue li in (List<LocalConfigListValue>)valor)
                            {
                                tw.WriteLine(pr.Name + ";" + li.Nome + "=" + (li.Valor == null ? "" : li.Valor.ToString()));
                            }
                        }
                        else
                        {
                            tw.WriteLine(pr.Name + "=" + (valor == null ? "" : valor.ToString()));
                        }
                        //pr.SetValue(obj, dr[pr.Name].ToString(), null);
                    }

                    tw.Close();
                    sucesso = true;
                }
                catch
                {
                    Thread.Sleep(1000);
                    t++;
                }
            }
        }
        private void Save()
        {
            if (_AutoSave)
                SaveConfig();
        }


    }
    public class LocalConfigListValue
    {
        public string Nome { get; set; }
        public object Valor { get; set; }
    }

    public class SiNodeStateConfig
    {
        DirectoryInfo diretorio;
        FileInfo fileNodeConfig;
        List<string> mensagemLinha = new List<string>();
        private string mensagem;
        public int status;
        public string statusConfig;
        public string nomeSistema;

        public SiNodeStateConfig(bool LerArquivo, string xNomeSistema)
        {
            nomeSistema = xNomeSistema;

            diretorio = new DirectoryInfo(System.Environment.GetEnvironmentVariable("APPDATA") + "\\" + nomeSistema + "\\");
            if (!diretorio.Exists)
                diretorio.Create();

            fileNodeConfig = new FileInfo(diretorio.FullName + "\\NodeState.dat");

            if (fileNodeConfig.Exists && LerArquivo)
                LoadConfig();

        }


        List<SiNodeState> listaNodes;

        public List<SiNodeState> ListaNodes
        {
            get { return listaNodes; }
            set { listaNodes = value; SaveConfig(); }
        }

        private void LoadConfig()
        {
            if (fileNodeConfig.Exists)
            {

                try//ler txt dentro da database
                {
                    StreamReader texto = new StreamReader(fileNodeConfig.FullName, Encoding.Default);

                    while ((mensagem = texto.ReadLine()) != null)
                    {
                        mensagemLinha.Add(mensagem.ToString());
                    }

                    texto.Close();
                    List<SiNodeState> lista = new List<SiNodeState>();
                    foreach (string s in mensagemLinha)
                    {
                        string[] l = s.Split('=');
                        SiNodeState aux = new SiNodeState();
                        aux.NodeName = l[0].ToString();
                        aux.Expanded = bool.Parse(l[1].ToString());
                        lista.Add(aux);
                    }

                    listaNodes = lista;

                    status = 0;
                    statusConfig = "Arquivo Carregado com sucesso!";
                }
                catch (Exception ex)
                {
                    status = 2;
                    statusConfig = "Erro ao ler arquivo. " + ex.Message;
                }

            }
            else
            {
                status = 1;
                statusConfig = "Arquivo de configuração de Nodes não existe.";
            }
        }

        private void SaveConfig()
        {
            TextWriter tw = new StreamWriter(fileNodeConfig.FullName, false, Encoding.Default);

            foreach (SiNodeState nd in listaNodes)
            {
                tw.WriteLine(nd.NodeName + "=" + nd.Expanded);
                //pr.SetValue(obj, dr[pr.Name].ToString(), null);
            }

            tw.Close();

        }
    }

    public class SiNodeState
    {
        public string NodeName { get; set; }
        public bool Expanded { get; set; }
    }
}
