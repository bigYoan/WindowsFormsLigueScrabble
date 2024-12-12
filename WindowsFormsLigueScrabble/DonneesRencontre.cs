using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsLigueScrabble
{
    internal class DonneesRencontre
    {
        DateTime dateEtHeure;
        int idSession;
        int table;
        int partie;
        int idTable;
        int idJoute;
        List<Joueur> joueurs;

        public DateTime DateEtHeure { get => dateEtHeure; set => dateEtHeure = value; }
        public int Table { get => table; set => table = value; }
        public int Partie { get => partie; set => partie = value; }
        public int IdTable { get => idTable; set => idTable = value; }
        public int IdJoute { get => idJoute; set => idJoute = value; }
        public int IdSession { get => idSession; set => idSession = value; }
        internal List<Joueur> Joueurs { get => joueurs; set => joueurs = value; }
    }
}
