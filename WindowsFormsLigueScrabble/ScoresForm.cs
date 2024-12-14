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
            
            dataGridViewScores.DataSource = null;
            dataGridViewScores.ColumnHeadersDefaultCellStyle.Font = new Font("Verdana", 9);
            dataGridViewScores.DefaultCellStyle.Font = new Font("Verdana", 12);
            dataGridViewScores.DataSource = scoresDataGrid;
            dataGridViewScores.Columns["IdJoute"].Visible = false;
            dataGridViewScores.Columns["IdScore"].Visible = false;
            dataGridViewScores.Columns["IdJoueur"].Visible = false;
            dataGridViewScores.RowHeadersVisible = false;
            dataGridViewScores.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;

        }

    }
}
