using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.LinkLabel;

namespace WindowsFormsLigueScrabble
{
    internal partial class ScoresForm : Form
    {
        Controleur controleur;
        Rencontre rencontreAjoutScores;
        //Score[] scoreJoueur = new Score[4];
        //List<Score[]> scores = new List<Score[]>();
        List<LienJouteScoreJoueur> liensJouteScoreJoueur = new List<LienJouteScoreJoueur>();
        List<ScoreJoueurDataGrid> scoresDataGrid = new List<ScoreJoueurDataGrid>();
        bool chargementEnCours = false;
        bool changementDataGridNonSauvegarde = false;

        int nouveauScore = 1;
        int scoreEnCours = 2;

        int indexLigneNom;
        int indexLignePseudo;
        int indexLigneRang;
        int indexLigneTotal;
        int indexLignePenalite;
        int indexLigneBonus;

        public ScoresForm(Controleur controleurX, Rencontre rencontreAAjouterScoresX)
        {
            InitializeComponent();
            controleur = controleurX;
            rencontreAjoutScores = rencontreAAjouterScoresX;
        }

        private void ScoresForm_Load(object sender, EventArgs e)
        {
            liensJouteScoreJoueur = controleur.ListerLiensJouteScoreJoueur("");
            //scoresDataGrid = controleur.GererScore(controleur.lister, liensJouteScoreJoueur);
            if (JouteExiste())
            {
                InitialiserDataGridViewScores();
            }
            else CreerNouveauxScores();
        }

        private void InitialiserDataGridViewScores()
        {
            List<ScoreJoueurDataGrid> scoresBrut = new List<ScoreJoueurDataGrid>();
            scoresBrut = controleur.ListerLiensJouteScoreJoueur(controleur.lister, liensJouteScoreJoueur, rencontreAjoutScores.Id_Joute);
            scoresDataGrid = DeterminerLesRangsDesJoueurs(scoresBrut);
            RemplirDataGridScores(scoreEnCours, null);
            ModifierScoresAJouteDejaCommencee();
        }

        private List<ScoreJoueurDataGrid> DeterminerLesRangsDesJoueurs(List<ScoreJoueurDataGrid> scores)
        {
            List<int> totalJoueur = new List<int>();
            int indexRang1;
            int indexRang2;
            int indexRang3;
            int indexRang4 = 5;
            foreach (var score in scores)
            {
                totalJoueur.Add(score.ScoreJoueur.Total);
            }

            indexRang1 = totalJoueur.IndexOf(totalJoueur.Max());

            totalJoueur[indexRang1] = 0;
            indexRang2 = totalJoueur.IndexOf(totalJoueur.Max());
            totalJoueur[indexRang2] = 0;
            indexRang3 = totalJoueur.IndexOf(totalJoueur.Max());
            totalJoueur[indexRang3] = 0;
            if (totalJoueur.Count == 4) indexRang4 = totalJoueur.IndexOf(totalJoueur.Max());

            for (int colonne = 0; colonne < scores.Count; colonne++)
            {
                if (colonne == indexRang1) scores[colonne].Rang = "1er";
                if (colonne == indexRang2) scores[colonne].Rang = "2e";
                if (colonne == indexRang3) scores[colonne].Rang = "3e";
                if (colonne == indexRang4) scores[colonne].Rang = "4e";
            }
            return scores;
        }

        private void CreerNouveauxScores()
        {
            //Créer un nouveau Score et un nouveau lien Joute_Score_Joueur
            int lienJouteScoreJoueurCree = controleur.CreerLienJouteScoreJoueurDansBD(rencontreAjoutScores);
            if (lienJouteScoreJoueurCree == 0) { MessageBox.Show("Une erreur s'est produite lors de la création\ndes nouveaux scores."); }
            RemplirDataGridScores(nouveauScore, null);
        }
        private bool JouteExiste()
        {
            bool jouteExiste = false;
            foreach (var lien in liensJouteScoreJoueur)
            {
                if (lien.IdJoute == rencontreAjoutScores.Id_Joute) jouteExiste |= true;
            }
            return jouteExiste;
        }

