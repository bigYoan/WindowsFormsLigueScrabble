using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsLigueScrabble
{
    internal class Joueur
    {
        string idCode;
        string nom;
        string pseudo;

        public Joueur(string idCode, string nom, string pseudo)
        {
            this.idCode = idCode;
            this.nom = nom;
            this.pseudo = pseudo;
        }

        public Joueur() { }


        public string IdCode { get => idCode; set => idCode = value; }
        public string Nom { get => nom; set => nom = value; }
        public string Pseudo { get => pseudo; set => pseudo = value; }
    }
}
