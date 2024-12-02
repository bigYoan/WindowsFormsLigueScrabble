namespace WindowsFormsLigueScrabble
{
    partial class AjoutJoueurForm
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
            this.dataGridViewAjoutJoueur = new System.Windows.Forms.DataGridView();
            this.textBoxIdCode = new System.Windows.Forms.TextBox();
            this.textBoxNom = new System.Windows.Forms.TextBox();
            this.textBoxPseudo = new System.Windows.Forms.TextBox();
            this.labelIDCode = new System.Windows.Forms.Label();
            this.labelNom = new System.Windows.Forms.Label();
            this.labelPseudo = new System.Windows.Forms.Label();
            this.buttonAjouterJoueur = new System.Windows.Forms.Button();
            this.buttonTerminer = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAjoutJoueur)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewAjoutJoueur
            // 
            this.dataGridViewAjoutJoueur.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewAjoutJoueur.Location = new System.Drawing.Point(37, 134);
            this.dataGridViewAjoutJoueur.Name = "dataGridViewAjoutJoueur";
            this.dataGridViewAjoutJoueur.RowHeadersWidth = 51;
            this.dataGridViewAjoutJoueur.RowTemplate.Height = 24;
            this.dataGridViewAjoutJoueur.Size = new System.Drawing.Size(709, 284);
            this.dataGridViewAjoutJoueur.TabIndex = 0;
            // 
            // textBoxIdCode
            // 
            this.textBoxIdCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxIdCode.Location = new System.Drawing.Point(44, 38);
            this.textBoxIdCode.Name = "textBoxIdCode";
            this.textBoxIdCode.Size = new System.Drawing.Size(163, 30);
            this.textBoxIdCode.TabIndex = 1;
            this.textBoxIdCode.TextChanged += new System.EventHandler(this.textBoxIdCode_TextChanged);
            // 
            // textBoxNom
            // 
            this.textBoxNom.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxNom.Location = new System.Drawing.Point(229, 38);
            this.textBoxNom.Name = "textBoxNom";
            this.textBoxNom.Size = new System.Drawing.Size(163, 30);
            this.textBoxNom.TabIndex = 1;
            // 
            // textBoxPseudo
            // 
            this.textBoxPseudo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxPseudo.Location = new System.Drawing.Point(413, 38);
            this.textBoxPseudo.Name = "textBoxPseudo";
            this.textBoxPseudo.Size = new System.Drawing.Size(163, 30);
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
            this.labelNom.Location = new System.Drawing.Point(226, 15);
            this.labelNom.Name = "labelNom";
            this.labelNom.Size = new System.Drawing.Size(42, 16);
            this.labelNom.TabIndex = 2;
            this.labelNom.Text = "Nom :";
            // 
            // labelPseudo
            // 
            this.labelPseudo.AutoSize = true;
            this.labelPseudo.Location = new System.Drawing.Point(410, 15);
            this.labelPseudo.Name = "labelPseudo";
            this.labelPseudo.Size = new System.Drawing.Size(42, 16);
            this.labelPseudo.TabIndex = 2;
            this.labelPseudo.Text = "Nom :";
            // 
            // buttonAjouterJoueur
            // 
            this.buttonAjouterJoueur.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonAjouterJoueur.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAjouterJoueur.Location = new System.Drawing.Point(618, 31);
            this.buttonAjouterJoueur.Name = "buttonAjouterJoueur";
            this.buttonAjouterJoueur.Size = new System.Drawing.Size(45, 44);
            this.buttonAjouterJoueur.TabIndex = 3;
            this.buttonAjouterJoueur.Text = "+";
            this.buttonAjouterJoueur.UseVisualStyleBackColor = true;
            this.buttonAjouterJoueur.Click += new System.EventHandler(this.buttonAjouterJoueur_Click);
            // 
            // buttonTerminer
            // 
            this.buttonTerminer.Location = new System.Drawing.Point(690, 31);
            this.buttonTerminer.Name = "buttonTerminer";
            this.buttonTerminer.Size = new System.Drawing.Size(90, 43);
            this.buttonTerminer.TabIndex = 4;
            this.buttonTerminer.Text = "Terminé";
            this.buttonTerminer.UseVisualStyleBackColor = true;
            this.buttonTerminer.Click += new System.EventHandler(this.buttonTerminer_Click);
            // 
            // AjoutJoueurForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.buttonTerminer);
            this.Controls.Add(this.buttonAjouterJoueur);
            this.Controls.Add(this.labelPseudo);
            this.Controls.Add(this.labelNom);
            this.Controls.Add(this.labelIDCode);
            this.Controls.Add(this.textBoxNom);
            this.Controls.Add(this.textBoxPseudo);
            this.Controls.Add(this.textBoxIdCode);
            this.Controls.Add(this.dataGridViewAjoutJoueur);
            this.Name = "AjoutJoueurForm";
            this.Text = "AjoutJoueurForm";
            this.Load += new System.EventHandler(this.AjoutJoueurForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAjoutJoueur)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewAjoutJoueur;
        private System.Windows.Forms.TextBox textBoxIdCode;
        private System.Windows.Forms.TextBox textBoxNom;
        private System.Windows.Forms.TextBox textBoxPseudo;
        private System.Windows.Forms.Label labelIDCode;
        private System.Windows.Forms.Label labelNom;
        private System.Windows.Forms.Label labelPseudo;
        private System.Windows.Forms.Button buttonAjouterJoueur;
        private System.Windows.Forms.Button buttonTerminer;
    }
}