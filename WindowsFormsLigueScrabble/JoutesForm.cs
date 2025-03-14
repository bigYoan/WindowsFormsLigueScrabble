using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Google.Protobuf.WellKnownTypes;

namespace WindowsFormsLigueScrabble
{
    internal partial class JoutesForm : Form
    {
        Controleur controleur;
        Score score = new Score();
        DB_Manager db_manager = new DB_Manager();
        List<JoutesDataGrid> joutesTrouvees = new List<JoutesDataGrid>();

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
            panelInfosGenerales.Visible = false;
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

            dataGridViewJoutes.DataSource = null;
            AfficherPartiesJoueurChoisi(idJoueurChoisi, nomJoueurChoisi);
        }

        private void AfficherPartiesJoueurChoisi(int idJoueurChoisi, string nomJoueurChoisi)
        {
            RendreInvisibleTousDataGrid();
            dataGridViewJoutes.Visible = true;
            panelInfosGenerales.Visible = true;
            joutesTrouvees.Clear();
            string commande = "WHERE Id_Joueur = " + idJoueurChoisi;
            //List<Partie> parties = new List<Partie>();
            //List<Partie> partiesBidon = new List<Partie>();
            List<LienJouteScoreJoueur> lienJouteScoreJoueurs = controleur.ListerLiensJouteScoreJoueur(null, commande);

            //Rencontre rencontreSelonPartie = controleur.TrouverSession(lienJouteScoreJoueurs[0].IdJoute);
            ScoreJoueurDataGrid scoreJoueur = new ScoreJoueurDataGrid();

            List<double> moyennesParTour = new List<double>();
            int nbParties = lienJouteScoreJoueurs.Count;
            int nbParties3Joueurs = 0;
            int nbParties4Joueurs = 0;
            double moyenneParTour = 0f;
            int totalPoints = 0;
            int totalTours = 0;
            int premierePlace = 0;
            int deuxiemePlace = 0;
            int troisiemePlace = 0;
            int quatriemePlace = 0;
            int scoreMax = 0;


            foreach (var lienChoisi in lienJouteScoreJoueurs)
            {
                JoutesDataGrid jouteEnCours = new JoutesDataGrid();

                // Trouver la session de la joute
                Rencontre rencontreSelonPartie = controleur.TrouverSession(lienChoisi.IdJoute);

                // Trouver le no de table et le no de joute
                //partiesBidon = controleur.ListerJoute(lienChoisi.IdJoute);

                // Charger les infos du score du joueur
                // NOte : optimiser scoreJoueur pour augmenter la vitesse
                //ScoreJoueurDataGrid scoreJoueur = controleur.ListerScore(controleur.lister, lienChoisi.IdScore);
                List<Score> scoresJoueur = db_manager.ListerScoresDansBD("WHERE Id_Score = " + lienChoisi.IdScore.ToString());
                scoreJoueur.ScoreJoueur = scoresJoueur[0];
                

                int pointageTotalToutesParties = 0;

                jouteEnCours.IdJoueur = idJoueurChoisi;
                jouteEnCours.NomJoueur = nomJoueurChoisi;
                jouteEnCours.DateSession = rencontreSelonPartie.DateDeJeu;
                jouteEnCours.NoJoute = rencontreSelonPartie.NoJoute;
                jouteEnCours.NoTable = rencontreSelonPartie.NoTable;
                jouteEnCours.ScoreFinal = scoreJoueur.TotalJoueur;
                if (jouteEnCours.ScoreFinal > scoreMax) scoreMax = jouteEnCours.ScoreFinal;
                jouteEnCours.NbJoueursDansPartie = TrouverJoueursParPartie(lienChoisi.IdJoute);
                if (jouteEnCours.NbJoueursDansPartie == 3) nbParties3Joueurs++;
                else nbParties4Joueurs++;
                totalPoints += scoreJoueur.TotalJoueur;

                scoreJoueur.Rang = scoreJoueur.ScoreJoueur.Rang;

                jouteEnCours.RangDansPartie = scoreJoueur.Rang;
                if (jouteEnCours.RangDansPartie == "1er") premierePlace++;
                else if (jouteEnCours.RangDansPartie == "2e") deuxiemePlace++;
                else if (jouteEnCours.RangDansPartie == "3e") troisiemePlace++;
                else if (jouteEnCours.RangDansPartie == "4e") quatriemePlace++;

                jouteEnCours.NbToursNonNuls = controleur.CalculerNbToursJoues(scoreJoueur);
                if (jouteEnCours.NbToursNonNuls != 0) 
                {
                    jouteEnCours.MoyenneParTour = (double)scoreJoueur.TotalJoueur / (double)jouteEnCours.NbToursNonNuls;
                    moyennesParTour.Add(jouteEnCours.MoyenneParTour);
                    totalTours += jouteEnCours.NbToursNonNuls;

                }

                //parties.Add(partiesBidon[0]); // parties ne contient qu'un seul élément
                joutesTrouvees.Add(jouteEnCours);
                jouteEnCours.NbPartiesJouees = joutesTrouvees.Count;
                //jouteEnCours.MoyenneParPartie = (double)pointageTotalToutesParties / (double)joutesTrouvees.Count;

            }
            
            dataGridViewJoutes.DataSource = null;
            List<JoutesDataGrid> joutesTest = new List<JoutesDataGrid>();
            joutesTest = joutesTrouvees.OrderBy(joute=>joute.DateSession).ToList();
            dataGridViewJoutes.DataSource = joutesTest;
            FormatterDataGridViewJoutes();
            dataGridViewJoutes.Visible = true;

            double regressionB1, regressionB0;
            List<double> moyennesParTourClassees = new List<double>();
            foreach (var joute in joutesTest) 
            {
                moyennesParTourClassees.Add(joute.MoyenneParTour);
            }
            regressionB1 = CalculerPenteMoyennesParTour(moyennesParTourClassees);
            regressionB0 = CalculerOrdonneeOrigineMoyennesParTour(moyennesParTourClassees, regressionB1);
            double tendance = regressionB1;
            double prevision = (moyennesParTourClassees.Count + 1) * regressionB1 + regressionB0;
            labelnbPente.Text = tendance.ToString("0.###");
            labelNomJoueur.Text = nomJoueurChoisi;
            labelnbParties.Text = nbParties.ToString();
            labelnb3J.Text = nbParties3Joueurs.ToString();
            labelnb4J.Text = nbParties4Joueurs.ToString();
            labelnbPoints.Text = totalPoints.ToString();
            labelnbTours.Text = totalTours.ToString();
            moyenneParTour = (double)totalPoints / (double)totalTours;
            labelMoyenneTour.Text = moyenneParTour.ToString("##.##");
            labelnb1rePlace.Text = premierePlace.ToString();
            labelnb2ePlace.Text = deuxiemePlace.ToString();
            labelnb3ePlace.Text = troisiemePlace.ToString();
            labelnb4ePlace.Text = quatriemePlace.ToString();
            labelScoreMax.Text = scoreMax.ToString();
        }

