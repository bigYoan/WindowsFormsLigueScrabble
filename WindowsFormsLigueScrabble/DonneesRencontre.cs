using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsLigueScrabble
{
    internal class DonneeRencontre
    {
        DateTime dateEtHeure;
        int table;
        int partie;

        public DateTime DateEtHeure { get => dateEtHeure; set => dateEtHeure = value; }
        public int Table { get => table; set => table = value; }
        public int Partie { get => partie; set => partie = value; }
    }
}
