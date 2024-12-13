namespace WindowsFormsLigueScrabble
{
    partial class FormConsole
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormConsole));
            this.buttonJoueurs = new System.Windows.Forms.Button();
            this.buttonRencontres = new System.Windows.Forms.Button();
            this.buttonParties = new System.Windows.Forms.Button();
            this.buttonTables = new System.Windows.Forms.Button();
            this.buttonScores = new System.Windows.Forms.Button();
            this.buttonStats = new System.Windows.Forms.Button();
            this.buttonCreerSaison = new System.Windows.Forms.Button();
            this.buttonQuitter = new System.Windows.Forms.Button();
            this.labelConnexion = new System.Windows.Forms.Label();
            this.timerFlash = new System.Windows.Forms.Timer(this.components);
            this.timerDelai = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // buttonJoueurs
            // 
            this.buttonJoueurs.BackColor = System.Drawing.Color.Orange;
            this.buttonJoueurs.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonJoueurs.Location = new System.Drawing.Point(32, 384);
            this.buttonJoueurs.Name = "buttonJoueurs";
            this.buttonJoueurs.Size = new System.Drawing.Size(235, 46);
            this.buttonJoueurs.TabIndex = 1;
            this.buttonJoueurs.Text = "Joueurs";
            this.buttonJoueurs.UseVisualStyleBackColor = false;
            this.buttonJoueurs.Click += new System.EventHandler(this.buttonJoueurs_Click);
            // 
            // buttonRencontres
            // 
            this.buttonRencontres.BackColor = System.Drawing.Color.Orange;
            this.buttonRencontres.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonRencontres.Location = new System.Drawing.Point(32, 332);
            this.buttonRencontres.Name = "buttonRencontres";
            this.buttonRencontres.Size = new System.Drawing.Size(235, 46);
            this.buttonRencontres.TabIndex = 1;
            this.buttonRencontres.Text = "Rencontres";
            this.buttonRencontres.UseVisualStyleBackColor = false;
            this.buttonRencontres.Click += new System.EventHandler(this.buttonRencontres_Click);
            // 
            // buttonParties
            // 
            this.buttonParties.BackColor = System.Drawing.Color.Orange;
            this.buttonParties.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonParties.Location = new System.Drawing.Point(307, 332);
            this.buttonParties.Name = "buttonParties";
            this.buttonParties.Size = new System.Drawing.Size(235, 46);
            this.buttonParties.TabIndex = 1;
            this.buttonParties.Text = "Parties";
            this.buttonParties.UseVisualStyleBackColor = false;
            this.buttonParties.Click += new System.EventHandler(this.buttonParties_Click);
            // 
            // buttonTables
            // 
            this.buttonTables.BackColor = System.Drawing.Color.Orange;
            this.buttonTables.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonTables.Location = new System.Drawing.Point(307, 384);
            this.buttonTables.Name = "buttonTables";
            this.buttonTables.Size = new System.Drawing.Size(235, 46);
            this.buttonTables.TabIndex = 1;
            this.buttonTables.Text = "Tables";
            this.buttonTables.UseVisualStyleBackColor = false;
            this.buttonTables.Click += new System.EventHandler(this.buttonTables_Click);
            // 
            // buttonScores
            // 
            this.buttonScores.BackColor = System.Drawing.Color.Orange;
            this.buttonScores.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonScores.Location = new System.Drawing.Point(578, 332);
            this.buttonScores.Name = "buttonScores";
            this.buttonScores.Size = new System.Drawing.Size(235, 46);
            this.buttonScores.TabIndex = 1;
            this.buttonScores.Text = "Scores";
            this.buttonScores.UseVisualStyleBackColor = false;
            this.buttonScores.Click += new System.EventHandler(this.buttonScores_Click);
            // 
            // buttonStats
            // 
            this.buttonStats.BackColor = System.Drawing.Color.Orange;
            this.buttonStats.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonStats.Location = new System.Drawing.Point(578, 384);
            this.buttonStats.Name = "buttonStats";
            this.buttonStats.Size = new System.Drawing.Size(235, 46);
            this.buttonStats.TabIndex = 1;
            this.buttonStats.Text = "Stats";
            this.buttonStats.UseVisualStyleBackColor = false;
            this.buttonStats.Click += new System.EventHandler(this.buttonStats_Click);
            // 
            // buttonCreerSaison
            // 
            this.buttonCreerSaison.BackColor = System.Drawing.Color.DarkKhaki;
            this.buttonCreerSaison.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCreerSaison.Location = new System.Drawing.Point(844, 332);
            this.buttonCreerSaison.Name = "buttonCreerSaison";
            this.buttonCreerSaison.Size = new System.Drawing.Size(235, 46);
            this.buttonCreerSaison.TabIndex = 1;
            this.buttonCreerSaison.Text = "Nouvelle Saison";
            this.buttonCreerSaison.UseVisualStyleBackColor = false;
            this.buttonCreerSaison.Click += new System.EventHandler(this.buttonCreerSaison_Click);
            // 
            // buttonQuitter
            // 
            this.buttonQuitter.BackColor = System.Drawing.Color.Orange;
            this.buttonQuitter.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonQuitter.Location = new System.Drawing.Point(844, 384);
            this.buttonQuitter.Name = "buttonQuitter";
            this.buttonQuitter.Size = new System.Drawing.Size(235, 46);
            this.buttonQuitter.TabIndex = 1;
            this.buttonQuitter.Text = "Quitter";
            this.buttonQuitter.UseVisualStyleBackColor = false;
            this.buttonQuitter.Click += new System.EventHandler(this.buttonQuitter_Click);
            // 
            // labelConnexion
            // 
            this.labelConnexion.AutoSize = true;
            this.labelConnexion.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelConnexion.Location = new System.Drawing.Point(807, 484);
            this.labelConnexion.Name = "labelConnexion";
            this.labelConnexion.Size = new System.Drawing.Size(142, 25);
            this.labelConnexion.TabIndex = 2;
            this.labelConnexion.Text = "Connexion : ";
            // 
            // timerFlash
            // 
            this.timerFlash.Interval = 250;
            this.timerFlash.Tick += new System.EventHandler(this.timerFlash_Tick);
            // 
            // timerDelai
            // 
            this.timerDelai.Interval = 2500;
            this.timerDelai.Tick += new System.EventHandler(this.timerDelai_Tick);
            // 
            // FormConsole
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Khaki;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1222, 528);
            this.Controls.Add(this.labelConnexion);
            this.Controls.Add(this.buttonQuitter);
            this.Controls.Add(this.buttonCreerSaison);
            this.Controls.Add(this.buttonStats);
            this.Controls.Add(this.buttonScores);
            this.Controls.Add(this.buttonTables);
            this.Controls.Add(this.buttonParties);
            this.Controls.Add(this.buttonRencontres);
            this.Controls.Add(this.buttonJoueurs);
            this.Name = "FormConsole";
            this.Text = "Accueil";
            this.Load += new System.EventHandler(this.FormConsole_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button buttonJoueurs;
        private System.Windows.Forms.Button buttonRencontres;
        private System.Windows.Forms.Button buttonParties;
        private System.Windows.Forms.Button buttonTables;
        private System.Windows.Forms.Button buttonScores;
        private System.Windows.Forms.Button buttonStats;
        private System.Windows.Forms.Button buttonCreerSaison;
        private System.Windows.Forms.Button buttonQuitter;
        private System.Windows.Forms.Label labelConnexion;
        private System.Windows.Forms.Timer timerFlash;
        private System.Windows.Forms.Timer timerDelai;
    }
}

