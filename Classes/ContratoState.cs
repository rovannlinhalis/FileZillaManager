using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileZillaManager.Classes
{
    public enum ContratoState
    {
        [Description("Não Verificado")]
        NaoVerificado = -1,
        [Description("Diretório Vazio")]
        DiretorioVazio = 0,
        [Description("Arquivo Recebido Hoje")]
        RecebidoHoje = 1,
        [Description("Arquivo Recebido há 1 dia")]
        Recebido1dia = 2,
        [Description("Arquivo Recebido há 2 ou 3 dias")]
        Recebido2ou3dias = 3,
        [Description("Arquivo Recebido há mais de 3 dias")]
        RecebidoMais3dias = 5,
        Erro = 9
    }

    public static class ContratoStateEx
    {
        static Dictionary<ContratoState, Color> dicColors = new System.Collections.Generic.Dictionary<ContratoState, Color>()
        {
            { ContratoState.NaoVerificado, Color.Yellow },
            { ContratoState.DiretorioVazio, Color.LightGray },
            { ContratoState.RecebidoHoje, Color.LightGreen },
            { ContratoState.Recebido1dia, Color.LightBlue },
            { ContratoState.Recebido2ou3dias, Color.Orange },
            { ContratoState.RecebidoMais3dias, Color.Red },
            { ContratoState.Erro, Color.DarkRed }

        };
        public static Color GetColor(this ContratoState s)
        {
            return dicColors[s];
        }
    }
}
