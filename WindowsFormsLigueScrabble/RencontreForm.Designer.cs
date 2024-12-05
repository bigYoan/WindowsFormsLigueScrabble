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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RencontreForm));
            this.comboBoxSession = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonTerminer = new System.Windows.Forms.Button();
            this.buttonModifierSession = new System.Windows.Forms.Button();
            this.buttonSupprimerSession = new System.Windows.Forms.Button();
            this.buttonAjouterSession = new System.Windows.Forms.Button();
            this.labelTotalSessions = new System.Windows.Forms.Label();
            this.dateTimePickerNewSession = new System.Windows.Forms.DateTimePicker();
            this.SuspendLayout();
            // 
            // comboBoxSession
            // 
            this.comboBoxSession.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxSession.FormattingEnabled = true;
            this.comboBoxSession.Location = new System.Drawing.Point(67, 63);
            this.comboBoxSession.Name = "comboBoxSession";
            this.comboBoxSession.Size = new System.Drawing.Size(248, 33);
            this.comboBoxSession.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(69, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(231, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "Date des rencontres :";
            // 
            // buttonTerminer
            // 
            this.buttonTerminer.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonTerminer.BackgroundImage")));
            this.buttonTerminer.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonTerminer.FlatAppearance.BorderSize = 0;
            this.buttonTerminer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonTerminer.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonTerminer.Location = new System.Drawing.Point(67, 316);
            this.buttonTerminer.Name = "buttonTerminer";
            this.buttonTerminer.Size = new System.Drawing.Size(147, 52);
            this.buttonTerminer.TabIndex = 9;
            this.buttonTerminer.Text = "Terminé";
            this.buttonTerminer.UseVisualStyleBackColor = true;
            // 
            // buttonModifierSession
            // 
            this.buttonModifierSession.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonModifierSession.BackColor = System.Drawing.Color.Transparent;
            this.buttonModifierSession.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonModifierSession.BackgroundImage")));
            this.buttonModifierSession.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonModifierSession.FlatAppearance.BorderSize = 0;
            this.buttonModifierSession.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonModifierSession.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonModifierSession.Location = new System.Drawing.Point(169, 250);
            this.buttonModifierSession.Name = "buttonModifierSession";
            this.buttonModifierSession.Size = new System.Drawing.Size(45, 44);
            this.buttonModifierSession.TabIndex = 6;
            this.buttonModifierSession.UseVisualStyleBackColor = false;
            // 
            // buttonSupprimerSession
            // 
            this.buttonSupprimerSession.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSupprimerSession.BackColor = System.Drawing.Color.Transparent;
            this.buttonSupprimerSession.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonSupprimerSession.BackgroundImage")));
            this.buttonSupprimerSession.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonSupprimerSession.FlatAppearance.BorderSize = 0;
            this.buttonSupprimerSession.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSupprimerSession.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSupprimerSession.Location = new System.Drawing.Point(118, 251);
            this.buttonSupprimerSession.Name = "buttonSupprimerSession";
            this.buttonSupprimerSession.Size = new System.Drawing.Size(45, 44);
            this.buttonSupprimerSession.TabIndex = 7;
            this.buttonSupprimerSession.Text = "–";
            this.buttonSupprimerSession.UseVisualStyleBackColor = false;
            // 
            // buttonAjouterSession
            // 
            this.buttonAjouterSession.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonAjouterSession.BackColor = System.Drawing.Color.Transparent;
            this.buttonAjouterSession.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonAjouterSession.BackgroundImage")));
            this.buttonAjouterSession.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonAjouterSession.FlatAppearance.BorderSize = 0;
            this.buttonAjouterSession.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAjouterSession.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAjouterSession.Location = new System.Drawing.Point(67, 251);
            this.buttonAjouterSession.Name = "buttonAjouterSession";
            this.buttonAjouterSession.Size = new System.Drawing.Size(45, 44);
            this.buttonAjouterSession.TabIndex = 8;
            this.buttonAjouterSession.UseVisualStyleBackColor = false;
            this.buttonAjouterSession.Click += new System.EventHandler(this.buttonAjouterSession_Click);
            // 
            // labelTotalSessions
            // 
            this.labelTotalSessions.AutoSize = true;
            this.labelTotalSessions.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTotalSessions.Location = new System.Drawing.Point(69, 119);
            this.labelTotalSessions.Name = "labelTotalSessions";
            this.labelTotalSessions.Size = new System.Drawing.Size(118, 25);
            this.labelTotalSessions.TabIndex = 5;
            this.labelTotalSessions.Text = "rencontre(s)";
            // 
            // dateTimePickerNewSession
            // 
            this.dateTimePickerNewSession.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePickerNewSession.Location = new System.Drawing.Point(72, 180);
            this.dateTimePickerNewSession.Name = "dateTimePickerNewSession";
            this.dateTimePickerNewSession.Size = new System.Drawing.Size(242, 32);
            this.dateTimePickerNewSession.TabIndex = 10;
            this.dateTimePickerNewSession.Visible = false;
            // 
            // RencontreForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1176, 450);
            this.Controls.Add(this.dateTimePickerNewSession);
            this.Controls.Add(this.buttonTerminer);
            this.Controls.Add(this.buttonModifierSession);
            this.Controls.Add(this.buttonSupprimerSession);
            this.Controls.Add(this.buttonAjouterSession);
            this.Controls.Add(this.labelTotalSessions);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBoxSession);
            this.Name = "RencontreForm";
            this.Text = "Rencontres";
            this.Load += new System.EventHandler(this.RencontreForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxSession;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonTerminer;
        private System.Windows.Forms.Button buttonModifierSession;
        private System.Windows.Forms.Button buttonSupprimerSession;
        private System.Windows.Forms.Button buttonAjouterSession;
        private System.Windows.Forms.Label labelTotalSessions;
        private System.Windows.Forms.DateTimePicker dateTimePickerNewSession;
    }
}