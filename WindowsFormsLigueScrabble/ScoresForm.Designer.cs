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
            this.buttonAnnulerModifs = new System.Windows.Forms.Button();
            this.buttonEnregistrerModifs = new System.Windows.Forms.Button();
            this.buttonQuitter = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewScores)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewScores
            // 
            this.dataGridViewScores.BackgroundColor = System.Drawing.Color.DeepSkyBlue;
            this.dataGridViewScores.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridViewScores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewScores.Location = new System.Drawing.Point(50, 103);
            this.dataGridViewScores.Name = "dataGridViewScores";
            this.dataGridViewScores.RowHeadersWidth = 51;
            this.dataGridViewScores.RowTemplate.Height = 24;
            this.dataGridViewScores.Size = new System.Drawing.Size(737, 551);
            this.dataGridViewScores.TabIndex = 0;
            this.dataGridViewScores.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewScores_CellValueChanged);
            // 
            // buttonAnnulerModifs
            // 
            this.buttonAnnulerModifs.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAnnulerModifs.Location = new System.Drawing.Point(50, 31);
            this.buttonAnnulerModifs.Name = "buttonAnnulerModifs";
            this.buttonAnnulerModifs.Size = new System.Drawing.Size(215, 66);
            this.buttonAnnulerModifs.TabIndex = 1;
            this.buttonAnnulerModifs.Text = "Annuler les modifications";
            this.buttonAnnulerModifs.UseVisualStyleBackColor = true;
            this.buttonAnnulerModifs.Click += new System.EventHandler(this.buttonAnnulerModifs_Click);
            // 
            // buttonEnregistrerModifs
            // 
            this.buttonEnregistrerModifs.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonEnregistrerModifs.Location = new System.Drawing.Point(312, 31);
            this.buttonEnregistrerModifs.Name = "buttonEnregistrerModifs";
            this.buttonEnregistrerModifs.Size = new System.Drawing.Size(215, 66);
            this.buttonEnregistrerModifs.TabIndex = 1;
            this.buttonEnregistrerModifs.Text = "Enregistrer les modifications";
            this.buttonEnregistrerModifs.UseVisualStyleBackColor = true;
            this.buttonEnregistrerModifs.Click += new System.EventHandler(this.buttonEnregistrerModifs_Click);
            // 
            // buttonQuitter
            // 
            this.buttonQuitter.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonQuitter.Location = new System.Drawing.Point(572, 31);
            this.buttonQuitter.Name = "buttonQuitter";
            this.buttonQuitter.Size = new System.Drawing.Size(215, 66);
            this.buttonQuitter.TabIndex = 1;
            this.buttonQuitter.Text = "Fermer";
            this.buttonQuitter.UseVisualStyleBackColor = true;
            this.buttonQuitter.Click += new System.EventHandler(this.buttonQuitter_Click);
            // 
            // ScoresForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.ClientSize = new System.Drawing.Size(846, 692);
            this.Controls.Add(this.buttonQuitter);
            this.Controls.Add(this.buttonEnregistrerModifs);
            this.Controls.Add(this.buttonAnnulerModifs);
            this.Controls.Add(this.dataGridViewScores);
            this.Name = "ScoresForm";
            this.Text = "Ajout/Modification des scores";
            this.Load += new System.EventHandler(this.ScoresForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewScores)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewScores;
        private System.Windows.Forms.Button buttonAnnulerModifs;
        private System.Windows.Forms.Button buttonEnregistrerModifs;
        private System.Windows.Forms.Button buttonQuitter;
    }
}