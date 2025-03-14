namespace WindowsFormsLigueScrabble
{
    partial class JoutesForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.rechercheParToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.joueurToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.heureToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tableToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nombreDeToursToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataGridViewJoueurs = new System.Windows.Forms.DataGridView();
            this.dataGridViewJoutes = new System.Windows.Forms.DataGridView();
            this.labelTotalParties = new System.Windows.Forms.Label();
            this.labelMoyenneParTour = new System.Windows.Forms.Label();
            this.labelParties3Joueurs = new System.Windows.Forms.Label();
            this.labelTotalPoints = new System.Windows.Forms.Label();
            this.labelParties4Joueurs = new System.Windows.Forms.Label();
            this.labelTotalTours = new System.Windows.Forms.Label();
            this.labelnb3J = new System.Windows.Forms.Label();
            this.labelnb4J = new System.Windows.Forms.Label();
            this.labelnbTours = new System.Windows.Forms.Label();
            this.labelMoyenneTour = new System.Windows.Forms.Label();
            this.labelnbPoints = new System.Windows.Forms.Label();
            this.labelPremierePlace = new System.Windows.Forms.Label();
            this.labelnb1rePlace = new System.Windows.Forms.Label();
            this.labeldeuxiemePlace = new System.Windows.Forms.Label();
            this.labelnb2ePlace = new System.Windows.Forms.Label();
            this.labeltroisiemePlace = new System.Windows.Forms.Label();
            this.labelnb3ePlace = new System.Windows.Forms.Label();
            this.labelquatriemePlace = new System.Windows.Forms.Label();
            this.labelnb4ePlace = new System.Windows.Forms.Label();
            this.labelnbParties = new System.Windows.Forms.Label();
            this.labelNomJoueur = new System.Windows.Forms.Label();
            this.panelInfosGenerales = new System.Windows.Forms.Panel();
            this.labelnbPente = new System.Windows.Forms.Label();
            this.labelScoreMax = new System.Windows.Forms.Label();
            this.labelTopScore = new System.Windows.Forms.Label();
            this.labelTendanceMoyenne = new System.Windows.Forms.Label();
            this.captureToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewJoueurs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewJoutes)).BeginInit();
            this.panelInfosGenerales.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.rechercheParToolStripMenuItem,
            this.captureToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1055, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // rechercheParToolStripMenuItem
            // 
            this.rechercheParToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.joueurToolStripMenuItem,
            this.dateToolStripMenuItem,
            this.heureToolStripMenuItem,
            this.tableToolStripMenuItem,
            this.sToolStripMenuItem,
            this.nombreDeToursToolStripMenuItem});
            this.rechercheParToolStripMenuItem.Name = "rechercheParToolStripMenuItem";
            this.rechercheParToolStripMenuItem.Size = new System.Drawing.Size(126, 24);
            this.rechercheParToolStripMenuItem.Text = "Recherche par...";
            // 
            // joueurToolStripMenuItem
            // 
            this.joueurToolStripMenuItem.Name = "joueurToolStripMenuItem";
            this.joueurToolStripMenuItem.Size = new System.Drawing.Size(205, 26);
            this.joueurToolStripMenuItem.Text = "Joueur";
            this.joueurToolStripMenuItem.Click += new System.EventHandler(this.joueurToolStripMenuItem_Click);
            // 
            // dateToolStripMenuItem
            // 
            this.dateToolStripMenuItem.Name = "dateToolStripMenuItem";
            this.dateToolStripMenuItem.Size = new System.Drawing.Size(205, 26);
            this.dateToolStripMenuItem.Text = "Date";
            // 
            // heureToolStripMenuItem
            // 
            this.heureToolStripMenuItem.Name = "heureToolStripMenuItem";
            this.heureToolStripMenuItem.Size = new System.Drawing.Size(205, 26);
            this.heureToolStripMenuItem.Text = "Heure";
            // 
            // tableToolStripMenuItem
            // 
            this.tableToolStripMenuItem.Name = "tableToolStripMenuItem";
            this.tableToolStripMenuItem.Size = new System.Drawing.Size(205, 26);
            this.tableToolStripMenuItem.Text = "Table";
            // 
            // sToolStripMenuItem
            // 
            this.sToolStripMenuItem.Name = "sToolStripMenuItem";
            this.sToolStripMenuItem.Size = new System.Drawing.Size(205, 26);
            this.sToolStripMenuItem.Text = "Scores";
            this.sToolStripMenuItem.Click += new System.EventHandler(this.sToolStripMenuItem_Click);
            // 
            // nombreDeToursToolStripMenuItem
            // 
            this.nombreDeToursToolStripMenuItem.Name = "nombreDeToursToolStripMenuItem";
            this.nombreDeToursToolStripMenuItem.Size = new System.Drawing.Size(205, 26);
            this.nombreDeToursToolStripMenuItem.Text = "Nombre de tours";
            // 
            // dataGridViewJoueurs
            // 
            this.dataGridViewJoueurs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewJoueurs.Location = new System.Drawing.Point(40, 46);
            this.dataGridViewJoueurs.Name = "dataGridViewJoueurs";
            this.dataGridViewJoueurs.RowHeadersWidth = 51;
            this.dataGridViewJoueurs.RowTemplate.Height = 24;
            this.dataGridViewJoueurs.Size = new System.Drawing.Size(286, 352);
            this.dataGridViewJoueurs.TabIndex = 1;
            this.dataGridViewJoueurs.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewJoueurs_CellClick);
            // 
            // dataGridViewJoutes
            // 
            this.dataGridViewJoutes.AllowUserToAddRows = false;
            this.dataGridViewJoutes.AllowUserToDeleteRows = false;
            this.dataGridViewJoutes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewJoutes.Location = new System.Drawing.Point(40, 211);
            this.dataGridViewJoutes.Name = "dataGridViewJoutes";
            this.dataGridViewJoutes.ReadOnly = true;
            this.dataGridViewJoutes.RowHeadersWidth = 51;
            this.dataGridViewJoutes.RowTemplate.Height = 24;
            this.dataGridViewJoutes.Size = new System.Drawing.Size(942, 513);
            this.dataGridViewJoutes.TabIndex = 2;
            // 
            // labelTotalParties
            // 
            this.labelTotalParties.AutoSize = true;
            this.labelTotalParties.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTotalParties.Location = new System.Drawing.Point(19, 56);
            this.labelTotalParties.Name = "labelTotalParties";
            this.labelTotalParties.Size = new System.Drawing.Size(130, 25);
            this.labelTotalParties.TabIndex = 3;
            this.labelTotalParties.Text = "Total parties :";
            this.labelTotalParties.Click += new System.EventHandler(this.label1_Click);
            // 
            // labelMoyenneParTour
            // 
            this.labelMoyenneParTour.AutoSize = true;
            this.labelMoyenneParTour.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMoyenneParTour.Location = new System.Drawing.Point(608, 98);
            this.labelMoyenneParTour.Name = "labelMoyenneParTour";
            this.labelMoyenneParTour.Size = new System.Drawing.Size(176, 25);
            this.labelMoyenneParTour.TabIndex = 3;
            this.labelMoyenneParTour.Text = "Moyenne par tour :";
            this.labelMoyenneParTour.Click += new System.EventHandler(this.label1_Click);
            // 
            // labelParties3Joueurs
            // 
            this.labelParties3Joueurs.AutoSize = true;
            this.labelParties3Joueurs.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelParties3Joueurs.Location = new System.Drawing.Point(19, 100);
            this.labelParties3Joueurs.Name = "labelParties3Joueurs";
            this.labelParties3Joueurs.Size = new System.Drawing.Size(184, 25);
            this.labelParties3Joueurs.TabIndex = 3;
            this.labelParties3Joueurs.Text = "Parties à 3 joueurs :";
            this.labelParties3Joueurs.Click += new System.EventHandler(this.label1_Click);
            // 
            // labelTotalPoints
            // 
            this.labelTotalPoints.AutoSize = true;
            this.labelTotalPoints.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTotalPoints.Location = new System.Drawing.Point(608, 15);
            this.labelTotalPoints.Name = "labelTotalPoints";
            this.labelTotalPoints.Size = new System.Drawing.Size(124, 25);
            this.labelTotalPoints.TabIndex = 3;
            this.labelTotalPoints.Text = "Total points :";
            this.labelTotalPoints.Click += new System.EventHandler(this.label1_Click);
            // 
            // labelParties4Joueurs
            // 
            this.labelParties4Joueurs.AutoSize = true;
            this.labelParties4Joueurs.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelParties4Joueurs.Location = new System.Drawing.Point(19, 139);
            this.labelParties4Joueurs.Name = "labelParties4Joueurs";
            this.labelParties4Joueurs.Size = new System.Drawing.Size(184, 25);
            this.labelParties4Joueurs.TabIndex = 3;
            this.labelParties4Joueurs.Text = "Parties à 4 joueurs :";
            this.labelParties4Joueurs.Click += new System.EventHandler(this.label1_Click);
            // 
            // labelTotalTours
            // 
            this.labelTotalTours.AutoSize = true;
            this.labelTotalTours.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTotalTours.Location = new System.Drawing.Point(608, 59);
            this.labelTotalTours.Name = "labelTotalTours";
            this.labelTotalTours.Size = new System.Drawing.Size(115, 25);
            this.labelTotalTours.TabIndex = 3;
            this.labelTotalTours.Text = "Total tours :";
            this.labelTotalTours.Click += new System.EventHandler(this.label1_Click);
            // 
            // labelnb3J
            // 
            this.labelnb3J.AutoSize = true;
            this.labelnb3J.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelnb3J.Location = new System.Drawing.Point(215, 100);
            this.labelnb3J.Name = "labelnb3J";
            this.labelnb3J.Size = new System.Drawing.Size(23, 25);
            this.labelnb3J.TabIndex = 3;
            this.labelnb3J.Text = "0";
            this.labelnb3J.Click += new System.EventHandler(this.label1_Click);
            // 
            // labelnb4J
            // 
            this.labelnb4J.AutoSize = true;
            this.labelnb4J.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelnb4J.Location = new System.Drawing.Point(215, 139);
            this.labelnb4J.Name = "labelnb4J";
            this.labelnb4J.Size = new System.Drawing.Size(23, 25);
            this.labelnb4J.TabIndex = 3;
            this.labelnb4J.Text = "0";
            this.labelnb4J.Click += new System.EventHandler(this.label1_Click);
            // 
            // labelnbTours
            // 
            this.labelnbTours.AutoSize = true;
            this.labelnbTours.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelnbTours.Location = new System.Drawing.Point(798, 59);
            this.labelnbTours.Name = "labelnbTours";
            this.labelnbTours.Size = new System.Drawing.Size(23, 25);
            this.labelnbTours.TabIndex = 3;
            this.labelnbTours.Text = "0";
            this.labelnbTours.Click += new System.EventHandler(this.label1_Click);
            // 
            // labelMoyenneTour
            // 
            this.labelMoyenneTour.AutoSize = true;
            this.labelMoyenneTour.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMoyenneTour.Location = new System.Drawing.Point(798, 98);
            this.labelMoyenneTour.Name = "labelMoyenneTour";
            this.labelMoyenneTour.Size = new System.Drawing.Size(23, 25);
            this.labelMoyenneTour.TabIndex = 3;
            this.labelMoyenneTour.Text = "0";
            this.labelMoyenneTour.Click += new System.EventHandler(this.label1_Click);
            // 
            // labelnbPoints
            // 
            this.labelnbPoints.AutoSize = true;
            this.labelnbPoints.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelnbPoints.Location = new System.Drawing.Point(798, 15);
            this.labelnbPoints.Name = "labelnbPoints";
            this.labelnbPoints.Size = new System.Drawing.Size(23, 25);
            this.labelnbPoints.TabIndex = 3;
            this.labelnbPoints.Text = "0";
            this.labelnbPoints.Click += new System.EventHandler(this.label1_Click);
            // 
            // labelPremierePlace
            // 
            this.labelPremierePlace.AutoSize = true;
            this.labelPremierePlace.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPremierePlace.Location = new System.Drawing.Point(356, 56);
            this.labelPremierePlace.Name = "labelPremierePlace";
            this.labelPremierePlace.Size = new System.Drawing.Size(112, 25);
            this.labelPremierePlace.TabIndex = 3;
            this.labelPremierePlace.Text = "Victoire(s) :";
            this.labelPremierePlace.Click += new System.EventHandler(this.label1_Click);
            // 
            // labelnb1rePlace
            // 
            this.labelnb1rePlace.AutoSize = true;
            this.labelnb1rePlace.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelnb1rePlace.Location = new System.Drawing.Point(485, 56);
            this.labelnb1rePlace.Name = "labelnb1rePlace";
            this.labelnb1rePlace.Size = new System.Drawing.Size(23, 25);
            this.labelnb1rePlace.TabIndex = 3;
            this.labelnb1rePlace.Text = "0";
            this.labelnb1rePlace.Click += new System.EventHandler(this.label1_Click);
            // 
            // labeldeuxiemePlace
            // 
            this.labeldeuxiemePlace.AutoSize = true;
            this.labeldeuxiemePlace.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labeldeuxiemePlace.Location = new System.Drawing.Point(356, 91);
            this.labeldeuxiemePlace.Name = "labeldeuxiemePlace";
            this.labeldeuxiemePlace.Size = new System.Drawing.Size(97, 25);
            this.labeldeuxiemePlace.TabIndex = 3;
            this.labeldeuxiemePlace.Text = "2e place :";
            this.labeldeuxiemePlace.Click += new System.EventHandler(this.label1_Click);
            // 
            // labelnb2ePlace
            // 
            this.labelnb2ePlace.AutoSize = true;
            this.labelnb2ePlace.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelnb2ePlace.Location = new System.Drawing.Point(485, 91);
            this.labelnb2ePlace.Name = "labelnb2ePlace";
            this.labelnb2ePlace.Size = new System.Drawing.Size(23, 25);
            this.labelnb2ePlace.TabIndex = 3;
            this.labelnb2ePlace.Text = "0";
            this.labelnb2ePlace.Click += new System.EventHandler(this.label1_Click);
            // 
            // labeltroisiemePlace
            // 
            this.labeltroisiemePlace.AutoSize = true;
            this.labeltroisiemePlace.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labeltroisiemePlace.Location = new System.Drawing.Point(356, 116);
            this.labeltroisiemePlace.Name = "labeltroisiemePlace";
            this.labeltroisiemePlace.Size = new System.Drawing.Size(97, 25);
            this.labeltroisiemePlace.TabIndex = 3;
            this.labeltroisiemePlace.Text = "3e place :";
            this.labeltroisiemePlace.Click += new System.EventHandler(this.label1_Click);
            // 
            // labelnb3ePlace
            // 
            this.labelnb3ePlace.AutoSize = true;
            this.labelnb3ePlace.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelnb3ePlace.Location = new System.Drawing.Point(485, 116);
            this.labelnb3ePlace.Name = "labelnb3ePlace";
            this.labelnb3ePlace.Size = new System.Drawing.Size(23, 25);
            this.labelnb3ePlace.TabIndex = 3;
            this.labelnb3ePlace.Text = "0";
            this.labelnb3ePlace.Click += new System.EventHandler(this.label1_Click);
            // 
            // labelquatriemePlace
            // 
            this.labelquatriemePlace.AutoSize = true;
            this.labelquatriemePlace.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelquatriemePlace.Location = new System.Drawing.Point(356, 141);
            this.labelquatriemePlace.Name = "labelquatriemePlace";
            this.labelquatriemePlace.Size = new System.Drawing.Size(97, 25);
            this.labelquatriemePlace.TabIndex = 3;
            this.labelquatriemePlace.Text = "4e place :";
            this.labelquatriemePlace.Click += new System.EventHandler(this.label1_Click);
            // 
            // labelnb4ePlace
            // 
            this.labelnb4ePlace.AutoSize = true;
            this.labelnb4ePlace.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelnb4ePlace.Location = new System.Drawing.Point(485, 141);
            this.labelnb4ePlace.Name = "labelnb4ePlace";
            this.labelnb4ePlace.Size = new System.Drawing.Size(23, 25);
            this.labelnb4ePlace.TabIndex = 3;
            this.labelnb4ePlace.Text = "0";
            this.labelnb4ePlace.Click += new System.EventHandler(this.label1_Click);
            // 
            // labelnbParties
            // 
            this.labelnbParties.AutoSize = true;
            this.labelnbParties.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelnbParties.Location = new System.Drawing.Point(215, 56);
            this.labelnbParties.Name = "labelnbParties";
            this.labelnbParties.Size = new System.Drawing.Size(23, 25);
            this.labelnbParties.TabIndex = 3;
            this.labelnbParties.Text = "0";
            this.labelnbParties.Click += new System.EventHandler(this.label1_Click);
            // 
            // labelNomJoueur
            // 
            this.labelNomJoueur.AutoSize = true;
            this.labelNomJoueur.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNomJoueur.Location = new System.Drawing.Point(19, 15);
            this.labelNomJoueur.Name = "labelNomJoueur";
            this.labelNomJoueur.Size = new System.Drawing.Size(119, 25);
            this.labelNomJoueur.TabIndex = 3;
            this.labelNomJoueur.Text = "Nom Joueur";
            this.labelNomJoueur.Click += new System.EventHandler(this.label1_Click);
            // 
            // panelInfosGenerales
            // 
            this.panelInfosGenerales.Controls.Add(this.labelnbPente);
            this.panelInfosGenerales.Controls.Add(this.labelMoyenneTour);
            this.panelInfosGenerales.Controls.Add(this.labelnb4ePlace);
            this.panelInfosGenerales.Controls.Add(this.labelScoreMax);
            this.panelInfosGenerales.Controls.Add(this.labelnbPoints);
            this.panelInfosGenerales.Controls.Add(this.labelnb3ePlace);
            this.panelInfosGenerales.Controls.Add(this.labelnbTours);
            this.panelInfosGenerales.Controls.Add(this.labelnb2ePlace);
            this.panelInfosGenerales.Controls.Add(this.labelTotalTours);
            this.panelInfosGenerales.Controls.Add(this.labelnb1rePlace);
            this.panelInfosGenerales.Controls.Add(this.labelTopScore);
            this.panelInfosGenerales.Controls.Add(this.labelTotalPoints);
            this.panelInfosGenerales.Controls.Add(this.labelTendanceMoyenne);
            this.panelInfosGenerales.Controls.Add(this.labelMoyenneParTour);
            this.panelInfosGenerales.Controls.Add(this.labelquatriemePlace);
            this.panelInfosGenerales.Controls.Add(this.labeltroisiemePlace);
            this.panelInfosGenerales.Controls.Add(this.labeldeuxiemePlace);
            this.panelInfosGenerales.Controls.Add(this.labelPremierePlace);
            this.panelInfosGenerales.Controls.Add(this.labelnb4J);
            this.panelInfosGenerales.Controls.Add(this.labelnbParties);
            this.panelInfosGenerales.Controls.Add(this.labelnb3J);
            this.panelInfosGenerales.Controls.Add(this.labelParties4Joueurs);
            this.panelInfosGenerales.Controls.Add(this.labelParties3Joueurs);
            this.panelInfosGenerales.Controls.Add(this.labelNomJoueur);
            this.panelInfosGenerales.Controls.Add(this.labelTotalParties);
            this.panelInfosGenerales.Location = new System.Drawing.Point(49, 31);
            this.panelInfosGenerales.Name = "panelInfosGenerales";
            this.panelInfosGenerales.Size = new System.Drawing.Size(933, 180);
            this.panelInfosGenerales.TabIndex = 4;
            this.panelInfosGenerales.Visible = false;
            // 
            // labelnbPente
            // 
            this.labelnbPente.AutoSize = true;
            this.labelnbPente.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelnbPente.Location = new System.Drawing.Point(798, 139);
            this.labelnbPente.Name = "labelnbPente";
            this.labelnbPente.Size = new System.Drawing.Size(23, 25);
            this.labelnbPente.TabIndex = 3;
            this.labelnbPente.Text = "0";
            this.labelnbPente.Click += new System.EventHandler(this.label1_Click);
            // 
            // labelScoreMax
            // 
            this.labelScoreMax.AutoSize = true;
            this.labelScoreMax.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelScoreMax.Location = new System.Drawing.Point(485, 15);
            this.labelScoreMax.Name = "labelScoreMax";
            this.labelScoreMax.Size = new System.Drawing.Size(23, 25);
            this.labelScoreMax.TabIndex = 3;
            this.labelScoreMax.Text = "0";
            this.labelScoreMax.Click += new System.EventHandler(this.label1_Click);
            // 
            // labelTopScore
            // 
            this.labelTopScore.AutoSize = true;
            this.labelTopScore.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTopScore.Location = new System.Drawing.Point(295, 15);
            this.labelTopScore.Name = "labelTopScore";
            this.labelTopScore.Size = new System.Drawing.Size(144, 25);
            this.labelTopScore.TabIndex = 3;
            this.labelTopScore.Text = "Meilleur score :";
            this.labelTopScore.Click += new System.EventHandler(this.label1_Click);
            // 
            // labelTendanceMoyenne
            // 
            this.labelTendanceMoyenne.AutoSize = true;
            this.labelTendanceMoyenne.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTendanceMoyenne.Location = new System.Drawing.Point(608, 139);
            this.labelTendanceMoyenne.Name = "labelTendanceMoyenne";
            this.labelTendanceMoyenne.Size = new System.Drawing.Size(112, 25);
            this.labelTendanceMoyenne.TabIndex = 3;
            this.labelTendanceMoyenne.Text = "Tendance :";
            this.labelTendanceMoyenne.Click += new System.EventHandler(this.label1_Click);
            // 
            // captureToolStripMenuItem
            // 
            this.captureToolStripMenuItem.Name = "captureToolStripMenuItem";
            this.captureToolStripMenuItem.Size = new System.Drawing.Size(75, 24);
            this.captureToolStripMenuItem.Text = "Capture";
            this.captureToolStripMenuItem.Click += new System.EventHandler(this.captureToolStripMenuItem_Click);
            // 
            // JoutesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1055, 736);
            this.Controls.Add(this.dataGridViewJoutes);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.panelInfosGenerales);
            this.Controls.Add(this.dataGridViewJoueurs);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "JoutesForm";
            this.Text = "JoutesForm";
            this.Load += new System.EventHandler(this.JoutesForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewJoueurs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewJoutes)).EndInit();
            this.panelInfosGenerales.ResumeLayout(false);
            this.panelInfosGenerales.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem rechercheParToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem joueurToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem heureToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tableToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nombreDeToursToolStripMenuItem;
        private System.Windows.Forms.DataGridView dataGridViewJoueurs;
        private System.Windows.Forms.DataGridView dataGridViewJoutes;
        private System.Windows.Forms.Label labelTotalParties;
        private System.Windows.Forms.Label labelMoyenneParTour;
        private System.Windows.Forms.Label labelParties3Joueurs;
        private System.Windows.Forms.Label labelTotalPoints;
        private System.Windows.Forms.Label labelParties4Joueurs;
        private System.Windows.Forms.Label labelTotalTours;
        private System.Windows.Forms.Label labelnb3J;
        private System.Windows.Forms.Label labelnb4J;
        private System.Windows.Forms.Label labelnbTours;
        private System.Windows.Forms.Label labelMoyenneTour;
        private System.Windows.Forms.Label labelnbPoints;
        private System.Windows.Forms.Label labelPremierePlace;
        private System.Windows.Forms.Label labelnb1rePlace;
        private System.Windows.Forms.Label labeldeuxiemePlace;
        private System.Windows.Forms.Label labelnb2ePlace;
        private System.Windows.Forms.Label labeltroisiemePlace;
        private System.Windows.Forms.Label labelnb3ePlace;
        private System.Windows.Forms.Label labelquatriemePlace;
        private System.Windows.Forms.Label labelnb4ePlace;
        private System.Windows.Forms.Label labelnbParties;
        private System.Windows.Forms.Label labelNomJoueur;
        private System.Windows.Forms.Panel panelInfosGenerales;
        private System.Windows.Forms.Label labelScoreMax;
        private System.Windows.Forms.Label labelTopScore;
        private System.Windows.Forms.Label labelnbPente;
        private System.Windows.Forms.Label labelTendanceMoyenne;
        private System.Windows.Forms.ToolStripMenuItem captureToolStripMenuItem;
    }
}