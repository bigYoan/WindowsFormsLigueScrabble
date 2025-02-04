﻿using System;
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
            try
            {
                joueurs = dB_Manager.ListerJoueursDansBD("ORDER BY Nom");
                rencontres = GererRencontres(null, 0, 0, null, lister, orderBy);
            }
            catch (Exception ex)
            {
                MsgErrDB();
            }
        }

        internal List<Joueur> GererJoueur(Joueur nouveauJoueur, int ordre, string orderBy)
        {
            int lignesAffectees = 0;

            if (nouveauJoueur == null && ordre == lister) 
            {
                //Afficher une liste des joueurs
                try
                {
                    joueurs = dB_Manager.ListerJoueursDansBD(orderBy);
                    return joueurs;
                }
                catch (Exception ex)
                {
                    MsgErrDB();
                }
                
            }
            if (nouveauJoueur != null && ordre == ajouter)
            {
                try
                { 
                    //Ajouter un nouveau joueur
                    lignesAffectees = dB_Manager.AjouterJoueurDansBD(nouveauJoueur);
                    joueurs.Add(nouveauJoueur);
                    if (lignesAffectees == 0) { MessageBox.Show("Exécution annulée"); }
                    joueurs = dB_Manager.ListerJoueursDansBD(orderBy);
                    return joueurs;
                }
                catch (Exception ex)
                {
                    MsgErrDB();
                }
            }
            if (nouveauJoueur !=null && ordre == supprimer)
            {
                // Supprimer joueur dans BD
                try
                {
                    lignesAffectees = dB_Manager.SupprimerJoueurDansBD(nouveauJoueur.IdJoueur);
                    if (lignesAffectees == 0) { MessageBox.Show("Exécution annulée"); }
                    joueurs = dB_Manager.ListerJoueursDansBD(orderBy);
                    return joueurs;
                }
                catch (Exception ex)
                {
                MsgErrDB();
                }
            }
            if (nouveauJoueur != null && ordre == modifier)
            {
                //Modifier joueur dans BD
                try
                {
                    lignesAffectees = dB_Manager.ModifierJoueurDansBD(nouveauJoueur);
                    if (lignesAffectees == 0) { MessageBox.Show("Exécution annulée"); }
                    joueurs = dB_Manager.ListerJoueursDansBD(orderBy);
                    return joueurs;
                }
                catch (Exception ex)
                {
                    MsgErrDB();
                }
            }
            return null;
        }
        public bool DemandeDeConfirmation(string rubriqueAModifier)
        {
            {
                DialogResult approuveChangement = MessageBox.Show(rubriqueAModifier + "\n\nCeci influencera toute donnée connexe.\n\nConfirmer...", "Attention!", MessageBoxButtons.OKCancel);
                return (approuveChangement != DialogResult.Cancel);
            }
        }
        internal List<RencontresDataGrid> GererRencontres(Rencontre newRencontre, int noTable, int noPartie, List<Joueur> joueurs, int ordre, string orderBy)
        {
            try { 
                int lignesAffectees = 0;

                if (newRencontre == null && ordre == lister)
                {
                    // La liste des rencontres est retournée, peu importe l'action à faire
                }
                if (newRencontre != null && ordre == ajouter)
                {
                    // Ajouter une rencontre (session) avec table et joute (partie)
                    int idNouvelleSession = dB_Manager.AjouterRencontreDansBD(newRencontre);
                    if (idNouvelleSession > 0 && noTable != 0 && noPartie !=0 && joueurs.Count !=0)
                    {
                        // Ajouter à la session :  table, joute et joueurs

                        int idTable = TrouverIdTable(noTable);
                        if (idTable == 0) throw new Exception("Table introuvalbe");

                        // Vérifier si table_Session_Joute existe avec date, heure, table et partie
                        // INsérer code ici

                        // Créer nouvelle partie et créer lien Session_Table_Partie
                        LiensSessionTablePartie newLienT_S_P = new LiensSessionTablePartie();
                        newLienT_S_P.IdSession = idNouvelleSession;
                        newLienT_S_P.IdTable = idTable;
                        newLienT_S_P.NoTable = noTable;
                        newLienT_S_P.NoPartie = noPartie;

                        int nbLiensCrees = AjouterTable(newLienT_S_P);
                        if (nbLiensCrees > 0) 
                        {
                            MessageBox.Show("Ajout de lien réussi");
                        }
                        //int idJoute = dB_Manager.TrouverIdJoute(newLienTable_Session_Joute);
                        //newLienT_S_P.NoPartie = dB_Manager.TrouverNoJoute(idJoute);

                        // Ajouter joueurs à la joute
                        int ajoutReussi = GererJoute(newLienT_S_P.IdPartie, newLienT_S_P.NoPartie, joueurs);

                        // Ajouter nombre de joueurs à rencontres data grid
                        if (ajoutReussi > 0)
                        {
                            MessageBox.Show("Ajout de joueurs réussi.");
                            foreach (var rencontreATrouver in rencontres)
                            {
                                if (idNouvelleSession == rencontreATrouver.IdSession)
                                {
                                    rencontreATrouver.NombreJoueurs = joueurs.Count;
                                    newLienT_S_P.IdSession = idNouvelleSession;
                                }
                            }
                        }

                        // Créer lien Joute_Score_Joueur
                        int newLienJoute_Score_Joueur = CreerLienJouteScoreJoueurDansBD(newLienT_S_P);

                        if (newLienJoute_Score_Joueur > 0)
                        {
                            MessageBox.Show("Ajout de lien réussi : " + newLienJoute_Score_Joueur.ToString() + " joueurs.");
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
                    // Supprimer une rencontre :  vérifier si liens avec d'autres tables avant de supprimer

                    // Lister liens puis les supprimer
                    int idJoute = 0;
                    List<LiensSessionTablePartie> liensSTP = dB_Manager.ListerLiensSessionTablePartie(" WHERE Id_Session = " + newRencontre.IdSession.ToString());
                    if (liensSTP.Count != 0)
                    {
                        List<LienJouteScoreJoueur> liensJSJ = dB_Manager.ListerLiensJouteScoreJoueur(" WHERE Id_Joute = " + liensSTP[0].IdPartie.ToString());
                        if (liensJSJ.Count != 0)
                        {
                            for (int noLien = 0; noLien < liensJSJ.Count; noLien++)
                            {
                                lignesAffectees = dB_Manager.SupprimerLienJouteScoreJoueur("DELETE FROM Joute_Score_Joueur WHERE Id_Score = " + liensJSJ[noLien].IdScore.ToString());
                                if (lignesAffectees != 0)
                                {
                                    dB_Manager.SupprimerScore(liensJSJ[noLien].IdScore);
                                }
                            }
                        }
                    }

                    // Supprimer rencontre et partie dans BD
                    lignesAffectees = dB_Manager.SupprimerRencontreDansBD(newRencontre.IdSession, noTable, noPartie);
                    if (lignesAffectees == 0) { MessageBox.Show("Exécution annulée"); }
                }

                if (newRencontre != null && ordre == modifier)
                {
                    //Modifier rencontre dans BD
                    lignesAffectees = dB_Manager.ModifierRencontreDansBD(newRencontre, modifier);
                    if (lignesAffectees == 0) { MessageBox.Show("Exécution annulée"); }
                }
            
                rencontres = dB_Manager.ListerRencontresDansBD(orderBy);
            }
            catch (Exception ex)
            {
                MsgErrDB();
            }
            return rencontres;
        }

        private int TrouverIdTable(int noTable)
        {
            return dB_Manager.TrouverIdTable(noTable);
        }

        private int AjouterTable(LiensSessionTablePartie lienT_S_P)
        {
            int nbLiensSessionTableJouteCree = 0;
            try 
            {
                lienT_S_P.IdPartie = dB_Manager.CreerNouvellePartie(lienT_S_P.NoPartie);
                nbLiensSessionTableJouteCree = dB_Manager.CreerLiens_Session_Table_Partie(lienT_S_P);
            }
            catch (Exception ex)
            {
                MsgErrDB();
            }
            return nbLiensSessionTableJouteCree;
        }
        internal bool VerifierLiens(DonneesRencontre nouvelledonneeRencontre)
        {
            // Vieux code, à remplacer
            // Vérifie s'il y a un lien créé dans la table Session_Table_Partie
            try
            {
                List<Rencontre> rencontresDansBD = dB_Manager.ListerRencontresSeules("");
                List<Table> tablesDansBD = dB_Manager.ListerTablesDansBD("");
                List<Partie> partiesDansBD = dB_Manager.ListerPartiesDansBD(null, "");
                List<LiensSessionTablePartie> liensSessionTableParties = dB_Manager.ListerLiensSessionTablePartie("");

                int idSessionDansBD = 0;
                List<int> listeSessionsAvecMatch = new List<int>();
                int idTableDansBD = 0;
                List<int> listeTablesAvecMatch = new List<int>();
                int idPartieDansBD = 0;
                List<int> listePartiesAvecMatch = new List<int>();
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
                    if (nouvelledonneeRencontre.NoTable == tableAVerifier.NoTable)
                    {
                        idTableDansBD = tableAVerifier.IDTable;
                        listeTablesAvecMatch.Add(idTableDansBD);
                        trouveMatchTable = true;
                    }
                }
                foreach (var partieAVerifier in partiesDansBD)
                {
                    if (nouvelledonneeRencontre.NoPartie == partieAVerifier.NoPartie)
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
            }
            catch (Exception ex)
            {
                MsgErrDB();
            }
            return false;
        }
        internal int GererJoute(int idJoute, int noJoute, List<Joueur> joueursAJouter)
        {
            int lignesAffectees = 0;
            try
            {
                if (joueursAJouter.Count <= 2) { MessageBox.Show("Un minimum de trois joueurs est requis."); return 0; }
                lignesAffectees = dB_Manager.AjouterJoueursDansJoute(idJoute, noJoute, joueursAJouter);
                
            }
            catch (Exception ex)
            {
                MsgErrDB();
            }
            return lignesAffectees;
        }

        internal List<LienJouteScoreJoueur> ListerLiensJouteScoreJoueur(Rencontre rencontreAjoutScores ,string commande)
        {
            try
            {
                return dB_Manager.ListerLiensJouteScoreJoueur(" WHERE Id_Joute =" + rencontreAjoutScores.Id_Joute.ToString());
            }
            catch (Exception ex)
            {
                MsgErrDB();
            }
            return null;
        }

        internal int CreerLienJouteScoreJoueurDansBD(LiensSessionTablePartie lienT_S_P)
        {
            int lignesAffectees = 0;
            try
            {
                Partie partie = new Partie();
                partie.IdPartie = lienT_S_P.IdPartie;
                List<Partie> parties = dB_Manager.ListerPartiesDansBD(partie, "");

                int id_Joute = parties[0].IdPartie;
                if (parties[0].Idjoueur1 != 0)
                {
                    int idScore = dB_Manager.CreerNouveauScore();
                    lignesAffectees += dB_Manager.CreerLienJouteScoreJoueur(id_Joute, parties[0].Idjoueur1, idScore);
                }
                if (parties[0].Idjoueur2 != 0)
                {
                    int idScore = dB_Manager.CreerNouveauScore();
                    lignesAffectees += dB_Manager.CreerLienJouteScoreJoueur(id_Joute, parties[0].Idjoueur2, idScore);
                }
                if (parties[0].Idjoueur3 != 0)
                {
                    int idScore = dB_Manager.CreerNouveauScore();
                    lignesAffectees += dB_Manager.CreerLienJouteScoreJoueur(id_Joute, parties[0].Idjoueur3, idScore);
                }
                if (parties[0].Idjoueur4 != 0)
                {
                    int idScore = dB_Manager.CreerNouveauScore();
                    lignesAffectees += dB_Manager.CreerLienJouteScoreJoueur(id_Joute, parties[0].Idjoueur4, idScore);
                }
            }
            catch (Exception ex)
            {
                MsgErrDB();
            }
            return lignesAffectees;
        }

        internal List<ScoreJoueurDataGrid> ListerScoresJoueurs(int lister, List<LienJouteScoreJoueur> liensJouteScoreJoueur, int idJoute)
        {
            try
            {
                List<ScoreJoueurDataGrid> scoresDataGrid = new List<ScoreJoueurDataGrid>();
                foreach (var lien in liensJouteScoreJoueur)
                {
                    if (lien.IdJoute == idJoute)
                    {
                        //Trouver joueur
                        Joueur joueur = dB_Manager.ListerJoueursDansBD("WHERE ID_Joueur = " + lien.IdJoueur.ToString())[0];
                        //Trouver score
                        Score score = dB_Manager.ListerScoresDansBD("WHERE ID_Score = " + lien.IdScore.ToString())[0];
                        // Ajouter à datagridJoueur
                        ScoreJoueurDataGrid scoreJoueur = new ScoreJoueurDataGrid();
                        score.IdScore = lien.IdScore;
                        scoreJoueur.IdJoute = idJoute;
                        scoreJoueur.Joueur = joueur;
                        scoreJoueur.ScoreJoueur = score;
                        
                        scoresDataGrid.Add(scoreJoueur);
                    }
                }
                return scoresDataGrid;
            }
            catch (Exception ex)
            {
                MsgErrDB();
            }
            return null;
        }

        internal int GererScore(int ajouter, ScoreJoueurDataGrid scoreJoueurDataGrid)
        {
            try
            {
                return dB_Manager.AjouterDonneesScore(scoreJoueurDataGrid);
            }
            catch (Exception ex)
            {
                MsgErrDB();
            }
            return 0;
        }

        internal void MsgErrDB()
        {
            MessageBox.Show("Erreur interne 1218 : Base de données.\nContacter votre service informatique.");
        }
    }
}
