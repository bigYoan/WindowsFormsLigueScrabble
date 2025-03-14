using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsLigueScrabble
{
    internal class DataGridIndexLigne
    {
        int idJoute;
        int idScore;
        int idJoueur;
        int nom;
        int pseudo;
        int rang;
        int total;
        int penalite;
        int bonus;

        public int Nom { get => nom; set => nom = value; }
        public int Pseudo { get => pseudo; set => pseudo = value; }
        public int Rang { get => rang; set => rang = value; }
        public int Total { get => total; set => total = value; }
        public int Penalite { get => penalite; set => penalite = value; }
        public int Bonus { get => bonus; set => bonus = value; }
        public int IdJoute { get => idJoute; set => idJoute = value; }
        public int IdScore { get => idScore; set => idScore = value; }
        public int IdJoueur { get => idJoueur; set => idJoueur = value; }
    }
}
