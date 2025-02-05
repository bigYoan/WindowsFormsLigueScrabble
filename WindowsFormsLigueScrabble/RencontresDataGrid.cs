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
        int id_Table;
        int table;
        int id_Ronde;
        int ronde;

        List<int> listeIdJoueurs;
        
        int nombreJoueurs;
        string gagnant;
        int scoreGagnant;
        bool homologation;

        public Rencontre Session { get => session; set => session = value; }
        public string JourRencontre { get => session.DateDeJeu.ToString("ddd"); }
        public string HeureRencontre { get => session.DateDeJeu.ToString("HH") +"h"; }
        public int Table { get => table; set => table = value; }
        public int Ronde { get => ronde; set => ronde = value; }
        
        public int NombreJoueurs { get => nombreJoueurs; set => nombreJoueurs = value; }
        public string Gagnant { get => gagnant; set => gagnant = value; }
        public int ScoreGagnant { get => scoreGagnant; set => scoreGagnant = value; }
        public bool Homologation { get => homologation; set => homologation = value; }
        public int IdSession { get => session.IdSession; }
        public int Id_Ronde { get => id_Ronde; set => id_Ronde = value; }
        public int Id_Table { get => id_Table; set => id_Table = value; }
        public List<int> ListeIdJoueurs { get => listeIdJoueurs; set => listeIdJoueurs = value; }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
