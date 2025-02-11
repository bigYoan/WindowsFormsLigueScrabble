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
        int tour6;
        int tour7;
        int tour8;
        int tour9;
        int tour10;
        int tour11;
        int tour12;
        int tour13;
        int tour14;
        int tour15;
        int tour16;
        int tour17;
        int tour18;
        int tour19;
        int tour20;
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
        public int Tour6 { get => scoreJoueur.Tour6; }
        public int Tour7 { get => scoreJoueur.Tour7; }
        public int Tour8 { get => scoreJoueur.Tour8; }
        public int Tour9 { get => scoreJoueur.Tour9; }
        public int Tour10 { get => scoreJoueur.Tour10; }
        public int Tour11 { get => scoreJoueur.Tour11; }
        public int Tour12 { get => scoreJoueur.Tour12; }
        public int Tour13 { get => scoreJoueur.Tour13; }
        public int Tour14 { get => scoreJoueur.Tour14; }
        public int Tour15 { get => scoreJoueur.Tour15; }
        public int Tour16 { get => scoreJoueur.Tour16; }
        public int Tour17 { get => scoreJoueur.Tour17; }
        public int Tour18 { get => scoreJoueur.Tour18; }
        public int Tour19 { get => scoreJoueur.Tour19; }
        public int Tour20 { get => scoreJoueur.Tour20; }                
        public int Penalite { get => scoreJoueur.Penalite; }
        public int Bonus { get => scoreJoueur.Bonus; }
        internal Score ScoreJoueur { get => scoreJoueur; set => scoreJoueur = value; }
        internal Joueur Joueur { get => joueur; set => joueur = value; }

    }
}
