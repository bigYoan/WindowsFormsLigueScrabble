using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsLigueScrabble
{
    internal partial class ScoresForm : Form
    {
        Controleur controleur;
        Rencontre rencontreAjoutScores;
        Score[] scoreJoueur = new Score[4];
        List<Score[]> scores = new List<Score[]>();
        List<LienJouteScoreJoueur> liensJouteScoreJoueur;
        List<ScoreJoueurDataGrid> scoresDataGrid = new List<ScoreJoueurDataGrid>();

        int nouveauScore = 1;
        int scoreEnCours = 2;

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
                scoresDataGrid = controleur.GererScore(controleur.lister, liensJouteScoreJoueur, rencontreAjoutScores.Id_Joute);
                RemplirDataGridScores(scoreEnCours);
                ModifierScoresAJouteDejaCommencee();
            }
            else CreerNouveauxScores();
        }

        private void CreerNouveauxScores()
        {
            //Créer un nouveau Score et un nouveau lien Joute_Score_Joueur
            int lienJouteScoreJoueurCree = controleur.CreerLienJouteScoreJoueurDansBD(rencontreAjoutScores);
            if (lienJouteScoreJoueurCree == 0) { MessageBox.Show("Une erreur s'est produite lors de la création\ndes nouveaux scores."); }
            RemplirDataGridScores(nouveauScore);
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

        private void RemplirDataGridScores(int commande)
        {
            //On souhaite afficher les scores avec les noms des joueurs dans les colonnes
            // et le pointage dans les lignes

            // Récupérer les données à afficher
            dataGridViewScores.DataSource = null;
            dataGridViewScores.DataSource = scoresDataGrid;

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
            {
                dataGridViewScores.Rows[lignesDataGrid].HeaderCell.Value = tableauInverseTitres[lignesDataGrid];
            }

            for (int lignesTableauInverse = 0; lignesTableauInverse < tableauInverseValeurs.GetLength(0); lignesTableauInverse++)
            {
                for (int colonnesTableauInverse = 0; colonnesTableauInverse < tableauInverseValeurs.GetLength(1); colonnesTableauInverse++)
                {
                    {
                        dataGridViewScores[lignesTableauInverse, colonnesTableauInverse].Value = tableauInverseValeurs[lignesTableauInverse, colonnesTableauInverse];
                    }
                }
            }

            // Formatter l'affichage du datagridview
            dataGridViewScores.RowHeadersDefaultCellStyle.Font = new Font("Verdana", 9);
            dataGridViewScores.DefaultCellStyle.Font = new Font("Verdana", 12);
            dataGridViewScores.Rows[3].HeaderCell.Value = "Joueur";
            dataGridViewScores.Rows[4].HeaderCell.Value = "Nom/Pseudo";
            dataGridViewScores.Rows[5].HeaderCell.Value = "Total";
            dataGridViewScores.Rows[5].DefaultCellStyle.Font = new Font("Verdana", 12, FontStyle.Bold);
            dataGridViewScores.Rows[5].DefaultCellStyle.ForeColor = Color.Red;
            //for (int ligne = 0; ligne < dataGridViewScores.RowCount; ligne++)
            //{
            //    if ((string)dataGridViewScores.Rows[ligne].HeaderCell.Value == "IdScore")
            //    {
            //        dataGridViewScores.Rows[ligne].Visible = false;
            //    }
            //    if ((string)dataGridViewScores.Rows[ligne].HeaderCell.Value == "IdJoute")
            //    {
            //        dataGridViewScores.Rows[ligne].Visible = false;
            //    }
            //    if ((string)dataGridViewScores.Rows[ligne].HeaderCell.Value == "IdJoueur")
            //    {
            //        dataGridViewScores.Rows[ligne].Visible = false;
            //    }
            //}
            dataGridViewScores.AutoResizeRowHeadersWidth(DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders);
            dataGridViewScores.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;


        }

        private void buttonAnnulerModifs_Click(object sender, EventArgs e)
        {
            RemplirDataGridScores(scoreEnCours);
        }

        private void buttonEnregistrerModifs_Click(object sender, EventArgs e)
        {
            List<ScoreJoueurDataGrid> nouveauxScoresDataGrid = new List<ScoreJoueurDataGrid>();
            for (int colonne = 0; colonne < dataGridViewScores.Rows.Count; colonne++)
            {
                //for (int ligne = 0; ligne < dataGridViewScores.ColumnCount; ligne++)
                //{
                    Joueur nouveauJoueur = new Joueur();
                    Score nouveauScore = new Score();
                    ScoreJoueurDataGrid nouveauScoreJoueur = new ScoreJoueurDataGrid();
                    nouveauScoreJoueur.IdJoute = int.Parse(dataGridViewScores[0, 0].FormattedValue.ToString());
                    nouveauScore.IdScore = int.Parse(dataGridViewScores[0, 1].FormattedValue.ToString());
                    nouveauJoueur.IdJoueur = int.Parse(dataGridViewScores[0, 2].FormattedValue.ToString());
                    nouveauJoueur.Nom = dataGridViewScores[0, 3].FormattedValue.ToString();
                    nouveauJoueur.Pseudo = (string)dataGridViewScores[0, 4].Value;
                    nouveauScore.Tour1 = int.Parse(dataGridViewScores[0, 6].FormattedValue.ToString());
                    nouveauScore.Tour2 = int.Parse(dataGridViewScores[0, 7].FormattedValue.ToString());
                    nouveauScore.Tour3 = int.Parse(dataGridViewScores[0, 8].FormattedValue.ToString());
                    nouveauScore.Tour4 = int.Parse(dataGridViewScores[0, 9].FormattedValue.ToString());
                    nouveauScore.Tour5 = int.Parse(dataGridViewScores[0, 10].FormattedValue.ToString());
                    nouveauScore.Bonus = int.Parse(dataGridViewScores[0, 11].FormattedValue.ToString());
                    nouveauScore.Penalite = int.Parse(dataGridViewScores[0, 12].FormattedValue.ToString());
                    nouveauScoreJoueur.Joueur = nouveauJoueur;
                    nouveauScoreJoueur.ScoreJoueur = nouveauScore;
                //}
            }
        }
    }
}
