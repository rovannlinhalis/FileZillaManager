using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileZillaManager.Classes
{
    public enum ZipCheckState
    {
        [Description(" Não Verificado")]
        NaoVerificado = -1,
        [Description("Não Aplicável")]
        NaoAplicavel = 0,
        [Description("1 - Aguardando Processamento")]
        AguardandoProcesso = 1,
        [Description("2 - Verificando")]
        Verificando = 2,
        [Description("3 - Válido")]
        Valido = 3,
        [Description("4 - Inválido")]
        Invalido = 4,
        [Description("5 - Gerando Hash")]
        GerandoHash = 5,
        [Description("6 - Aguardando Verificação")]
        AguardandoVerificacao = 6,
        Erro = 9
    }

    public static class ZipCheckStateEx
    {
        static Dictionary<ZipCheckState,Color> dicColors = new System.Collections.Generic.Dictionary<ZipCheckState,Color>()
        {
            { ZipCheckState.NaoVerificado, Color.Yellow },
            { ZipCheckState.NaoAplicavel, Color.LightGray },
            { ZipCheckState.AguardandoProcesso, Color.LightPink },
            { ZipCheckState.Verificando, Color.Blue },
            { ZipCheckState.Valido, Color.LightGreen },
            { ZipCheckState.Invalido, Color.Red },
            { ZipCheckState.GerandoHash, Color.Purple },
            { ZipCheckState.AguardandoVerificacao, Color.Orange },
            { ZipCheckState.Erro, Color.DarkRed }

        };
        public static Color GetColor(this ZipCheckState s)
        {
            return dicColors[s];
        }
    }
  
}
