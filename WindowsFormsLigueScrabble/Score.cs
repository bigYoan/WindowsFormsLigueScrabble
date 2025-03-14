using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsLigueScrabble
{
    internal class Score : Controleur
    {
        int idScore;
        List<int> tours;
        int tour1;
        int tour2;
        int tour3;
        int tour4;
        int tour5;
        int tour6;
        int tour7;
        int tour8;
        int tour9;
        int tour10;
        int tour11;
        int tour12;
        int tour13;
        int tour14;
        int tour15;
        int tour16;
        int tour17;
        int tour18;
        int tour19;
        int tour20;
        int totalTours;
        int penalite;
        int bonus;
        int total;
        int toursNonNuls;
        string rang;

        public int IdScore { get => idScore; set => idScore = value; }
        public int Tour1 { get => tours[0]; }
        public int Tour2 { get => tours[1]; }
        public int Tour3 { get => tours[2]; }
        public int Tour4 { get => tours[3]; }
        public int Tour5 { get => tours[4]; }
        public int Tour6 { get => tours[5]; }
        public int Tour7 { get => tours[6]; }
        public int Tour8 { get => tours[7]; }
        public int Tour9 { get => tours[8]; }
        public int Tour10 { get => tours[9]; }
        public int Tour11 { get => tours[10]; }
        public int Tour12 { get => tours[11]; }
        public int Tour13 { get => tours[12]; }
        public int Tour14 { get => tours[13]; }
        public int Tour15 { get => tours[14]; }
        public int Tour16 { get => tours[15]; }
        public int Tour17 { get => tours[16]; }
        public int Tour18 { get => tours[17]; }
        public int Tour19 { get => tours[18]; }
        public int Tour20 { get => tours[19]; }      
        public int Penalite { get => penalite; set => penalite = value; }
        public int Bonus { get => bonus; set => bonus = value; }

        public int TotalTours
        {
            get
            {
                int totalTours = 0;
                for (int x = 0; x < 20; x++)
                {
                    totalTours += Tours[x];
                }
                return totalTours;
            }
        }
        public int Total { get => TotalTours + Bonus + Penalite; }
        public int ToursNonNuls { get => toursNonNuls; set => toursNonNuls = value; }
        public List<int> Tours { get => tours; set => tours = value; }
        public string Rang { get => rang; set => rang = value; }

        public List<ScoreJoueurDataGrid> listeAffichee = new List<ScoreJoueurDataGrid>();


        public List<ScoreJoueurDataGrid> InitialiseLaListeScoresAAfficher(Rencontre rencontreAAfficher) 
        {
            List<LienJouteScoreJoueur> liensJouteScoreJoueur = ListerLiensJouteScoreJoueur(rencontreAAfficher, "WHERE");
            if (liensJouteScoreJoueur == null)
            {
                MsgErrDB();
                return null;
            }
            else return ListerScoresJoueurs(lister, liensJouteScoreJoueur, rencontreAAfficher.Id_Joute, 0);
        }

        public List<ScoreJoueurDataGrid> DeterminerLesRangsDesJoueurs(List<ScoreJoueurDataGrid> scores)
        {
            // Trouver combien de 1re, 2e, 3e et 4e places
            // en tenant compte des cas où il y aurait des scores identiques

            List<int> scoresJoueurs = new List<int>(); 
            foreach (var score in scores)
            {
                scoresJoueurs.Add(score.ScoreJoueur.Total);
            }

            if (!scoresJoueurs.Contains(0)) 
            {
                int scoreMax = scoresJoueurs.Max();
                int rangActuel = 1;  // Commencer avec le 1er rang

                while (scoreMax > 0)
                {
                    // Trouver combien de scores ont le score max
                    List<int> result = Enumerable.Range(0, scoresJoueurs.Count).Where(i => scoresJoueurs[i] == scoreMax).ToList();

                    foreach (int rang in result)
                    {
                        scores[rang].Rang = rangActuel.ToString();
                        scoresJoueurs[scoresJoueurs.IndexOf(scoreMax)] = 0; //Enlever le score de la liste
                    }
                    scoreMax = scoresJoueurs.Max(); // Redéfinir le nouveau scoreMax pour le prochain rang
                    rangActuel += result.Count; // Recalculer le rang actuel
                    result.Clear();
                }
            }
            else
            {
                foreach (var score in scores)
                {
                    score.Rang = "";
                }
            }

            return scores;
        }

        internal List<ScoreJoueurDataGrid> CompterToursNonNuls(List<ScoreJoueurDataGrid> scoresDataGrid)
        {
            foreach (var scoreJoueur in scoresDataGrid)
            {
                scoreJoueur.ScoreJoueur.ToursNonNuls = CalculerNbToursJoues(scoreJoueur);
            }
            return scoresDataGrid;
        }

        internal void PivoterScores(ref DataGridView dataGridViewScores, List<ScoreJoueurDataGrid> scoresDataGrid)
        {
            //On souhaite afficher les scores avec les noms des joueurs dans les colonnes
            // et le pointage dans les lignes. Pour ce faire il faut pivoter les données du datagridview

            // Prépare pour inverser colonnes-lignes du datagridview
            dataGridViewScores.DataSource = scoresDataGrid;
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
            //DataGridView dataGridViewScoresPivotes = new DataGridView();
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

            //return tableauInverseValeurs;
        }

        internal void FormatterAffichageDataGridViewScores(List<ScoreJoueurDataGrid> scoresDataGrid, ref DataGridView dataGridViewScores, ref DataGridIndexLigne indexLigne, ref bool premierChargementScores, ref int lignesDeScoreAAfficher, ref int lignesDeScoreSuppl)
        {
            // N'affiche que les colonnes nécessaires et change les titres
            // Détermine le nombre de lignes à afficher en fonction du nombre de tours non nuls
            // Police, Couleur, Taille sur les lignes de total, pénalité et bonus
            // Ajuste la largeur des colonnes

            dataGridViewScores.ColumnHeadersVisible = false;
            dataGridViewScores.RowHeadersDefaultCellStyle.Font = new Font("Verdana", 9);
            dataGridViewScores.DefaultCellStyle.Font = new Font("Verdana", 12);
           
            for (int ligne = 0; ligne < dataGridViewScores.RowCount; ligne++)
            {
                if ((string)dataGridViewScores.Rows[ligne].HeaderCell.Value == "NomJoueur")
                {
                    dataGridViewScores.Rows[ligne].HeaderCell.Value = "Joueur";
                    dataGridViewScores.Rows[ligne].ReadOnly = true;
                    indexLigne.Nom = ligne;
                }
                if ((string)dataGridViewScores.Rows[ligne].HeaderCell.Value == "PseudoJoueur")
                {
                    dataGridViewScores.Rows[ligne].HeaderCell.Value = "Pseudo/Nom";
                    dataGridViewScores.Rows[ligne].ReadOnly = true;
                    indexLigne.Pseudo = ligne;
                }
                if ((string)dataGridViewScores.Rows[ligne].HeaderCell.Value == "Rang")
                {
                    dataGridViewScores.Rows[ligne].ReadOnly = true;
                    indexLigne.Rang = ligne;
                }
                if ((string)dataGridViewScores.Rows[ligne].HeaderCell.Value == "TotalJoueur")
                {
                    dataGridViewScores.Rows[ligne].HeaderCell.Value = "Total";
                    dataGridViewScores.Rows[ligne].ReadOnly = true;
                    dataGridViewScores.Rows[ligne].DefaultCellStyle.Font = new Font("Verdana", 12, FontStyle.Bold);
                    dataGridViewScores.Rows[ligne].DefaultCellStyle.ForeColor = Color.Blue;
                    indexLigne.Total = ligne;
                }
                if ((string)dataGridViewScores.Rows[ligne].HeaderCell.FormattedValue == "IdScore")
                {
                    indexLigne.IdScore = ligne;
                    dataGridViewScores.Rows[ligne].Visible = false;
                }
                if ((string)dataGridViewScores.Rows[ligne].HeaderCell.Value == "IdJoute")
                {
                    indexLigne.IdJoute = ligne;
                    dataGridViewScores.Rows[ligne].Visible = false;
                }
                if ((string)dataGridViewScores.Rows[ligne].HeaderCell.Value == "IdJoueur")
                {
                    indexLigne.IdJoueur = ligne;
                    dataGridViewScores.Rows[ligne].Visible = false;
                }
                if ((string)dataGridViewScores.Rows[ligne].HeaderCell.Value == "Penalite")
                {
                    dataGridViewScores.Rows[ligne].DefaultCellStyle.ForeColor = Color.Red;
                    indexLigne.Penalite = ligne;
                    dataGridViewScores.Rows[ligne].HeaderCell.Value = "Penalité";
                }
                if ((string)dataGridViewScores.Rows[ligne].HeaderCell.Value == "Bonus")
                {
                    dataGridViewScores.Rows[ligne].DefaultCellStyle.ForeColor = Color.Green;
                    indexLigne.Bonus = ligne;
                }

                // Ajoute un espace dans les titres des tours.  Ex :  Tour1 -> Tour 1
                string titreHeader = dataGridViewScores.Rows[ligne].HeaderCell.FormattedValue.ToString();
                {
                    if (titreHeader.Contains("Tour") && !titreHeader.Contains(" "))
                    {
                        titreHeader = titreHeader.Insert(4, " ");
                        dataGridViewScores.Rows[ligne].HeaderCell.Value = titreHeader;
                    }
                }

            }

            // Si on affiche les scores pour la première fois, on détermine le nombre de lignes à afficher
            if (premierChargementScores)
            {
                int nbToursNonNulsMin = 20;
                
                for (int noJoueur = 0; noJoueur < dataGridViewScores.Columns.Count; noJoueur++)
                {
                    if (nbToursNonNulsMin > scoresDataGrid[noJoueur].ScoreJoueur.ToursNonNuls)
                    {
                        nbToursNonNulsMin = scoresDataGrid[noJoueur].ScoreJoueur.ToursNonNuls;
                    }
                    if (nbToursNonNulsMin != 0) lignesDeScoreAAfficher = nbToursNonNulsMin + lignesDeScoreSuppl;
                    else lignesDeScoreAAfficher = 10; // Nombre de lignes à afficher si aucun score n'est présent
                }
                premierChargementScores = false;
            }
            for (int lignesEnCours = 20; lignesEnCours > 7; lignesEnCours--)
            {
                if (lignesDeScoreAAfficher < lignesEnCours) dataGridViewScores.Rows[lignesEnCours + indexLigne.Rang].Visible = false;
                else dataGridViewScores.Rows[lignesEnCours + indexLigne.Rang].Visible = true;
            }
            premierChargementScores = false;
            dataGridViewScores.AutoResizeRowHeadersWidth(DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders);
            dataGridViewScores.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        internal List<ScoreJoueurDataGrid> RecupererScoresDansDataGridScores(DataGridView dataGridViewScores, DataGridIndexLigne indexLigne)
        {
            List<ScoreJoueurDataGrid> scoresDansDataGrid = new List<ScoreJoueurDataGrid>();

            for (int colonne = 0; colonne < dataGridViewScores.Columns.Count; colonne++)
            {
                List<int> tours = new List<int>();
                for (int x = 0; x < 20; x++) tours.Add(0);
                Joueur nouveauJoueur = new Joueur();
                Score nouveauScore = new Score();
                nouveauScore.Tours = tours;
                ScoreJoueurDataGrid nouveauScoreJoueur = new ScoreJoueurDataGrid();
                nouveauScoreJoueur.Joueur = nouveauJoueur;
                nouveauScoreJoueur.ScoreJoueur = nouveauScore;
                nouveauScoreJoueur.IdJoute = int.Parse(dataGridViewScores[colonne, indexLigne.IdJoute].FormattedValue.ToString());
                nouveauScore.IdScore = int.Parse(dataGridViewScores[colonne, indexLigne.IdScore].FormattedValue.ToString());
                nouveauScoreJoueur.Joueur.IdJoueur = int.Parse(dataGridViewScores[colonne, indexLigne.IdJoueur].FormattedValue.ToString());
                nouveauScoreJoueur.Joueur.Nom = dataGridViewScores[colonne, indexLigne.Nom].FormattedValue.ToString();
                nouveauScoreJoueur.Joueur.Pseudo = dataGridViewScores[colonne, indexLigne.Pseudo].FormattedValue.ToString();
                for (int ligneTour = 0; ligneTour < 20; ligneTour++)
                {
                    nouveauScoreJoueur.ScoreJoueur.Tours[ligneTour] = int.Parse(dataGridViewScores[colonne, ligneTour + indexLigne.Rang + 1].FormattedValue.ToString());
                }
                nouveauScoreJoueur.ScoreJoueur.Bonus = int.Parse(dataGridViewScores[colonne, indexLigne.Bonus].FormattedValue.ToString());
                nouveauScoreJoueur.ScoreJoueur.Penalite = int.Parse(dataGridViewScores[colonne, indexLigne.Penalite].FormattedValue.ToString());
                nouveauScoreJoueur.Rang = dataGridViewScores[colonne, indexLigne.Rang].FormattedValue.ToString();
                nouveauScoreJoueur.ScoreJoueur.Rang = nouveauScoreJoueur.Rang;
                scoresDansDataGrid.Add(nouveauScoreJoueur);
            }
            return scoresDansDataGrid;
        }
    }

    
}