        private void ModifierScoresAJouteDejaCommencee()
        {

        }

        private void RemplirDataGridScores(int commande, List<ScoreJoueurDataGrid> scoresModifies)
        {
            //On souhaite afficher les scores avec les noms des joueurs dans les colonnes
            // et le pointage dans les lignes

            // Récupérer les données à afficher
            chargementEnCours = true; //Bloque l'événement : "Changement dans les cellules"
            dataGridViewScores.DataSource = null;
            dataGridViewScores.DataSource = scoresDataGrid;
            if (scoresModifies != null) dataGridViewScores.DataSource = scoresModifies;
            if (commande == 3) return;
            // Prépare pour inverser colonnes-lignes du datagridview
            int nbLignes = dataGridViewScores.Rows.Count;
            int nbColonnes = dataGridViewScores.Columns.Count;

            // Stoquer les valeurs du datagridview dans un tableau temporaire
            string[,] tableauInverseValeurs = new string[nbLignes, nbColonnes];
            for (int lignesDataGrid = 0; lignesDataGrid < nbColonnes; lignesDataGrid++)
            {
                for (int colonnesDataGrid = 0; colonnesDataGrid < nbLignes; colonnesDataGrid++)
                {
                    {
                        tableauInverseValeurs[colonnesDataGrid, lignesDataGrid] = dataGridViewScores[lignesDataGrid, colonnesDataGrid].FormattedValue.ToString();
                    }
                }
            }

            // Stoquer les titres des colonnes dans une liste temporaire
            List<string> tableauInverseTitres = new List<string>();

            DataGridViewColumn colonneDataGrid = new DataGridViewColumn();
            foreach (DataGridViewColumn colonne in dataGridViewScores.Columns)
            {
                tableauInverseTitres.Add((string)colonne.HeaderCell.Value);
            }

            // Transférer les données temporaires dans un nouveau datagridview dont les lignes-colonnes sont inversées
            dataGridViewScores.DataSource = null;
            dataGridViewScores.ColumnCount = nbLignes;
            dataGridViewScores.RowCount = nbColonnes;

            for (int lignesDataGrid = 0; lignesDataGrid < nbColonnes; lignesDataGrid++)
            {   //Headers
                dataGridViewScores.Rows[lignesDataGrid].HeaderCell.Value = tableauInverseTitres[lignesDataGrid];
            }

            for (int lignesTableauInverse = 0; lignesTableauInverse < tableauInverseValeurs.GetLength(0); lignesTableauInverse++)
            {   //Data
                for (int colonnesTableauInverse = 0; colonnesTableauInverse < tableauInverseValeurs.GetLength(1); colonnesTableauInverse++)
                {
                    {
                        dataGridViewScores[lignesTableauInverse, colonnesTableauInverse].Value = tableauInverseValeurs[lignesTableauInverse, colonnesTableauInverse];
                    }
                }
            }

            FormatterAffichageDataGridViewScores();

            
            chargementEnCours = false;
            changementDataGridNonSauvegarde = false;
        }