        private double CalculerOrdonneeOrigineMoyennesParTour(List<double> moyennesParTour, double regressionB1)
        {
            // Calculer l'ordonnée à l'origine par régression linéaire

            Valeur valeur = new Valeur();
            List<Valeur> valeurs = OrganiserXY(moyennesParTour);

            // Trouver moyenne des "x" et des "y"
            double moyenneX = CalculerMoyenne(valeurs, "X");
            double moyenneY = CalculerMoyenne(valeurs, "Y");

            double pente = regressionB1;
            return moyenneY - pente * moyenneX;  // Ordonnée à l'origine
        }

        struct Valeur
        {
            public double valeurX;
            public double valeurY;
        }
        private double CalculerPenteMoyennesParTour(List<double> moyennesParTour)
        {
            // Calculer la tendance (pente) par régression linéaire

            Valeur valeur = new Valeur();
            List<Valeur> valeurs = OrganiserXY(moyennesParTour);
            
            // Trouver moyenne des "x" et des "y"
            double moyenneX = CalculerMoyenne(valeurs, "X");
            double moyenneY = CalculerMoyenne(valeurs, "Y");                       

            // Trouver variances
            double varianceXX = CalculerVariance(valeurs, moyenneX, moyenneY, "XX");
            double varianceXY = CalculerVariance(valeurs, moyenneX, moyenneY, "XY");

            if (varianceXX != 0) return varianceXY / varianceXX;  // La pente
            else return 0;
        }

        private double CalculerVariance(List<Valeur> valeurs, double moyenneX, double moyenneY, string variance)
        {
            double varianceXX = 0f;
            double varianceXY = 0f;
            foreach (var valeurEnCours in valeurs)
            {
                varianceXX += Math.Pow((valeurEnCours.valeurX - moyenneX), 2);
                varianceXY += (valeurEnCours.valeurX - moyenneX) * (valeurEnCours.valeurY - moyenneY);
            }
            if (variance == "XX") return varianceXX;
            if (variance == "XY") return varianceXY;
            else return 0;
        }

