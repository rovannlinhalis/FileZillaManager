using Miracle.FileZilla.Api;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FileZillaManager.Classes
{
    public class MonitorViewModel : INotifyPropertyChanged
    {
        public MonitorViewModel(Empresa _emp)
        {
            this.Empresa = _emp;
        }

        private string msgErro;
        private bool monitorarSubPastasIndividualmente;
        private bool monitorarSubPastas;
        private bool ocultarPastasVazias;
        //private DateTime dataReferencia;
        private Empresa empresa;
        
        
        LocalConfig config = new LocalConfig(true, "FileZillaManager");
       
        public bool Running { get; set; } = false;
        public SortableBindingList<ContratoViewModel> Contratos { get; set; } = new SortableBindingList<ContratoViewModel>();
        public Empresa Empresa { get => empresa; set { empresa = value; RaisePropertyChanged("Empresa"); } }
        public DateTime DataReferencia { get; set; } = DateTime.MinValue;
        public bool OcultarPastasVazias { get => ocultarPastasVazias; set { ocultarPastasVazias = value; RaisePropertyChanged("OcultarPastasVazias"); } }
        public bool MonitorarSubPastas { get => monitorarSubPastas; set { monitorarSubPastas = value; RaisePropertyChanged("MonitorarSubPastas"); } }
        public bool MonitorarSubPastasIndividualmente { get => monitorarSubPastasIndividualmente; set { monitorarSubPastasIndividualmente = value; RaisePropertyChanged("MonitorarSubPastasIndividualmente"); } }
        public string MsgErro { get => msgErro; set { msgErro = value; RaisePropertyChanged("MsgErro"); } }
        public string StatusServidor { get; set; }
        public string StatusConexoes { get; set; }
        public static List<Connection> Conexoes { get; set; } = new List<Connection>();
        public Color ServerColor { get; set; } = Color.Blue;

        List<ContratoViewModel> cache = new List<ContratoViewModel>();

        public event PropertyChangedEventHandler PropertyChanged;
        //public event StatusChangedHandler StatusChanged;
        //public delegate void StatusChangedHandler(ContratoViewModel sender, EventArgs e);
        public event ProcessaContratosEndHandler ProcessaContratosEnd;
        public delegate void ProcessaContratosEndHandler(object sender, EventArgs e);
        private void RaisePropertyChanged(string prop)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));

        }

        public void ClearAll()
        {
            cache.ForEach(x => x.Dispose());
            cache.Clear();
            foreach (var c in Contratos)
                c.Dispose();
            Contratos.Clear();

        }


        public Task<List<Contrato>> GetContratos()
        {
            return Task.Factory.StartNew<List<Contrato>>(() =>
            {
                List<Contrato> contratos;
                //List<ContratoViewModel> listaAux = new List<ContratoViewModel>();
                using (Repositorio.ContratoRepositorio rep = new Repositorio.ContratoRepositorio())
                {
                    contratos = rep.SelectAll("ATIVO = 1 AND MONITORAR = 1");
                }
                return contratos;
            });
        }
        public async void ProcessaContratos()
        {
            var contratos = await GetContratos();
            cache.ForEach(x => x.Dispose());
            cache.Clear();
            
            foreach (var c in contratos)
            {
                ContratoViewModel model;
                try
                {
                    //DirectoryInfo dir = new DirectoryInfo(c.Pasta);

                    //model = new ContratoViewModel(c, dir.FullName, false, DataReferencia, this.Empresa);
                    //cache.Add(model);


                    //foreach (DirectoryInfo d in dir.GetDirectories("*", SearchOption.AllDirectories))
                    //{
                    //    model = new ContratoViewModel(c, d.FullName, false, DataReferencia, this.Empresa);
                    //    cache.Add(model);
                    //}


                    if (MonitorarSubPastasIndividualmente)
                    {
                        DirectoryInfo dir = new DirectoryInfo(c.Pasta);
                        foreach (DirectoryInfo d in dir.GetDirectories("*", MonitorarSubPastas ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly))
                        {
                            model = new ContratoViewModel(c, d.FullName, false, DataReferencia, this.Empresa);
                            cache.Add(model);
                        }
                        model = new ContratoViewModel(c, c.Pasta, false, DataReferencia, this.Empresa);
                        cache.Add(model);
                    }
                    else
                    {
                        model = new ContratoViewModel(c, c.Pasta, MonitorarSubPastas, DataReferencia, this.Empresa);
                        cache.Add(model);
                    }
                }
                catch (Exception ex)
                {
                    MsgErro = ex.Message;
                }
            }

            foreach (var c in Contratos)
                c.LastLerDiretorio = DateTime.MinValue;

            ProcessaCache();

            if (ProcessaContratosEnd != null)
                ProcessaContratosEnd(this, new EventArgs());

        }
        public void ProcessarArquivos()
        {
            //foreach (var c in cache.Where(x=> !Contratos.Any(y=>y.Pasta == x.Pasta && y.Login == x.Login ) && ( x.Status == ContratoState.NaoVerificado || x.Status == ContratoState.Erro || x.Integridade == ZipCheckState.Erro)).OrderBy(x => x.LastLerDiretorio))
            foreach (var c in cache.Where(x => !x.LendoDiretorio &&  !Contratos.Any(y => y.Pasta == x.Pasta && y.Login == x.Login) && DateTime.Now - x.LastLerDiretorio >= TimeSpan.FromSeconds(1)).OrderBy(x => x.LastLerDiretorio))
            {
                c.LerDiretorio();
            }

            foreach (var c in Contratos.Where(x=> !x.LendoDiretorio &&  DateTime.Now - x.LastLerDiretorio >= TimeSpan.FromSeconds(1)).OrderBy(x=>x.LastLerDiretorio))
            {
                c.LerDiretorio();
            }


            GetServerStatus();

            foreach (var c in Contratos)
            {
                c.CheckStatusFTP();
            }


            for (int i = 0; i < Contratos.Count(); i++)
            {
                if (this.OcultarPastasVazias && Contratos[i].Status == ContratoState.DiretorioVazio)
                {
                    Contratos.RemoveAt(i);
                    i--;
                }
            }


            //while (Contratos.Any(x => x.Integridade == ZipCheckState.AguardandoProcesso) || Contratos.Any(x => x.Integridade == ZipCheckState.AguardandoVerificacao || x.Integridade == ZipCheckState.Erro))

            foreach (var c in Contratos.Where(x => x.FtpState != FTPState.Recebendo && ( x.Integridade == ZipCheckState.AguardandoProcesso || x.Integridade == ZipCheckState.AguardandoVerificacao || x.Integridade == ZipCheckState.Erro || DateTime.Now - x.LastHashDate > TimeSpan.FromMinutes(10))).OrderBy(x => x.LastHashDate))
            {
                try
                {
                    if (Contratos.Where(x => x.VerificandoHash)?.Count() < 6)
                    {
                        if (!c.VerificandoHash)
                        {
                            c.VerificarHash();
                        }
                    }
                }
                catch { }
            }


            foreach (var c in Contratos.Where(x => x.Integridade == ZipCheckState.AguardandoVerificacao).OrderBy(x => x.lastIntegrityDate))
            {
                try
                {
                    if (Contratos.Where(x => x.VerificandoIntegridade)?.Count() < 3)
                    {
                        c.VerificarIntegridade();
                    }
                }
                catch { }
            }

        }
        private void ProcessaCache()
        {

            cache.ForEach(x =>
          {
              if (!Contratos.Any(y => y.Login == x.Login && y.Pasta == x.Pasta))
              {
                  Contratos.Add(x);
              }
              else
              {
                  var c = Contratos.Where(y => y.Login == x.Login && y.Pasta == x.Pasta).FirstOrDefault();
                  if (x != c)
                  {
                      x = c;
                  }
              }

          });

            for (int i = 0; i < Contratos.Count; i++)
            {
                if (!cache.Any(y => y.Pasta == Contratos[i].Pasta && y.Login == Contratos[i].Login) || (OcultarPastasVazias && !Contratos[i].Visible))
                {
                    Contratos[i].Dispose();
                    Contratos.RemoveAt(i);
                    i--;
                }
            }

        }
        public void GetServerStatus()
        {
            try
            {
                if (IPAddress.TryParse(this.Empresa.Host, out IPAddress ip))
                {
                    using (IFileZillaApi fileZillaApi = new FileZillaApi(ip, this.Empresa.Port))
                    {
                        fileZillaApi.Connect(this.Empresa.Pass);

                        if (fileZillaApi.IsConnected)
                        {
                            var state = fileZillaApi.GetServerState();
                            StatusServidor = "Conectado / " + state;
                            ServerColor = Color.Green;
                            Conexoes = fileZillaApi.GetConnections();
                            StatusConexoes = Conexoes.Count + " Conexões ativas";
                            //if (Contratos != null)
                            //{
                            //    foreach (var c in Conexoes)
                            //    {
                            //        var contratos = Contratos.Where(x => x.Login == c.UserName).ToList();
                            //        contratos.ForEach(x =>
                            //        {
                            //            x.Status = c.TransferMode == TransferMode.Receive ? "Recebendo..." : c.TransferMode == TransferMode.Send ? "Enviando..." : "Conectado";
                            //            x.Cor = Color.Pink;
                            //            x.Tamanho = c.TotalSize.HasValue ? c.TotalSize.Value : x.Tamanho;
                            //        });
                            //    }
                            //}
                        }
                        else
                        {
                            StatusServidor = "Desconectado";
                            StatusConexoes = "";
                            ServerColor = Color.Red;
                        }


                    }
                }
            }
            catch (Exception ex)
            {
                Conexoes.Clear();
                StatusServidor = "Erro: " + ex.Message;
                ServerColor = Color.Red;
            }
        }
    }
}
