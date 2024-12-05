namespace WindowsFormsLigueScrabble
{
    partial class RencontreForm
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
            this.comboBoxRencontres = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // comboBoxRencontres
            // 
            this.comboBoxRencontres.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxRencontres.FormattingEnabled = true;
            this.comboBoxRencontres.Location = new System.Drawing.Point(43, 40);
            this.comboBoxRencontres.Name = "comboBoxRencontres";
            this.comboBoxRencontres.Size = new System.Drawing.Size(248, 33);
            this.comboBoxRencontres.TabIndex = 0;
            // 
            // RencontreForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1176, 450);
            this.Controls.Add(this.comboBoxRencontres);
            this.Name = "RencontreForm";
            this.Text = "Rencontres";
            this.Load += new System.EventHandler(this.RencontreForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxRencontres;
    }
}