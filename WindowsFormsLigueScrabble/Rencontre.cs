using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsLigueScrabble
{
    internal class Rencontre
    {
        DateTime dateDeJeu;
        DateTime dateNouvelle;

        public DateTime DateDeJeu { get => dateDeJeu; set => dateDeJeu = value; }
        public DateTime DateNouvelle { get => dateNouvelle; set => dateNouvelle = value; }

        public override string ToString()
        {
            return dateDeJeu.ToString("D");
        }
    }
}
