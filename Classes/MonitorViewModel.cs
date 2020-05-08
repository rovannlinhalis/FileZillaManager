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
        private DateTime dataReferencia;
        private Empresa empresa;
        private SortableBindingList<ContratoViewModel> contratos = new SortableBindingList<ContratoViewModel>();
        private string statusServidor;
        LocalConfig config = new LocalConfig(true, "FileZillaManager");
        private List<Connection> conexoes = new List<Connection>();
        private Color serverColor = Color.Blue;
        
        public bool Running { get; set; } = false;
        public SortableBindingList<ContratoViewModel> Contratos { get=> contratos; set { contratos = value; RaisePropertyChanged("Contratos"); } }
        public Empresa Empresa { get => empresa; set { empresa = value; RaisePropertyChanged("Empresa"); } }
        public DateTime DataReferencia { get => dataReferencia; set { dataReferencia = value; RaisePropertyChanged("DataReferencia"); } }
        public bool OcultarPastasVazias { get => ocultarPastasVazias; set { ocultarPastasVazias = value; RaisePropertyChanged("OcultarPastasVazias"); }  }
        public bool MonitorarSubPastas { get => monitorarSubPastas; set { monitorarSubPastas = value; RaisePropertyChanged("MonitorarSubPastas"); } }
        public bool MonitorarSubPastasIndividualmente { get => monitorarSubPastasIndividualmente; set { monitorarSubPastasIndividualmente = value; RaisePropertyChanged("MonitorarSubPastasIndividualmente"); } }
        public string MsgErro { get => msgErro; set { msgErro = value; RaisePropertyChanged("MsgErro"); } }
        public string StatusServidor { get => statusServidor; set { statusServidor = value; RaisePropertyChanged("StatusServidor"); } }
        public List<Connection> Conexoes { get => conexoes; set { conexoes = value; RaisePropertyChanged("Conexoes"); } }
        public Color ServerColor { get => serverColor; set { serverColor = value; RaisePropertyChanged("ServerColor"); } }

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

            if (prop == "OcultarPastasVazias")
            {
                ProcessaCache();
            }
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
            
            cache.Clear();
            foreach (var c in contratos)
            {
                ContratoViewModel model;
                try
                {
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

            ProcessaCache();

            if (ProcessaContratosEnd != null)
                ProcessaContratosEnd(this, new EventArgs());
        }

        public void ProcessarDiretorios()
        {
            TGetServerStatus();
            foreach (var c in cache.OrderBy(x => x.LastLerDiretorio))
                c.LerDiretorio(this.Conexoes);
        }


        public void ProcessarArquivos()
        {
            Parallel.ForEach(cache.OrderBy(x => x.LastWrite), new ParallelOptions() { MaxDegreeOfParallelism = 3 }, c => {
                c.VerificarHash();
            });

            while (cache.Any(x => x.Integridade == ZipCheckState.AguardandoVerificacao))
            {
                foreach (var c in cache.Where(x => x.Integridade == ZipCheckState.AguardandoVerificacao))
                {
                    if (cache.Where(x => x.VerificandoIntegridade).Count() < 3)
                        c.VerificarIntegridade();
                }
                Thread.Sleep(1000);
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
                    Contratos.RemoveAt(i);
                    i--;
                }
            }
         
        }


        public void TGetServerStatus()
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
