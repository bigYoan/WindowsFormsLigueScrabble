using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsLigueScrabble
{
    internal class Joueur
    {
        int idJoueur;
        string codeJoueur;
        string nom;
        bool cacherNom;
        string pseudo;
        string fqcsf;  // numéro de membre  Fédération Québécoise des Clubs de Scrabble Francophones,
        int noFqscf;
        public Joueur(string codeJoueur, string nom, string pseudo)
        {
            this.CodeJoueur = codeJoueur;
            this.nom = nom;
            this.pseudo = pseudo;
        }

        public Joueur() { }


        public string Nom { get => nom; set => nom = value; }
        public bool CacherNom { get => cacherNom; set => cacherNom = value; }

        public string Pseudo { get => pseudo; set => pseudo = value; }
        public int IdJoueur { get => idJoueur; set => idJoueur = value; }
        public string CodeJoueur { get => codeJoueur; set => codeJoueur = value; }
        public string Fqcsf { get => fqcsf; set => fqcsf = value; }
        public int NoFqcsf { get { bool no = int.TryParse(fqcsf, out noFqscf); return noFqscf; } }

        //public override string ToString()
        //{
        //    //if (pseudo == "(vide)") return "".ToString();
        //    //else return CodeJoueur + " :  " + nom.ToString();

        //}
    }
}