        private void FormatterAffichageDataGridViewScores()
        {
            dataGridViewScores.RowHeadersDefaultCellStyle.Font = new Font("Verdana", 9);
            dataGridViewScores.DefaultCellStyle.Font = new Font("Verdana", 12);

            for (int ligne = 0; ligne < dataGridViewScores.RowCount; ligne++)
            {
                if ((string)dataGridViewScores.Rows[ligne].HeaderCell.Value == "NomJoueur")
                {
                    dataGridViewScores.Rows[ligne].HeaderCell.Value = "Joueur";
                    dataGridViewScores.Rows[ligne].ReadOnly = true;
                    indexLigneNom = ligne;
                }
                if ((string)dataGridViewScores.Rows[ligne].HeaderCell.Value == "PseudoJoueur")
                {
                    dataGridViewScores.Rows[ligne].HeaderCell.Value = "Pseudo/Nom";
                    dataGridViewScores.Rows[ligne].ReadOnly = true;
                    indexLignePseudo = ligne;

                }
                if ((string)dataGridViewScores.Rows[ligne].HeaderCell.Value == "Rang")
                {
                    dataGridViewScores.Rows[ligne].ReadOnly = true;
                    indexLigneRang = ligne;

                }
                if ((string)dataGridViewScores.Rows[ligne].HeaderCell.Value == "TotalJoueur")
                {
                    dataGridViewScores.Rows[ligne].HeaderCell.Value = "Total";
                    dataGridViewScores.Rows[ligne].ReadOnly = true;
                    dataGridViewScores.Rows[ligne].DefaultCellStyle.Font = new Font("Verdana", 12, FontStyle.Bold);
                    dataGridViewScores.Rows[ligne].DefaultCellStyle.ForeColor = Color.Blue;
                    indexLigneTotal = ligne;
                }
                if ((string)dataGridViewScores.Rows[ligne].HeaderCell.Value == "IdScore")
                {
                    dataGridViewScores.Rows[ligne].Visible = false;
                }
                if ((string)dataGridViewScores.Rows[ligne].HeaderCell.Value == "IdJoute")
                {
                    dataGridViewScores.Rows[ligne].Visible = false;
                }
                if ((string)dataGridViewScores.Rows[ligne].HeaderCell.Value == "IdJoueur")
                {
                    dataGridViewScores.Rows[ligne].Visible = false;
                }
                if ((string)dataGridViewScores.Rows[ligne].HeaderCell.Value == "Penalite")
                {
                    dataGridViewScores.Rows[ligne].DefaultCellStyle.ForeColor = Color.Red;
                    indexLignePenalite = ligne;
                }
                if ((string)dataGridViewScores.Rows[ligne].HeaderCell.Value == "Bonus")
                {
                    dataGridViewScores.Rows[ligne].DefaultCellStyle.ForeColor = Color.Green;
                    indexLigneBonus = ligne;
                }
            }
            dataGridViewScores.AutoResizeRowHeadersWidth(DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders);
            dataGridViewScores.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        private void buttonAnnulerModifs_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Cette fonctionnalité n'est pas disponible.\n\nPour annuler TOUTES les modifications,\n veuillez fermer cette page sans sauvegarder\npuis modifier à nouveau la session.");
        }

        private void buttonEnregistrerModifs_Click(object sender, EventArgs e)
        {
            int lignesAffectees = 0;
            List<ScoreJoueurDataGrid> scoresASauvegarderDataGrid = RecupererScoresDansDataGridScores();

            for (int noScore = 0; noScore < scoresASauvegarderDataGrid.Count; noScore++)
            {
                lignesAffectees = controleur.GererScore(controleur.ajouter, scoresASauvegarderDataGrid[noScore]);
            }

            changementDataGridNonSauvegarde = false;
        }

