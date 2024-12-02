using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsLigueScrabble
{
    public class Controleur
    {
        List<Joueur> joueurs = new List<Joueur>();

        internal List<Joueur> AjouterJoueur(Joueur nouveauJoueur, int ordre)
        {
            if (ordre == 1) joueurs.Add(nouveauJoueur);
            return joueurs;
        }
    }
}
