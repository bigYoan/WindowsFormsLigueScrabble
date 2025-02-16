using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsLigueScrabble
{
    internal class JoutesDataGrid
    {
        int idJoueur;
        string nomJoueur;
        DateTime dateSession;
        //int idJoute;
        int noJoute;
        //int idTable;
        int noTable;
        int scoreFinal;
        string rangDansPartie;
        int nbToursNonNuls;
        double moyenneParTour;
        string moyenneParTourFormattee;
        int nbPartiesJouees;
        double moyenneParPartie;
        string moyenneParPartieFormattee;


        public int IdJoueur { get => idJoueur; set => idJoueur = value; }
        public string NomJoueur { get => nomJoueur; set => nomJoueur = value; }
        public DateTime DateSession { get => dateSession; set => dateSession = value; }
        public int NoJoute { get => noJoute; set => noJoute = value; }
        public int NoTable { get => noTable; set => noTable = value; }
        public int ScoreFinal { get => scoreFinal; set => scoreFinal = value; }
        public string RangDansPartie { get => rangDansPartie; set => rangDansPartie = value; }
        public int NbToursNonNuls { get => nbToursNonNuls; set => nbToursNonNuls = value; }
        public double MoyenneParTour { get => moyenneParTour; set => moyenneParTour = value; }
        public int NbPartiesJouees { get => nbPartiesJouees; set => nbPartiesJouees = value; }
        public double MoyenneParPartie { get => moyenneParPartie; set => moyenneParPartie = value; }
        public string MoyenneParTourFormattee { get => moyenneParTour.ToString("##.##"); set => moyenneParTourFormattee = value; }
        public string MoyenneParPartieFormattee { get => moyenneParPartie.ToString("##.##"); set => moyenneParPartieFormattee = value; }

       
    }
}
