using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsLigueScrabble
{
    internal class Score
    {
        int idScore;
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
        int totalTours;
        int penalite;
        int bonus;
        int total;

        public int IdScore { get => idScore; set => idScore = value; }
        public int Tour1 { get => tour1; set => tour1 = value; }
        public int Tour2 { get => tour2; set => tour2 = value; }
        public int Tour3 { get => tour3; set => tour3 = value; }
        public int Tour4 { get => tour4; set => tour4 = value; }
        public int Tour5 { get => tour5; set => tour5 = value; }
        public int Tour6 { get => tour6; set => tour6 = value; }
        public int Tour7 { get => tour7; set => tour7 = value; }
        public int Tour8 { get => tour8; set => tour8 = value; }
        public int Tour9 { get => tour9; set => tour9 = value; }
        public int Tour10 { get => tour10; set => tour10 = value; }
        public int Tour11 { get => tour11; set => tour11 = value; }
        public int Tour12 { get => tour12; set => tour12 = value; }
        public int Tour13 { get => tour13; set => tour13 = value; }
        public int Tour14 { get => tour14; set => tour14 = value; }
        public int Tour15 { get => tour15; set => tour15 = value; }
        public int Tour16 { get => tour16; set => tour16 = value; }
        public int Tour17 { get => tour17; set => tour17 = value; }
        public int Tour18 { get => tour18; set => tour18 = value; }
        public int Tour19 { get => tour19; set => tour19 = value; }
        public int Tour20 { get => tour20; set => tour20 = value; }      
        public int Penalite { get => penalite; set => penalite = value; }
        public int Bonus { get => bonus; set => bonus = value; }
        public int TotalTours { get => tour1 + tour2 + tour3 + tour4 + tour5 + tour6 + tour7 + tour8 + tour9 + tour10 +
                tour11 + tour12 + tour13 + tour14 + tour15 + tour16 + tour17 + tour18 + tour19 + tour20 ; }
        public int Total { get => TotalTours + Bonus + Penalite; }
    }
}
