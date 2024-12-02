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
            this.buttonConnect = new System.Windows.Forms.Button();
            this.buttonAjouterJoueur = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonConnect
            // 
            this.buttonConnect.Location = new System.Drawing.Point(189, 169);
            this.buttonConnect.Name = "buttonConnect";
            this.buttonConnect.Size = new System.Drawing.Size(133, 53);
            this.buttonConnect.TabIndex = 0;
            this.buttonConnect.Text = "Connect";
            this.buttonConnect.UseVisualStyleBackColor = true;
            this.buttonConnect.Click += new System.EventHandler(this.buttonConnect_Click);
            // 
            // buttonAjouterJoueur
            // 
            this.buttonAjouterJoueur.Location = new System.Drawing.Point(538, 36);
            this.buttonAjouterJoueur.Name = "buttonAjouterJoueur";
            this.buttonAjouterJoueur.Size = new System.Drawing.Size(235, 46);
            this.buttonAjouterJoueur.TabIndex = 1;
            this.buttonAjouterJoueur.Text = "Ajouter joueur";
            this.buttonAjouterJoueur.UseVisualStyleBackColor = true;
            this.buttonAjouterJoueur.Click += new System.EventHandler(this.buttonAjouterJoueur_Click);
            // 
            // FormConsole
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.buttonAjouterJoueur);
            this.Controls.Add(this.buttonConnect);
            this.Name = "FormConsole";
            this.Text = "Accueil";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonConnect;
        private System.Windows.Forms.Button buttonAjouterJoueur;
    }
}

