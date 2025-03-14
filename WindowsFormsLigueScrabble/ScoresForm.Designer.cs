namespace WindowsFormsLigueScrabble
{
    partial class ScoresForm
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
            this.dataGridViewScores = new System.Windows.Forms.DataGridView();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.choisirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.joueurToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.dateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.heureToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tableToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.jouteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.enregistrerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.annulerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.modificationsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ajouterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lignesDeScoreToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.joueurToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fermerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.labelDate = new System.Windows.Forms.Label();
            this.labelHeure = new System.Windows.Forms.Label();
            this.labelTable = new System.Windows.Forms.Label();
            this.labelJoute = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewScores)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridViewScores
            // 
            this.dataGridViewScores.AllowUserToDeleteRows = false;
            this.dataGridViewScores.BackgroundColor = System.Drawing.Color.DeepSkyBlue;
            this.dataGridViewScores.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridViewScores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewScores.Location = new System.Drawing.Point(50, 93);
            this.dataGridViewScores.MultiSelect = false;
            this.dataGridViewScores.Name = "dataGridViewScores";
            this.dataGridViewScores.RowHeadersWidth = 51;
            this.dataGridViewScores.RowTemplate.Height = 24;
            this.dataGridViewScores.Size = new System.Drawing.Size(737, 645);
            this.dataGridViewScores.TabIndex = 0;
            this.dataGridViewScores.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewScores_CellValueChanged);
            this.dataGridViewScores.KeyUp += new System.Windows.Forms.KeyEventHandler(this.dataGridViewScores_KeyUp);
            // 
            // menuStrip1
            // 
            this.menuStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible;
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.choisirToolStripMenuItem,
            this.enregistrerToolStripMenuItem,
            this.annulerToolStripMenuItem,
            this.ajouterToolStripMenuItem,
            this.fermerToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(846, 28);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // choisirToolStripMenuItem
            // 
            this.choisirToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.joueurToolStripMenuItem1,
            this.dateToolStripMenuItem,
            this.heureToolStripMenuItem,
            this.tableToolStripMenuItem,
            this.jouteToolStripMenuItem});
            this.choisirToolStripMenuItem.Name = "choisirToolStripMenuItem";
            this.choisirToolStripMenuItem.Size = new System.Drawing.Size(68, 24);
            this.choisirToolStripMenuItem.Text = "Choisir";
            // 
            // joueurToolStripMenuItem1
            // 
            this.joueurToolStripMenuItem1.Name = "joueurToolStripMenuItem1";
            this.joueurToolStripMenuItem1.Size = new System.Drawing.Size(135, 26);
            this.joueurToolStripMenuItem1.Text = "Joueur";
            // 
            // dateToolStripMenuItem
            // 
            this.dateToolStripMenuItem.Name = "dateToolStripMenuItem";
            this.dateToolStripMenuItem.Size = new System.Drawing.Size(135, 26);
            this.dateToolStripMenuItem.Text = "Date";
            // 
            // heureToolStripMenuItem
            // 
            this.heureToolStripMenuItem.Name = "heureToolStripMenuItem";
            this.heureToolStripMenuItem.Size = new System.Drawing.Size(135, 26);
            this.heureToolStripMenuItem.Text = "Heure";
            // 
            // tableToolStripMenuItem
            // 
            this.tableToolStripMenuItem.Name = "tableToolStripMenuItem";
            this.tableToolStripMenuItem.Size = new System.Drawing.Size(135, 26);
            this.tableToolStripMenuItem.Text = "Table";
            // 
            // jouteToolStripMenuItem
            // 
            this.jouteToolStripMenuItem.Name = "jouteToolStripMenuItem";
            this.jouteToolStripMenuItem.Size = new System.Drawing.Size(135, 26);
            this.jouteToolStripMenuItem.Text = "Joute";
            // 
            // enregistrerToolStripMenuItem
            // 
            this.enregistrerToolStripMenuItem.Name = "enregistrerToolStripMenuItem";
            this.enregistrerToolStripMenuItem.Size = new System.Drawing.Size(94, 24);
            this.enregistrerToolStripMenuItem.Text = "Enregistrer";
            this.enregistrerToolStripMenuItem.Click += new System.EventHandler(this.enregistrerToolStripMenuItem_Click);
            // 
            // annulerToolStripMenuItem
            // 
            this.annulerToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.modificationsToolStripMenuItem});
            this.annulerToolStripMenuItem.Name = "annulerToolStripMenuItem";
            this.annulerToolStripMenuItem.Size = new System.Drawing.Size(74, 24);
            this.annulerToolStripMenuItem.Text = "Annuler";
            // 
            // modificationsToolStripMenuItem
            // 
            this.modificationsToolStripMenuItem.Name = "modificationsToolStripMenuItem";
            this.modificationsToolStripMenuItem.Size = new System.Drawing.Size(183, 26);
            this.modificationsToolStripMenuItem.Text = "Modifications";
            this.modificationsToolStripMenuItem.Click += new System.EventHandler(this.AnnulerModificationsToolStripMenuItem_Click);
            // 
            // ajouterToolStripMenuItem
            // 
            this.ajouterToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lignesDeScoreToolStripMenuItem,
            this.joueurToolStripMenuItem});
            this.ajouterToolStripMenuItem.Name = "ajouterToolStripMenuItem";
            this.ajouterToolStripMenuItem.Size = new System.Drawing.Size(72, 24);
            this.ajouterToolStripMenuItem.Text = "Ajouter";
            // 
            // lignesDeScoreToolStripMenuItem
            // 
            this.lignesDeScoreToolStripMenuItem.Name = "lignesDeScoreToolStripMenuItem";
            this.lignesDeScoreToolStripMenuItem.Size = new System.Drawing.Size(196, 26);
            this.lignesDeScoreToolStripMenuItem.Text = "Lignes de Score";
            this.lignesDeScoreToolStripMenuItem.Click += new System.EventHandler(this.AjouterlignesDeScoreToolStripMenuItem_Click);
            // 
            // joueurToolStripMenuItem
            // 
            this.joueurToolStripMenuItem.Name = "joueurToolStripMenuItem";
            this.joueurToolStripMenuItem.Size = new System.Drawing.Size(196, 26);
            this.joueurToolStripMenuItem.Text = "Joueur";
            // 
            // fermerToolStripMenuItem
            // 
            this.fermerToolStripMenuItem.Name = "fermerToolStripMenuItem";
            this.fermerToolStripMenuItem.Size = new System.Drawing.Size(69, 24);
            this.fermerToolStripMenuItem.Text = "Fermer";
            this.fermerToolStripMenuItem.Click += new System.EventHandler(this.fermerToolStripMenuItem_Click);
            // 
            // labelDate
            // 
            this.labelDate.AutoSize = true;
            this.labelDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDate.Location = new System.Drawing.Point(68, 53);
            this.labelDate.Name = "labelDate";
            this.labelDate.Size = new System.Drawing.Size(64, 25);
            this.labelDate.TabIndex = 4;
            this.labelDate.Text = "Date :";
            // 
            // labelHeure
            // 
            this.labelHeure.AutoSize = true;
            this.labelHeure.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelHeure.Location = new System.Drawing.Point(222, 53);
            this.labelHeure.Name = "labelHeure";
            this.labelHeure.Size = new System.Drawing.Size(76, 25);
            this.labelHeure.TabIndex = 4;
            this.labelHeure.Text = "Heure :";
            // 
            // labelTable
            // 
            this.labelTable.AutoSize = true;
            this.labelTable.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTable.Location = new System.Drawing.Point(416, 53);
            this.labelTable.Name = "labelTable";
            this.labelTable.Size = new System.Drawing.Size(105, 25);
            this.labelTable.TabIndex = 4;
            this.labelTable.Text = "Table no : ";
            // 
            // labelJoute
            // 
            this.labelJoute.AutoSize = true;
            this.labelJoute.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelJoute.Location = new System.Drawing.Point(586, 53);
            this.labelJoute.Name = "labelJoute";
            this.labelJoute.Size = new System.Drawing.Size(78, 25);
            this.labelJoute.TabIndex = 4;
            this.labelJoute.Text = "Partie : ";
            // 
            // ScoresForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.ClientSize = new System.Drawing.Size(846, 773);
            this.Controls.Add(this.labelJoute);
            this.Controls.Add(this.labelTable);
            this.Controls.Add(this.labelHeure);
            this.Controls.Add(this.labelDate);
            this.Controls.Add(this.dataGridViewScores);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "ScoresForm";
            this.Text = "Ajout/Modification des scores";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ScoresForm_FormClosing);
            this.Load += new System.EventHandler(this.ScoresForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewScores)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewScores;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem enregistrerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ajouterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem lignesDeScoreToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem joueurToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem annulerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem modificationsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fermerToolStripMenuItem;
        private System.Windows.Forms.Label labelDate;
        private System.Windows.Forms.Label labelHeure;
        private System.Windows.Forms.Label labelTable;
        private System.Windows.Forms.Label labelJoute;
        private System.Windows.Forms.ToolStripMenuItem choisirToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem joueurToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem dateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem heureToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tableToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem jouteToolStripMenuItem;
    }
}