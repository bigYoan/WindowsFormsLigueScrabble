using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsLigueScrabble
{
    internal class Partie
    {
        int idPartie;
        int noPartie;
        List<Joueur> joueurs;
        int partieCompletee;

        public int IdPartie { get => idPartie; set => idPartie = value; }
        public int NoPartie { get => noPartie; set => noPartie = value; }
        public int PartieCompletee { get => partieCompletee; set => partieCompletee = value; }
        internal List<Joueur> Joueurs { get => joueurs; set => joueurs = value; }
    }
}
