using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZstdSharp.Unsafe;
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
        List<ScoreJoueurDataGrid> backupDataGridScores = new List<ScoreJoueurDataGrid>();
        bool chargementEnCours = false;
        bool changementDataGridNonSauvegarde = false;
        bool premierChargementScores = true;
        int lignesDeScoreAAfficher = 20;

        int nouveauScore = 1;
        int scoreEnCours = 2;
        int lignesDeScoreSuppl = 2;
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

            liensJouteScoreJoueur = controleur.ListerLiensJouteScoreJoueur(rencontreAjoutScores, "");
            if (liensJouteScoreJoueur == null) controleur.MsgErrDB();
            if (JouteExiste())
            {
                InitialiserDataGridViewScores();
                AfficherInfosRencontre(rencontreAjoutScores);
                backupDataGridScores.AddRange(scoresDataGrid);
            }
            //else CreerNouveauxScores();
        }

        private void AfficherInfosRencontre(Rencontre rencontreAjoutScores)
        {
            labelDate.Text = rencontreAjoutScores.DateDeJeu.ToString("D");
            labelHeure.Text = rencontreAjoutScores.DateDeJeu.ToString("t");
            labelTable.Text += rencontreAjoutScores.NoTable.ToString();
            labelJoute.Text += rencontreAjoutScores.NoJoute.ToString();
        }

        private void InitialiserDataGridViewScores()
        {
            List<ScoreJoueurDataGrid> scoresBrut = new List<ScoreJoueurDataGrid>();
            scoresBrut = controleur.ListerScoresJoueurs(controleur.lister, liensJouteScoreJoueur, rencontreAjoutScores.Id_Joute);
            if (scoresBrut == null) controleur.MsgErrDB();
            scoresDataGrid = DeterminerLesRangsDesJoueurs(scoresBrut);
            dataGridViewScores.DataSource = scoresDataGrid;
            foreach (var scoreJoueur in scoresDataGrid)
            {
                scoreJoueur.ScoreJoueur.ToursNonNuls = controleur.CalculerNbToursJoues(scoreJoueur);
            }
            RemplirDataGridScores(scoreEnCours, null);
            //ModifierScoresAJouteDejaCommencee();
        }

        private List<ScoreJoueurDataGrid> DeterminerLesRangsDesJoueurs(List<ScoreJoueurDataGrid> scores)
        {
            List<int> totalJoueur = new List<int>();
            int indexRang1;
            int indexRang2;
            int indexRang3;
            int indexRang4;
            int joueursSansTotal = 0;
            foreach (var score in scores)
            {
                totalJoueur.Add(score.ScoreJoueur.Total);
                if (score.ScoreJoueur.Total == 0) joueursSansTotal++;
            }
            indexRang1 = totalJoueur.IndexOf(totalJoueur.Max());
            totalJoueur[indexRang1] = 0;
            indexRang2 = totalJoueur.IndexOf(totalJoueur.Max());
            totalJoueur[indexRang2] = 0;
            indexRang3 = totalJoueur.IndexOf(totalJoueur.Max());
            totalJoueur[indexRang3] = 0;
            if (totalJoueur.Count == 4) indexRang4 = totalJoueur.IndexOf(totalJoueur.Max());
            else indexRang4 = 0;
            for (int colonne = 0; colonne < scores.Count; colonne++)
            {
                if (joueursSansTotal == 0)
                {
                    if (colonne == indexRang1) scores[colonne].Rang = "1er";
                    if (colonne == indexRang2) scores[colonne].Rang = "2e";
                    if (colonne == indexRang3) scores[colonne].Rang = "3e";
                    if (totalJoueur.Count > 3) if (colonne == indexRang4) scores[colonne].Rang = "4e";
                }
                else scores[colonne].Rang = "";
            }
            return scores;
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
        //private void ModifierScoresAJouteDejaCommencee()
        //{

        //}
        private void RemplirDataGridScores(int commande, List<ScoreJoueurDataGrid> scoresModifies)
        {
            //On souhaite afficher les scores avec les noms des joueurs dans les colonnes
            // et le pointage dans les lignes. Pour ce faire il faut pivoter les données du datagridview

            chargementEnCours = true; //Bloque l'événement : "dataGridViewScores_CellValueChanged"
            
            //if (scoresModifies != null) dataGridViewScores.DataSource = scoresModifies;
            //if (commande == 3) return;

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
            //int test = dataGridViewScores.Rows.Count;
            //int test2 = dataGridViewScores.Columns.Count;

        }

        private List<string> AfficherListeHeader (DataGridView dataGridView, string ligneOuColonne)
        {
            List<string> valeurs = new List<string>();
            int nbFinal = dataGridView.Rows.Count;
            if (ligneOuColonne == "colonnes") nbFinal = dataGridView.Columns.Count;
            for (int ligne = 0; ligne < nbFinal; ligne++)
            {
                if (ligneOuColonne != "colonnes") 
                    valeurs.Add((string)dataGridViewScores.Rows[ligne].HeaderCell.Value);
                else valeurs.Add((string)dataGridViewScores.Columns[ligne].HeaderCell.Value);
                
            }
            return valeurs;
        }   

        private void FormatterAffichageDataGridViewScores()
        {

            dataGridViewScores.ColumnHeadersVisible = false;
            dataGridViewScores.RowHeadersDefaultCellStyle.Font = new Font("Verdana", 9);
            dataGridViewScores.DefaultCellStyle.Font = new Font("Verdana", 12);

            // Enleve les lignes inutiles créées par le pivotage
            //for (int ligne = 0; ligne < dataGridViewScores.RowCount; ligne++)
            //{
            //    valeurs.Add((string)dataGridViewScores.Rows[ligne].HeaderCell.Value);
            //    if ((string)dataGridViewScores.Rows[ligne].HeaderCell.Value == "")
            //    {
            //        dataGridViewScores.Rows.RemoveAt(ligne);
            //    }
            //}
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
                if ((string)dataGridViewScores.Rows[ligne].HeaderCell.FormattedValue == "IdScore")
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
            if (premierChargementScores)
            {
                int nbToursNonNulsMin = 20;
                for (int noJoueur = 0; noJoueur < scoresDataGrid.Count; noJoueur++)
                {
                    if (nbToursNonNulsMin > scoresDataGrid[noJoueur].ScoreJoueur.ToursNonNuls)
                    {
                        nbToursNonNulsMin = scoresDataGrid[noJoueur].ScoreJoueur.ToursNonNuls;
                    }
                    lignesDeScoreAAfficher = nbToursNonNulsMin + lignesDeScoreSuppl;
                }
            }

            //lignesDeScoreAAfficher = lignesDeScoreAAfficher + lignesDeScoreSuppl;
            if (lignesDeScoreAAfficher < 20) dataGridViewScores.Rows[26].Visible = false;
            else dataGridViewScores.Rows[26].Visible = true;
            if (lignesDeScoreAAfficher < 19) dataGridViewScores.Rows[25].Visible = false;
            else dataGridViewScores.Rows[25].Visible = true;
            if (lignesDeScoreAAfficher < 18) dataGridViewScores.Rows[24].Visible = false;
            else dataGridViewScores.Rows[24].Visible = true;
            if (lignesDeScoreAAfficher < 17) dataGridViewScores.Rows[23].Visible = false;
            else dataGridViewScores.Rows[23].Visible = true;
            if (lignesDeScoreAAfficher < 16) dataGridViewScores.Rows[22].Visible = false;
            else dataGridViewScores.Rows[22].Visible = true;
            if (lignesDeScoreAAfficher < 15) dataGridViewScores.Rows[21].Visible = false;
            else dataGridViewScores.Rows[21].Visible = true;
            if (lignesDeScoreAAfficher < 14) dataGridViewScores.Rows[20].Visible = false;
            else dataGridViewScores.Rows[20].Visible = true;
            if (lignesDeScoreAAfficher < 13) dataGridViewScores.Rows[19].Visible = false;
            else dataGridViewScores.Rows[19].Visible = true;
            if (lignesDeScoreAAfficher < 12) dataGridViewScores.Rows[18].Visible = false;
            else dataGridViewScores.Rows[18].Visible = true;
            if (lignesDeScoreAAfficher < 11) dataGridViewScores.Rows[17].Visible = false;
            else dataGridViewScores.Rows[17].Visible = true;
            if (lignesDeScoreAAfficher < 10) dataGridViewScores.Rows[16].Visible = false;
            else dataGridViewScores.Rows[16].Visible = true;
            if (lignesDeScoreAAfficher < 9) dataGridViewScores.Rows[15].Visible = false;
            else dataGridViewScores.Rows[15].Visible = true;
            if (lignesDeScoreAAfficher < 8) dataGridViewScores.Rows[14].Visible = false;
            else dataGridViewScores.Rows[14].Visible = true;

            premierChargementScores = false;
            dataGridViewScores.AutoResizeRowHeadersWidth(DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders);
            dataGridViewScores.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        private void buttonAnnulerModifs_Click(object sender, EventArgs e)
        {
            scoresDataGrid.Clear();
            List<string> valeurs = AfficherListeHeader(dataGridViewScores, "colonnes");
            scoresDataGrid.AddRange(backupDataGridScores);
            dataGridViewScores.DataSource = scoresDataGrid;
            InitialiserDataGridViewScores();
            //MessageBox.Show("Cette fonctionnalité n'est pas disponible.\n\nPour annuler TOUTES les modifications,\n veuillez fermer cette page sans sauvegarder\npuis modifier à nouveau la session.");
        }

        private void buttonEnregistrerModifs_Click(object sender, EventArgs e)
        {
            int lignesAffectees = 0;
            List<ScoreJoueurDataGrid> scoresASauvegarderDataGrid = RecupererScoresDansDataGridScores();

            for (int noScore = 0; noScore < scoresASauvegarderDataGrid.Count; noScore++)
            {
                lignesAffectees = controleur.GererScore(controleur.ajouter, scoresASauvegarderDataGrid[noScore]);
            }
            if (lignesAffectees > 0) MessageBox.Show("Données sauvegardées.");
            else controleur.MsgErrDB();
            changementDataGridNonSauvegarde = false;
        }

        private List<ScoreJoueurDataGrid> RecupererScoresDansDataGridScores()
        {
            List<ScoreJoueurDataGrid> scoresDansDataGrid = new List<ScoreJoueurDataGrid>();
            // Enleve les lignes inutiles créées par le pivotage
            //for (int ligne = 0; ligne < dataGridViewScores.RowCount; ligne++)
            //{
            //    if ((string)dataGridViewScores.Rows[ligne].HeaderCell.Value == "")
            //    {
            //        dataGridViewScores.Rows.RemoveAt(ligne);
            //    }
            //}
            for (int colonne = 0; colonne < dataGridViewScores.Columns.Count; colonne++)
            {
                Joueur nouveauJoueur = new Joueur();
                Score nouveauScore = new Score();
                ScoreJoueurDataGrid nouveauScoreJoueur = new ScoreJoueurDataGrid();
                nouveauScoreJoueur.Joueur = nouveauJoueur;
                nouveauScoreJoueur.ScoreJoueur = nouveauScore;
                nouveauScoreJoueur.IdJoute = int.Parse(dataGridViewScores[colonne, 0].FormattedValue.ToString());
                nouveauScore.IdScore = int.Parse(dataGridViewScores[colonne, 1].FormattedValue.ToString());
                nouveauScoreJoueur.Joueur.IdJoueur = int.Parse(dataGridViewScores[colonne, 2].FormattedValue.ToString());
                nouveauScoreJoueur.Joueur.Nom = dataGridViewScores[colonne, indexLigneNom].FormattedValue.ToString();
                nouveauScoreJoueur.Joueur.Pseudo = dataGridViewScores[colonne, indexLignePseudo].FormattedValue.ToString();

                nouveauScoreJoueur.ScoreJoueur.Tour1 = int.Parse(dataGridViewScores[colonne, 7].FormattedValue.ToString());
                nouveauScoreJoueur.ScoreJoueur.Tour2 = int.Parse(dataGridViewScores[colonne, 8].FormattedValue.ToString());
                nouveauScoreJoueur.ScoreJoueur.Tour3 = int.Parse(dataGridViewScores[colonne, 9].FormattedValue.ToString());
                nouveauScoreJoueur.ScoreJoueur.Tour4 = int.Parse(dataGridViewScores[colonne, 10].FormattedValue.ToString());
                nouveauScoreJoueur.ScoreJoueur.Tour5 = int.Parse(dataGridViewScores[colonne, 11].FormattedValue.ToString());
                nouveauScoreJoueur.ScoreJoueur.Tour6 = int.Parse(dataGridViewScores[colonne, 12].FormattedValue.ToString());
                nouveauScoreJoueur.ScoreJoueur.Tour7 = int.Parse(dataGridViewScores[colonne, 13].FormattedValue.ToString());
                nouveauScoreJoueur.ScoreJoueur.Tour8 = int.Parse(dataGridViewScores[colonne, 14].FormattedValue.ToString());
                nouveauScoreJoueur.ScoreJoueur.Tour9 = int.Parse(dataGridViewScores[colonne, 15].FormattedValue.ToString());
                nouveauScoreJoueur.ScoreJoueur.Tour10 = int.Parse(dataGridViewScores[colonne, 16].FormattedValue.ToString());
                nouveauScoreJoueur.ScoreJoueur.Tour11 = int.Parse(dataGridViewScores[colonne, 17].FormattedValue.ToString());
                nouveauScoreJoueur.ScoreJoueur.Tour12 = int.Parse(dataGridViewScores[colonne, 18].FormattedValue.ToString());
                nouveauScoreJoueur.ScoreJoueur.Tour13 = int.Parse(dataGridViewScores[colonne, 19].FormattedValue.ToString());
                nouveauScoreJoueur.ScoreJoueur.Tour14 = int.Parse(dataGridViewScores[colonne, 20].FormattedValue.ToString());
                nouveauScoreJoueur.ScoreJoueur.Tour15 = int.Parse(dataGridViewScores[colonne, 21].FormattedValue.ToString());
                nouveauScoreJoueur.ScoreJoueur.Tour16 = int.Parse(dataGridViewScores[colonne, 22].FormattedValue.ToString());
                nouveauScoreJoueur.ScoreJoueur.Tour17 = int.Parse(dataGridViewScores[colonne, 23].FormattedValue.ToString());
                nouveauScoreJoueur.ScoreJoueur.Tour18 = int.Parse(dataGridViewScores[colonne, 24].FormattedValue.ToString());
                nouveauScoreJoueur.ScoreJoueur.Tour19 = int.Parse(dataGridViewScores[colonne, 25].FormattedValue.ToString());
                nouveauScoreJoueur.ScoreJoueur.Tour20 = int.Parse(dataGridViewScores[colonne, 26].FormattedValue.ToString());
                nouveauScoreJoueur.ScoreJoueur.Bonus = int.Parse(dataGridViewScores[colonne, indexLigneBonus].FormattedValue.ToString());
                nouveauScoreJoueur.ScoreJoueur.Penalite = int.Parse(dataGridViewScores[colonne, indexLignePenalite].FormattedValue.ToString());
                //nouveauScoreJoueur.Joueur = nouveauJoueur;
                //nouveauScoreJoueur.ScoreJoueur = nouveauScore;
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
                    dataGridViewScores[colonne, indexLigneTotal].Value = scoresModifies[colonne].TotalJoueur;
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

        private void enregistrerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int lignesAffectees = 0;
            List<ScoreJoueurDataGrid> scoresASauvegarderDataGrid = RecupererScoresDansDataGridScores();

            for (int noScore = 0; noScore < scoresASauvegarderDataGrid.Count; noScore++)
            {
                lignesAffectees = controleur.GererScore(controleur.ajouter, scoresASauvegarderDataGrid[noScore]);
            }
            if (lignesAffectees > 0) MessageBox.Show("Données sauvegardées.");
            else controleur.MsgErrDB();
            changementDataGridNonSauvegarde = false;
        }

        private void modificationsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Annule les modifications en rechargeant les données originales
            scoresDataGrid.Clear();
            List<string> valeurs = AfficherListeHeader(dataGridViewScores, "colonnes");
            scoresDataGrid.AddRange(backupDataGridScores);
            dataGridViewScores.DataSource = scoresDataGrid;
            InitialiserDataGridViewScores();
        }

        private void lignesDeScoreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Ajoute des lignes de score supplémentaires 
            lignesDeScoreAAfficher++;
            if (lignesDeScoreAAfficher > 20) 
            {
                MessageBox.Show("Le nombre de lignes de score ne peut pas dépasser 20.");
                lignesDeScoreAAfficher = 20;
            }
            
            FormatterAffichageDataGridViewScores();
        }

        private void fermerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
