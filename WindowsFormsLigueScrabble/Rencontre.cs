using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsLigueScrabble
{
    internal class Rencontre
    {
        int idSession;
        DateTime dateDeJeu;
        DateTime dateNouvelle;
        //int heureNouvelle;

        public DateTime DateDeJeu { get => dateDeJeu; set => dateDeJeu = value; }
        public DateTime DateNouvelle { get => dateNouvelle; set => dateNouvelle = value; }
        public int IdSession { get => idSession; set => idSession = value; }

        //public int HeureNouvelle { get => heureNouvelle; set => heureNouvelle = value; }

        public override string ToString()
        {
            return dateDeJeu.ToString("D");
        }
    }
}
