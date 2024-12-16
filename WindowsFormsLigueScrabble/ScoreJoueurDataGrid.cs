using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsLigueScrabble
{
    internal class ScoreJoueurDataGrid
    {
        int idJoute;
        int idScore;
        int idJoueur;
        string nomJoueur;
        string pseudoJoueur;
        int totalJoueur;
        string rang;
        int tour1;
        int tour2;
        int tour3;
        int tour4;
        int tour5;
        int penalite;
        int bonus;
        Score scoreJoueur;
        Joueur joueur;

        public int IdJoute { get => idJoute; set => idJoute = value; }
        public int IdScore { get => scoreJoueur.IdScore; }
        public int IdJoueur { get => joueur.IdJoueur; }
        public string NomJoueur { get => joueur.CacherNom ? "--" : joueur.Nom; }
        public string PseudoJoueur { get => joueur.Pseudo; }
        public int TotalJoueur { get => scoreJoueur.Total; }

        public string Rang { get => rang; set => rang = value; }
        public int Tour1 { get => scoreJoueur.Tour1; }
        public int Tour2 { get => scoreJoueur.Tour2; }
        public int Tour3 { get => scoreJoueur.Tour3; }
        public int Tour4 { get => scoreJoueur.Tour4; }
        public int Tour5 { get => scoreJoueur.Tour5; }
        public int Penalite { get => scoreJoueur.Penalite; }
        public int Bonus { get => scoreJoueur.Bonus; }
       
        internal Score ScoreJoueur { get => scoreJoueur; set => scoreJoueur = value; }
        internal Joueur Joueur { get => joueur; set => joueur = value; }
    }
}
