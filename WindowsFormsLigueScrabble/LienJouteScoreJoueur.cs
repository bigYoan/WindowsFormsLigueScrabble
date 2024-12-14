using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsLigueScrabble
{
    internal class LienJouteScoreJoueur
    {
        int idJoute;
        int idScore;
        int idJoueur;

        public int IdJoute { get => idJoute; set => idJoute = value; }
        public int IdScore { get => idScore; set => idScore = value; }
        public int IdJoueur { get => idJoueur; set => idJoueur = value; }
    }
}
