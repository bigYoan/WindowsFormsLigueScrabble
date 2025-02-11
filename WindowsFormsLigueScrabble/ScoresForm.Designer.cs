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
            this.enregistrerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.annulerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.modificationsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ajouterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lignesDeScoreToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.joueurToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fermerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewScores)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridViewScores
            // 
            this.dataGridViewScores.BackgroundColor = System.Drawing.Color.DeepSkyBlue;
            this.dataGridViewScores.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridViewScores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewScores.Location = new System.Drawing.Point(50, 77);
            this.dataGridViewScores.Name = "dataGridViewScores";
            this.dataGridViewScores.RowHeadersWidth = 51;
            this.dataGridViewScores.RowTemplate.Height = 24;
            this.dataGridViewScores.Size = new System.Drawing.Size(737, 645);
            this.dataGridViewScores.TabIndex = 0;
            this.dataGridViewScores.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewScores_CellValueChanged);
            // 
            // menuStrip1
            // 
            this.menuStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible;
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
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
            this.modificationsToolStripMenuItem.Click += new System.EventHandler(this.modificationsToolStripMenuItem_Click);
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
            this.lignesDeScoreToolStripMenuItem.Click += new System.EventHandler(this.lignesDeScoreToolStripMenuItem_Click);
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
            // ScoresForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.ClientSize = new System.Drawing.Size(846, 773);
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
    }
}