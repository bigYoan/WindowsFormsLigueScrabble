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
        //Score[] scoreJoueur = new Score[4];
        //List<Score[]> scores = new List<Score[]>();
        List<LienJouteScoreJoueur> liensJouteScoreJoueur = new List<LienJouteScoreJoueur>();
        List<ScoreJoueurDataGrid> scoresDataGrid = new List<ScoreJoueurDataGrid>();
        bool chargementEnCours = false;
        bool changementDataGridNonSauvegarde = false;

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
                InitialiserDataGridViewScores(0);
            }
            else CreerNouveauxScores();
        }

        private void InitialiserDataGridViewScores( int offset)
        {
            scoresDataGrid = controleur.ListerLiensJouteScoreJoueur(controleur.lister, liensJouteScoreJoueur, rencontreAjoutScores.Id_Joute);
            RemplirDataGridScores(scoreEnCours);
            ModifierScoresAJouteDejaCommencee();
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
            chargementEnCours = true; //Bloque l'événement : "Changement dans les cellules"
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
            dataGridViewScores.Rows[1].HeaderCell.Value = "Joueur";
            dataGridViewScores.Rows[2].HeaderCell.Value = "Nom/Pseudo";
            dataGridViewScores.Rows[3].HeaderCell.Value = "Total";
            dataGridViewScores.Rows[3].DefaultCellStyle.Font = new Font("Verdana", 12, FontStyle.Bold);
            dataGridViewScores.Rows[3].DefaultCellStyle.ForeColor = Color.Red;
            for (int ligne = 0; ligne < dataGridViewScores.RowCount; ligne++)
            {
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
            }
            dataGridViewScores.AutoResizeRowHeadersWidth(DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders);
            dataGridViewScores.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            
            chargementEnCours = false;
            changementDataGridNonSauvegarde = false;
        }

        private void buttonAnnulerModifs_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Cette fonctionnalité n'est pas disponible.\n\nPour annuler TOUTES les modifications,\n veuillez fermer cette page sans sauvegarder\npuis modifier à nouveau la session.");
            //scoresDataGrid = null;
            //dataGridViewScores.DataSource = null;
            //liensJouteScoreJoueur = controleur.ListerLiensJouteScoreJoueur("");
            //scoresDataGrid = controleur.(controleur.lister, liensJouteScoreJoueur);
            //if (JouteExiste())
            //{
            //    InitialiserDataGridViewScores(0);
            //}
            //else CreerNouveauxScores();

            //InitialiserDataGridViewScores(0);

            //this.Refresh();
            //this.Load += new EventHandler(ScoresForm_Load);
        }

        private void buttonEnregistrerModifs_Click(object sender, EventArgs e)
        {
            int lignesAffectees = 0;
            List<ScoreJoueurDataGrid> nouveauxScoresDataGrid = new List<ScoreJoueurDataGrid>();
            for (int colonne = 0; colonne < dataGridViewScores.Columns.Count; colonne++)
            {
                Joueur nouveauJoueur = new Joueur();
                Score nouveauScore = new Score();
                ScoreJoueurDataGrid nouveauScoreJoueur = new ScoreJoueurDataGrid();
                nouveauScoreJoueur.IdJoute = int.Parse(dataGridViewScores[colonne, 0].FormattedValue.ToString());
                //nouveauScore.IdScore = int.Parse(dataGridViewScores[colonne, 1].FormattedValue.ToString());
                //nouveauJoueur.IdJoueur = int.Parse(dataGridViewScores[colonne, 2].FormattedValue.ToString());
                nouveauJoueur.Nom = dataGridViewScores[colonne, 2].FormattedValue.ToString();
                nouveauJoueur.Pseudo = (string)dataGridViewScores[colonne, 2].Value;
                nouveauScore.Tour1 = int.Parse(dataGridViewScores[colonne, 4].FormattedValue.ToString());
                nouveauScore.Tour2 = int.Parse(dataGridViewScores[colonne, 5].FormattedValue.ToString());
                nouveauScore.Tour3 = int.Parse(dataGridViewScores[colonne, 6].FormattedValue.ToString());
                nouveauScore.Tour4 = int.Parse(dataGridViewScores[colonne, 7].FormattedValue.ToString());
                nouveauScore.Tour5 = int.Parse(dataGridViewScores[colonne, 8].FormattedValue.ToString());
                nouveauScore.Bonus = int.Parse(dataGridViewScores[colonne, 9].FormattedValue.ToString());
                nouveauScore.Penalite = int.Parse(dataGridViewScores[colonne, 10].FormattedValue.ToString());
                nouveauScoreJoueur.Joueur = nouveauJoueur;
                nouveauScoreJoueur.ScoreJoueur = nouveauScore;
                nouveauxScoresDataGrid.Add(nouveauScoreJoueur);
            }
            for (int noScore = 0; noScore < nouveauxScoresDataGrid.Count; noScore++)
            {
                lignesAffectees = controleur.GererScore(controleur.ajouter, nouveauxScoresDataGrid[noScore]);
            }
            
            changementDataGridNonSauvegarde = false;
        }

        private void dataGridViewScores_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (!chargementEnCours) 
            changementDataGridNonSauvegarde = true;
        }
        private void buttonQuitter_Click(object sender, EventArgs e)
        {
            if (changementDataGridNonSauvegarde) 
            {
                bool fermerOk = controleur.DemandeDeConfirmation("Quitter cette page sans enregistrer les modifications? ");
                if (!fermerOk) return;
            }
            this.Close();
        }
    }
}
