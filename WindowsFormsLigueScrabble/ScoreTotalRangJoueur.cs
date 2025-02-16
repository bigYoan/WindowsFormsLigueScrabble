using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsLigueScrabble
{
    internal class ScoreTotalRangJoueur
    {
        int idJoueur;
        int pointageTotal;
        string rangJoueur;

        public int IdJoueur { get => idJoueur; set => idJoueur = value; }
        public int PointageTotal { get => pointageTotal; set => pointageTotal = value; }
        public string RangJoueur { get => rangJoueur; set => rangJoueur = value; }
    }
}
