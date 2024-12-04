﻿namespace WindowsFormsLigueScrabble
{
    partial class JoueurForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(JoueurForm));
            this.dataGridViewJoueurs = new System.Windows.Forms.DataGridView();
            this.textBoxIdCode = new System.Windows.Forms.TextBox();
            this.textBoxNom = new System.Windows.Forms.TextBox();
            this.textBoxPseudo = new System.Windows.Forms.TextBox();
            this.labelIDCode = new System.Windows.Forms.Label();
            this.labelNom = new System.Windows.Forms.Label();
            this.labelPseudo = new System.Windows.Forms.Label();
            this.buttonAjouterJoueur = new System.Windows.Forms.Button();
            this.buttonTerminer = new System.Windows.Forms.Button();
            this.buttonSupprimerJoueur = new System.Windows.Forms.Button();
            this.buttonModifierJoueur = new System.Windows.Forms.Button();
            this.labelNombreJoueurs = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewJoueurs)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewJoueurs
            // 
            this.dataGridViewJoueurs.BackgroundColor = System.Drawing.Color.DeepSkyBlue;
            this.dataGridViewJoueurs.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridViewJoueurs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewJoueurs.Location = new System.Drawing.Point(37, 80);
            this.dataGridViewJoueurs.Name = "dataGridViewJoueurs";
            this.dataGridViewJoueurs.RowHeadersWidth = 51;
            this.dataGridViewJoueurs.RowTemplate.Height = 24;
            this.dataGridViewJoueurs.Size = new System.Drawing.Size(487, 275);
            this.dataGridViewJoueurs.TabIndex = 0;
            // 
            // textBoxIdCode
            // 
            this.textBoxIdCode.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.textBoxIdCode.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxIdCode.Location = new System.Drawing.Point(44, 38);
            this.textBoxIdCode.MaxLength = 1;
            this.textBoxIdCode.Name = "textBoxIdCode";
            this.textBoxIdCode.Size = new System.Drawing.Size(65, 36);
            this.textBoxIdCode.TabIndex = 1;
            this.textBoxIdCode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBoxIdCode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxIdCode_KeyPress);
            this.textBoxIdCode.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBoxIdCode_KeyUp);
            // 
            // textBoxNom
            // 
            this.textBoxNom.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.textBoxNom.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxNom.Location = new System.Drawing.Point(135, 38);
            this.textBoxNom.Name = "textBoxNom";
            this.textBoxNom.Size = new System.Drawing.Size(163, 36);
            this.textBoxNom.TabIndex = 1;
            // 
            // textBoxPseudo
            // 
            this.textBoxPseudo.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.textBoxPseudo.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxPseudo.Location = new System.Drawing.Point(319, 38);
            this.textBoxPseudo.Name = "textBoxPseudo";
            this.textBoxPseudo.Size = new System.Drawing.Size(163, 36);
            this.textBoxPseudo.TabIndex = 1;
            // 
            // labelIDCode
            // 
            this.labelIDCode.AutoSize = true;
            this.labelIDCode.Location = new System.Drawing.Point(47, 15);
            this.labelIDCode.Name = "labelIDCode";
            this.labelIDCode.Size = new System.Drawing.Size(62, 16);
            this.labelIDCode.TabIndex = 2;
            this.labelIDCode.Text = "ID Code :";
            // 
            // labelNom
            // 
            this.labelNom.AutoSize = true;
            this.labelNom.Location = new System.Drawing.Point(132, 15);
            this.labelNom.Name = "labelNom";
            this.labelNom.Size = new System.Drawing.Size(60, 16);
            this.labelNom.TabIndex = 2;
            this.labelNom.Text = "Prénom :";
            // 
            // labelPseudo
            // 
            this.labelPseudo.AutoSize = true;
            this.labelPseudo.Location = new System.Drawing.Point(316, 15);
            this.labelPseudo.Name = "labelPseudo";
            this.labelPseudo.Size = new System.Drawing.Size(93, 16);
            this.labelPseudo.TabIndex = 2;
            this.labelPseudo.Text = "Pseudo/Nom :";
            // 
            // buttonAjouterJoueur
            // 
            this.buttonAjouterJoueur.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonAjouterJoueur.BackColor = System.Drawing.Color.Transparent;
            this.buttonAjouterJoueur.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonAjouterJoueur.BackgroundImage")));
            this.buttonAjouterJoueur.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonAjouterJoueur.FlatAppearance.BorderSize = 0;
            this.buttonAjouterJoueur.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAjouterJoueur.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAjouterJoueur.Location = new System.Drawing.Point(618, 31);
            this.buttonAjouterJoueur.Name = "buttonAjouterJoueur";
            this.buttonAjouterJoueur.Size = new System.Drawing.Size(45, 44);
            this.buttonAjouterJoueur.TabIndex = 3;
            this.buttonAjouterJoueur.UseVisualStyleBackColor = false;
            this.buttonAjouterJoueur.Click += new System.EventHandler(this.buttonAjouterJoueur_Click);
            // 
            // buttonTerminer
            // 
            this.buttonTerminer.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonTerminer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonTerminer.Location = new System.Drawing.Point(648, 105);
            this.buttonTerminer.Name = "buttonTerminer";
            this.buttonTerminer.Size = new System.Drawing.Size(90, 43);
            this.buttonTerminer.TabIndex = 4;
            this.buttonTerminer.Text = "Terminé";
            this.buttonTerminer.UseVisualStyleBackColor = true;
            this.buttonTerminer.Click += new System.EventHandler(this.buttonTerminer_Click);
            // 
            // buttonSupprimerJoueur
            // 
            this.buttonSupprimerJoueur.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSupprimerJoueur.BackColor = System.Drawing.Color.Transparent;
            this.buttonSupprimerJoueur.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonSupprimerJoueur.BackgroundImage")));
            this.buttonSupprimerJoueur.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonSupprimerJoueur.FlatAppearance.BorderSize = 0;
            this.buttonSupprimerJoueur.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSupprimerJoueur.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSupprimerJoueur.Location = new System.Drawing.Point(669, 31);
            this.buttonSupprimerJoueur.Name = "buttonSupprimerJoueur";
            this.buttonSupprimerJoueur.Size = new System.Drawing.Size(45, 44);
            this.buttonSupprimerJoueur.TabIndex = 3;
            this.buttonSupprimerJoueur.Text = "–";
            this.buttonSupprimerJoueur.UseVisualStyleBackColor = false;
            this.buttonSupprimerJoueur.Click += new System.EventHandler(this.buttonRetirerJoueur_Click);
            // 
            // buttonModifierJoueur
            // 
            this.buttonModifierJoueur.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonModifierJoueur.BackColor = System.Drawing.Color.Transparent;
            this.buttonModifierJoueur.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonModifierJoueur.BackgroundImage")));
            this.buttonModifierJoueur.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonModifierJoueur.FlatAppearance.BorderSize = 0;
            this.buttonModifierJoueur.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonModifierJoueur.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonModifierJoueur.Location = new System.Drawing.Point(720, 30);
            this.buttonModifierJoueur.Name = "buttonModifierJoueur";
            this.buttonModifierJoueur.Size = new System.Drawing.Size(45, 44);
            this.buttonModifierJoueur.TabIndex = 3;
            this.buttonModifierJoueur.UseVisualStyleBackColor = false;
            this.buttonModifierJoueur.Click += new System.EventHandler(this.buttonAjouterJoueur_Click);
            // 
            // labelNombreJoueurs
            // 
            this.labelNombreJoueurs.AutoSize = true;
            this.labelNombreJoueurs.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNombreJoueurs.Location = new System.Drawing.Point(41, 374);
            this.labelNombreJoueurs.Name = "labelNombreJoueurs";
            this.labelNombreJoueurs.Size = new System.Drawing.Size(193, 25);
            this.labelNombreJoueurs.TabIndex = 2;
            this.labelNombreJoueurs.Text = "Nombre de joueurs : ";
            // 
            // JoueurForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.buttonTerminer);
            this.Controls.Add(this.buttonModifierJoueur);
            this.Controls.Add(this.buttonSupprimerJoueur);
            this.Controls.Add(this.buttonAjouterJoueur);
            this.Controls.Add(this.labelPseudo);
            this.Controls.Add(this.labelNom);
            this.Controls.Add(this.labelNombreJoueurs);
            this.Controls.Add(this.labelIDCode);
            this.Controls.Add(this.textBoxNom);
            this.Controls.Add(this.textBoxPseudo);
            this.Controls.Add(this.textBoxIdCode);
            this.Controls.Add(this.dataGridViewJoueurs);
            this.Name = "JoueurForm";
            this.Text = "AjoutJoueurForm";
            this.Load += new System.EventHandler(this.AjoutJoueurForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewJoueurs)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewJoueurs;
        private System.Windows.Forms.TextBox textBoxIdCode;
        private System.Windows.Forms.TextBox textBoxNom;
        private System.Windows.Forms.TextBox textBoxPseudo;
        private System.Windows.Forms.Label labelIDCode;
        private System.Windows.Forms.Label labelNom;
        private System.Windows.Forms.Label labelPseudo;
        private System.Windows.Forms.Button buttonAjouterJoueur;
        private System.Windows.Forms.Button buttonTerminer;
        private System.Windows.Forms.Button buttonSupprimerJoueur;
        private System.Windows.Forms.Button buttonModifierJoueur;
        private System.Windows.Forms.Label labelNombreJoueurs;
    }
}