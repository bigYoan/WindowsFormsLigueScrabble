using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsLigueScrabble
{
    internal class Controleur
    {
        DB_Manager dB_Manager = new DB_Manager();
        public List<Joueur> joueurs = new List<Joueur>();

        public Controleur()
        {
            joueurs = dB_Manager.ListerJoueursDansBD();
        }

        internal List<Joueur> GererJoueur(Joueur nouveauJoueur, int ordre)
        {
            int lignesAffectees = 0;

            if (nouveauJoueur == null && ordre == 0) 
            {
                //Fait une liste des joueurs
                joueurs = dB_Manager.ListerJoueursDansBD();
                return joueurs;
            }
            if (nouveauJoueur != null && ordre == 1)
            {
                lignesAffectees = dB_Manager.AjouterJoueurDansBD(nouveauJoueur);
                joueurs.Add(nouveauJoueur);
                if (lignesAffectees == 0) { MessageBox.Show("Exécution annulée"); }
                return dB_Manager.ListerJoueursDansBD();
            }
            if (nouveauJoueur !=null && ordre == 2)
            {
                // Supprimer joueur dans BD
                lignesAffectees = dB_Manager.SupprimerJoueurDansBD(nouveauJoueur.IdCode);
                if (lignesAffectees == 0) { MessageBox.Show("Exécution annulée"); }
                joueurs = dB_Manager.ListerJoueursDansBD();
                return joueurs;
            }
            if (nouveauJoueur != null && ordre == 3)
            {
                //Modifier joueur dans BD
            }
            return null;
            
        }
        internal List<Joueur> AjouterJoueurDansBD(Joueur joueurAAjouter)
        {
            
            return joueurs;
        }

        public bool DemandeDeConfirmationDeSuppression(string rubriqueAModifier)
        {
            {
                DialogResult approuveChangement = MessageBox.Show(rubriqueAModifier + "\nCette modification va influencer\ntoutes les données connexes.\nConfirmer...", "Attention!", MessageBoxButtons.OKCancel);
                return (approuveChangement != DialogResult.Cancel);
            }
        }
    }
}
