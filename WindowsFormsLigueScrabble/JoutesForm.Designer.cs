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
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewJoueurs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewJoutes)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.rechercheParToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 28);
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
            this.dataGridViewJoueurs.Location = new System.Drawing.Point(40, 64);
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
            this.dataGridViewJoutes.Location = new System.Drawing.Point(30, 46);
            this.dataGridViewJoutes.Name = "dataGridViewJoutes";
            this.dataGridViewJoutes.ReadOnly = true;
            this.dataGridViewJoutes.RowHeadersWidth = 51;
            this.dataGridViewJoutes.RowTemplate.Height = 24;
            this.dataGridViewJoutes.Size = new System.Drawing.Size(742, 385);
            this.dataGridViewJoutes.TabIndex = 2;
            // 
            // JoutesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dataGridViewJoutes);
            this.Controls.Add(this.dataGridViewJoueurs);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "JoutesForm";
            this.Text = "JoutesForm";
            this.Load += new System.EventHandler(this.JoutesForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewJoueurs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewJoutes)).EndInit();
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
    }
}