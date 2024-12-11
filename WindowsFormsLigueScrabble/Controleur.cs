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
        public List<RencontresDataGrid> rencontres = new List<RencontresDataGrid>();
        public int lister = 0;
        public int ajouter = 1;
        public int supprimer = 2;
        public int modifier = 3;
        public string orderBy = "ORDER BY Session.Date_Session DESC, _Table.No_Table; ";

        public Controleur()
        {
            joueurs = dB_Manager.ListerJoueursDansBD("ORDER BY Nom");
            rencontres = GererRencontres(null, 0, 0, null, lister, orderBy);
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
                joueurs = dB_Manager.ListerJoueursDansBD(orderBy);
                return joueurs; 
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
                DialogResult approuveChangement = MessageBox.Show(rubriqueAModifier + "\nCette modification pourrait influencer toute donnée connexe.\nConfirmer...", "Attention!", MessageBoxButtons.OKCancel);
                return (approuveChangement != DialogResult.Cancel);
            }
        }

        internal List<RencontresDataGrid> GererRencontres(Rencontre newRencontre, int noTable, int noPartie, List<Joueur> joueurs, int ordre, string orderBy)
        {
            int lignesAffectees = 0;

            if (newRencontre == null && ordre == lister)
            {
                //Fait une liste des joueurs
                //rencontres = dB_Manager.ListerRencontresDansBD(orderBy);
                //return rencontres;
            }
            if (newRencontre != null && ordre == ajouter)
            {
                int idNouvelleSession = dB_Manager.AjouterRencontreDansBD(newRencontre);
                if (idNouvelleSession >0 && noTable != 0)
                {
                    if (AjouterTable(idNouvelleSession, noTable, noPartie) > 0) 
                    {
                        MessageBox.Show("Ajout réussi");
                        //return dB_Manager.ListerRencontresDansBD(orderBy);
                    }
                }
                else
                {
                    if (idNouvelleSession == 0)
                    {
                        MessageBox.Show("Exécution annulée");
                    }
                    else MessageBox.Show("Ajout réussi");
                }
            }

            if (newRencontre != null && ordre == supprimer)
            {
                // Supprimer joueur dans BD
                lignesAffectees = dB_Manager.SupprimerRencontreDansBD(newRencontre.IdSession, noTable, noPartie);
                if (lignesAffectees == 0) { MessageBox.Show("Exécution annulée"); }
                //rencontres = dB_Manager.ListerRencontresDansBD(orderBy);
                //return rencontres;
            }
            if (newRencontre != null && ordre == modifier)
            {
                //Modifier joueur dans BD
                lignesAffectees = dB_Manager.ModifierRencontreDansBD(newRencontre, modifier);
                if (lignesAffectees == 0) { MessageBox.Show("Exécution annulée"); }
                //rencontres = dB_Manager.ListerRencontresDansBD(orderBy);
                //return rencontres;
            }
            //return null;
            rencontres = dB_Manager.ListerRencontresDansBD(orderBy);
            return rencontres;
        }

        private int AjouterTable(int id_rencontre, int noTable, int noPartie)
        {
            int idTable = 0;
            int idPartie = 0;

            List<Table> tables = dB_Manager.ListerTablesDansBD("");
            foreach (Table table in tables) { if (noTable == table.NoTable) { idTable = table.IDTable; } }

            if (idTable == 0)
            {
                idTable = dB_Manager.AjouterNouvelleTable(noTable, "Sans ODS");
            }

            //if (noPartie != 0)
            //{
            //    List<Partie> parties = dB_Manager.ListerPartiesDansBD("");
            //    foreach (Partie partie in parties) { if (noPartie == partie.NoPartie) { idPartie = partie.IdPartie; } }
            //}
            // Crée des tables ou des nouvelles parties au besoin
            //if (idPartie == 0)
            //{
                idPartie = dB_Manager.CreerNouvellePartie(noPartie);
            //}
            // Ajouter des tables avec joutes
            int lignesAffectees = dB_Manager.CreerLiens_Session_Table_Partie(id_rencontre, idTable, idPartie);
            return lignesAffectees;
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

        internal bool VerifierLiens(DonneesRencontre nouvelledonneeRencontre)
        {
            List<Rencontre> rencontresDansBD = dB_Manager.ListerRencontresSeules("");
            List<Table> tablesDansBD = dB_Manager.ListerTablesDansBD("");
            List<Partie> partiesDansBD = dB_Manager.ListerPartiesDansBD("");
            List<LiensSessionTablePartie> liensSessionTableParties = dB_Manager.ListerLiensSessionTablePartie("");

            int idSessionDansBD = 0;
            List<int> listeSessionsAvecMatch = new List<int>();
            int idTableDansBD = 0;
            List<int> listeTablesAvecMatch = new List<int>();
            int idPartieDansBD = 0;
            List<int> listePartiesAvecMatch = new List<int>();
            int idRencontre = 0;
            int idTable = 0;
            int idPartie = 0;
            bool trouveMatchRencontre = false;
            bool trouveMatchTable = false;
            bool trouveMatchPartie = false;

            foreach (var rencontreAVerifier in rencontresDansBD)
            {
                if (nouvelledonneeRencontre.DateEtHeure == rencontreAVerifier.DateDeJeu)
                {
                    idSessionDansBD = rencontreAVerifier.IdSession;
                    listeSessionsAvecMatch.Add(idSessionDansBD);
                    trouveMatchRencontre = true;
                }
                 
            }
            foreach (var tableAVerifier in tablesDansBD)
            {
                if (nouvelledonneeRencontre.Table == tableAVerifier.NoTable)
                {
                    idTableDansBD = tableAVerifier.IDTable;
                    listeTablesAvecMatch.Add(idTableDansBD);
                    trouveMatchTable = true;
                }
                 
            }
            foreach (var partieAVerifier in partiesDansBD)
            {
                if (nouvelledonneeRencontre.Partie == partieAVerifier.NoPartie)
                {
                    idPartieDansBD = partieAVerifier.IdPartie;
                    listePartiesAvecMatch.Add(idPartieDansBD);
                    trouveMatchPartie = true;
                }
                
            }
            if (trouveMatchRencontre && trouveMatchTable && trouveMatchPartie)
            {
                foreach (var lienAVerifier in liensSessionTableParties)
                {
                    foreach (int sessionX in listeSessionsAvecMatch)
                    {
                        if (lienAVerifier.IdSession == sessionX)
                        {
                            foreach (int tableX in listeTablesAvecMatch)
                            {
                                if (lienAVerifier.IdTable == tableX)
                                {
                                    foreach (int partieX in listePartiesAvecMatch)
                                    {
                                        if (lienAVerifier.IdPartie == partieX)
                                        {
                                            return true;
                                        }
                                    }
                                }
                            }
                        }
                    }
                    
                }
            }
            return false;
        }

        private void ChercherMatchDansLiens(Rencontre rencontreAVerifier, DonneesRencontre nouvellesdonneesRencontre)
        {
            throw new NotImplementedException();
        }

        internal Rencontre TrouverRencontre(int idSession)
        {
            Rencontre rencontreTrouvee = new Rencontre();
            rencontreTrouvee = dB_Manager.ListerRencontreSeule(idSession);
            return rencontreTrouvee;
        }
    }
}
