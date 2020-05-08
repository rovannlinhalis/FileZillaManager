using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileZillaManager.Classes
{
    public enum FTPState
    {
        
        Desconectado =0,
        Conectado = 1,
        Enviando = 2,
        Recebendo = 3
    }

    public static class FTPStateEx
    {
        static Dictionary<FTPState, Color> dicColors = new System.Collections.Generic.Dictionary<FTPState, Color>()
        {
            { FTPState.Desconectado, Color.LightGray },
            { FTPState.Recebendo, Color.LightGreen },
            { FTPState.Conectado, Color.LightBlue },
            { FTPState.Enviando, Color.Orange }
        };
        public static Color GetColor(this FTPState s)
        {
            return dicColors[s];
        }
    }
}
