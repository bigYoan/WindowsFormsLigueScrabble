using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
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
        Score score = new Score();
        Rencontre rencontreAjoutScores;
        //Score[] scoreJoueur = new Score[4];
        //List<Score[]> scores = new List<Score[]>();
        List<LienJouteScoreJoueur> liensJouteScoreJoueur = new List<LienJouteScoreJoueur>();
        List<ScoreJoueurDataGrid> scoresDataGrid = new List<ScoreJoueurDataGrid>();
        List<ScoreJoueurDataGrid> backupDataGridScores = new List<ScoreJoueurDataGrid>();
        List<ScoreJoueurDataGrid> scoresModifiesBrut = new List<ScoreJoueurDataGrid>();
        bool chargementEnCours = false;
        bool changementDataGridNonSauvegarde = false;
        bool premierChargementScores = true;
        int lignesDeScoreAAfficher = 20;
        const int lignesDeScoresSiScoresVides = 10;
        int nouveauScore = 1;
        int scoreEnCours = 2;
        int lignesDeScoreSuppl = 2;
        DataGridIndexLigne indexLigne = new DataGridIndexLigne();
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
            else
            {
                InitialiserDataGridViewScores();
                AfficherInfosRencontre(rencontreAjoutScores);
                backupDataGridScores.AddRange(scoresDataGrid);
                scoresModifiesBrut = score.RecupererScoresDansDataGridScores(dataGridViewScores, indexLigne);
            }
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
            scoresBrut = score.InitialiseLaListeScoresAAfficher(rencontreAjoutScores);
            scoresDataGrid = score.DeterminerLesRangsDesJoueurs(scoresBrut);
            scoresDataGrid = score.CompterToursNonNuls(scoresDataGrid);
            chargementEnCours = true; //Bloquer l'événement : "dataGridViewScores_CellValueChanged"
            score.PivoterScores(ref dataGridViewScores, scoresDataGrid); //Pour afficher les scores verticalement
            score.FormatterAffichageDataGridViewScores(scoresDataGrid, ref dataGridViewScores, ref indexLigne, ref premierChargementScores, ref lignesDeScoreAAfficher, ref lignesDeScoreSuppl);
            chargementEnCours = false;  // Réactive l'événement : "dataGridViewScores_CellValueChanged"
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

        private void dataGridViewScores_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (!chargementEnCours)   // Ne pas valider si les données sont en chargement
                {
                    // Empêche une cellule vide d'être effacée - empêche de planter l'appli
                    if (dataGridViewScores[e.ColumnIndex, e.RowIndex].Value == null)
                    {
                        dataGridViewScores[e.ColumnIndex, e.RowIndex].Value = 0;
                    }
                    // Empêche la pénalité d'être un nombre positif
                    else if (e.RowIndex == indexLigne.Penalite)
                    {
                        bool nombreOk = int.TryParse((string)dataGridViewScores[e.ColumnIndex, e.RowIndex].FormattedValue, out int result);
                        if (nombreOk && result <= 0) { }
                        else if (nombreOk && result > 0) dataGridViewScores[e.ColumnIndex, e.RowIndex].Value = - result;
                        else
                        {
                            MessageBox.Show("Points de pénalité : SVP, entrer un nombre négatif.");
                            return;
                            //dataGridViewScores[e.ColumnIndex, e.RowIndex].Value = 0;
                        }
                    }
                    MetAJourDansDataGrid(e.RowIndex, e.ColumnIndex);
                    changementDataGridNonSauvegarde = true; // Changement valide
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Erreur de données.\nSVP, corriger.");
                //throw;
            }
            
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
            // Récupérer les scores affichés dans DataGridView
            // Écrire dans la BD

            int lignesAffectees = 0;
            List<ScoreJoueurDataGrid> scoresASauvegarderDataGrid = score.RecupererScoresDansDataGridScores(dataGridViewScores, indexLigne); ;

            for (int noScore = 0; noScore < scoresASauvegarderDataGrid.Count; noScore++)
            {
                lignesAffectees = controleur.GererScore(controleur.ajouter, scoresASauvegarderDataGrid[noScore]);
            }
            if (lignesAffectees > 0) MessageBox.Show("Données sauvegardées.");
            else controleur.MsgErrDB();
            changementDataGridNonSauvegarde = false;
        }

        private void fermerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridViewScores_KeyUp(object sender, KeyEventArgs e)
        {
            // Intercepte une touche pour outrepasser le mode "Read Only" du DataGridView

            int ligneModifiee = 0;
            int colonneModifiee = 0;

            //bool toucheValide = e.KeyCode == Keys.Delete || e.KeyCode == Keys.Back || e.KeyCode == Keys.Enter || e.KeyCode == Keys.Left || e.KeyCode == Keys.Right || e.KeyCode == Keys.Up || e.KeyCode == Keys.Down;
            bool touchesDeleteOuBackSpace = e.KeyCode == Keys.Delete || e.KeyCode == Keys.Back;
            //bool touchesFleches = e.KeyCode == Keys.Left || e.KeyCode == Keys.Right || e.KeyCode == Keys.Up || e.KeyCode == Keys.Down;
            //bool toucheEnter = e.KeyCode == Keys.Enter;
            //bool toucheNombre = (e.KeyCode < Keys.D0 || e.KeyCode > Keys.D9);

            if (touchesDeleteOuBackSpace)
            {
                try
                {
                    ligneModifiee = dataGridViewScores.CurrentCell.RowIndex;
                    colonneModifiee = dataGridViewScores.CurrentCell.ColumnIndex;

                    // On ne peut supprimer que le pointage des tours
                    // qui sont situés entre les lignes "Rang" et "Pénalité"
                    if (ligneModifiee > indexLigne.Rang)
                    {
                        chargementEnCours = true;
                        dataGridViewScores.CurrentCell.Value = "0";
                        chargementEnCours = false;
                        MetAJourDansDataGrid(ligneModifiee, colonneModifiee);
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Impossible d'effectuer cette opération.");
                    //throw;
                }
            }
        }

        private void MetAJourDansDataGrid(int ligneModifiee, int colonneModifiee)
        {
            try
            {
                int nouveauTotal = CalculerNouveauTotal(ligneModifiee, colonneModifiee);

                ActualiserScoresModifiesBrut(ligneModifiee, colonneModifiee);

                List<ScoreJoueurDataGrid> scoresModifies = score.DeterminerLesRangsDesJoueurs(scoresModifiesBrut);

                // Afficher dans DataGridView
                chargementEnCours = true;
                for (int colonne = 0; colonne < scoresModifies.Count; colonne++)
                {
                    if (scoresModifies[colonne].Rang != null) // Si tous les scores sont entrés
                    dataGridViewScores[colonne, indexLigne.Rang].Value = scoresModifies[colonne].Rang;
                }
                dataGridViewScores[colonneModifiee, indexLigne.Total].Value = nouveauTotal.ToString();
                chargementEnCours = false;
            }
            catch (Exception)
            {
                MessageBox.Show("Nombre non valide. SVP, corriger.");
                //throw;
            }
        }

        private void ActualiserScoresModifiesBrut(int ligneModifiee, int colonneModifiee)
        {
            // Ajoute les nouveaux pointages aux scoresModifiesBrut afin de déterminer les rangs

            if (ligneModifiee < indexLigne.Penalite && ligneModifiee > indexLigne.Rang)
            {
                int pointageTour = int.Parse(dataGridViewScores[colonneModifiee, ligneModifiee].FormattedValue.ToString());
                scoresModifiesBrut[colonneModifiee].ScoreJoueur.Tours[ligneModifiee - 7] = pointageTour;
            }
            else if (ligneModifiee == indexLigne.Penalite)
            {
                int penalite = int.Parse(dataGridViewScores[colonneModifiee, ligneModifiee].FormattedValue.ToString());
                scoresModifiesBrut[colonneModifiee].ScoreJoueur.Penalite = penalite;
            }
            else if (ligneModifiee == indexLigne.Bonus)
            {
                int bonus = int.Parse(dataGridViewScores[colonneModifiee, ligneModifiee].FormattedValue.ToString());
                scoresModifiesBrut[colonneModifiee].ScoreJoueur.Bonus = bonus;
            }
        }

        private int CalculerNouveauTotal(int ligneModifiee, int colonneModifiee)
        {
            string[] pointage = new string[28];
            int totalModifie = 0;

            for (int ligne = indexLigne.Rang + 1; ligne < indexLigne.Penalite; ligne++)
            {
                pointage[ligne] = dataGridViewScores[colonneModifiee, ligne].FormattedValue.ToString();
                totalModifie += int.Parse(pointage[ligne]);
            }
            totalModifie += int.Parse(dataGridViewScores[colonneModifiee, indexLigne.Bonus].FormattedValue.ToString());
            totalModifie += int.Parse(dataGridViewScores[colonneModifiee, indexLigne.Penalite].FormattedValue.ToString());
            return totalModifie;
        }

        private void AnnulerModificationsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Annule les modifications en rechargeant les données originales
            //scoresDataGrid.Clear();
            //List<string> valeurs = AfficherListeHeader(dataGridViewScores, "colonnes");
            //scoresDataGrid.AddRange(backupDataGridScores);
            //dataGridViewScores.DataSource = scoresDataGrid;
            dataGridViewScores.DataSource = backupDataGridScores;
            InitialiserDataGridViewScores();
            dataGridViewScores.Rows[indexLigne.IdJoute].Visible = false;
        }

        private void AjouterlignesDeScoreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Ajoute des lignes de score supplémentaires 
            lignesDeScoreAAfficher++;
            if (lignesDeScoreAAfficher > 20)
            {
                MessageBox.Show("Le nombre de lignes de score ne peut pas dépasser 20.");
                lignesDeScoreAAfficher = 20;
            }
            score.FormatterAffichageDataGridViewScores(scoresDataGrid, ref dataGridViewScores, ref indexLigne, ref premierChargementScores, ref lignesDeScoreAAfficher, ref lignesDeScoreSuppl);
        }
    }
}
