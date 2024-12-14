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
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewScores)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewScores
            // 
            this.dataGridViewScores.BackgroundColor = System.Drawing.Color.DeepSkyBlue;
            this.dataGridViewScores.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridViewScores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewScores.Location = new System.Drawing.Point(44, 47);
            this.dataGridViewScores.Name = "dataGridViewScores";
            this.dataGridViewScores.RowHeadersWidth = 51;
            this.dataGridViewScores.RowTemplate.Height = 24;
            this.dataGridViewScores.Size = new System.Drawing.Size(1207, 266);
            this.dataGridViewScores.TabIndex = 0;
            // 
            // ScoresForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.ClientSize = new System.Drawing.Size(1294, 440);
            this.Controls.Add(this.dataGridViewScores);
            this.Name = "ScoresForm";
            this.Text = "Ajout/Modification des scores";
            this.Load += new System.EventHandler(this.ScoresForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewScores)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewScores;
    }
}