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
        int idjoueur1;
        int idjoueur2;
        int idjoueur3;
        int idjoueur4;
        int partieCompletee;

        public int IdPartie { get => idPartie; set => idPartie = value; }
        public int NoPartie { get => noPartie; set => noPartie = value; }
        public int PartieCompletee { get => partieCompletee; set => partieCompletee = value; }
        public int Idjoueur1 { get => idjoueur1; set => idjoueur1 = value; }
        public int Idjoueur2 { get => idjoueur2; set => idjoueur2 = value; }
        public int Idjoueur3 { get => idjoueur3; set => idjoueur3 = value; }
        public int Idjoueur4 { get => idjoueur4; set => idjoueur4 = value; }
        internal List<Joueur> Joueurs { get => joueurs; set => joueurs = value; }
    }
}
