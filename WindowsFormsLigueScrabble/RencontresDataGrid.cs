using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsLigueScrabble
{
    internal class RencontresDataGrid
    {
        int idSession;
        string jourRencontre;
        Rencontre session;
        string heureRencontre;
        int ronde;
        int table;
        int nombreJoueurs;
        string gagnant;
        int scoreGagnant;
        bool homologation;

        public Rencontre Session { get => session; set => session = value; }
        public string JourRencontre { get => session.DateDeJeu.ToString("ddd"); }
        public string HeureRencontre { get => session.DateDeJeu.ToString("HH") +"h"; }
        public int Ronde { get => ronde; set => ronde = value; }
        public int Table { get => table; set => table = value; }
        public int NombreJoueurs { get => nombreJoueurs; set => nombreJoueurs = value; }
        public string Gagnant { get => gagnant; set => gagnant = value; }
        public int ScoreGagnant { get => scoreGagnant; set => scoreGagnant = value; }
        public bool Homologation { get => homologation; set => homologation = value; }
        public int IdSession { get => session.IdSession; }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
