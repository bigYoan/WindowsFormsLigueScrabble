using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Mysqlx.Crud;

namespace WindowsFormsLigueScrabble
{
    internal class Controleur
    {
        DB_Manager dB_Manager = new DB_Manager();
        public List<Joueur> joueurs = new List<Joueur>();
        public List<Rencontre> rencontres = new List<Rencontre>();
        public int lister = 0;
        public int ajouter = 1;
        public int supprimer = 2;
        public int modifier = 3;

        public Controleur()
        {
            joueurs = dB_Manager.ListerJoueursDansBD("ORDER BY Nom");
        }

        internal List<Joueur> GererJoueur(Joueur nouveauJoueur, int ordre, string orderBy)
        {
            int lignesAffectees = 0;

            if (nouveauJoueur == null && ordre == lister) 
            {
                //Fait une liste des joueurs
                joueurs = dB_Manager.ListerJoueursDansBD(orderBy);
                return joueurs;
            }
            if (nouveauJoueur != null && ordre == ajouter)
            {
                lignesAffectees = dB_Manager.AjouterJoueurDansBD(nouveauJoueur);
                joueurs.Add(nouveauJoueur);
                if (lignesAffectees == 0) { MessageBox.Show("Exécution annulée"); }
                return dB_Manager.ListerJoueursDansBD(orderBy);
            }
            if (nouveauJoueur !=null && ordre == supprimer)
            {
                // Supprimer joueur dans BD
                lignesAffectees = dB_Manager.SupprimerJoueurDansBD(nouveauJoueur.IdJoueur);
                if (lignesAffectees == 0) { MessageBox.Show("Exécution annulée"); }
                joueurs = dB_Manager.ListerJoueursDansBD(orderBy);
                return joueurs;
            }
            if (nouveauJoueur != null && ordre == modifier)
            {
                //Modifier joueur dans BD
                lignesAffectees = dB_Manager.ModifierJoueurDansBD(nouveauJoueur);
                if (lignesAffectees == 0) { MessageBox.Show("Exécution annulée"); }
                joueurs = dB_Manager.ListerJoueursDansBD(orderBy);
                return joueurs;
            }
            return null;
            
        }
        internal List<Joueur> AjouterJoueurDansBD(Joueur joueurAAjouter)
        {
            
            return joueurs;
        }

        public bool DemandeDeConfirmation(string rubriqueAModifier)
        {
            {
                DialogResult approuveChangement = MessageBox.Show(rubriqueAModifier + "\nCette modification va influencer\ntoutes les données connexes.\nConfirmer...", "Attention!", MessageBoxButtons.OKCancel);
                return (approuveChangement != DialogResult.Cancel);
            }
        }

        internal List<Rencontre> GererRencontres(Rencontre newRencontre, int ordre, string orderBy)
        {
            int lignesAffectees = 0;

            if (newRencontre == null && ordre == lister)
            {
                //Fait une liste des joueurs
                rencontres = dB_Manager.ListerRencontresDansBD(orderBy);
                return rencontres;
            }
            if (newRencontre != null && ordre == ajouter)
            {
                lignesAffectees = dB_Manager.AjouterRencontreDansBD(newRencontre);
                rencontres.Add(newRencontre);
                if (lignesAffectees == 0) { MessageBox.Show("Exécution annulée"); }
                return dB_Manager.ListerRencontresDansBD(orderBy);
            }
            if (newRencontre != null && ordre == supprimer)
            {
                // Supprimer joueur dans BD
                lignesAffectees = dB_Manager.SupprimerRencontreDansBD(newRencontre.IdSession);
                if (lignesAffectees == 0) { MessageBox.Show("Exécution annulée"); }
                rencontres = dB_Manager.ListerRencontresDansBD(orderBy);
                return rencontres;
            }
            if (newRencontre != null && ordre == modifier)
            {
                //Modifier joueur dans BD
                lignesAffectees = dB_Manager.ModifierRencontreDansBD(newRencontre, modifier);
                if (lignesAffectees == 0) { MessageBox.Show("Exécution annulée"); }
                rencontres = dB_Manager.ListerRencontresDansBD(orderBy);
                return rencontres;
            }
            return null;
        }

        internal List<LienTableSession> ListerLiens(string commande)
        {
            List<LienTableSession> liens = new List<LienTableSession>();

            if (commande == "Table_Session")
            {
                liens = dB_Manager.ListerLiensRencontre_Table("");
            }
            return liens;
        }

        internal bool VerifierLiens(DonneeRencontre nouvelledonneeRencontre)
        {
            List<Rencontre> rencontresDansBD = dB_Manager.ListerRencontresDansBD("");
            List<Table> tablesDansBD = dB_Manager.ListerTablesDansBD("");
            List<Partie> partiesDansBD = dB_Manager.ListerPartiesDansBD("");
            List<LiensSessionTablePartie> liensSessionTableParties = dB_Manager.ListerLiensSessionTablePartie("");


            int idRencontre = 0;
            int idTable = 0;
            int idPartie = 0;
            bool trouveMatchRencontre = false;
            bool trouveMatchTable = false;

            foreach (var rencontreAVerifier in rencontresDansBD)
            {
                if (nouvelledonneeRencontre.DateEtHeure == rencontreAVerifier.DateNouvelle)
                {
                    ChercherMatchDansLiens(rencontreAVerifier, nouvelledonneeRencontre);
                    trouveMatchRencontre = true;
                }
                else
                {
                    trouveMatchRencontre = true;
                    //idRencontre = rencontreAVerifier.IdSession;
                }
                if (!trouveMatchRencontre) return false;

                foreach (var tableAVerifier in tablesDansBD)
                {
                    if (nouvelledonneeRencontre.Table != tableAVerifier.NoTable)
                    {
                        return false;
                    }
                    else
                    {
                        idTable = tableAVerifier.IDTable;
                    }

                    foreach (var partieAVerifier in partiesDansBD)
                    {
                        if (nouvelledonneeRencontre.Partie != partieAVerifier.NoPartie)
                        {
                            return false;
                        }
                        else
                        {
                            idPartie = tableAVerifier.IDTable;
                        }
                    }
                }
            }
            foreach (var lienAVerifier in liensSessionTableParties)
            {
                if (idRencontre == lienAVerifier.IdSession & idTable == lienAVerifier.IdTable && idPartie == lienAVerifier.IdPartie)
                {
                    return true;
                }
            }
            return false;
        }

        private void ChercherMatchDansLiens(Rencontre rencontreAVerifier, DonneeRencontre nouvelledonneeRencontre)
        {
            throw new NotImplementedException();
        }
    }
}