        private List<ScoreJoueurDataGrid> RecupererScoresDansDataGridScores()
        {
            List<ScoreJoueurDataGrid> scoresDansDataGrid = new List<ScoreJoueurDataGrid>();
            for (int colonne = 0; colonne < dataGridViewScores.Columns.Count; colonne++)
            {
                Joueur nouveauJoueur = new Joueur();
                Score nouveauScore = new Score();
                ScoreJoueurDataGrid nouveauScoreJoueur = new ScoreJoueurDataGrid();
                nouveauScoreJoueur.IdJoute = int.Parse(dataGridViewScores[colonne, 0].FormattedValue.ToString());
                nouveauScore.IdScore = int.Parse(dataGridViewScores[colonne, 1].FormattedValue.ToString());
                nouveauJoueur.IdJoueur = int.Parse(dataGridViewScores[colonne, 2].FormattedValue.ToString());
                nouveauJoueur.Nom = dataGridViewScores[colonne, indexLigneNom].FormattedValue.ToString();
                nouveauJoueur.Pseudo = dataGridViewScores[colonne, indexLignePseudo].FormattedValue.ToString();

                nouveauScore.Tour1 = int.Parse(dataGridViewScores[colonne, 7].FormattedValue.ToString());
                nouveauScore.Tour2 = int.Parse(dataGridViewScores[colonne, 8].FormattedValue.ToString());
                nouveauScore.Tour3 = int.Parse(dataGridViewScores[colonne, 9].FormattedValue.ToString());
                nouveauScore.Tour4 = int.Parse(dataGridViewScores[colonne, 10].FormattedValue.ToString());
                nouveauScore.Tour5 = int.Parse(dataGridViewScores[colonne, 11].FormattedValue.ToString());
                nouveauScore.Bonus = int.Parse(dataGridViewScores[colonne, indexLigneBonus].FormattedValue.ToString());
                nouveauScore.Penalite = int.Parse(dataGridViewScores[colonne, indexLignePenalite].FormattedValue.ToString());
                nouveauScoreJoueur.Joueur = nouveauJoueur;
                nouveauScoreJoueur.ScoreJoueur = nouveauScore;
                scoresDansDataGrid.Add(nouveauScoreJoueur);
            }
            return scoresDansDataGrid;
        }

        private void dataGridViewScores_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (!chargementEnCours)
            {
                // Empêche la cellule d'être effacée 
                if (dataGridViewScores[e.ColumnIndex, e.RowIndex].Value == null)
                {
                    dataGridViewScores[e.ColumnIndex, e.RowIndex].Value = 0;
                }
                // Empêche la pénalité d'être un nombre positif
                if (e.RowIndex == indexLignePenalite)
                {
                    if (int.Parse((string)dataGridViewScores[e.ColumnIndex, e.RowIndex].FormattedValue) > 0)
                    {
                        MessageBox.Show("Entrer un nombre négatif.");
                        dataGridViewScores[e.ColumnIndex, e.RowIndex].Value = 0;
                    }
                }

                // Refaire les calculs des totaux et des rangs
                List<ScoreJoueurDataGrid> scoresModifiesBrut = RecupererScoresDansDataGridScores();
                List<ScoreJoueurDataGrid> scoresModifies = DeterminerLesRangsDesJoueurs(scoresModifiesBrut);
                for (int colonne = 0; colonne < scoresModifies.Count; colonne++)
                {
                    dataGridViewScores[colonne, indexLigneRang].Value = scoresModifies[colonne].Rang;
                    //dataGridViewScores[1, indexLigneRang].Value = scoresModifies[1].Rang;
                    //dataGridViewScores[2, indexLigneRang].Value = scoresModifies[2].Rang;
                    //dataGridViewScores[3, indexLigneRang].Value = scoresModifies[3].Rang;
                    dataGridViewScores[colonne, indexLigneTotal].Value = scoresModifies[colonne].TotalJoueur;
                    //dataGridViewScores[1, indexLigneTotal].Value = scoresModifies[1].TotalJoueur;
                    //dataGridViewScores[2, indexLigneTotal].Value = scoresModifies[2].TotalJoueur;
                    //dataGridViewScores[3, indexLigneTotal].Value = scoresModifies[3].TotalJoueur;
                }

                changementDataGridNonSauvegarde = true;
            }
        }
        private void buttonQuitter_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ScoresForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (changementDataGridNonSauvegarde)
            {
                bool fermerOk = controleur.DemandeDeConfirmation("Quitter cette page sans enregistrer les modifications? ");
                if (!fermerOk) e.Cancel = true;
                else return;
            }
        }
    }
}