        private double CalculerMoyenne(List<Valeur> valeurs, string axe)
        {
            double totalX = 0f; double totalY = 0f;

            foreach (var valeurEnCours in valeurs)
            {
                totalX += valeurEnCours.valeurX;
                totalY += valeurEnCours.valeurY;
            }
            double moyenneX = totalX / valeurs.Count;
            double moyenneY = totalY / valeurs.Count;

            if (axe == "X") return moyenneX;
            if (axe == "Y") return moyenneY;
            return 0;
        }

        private List<Valeur> OrganiserXY(List<double> moyennesParTour)
        {
            Valeur valeur = new Valeur();
            List<Valeur> valeurs = new List<Valeur>();
            for (int item = 0; item < moyennesParTour.Count; item++)
            {
                valeur.valeurX = item + 1;
                valeur.valeurY = moyennesParTour[item];
                valeurs.Add(valeur);
            }
            return valeurs;
        }

        private int TrouverJoueursParPartie(int idJoute)
        {
            int nbJoueursDansPartie = 0;
            nbJoueursDansPartie = controleur.CompterJoueurDansJoute(idJoute);
            return nbJoueursDansPartie;
        }

        private void FormatterDataGridViewJoutes()
        {
            //dataGridViewJoutes.DataSource = joutesTrouvees;

            dataGridViewJoutes.ColumnHeadersDefaultCellStyle.Font = new Font("Verdana", 9);
            dataGridViewJoutes.DefaultCellStyle.Font = new Font("Verdana", 12);
            dataGridViewJoutes.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewJoutes.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewJoutes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;

            dataGridViewJoutes.Columns["DateSession"].Visible = false;
            dataGridViewJoutes.Columns["IdJoueur"].Visible = false;
            dataGridViewJoutes.Columns["NomJoueur"].Visible = false;
            dataGridViewJoutes.Columns["NoTable"].Visible = false;
            dataGridViewJoutes.Columns["NoJoute"].Visible = false;
            dataGridViewJoutes.Columns["NbPartiesJouees"].Visible = false;
            dataGridViewJoutes.Columns["MoyenneParPartie"].Visible = false;
            dataGridViewJoutes.Columns["MoyenneParPartieFormattee"].Visible = false;

            //dataGridViewJoutes.Columns["ScoreFinal"].Visible = false;
            //dataGridViewJoutes.Columns["RangDansPartie"].Visible = false;NbJoueursDansPartie
            dataGridViewJoutes.Columns["MoyenneParTour"].Visible = false;
            dataGridViewJoutes.Columns["ScoreEtRang"].Visible = false;


            dataGridViewJoutes.Columns["DateSession"].HeaderCell.Value = "Date";
            dataGridViewJoutes.Columns["JourEtMois"].HeaderCell.Value = "Date";

            dataGridViewJoutes.Columns["TableJoute"].HeaderCell.Value = "Table-Joute";
            dataGridViewJoutes.Columns["ScoreEtRang"].HeaderCell.Value = "Score-Rang";
            dataGridViewJoutes.Columns["ScoreFinal"].HeaderCell.Value = "Score";
            dataGridViewJoutes.Columns["RangDansPartie"].HeaderCell.Value = "Rang";
            dataGridViewJoutes.Columns["NbJoueursDansPartie"].HeaderCell.Value = "Nb Joueurs";

            dataGridViewJoutes.Columns["NbToursNonNuls"].HeaderCell.Value = "Nb Tours";
            dataGridViewJoutes.Columns["MoyenneParTourFormattee"].HeaderCell.Value = "Moyenne/Tour";

            //dataGridViewJoutes.RowHeadersWidth = 100;
            dataGridViewJoutes.RowHeadersVisible = false;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void captureToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Rectangle bounds = this.Bounds;
            Bitmap b = new Bitmap(bounds.Width, bounds.Height, PixelFormat.Format32bppArgb);
            using (Graphics g = Graphics.FromImage(b))
            {
                g.CopyFromScreen(bounds.X, bounds.Y, 0, 0, bounds.Size, CopyPixelOperation.SourceCopy);
            }
            b.Save("Capture " + labelNomJoueur.Text);
        }
    }
}
