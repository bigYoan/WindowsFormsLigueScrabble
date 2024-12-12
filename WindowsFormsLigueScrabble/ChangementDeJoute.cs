using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsLigueScrabble
{
    internal class ChangementDeJoute
    {
        int idNewJoute;
        int idOldJoute;
        bool jouteChangee;

        public int IdNewJoute { get => idNewJoute; set => idNewJoute = value; }
        public int IdOldJoute { get => idOldJoute; set => idOldJoute = value; }
        public bool JouteChangee { get => jouteChangee; set => jouteChangee = value; }
    }
}
