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
    internal partial class JoutesForm : Form
    {
        Controleur controleur;
        public JoutesForm(Controleur controleurX)
        {
            InitializeComponent();
            controleur = controleurX;
        }
        private void JoutesForm_Load(object sender, EventArgs e)
        {
            RendreInvisibleTousDataGrid();
        }

        private void RendreInvisibleTousDataGrid()
        {
            dataGridViewJoueurs.Visible = false;
            dataGridViewJoutes.Visible = false;
        }

        private void sToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void joueurToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RendreInvisibleTousDataGrid();
            dataGridViewJoueurs.Visible = true;
            dataGridViewJoueurs.DataSource = null;
            dataGridViewJoueurs.DataSource = controleur.GererJoueur(null, controleur.lister, "ORDER BY Nom");
            dataGridViewJoueurs.RowHeadersVisible = false;
            //dataGridViewJoueurs.Columns["IdJoueur"].Visible = false;
            dataGridViewJoueurs.Columns["CacherNom"].Visible = false;
            dataGridViewJoueurs.Columns["Pseudo"].Visible = false;
            dataGridViewJoueurs.Columns["Nom"].HeaderText = "Nom du joueur";
            dataGridViewJoueurs.Columns["CodeJoueur"].HeaderText = "Code du joueur";
            //dataGridViewJoueurs.Columns["IdJoueur"].Visible = false;
            dataGridViewJoueurs.Columns["NoFQCSF"].Visible = false;
            dataGridViewJoueurs.Columns["FQCSF"].Visible = false;
            dataGridViewJoueurs.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void dataGridViewJoueurs_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridViewJoueurs.Visible = false;
            int idJoueurChoisi = int.Parse(dataGridViewJoueurs["IdJoueur", dataGridViewJoueurs.CurrentRow.Index].Value.ToString());
            string nomJoueurChoisi = dataGridViewJoueurs["Nom", dataGridViewJoueurs.CurrentRow.Index].Value.ToString();

            AfficherPartiesJoueurChoisi(idJoueurChoisi, nomJoueurChoisi);
        }

        private void AfficherPartiesJoueurChoisi(int idJoueurChoisi, string nomJoueurChoisi)
        {
            RendreInvisibleTousDataGrid();
            dataGridViewJoutes.Visible = true;
            FormatterDataGridViewJoutes();
            string commande = "WHERE Id_Joueur = " + idJoueurChoisi;
            List<Partie> parties = new List<Partie>();
            List<Partie> partiesBidon = new List<Partie>();
            List<LienJouteScoreJoueur> lienJouteScoreJoueurs = controleur.ListerLiensJouteScoreJoueur(null, commande);
            List<JoutesDataGrid> joutesTrouvees = new List<JoutesDataGrid>();
            foreach (var lienChoisi in lienJouteScoreJoueurs)
            {
                JoutesDataGrid jouteEnCours = new JoutesDataGrid();

                // Trouver la session de la joute
                Rencontre rencontreSelonPartie = controleur.TrouverSession(lienChoisi.IdJoute);

                // Trouver le no de table et le no de joute
                partiesBidon = controleur.ListerJoute(lienChoisi.IdJoute);

                // Charger les infos du score du joueur
                ScoreJoueurDataGrid scoreJoueur = controleur.ListerScore(controleur.lister, lienChoisi.IdScore);

                int pointageTotalToutesParties = 0;

                jouteEnCours.IdJoueur = idJoueurChoisi;
                jouteEnCours.NomJoueur = nomJoueurChoisi;
                jouteEnCours.DateSession = rencontreSelonPartie.DateDeJeu;
                jouteEnCours.NoJoute = rencontreSelonPartie.NoJoute;
                jouteEnCours.NoTable = rencontreSelonPartie.NoTable;
                jouteEnCours.ScoreFinal = scoreJoueur.TotalJoueur;
                pointageTotalToutesParties += scoreJoueur.TotalJoueur;
                scoreJoueur.Rang = controleur.DeterminerRangDuJoueur(lienChoisi, idJoueurChoisi);
                jouteEnCours.RangDansPartie = scoreJoueur.Rang;
                jouteEnCours.NbToursNonNuls = controleur.CalculerNbToursJoues(scoreJoueur);
                if (jouteEnCours.NbToursNonNuls !=0) jouteEnCours.MoyenneParTour = (double)scoreJoueur.TotalJoueur / (double)jouteEnCours.NbToursNonNuls;

                parties.Add(partiesBidon[0]); // parties ne contient qu'un seul élément
                joutesTrouvees.Add(jouteEnCours);
                jouteEnCours.NbPartiesJouees = joutesTrouvees.Count;
                jouteEnCours.MoyenneParPartie = (double)pointageTotalToutesParties / (double)joutesTrouvees.Count;

            }

            dataGridViewJoutes.DataSource = joutesTrouvees;
            dataGridViewJoutes.Visible = true;
            dataGridViewJoutes.Rows[0].HeaderCell.Value = nomJoueurChoisi;
        }

        private void FormatterDataGridViewJoutes()
        {
            dataGridViewJoutes.RowHeadersWidth = 100;
            
        }
    }
}
