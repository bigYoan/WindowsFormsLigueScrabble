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
            this.labelSessions = new System.Windows.Forms.Label();
            this.buttonTerminer = new System.Windows.Forms.Button();
            this.buttonModifierSession = new System.Windows.Forms.Button();
            this.buttonSupprimerSession = new System.Windows.Forms.Button();
            this.buttonAjouterSession = new System.Windows.Forms.Button();
            this.labelTotalSessions = new System.Windows.Forms.Label();
            this.dataGridViewSessions = new System.Windows.Forms.DataGridView();
            this.groupBoxModifierDetruire = new System.Windows.Forms.GroupBox();
            this.groupBoxTriage = new System.Windows.Forms.GroupBox();
            this.radioButtonFQCSF = new System.Windows.Forms.RadioButton();
            this.radioButtonSessionCroissant = new System.Windows.Forms.RadioButton();
            this.radioButtonSessionDecroissant = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSessions)).BeginInit();
            this.groupBoxModifierDetruire.SuspendLayout();
            this.groupBoxTriage.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelSessions
            // 
            this.labelSessions.AutoSize = true;
            this.labelSessions.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSessions.Location = new System.Drawing.Point(346, 25);
            this.labelSessions.Name = "labelSessions";
            this.labelSessions.Size = new System.Drawing.Size(115, 25);
            this.labelSessions.TabIndex = 1;
            this.labelSessions.Text = "Sessions :";
            // 
            // buttonTerminer
            // 
            this.buttonTerminer.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonTerminer.BackgroundImage")));
            this.buttonTerminer.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonTerminer.FlatAppearance.BorderSize = 0;
            this.buttonTerminer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonTerminer.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonTerminer.Location = new System.Drawing.Point(87, 366);
            this.buttonTerminer.Name = "buttonTerminer";
            this.buttonTerminer.Size = new System.Drawing.Size(147, 52);
            this.buttonTerminer.TabIndex = 9;
            this.buttonTerminer.Text = "Fermer";
            this.buttonTerminer.UseVisualStyleBackColor = true;
            this.buttonTerminer.Click += new System.EventHandler(this.buttonTerminer_Click);
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
            this.buttonModifierSession.Location = new System.Drawing.Point(107, 37);
            this.buttonModifierSession.Name = "buttonModifierSession";
            this.buttonModifierSession.Size = new System.Drawing.Size(45, 44);
            this.buttonModifierSession.TabIndex = 6;
            this.buttonModifierSession.UseVisualStyleBackColor = false;
            this.buttonModifierSession.Click += new System.EventHandler(this.buttonModifierSession_Click);
            this.buttonModifierSession.MouseHover += new System.EventHandler(this.buttonConfirmMouseHover);
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
            this.buttonSupprimerSession.Location = new System.Drawing.Point(189, 37);
            this.buttonSupprimerSession.Name = "buttonSupprimerSession";
            this.buttonSupprimerSession.Size = new System.Drawing.Size(45, 44);
            this.buttonSupprimerSession.TabIndex = 7;
            this.buttonSupprimerSession.Text = "–";
            this.buttonSupprimerSession.UseVisualStyleBackColor = false;
            this.buttonSupprimerSession.Click += new System.EventHandler(this.buttonSupprimerSession_Click);
            this.buttonSupprimerSession.MouseHover += new System.EventHandler(this.buttonConfirmMouseHover);
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
            this.buttonAjouterSession.Location = new System.Drawing.Point(26, 37);
            this.buttonAjouterSession.Name = "buttonAjouterSession";
            this.buttonAjouterSession.Size = new System.Drawing.Size(45, 44);
            this.buttonAjouterSession.TabIndex = 8;
            this.buttonAjouterSession.UseVisualStyleBackColor = false;
            this.buttonAjouterSession.Click += new System.EventHandler(this.buttonAjouterSession_Click);
            this.buttonAjouterSession.MouseHover += new System.EventHandler(this.buttonConfirmMouseHover);
            // 
            // labelTotalSessions
            // 
            this.labelTotalSessions.AutoSize = true;
            this.labelTotalSessions.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTotalSessions.Location = new System.Drawing.Point(877, 26);
            this.labelTotalSessions.Name = "labelTotalSessions";
            this.labelTotalSessions.Size = new System.Drawing.Size(118, 25);
            this.labelTotalSessions.TabIndex = 5;
            this.labelTotalSessions.Text = "rencontre(s)";
            // 
            // dataGridViewSessions
            // 
            this.dataGridViewSessions.BackgroundColor = System.Drawing.Color.DeepSkyBlue;
            this.dataGridViewSessions.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridViewSessions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewSessions.Location = new System.Drawing.Point(334, 63);
            this.dataGridViewSessions.Name = "dataGridViewSessions";
            this.dataGridViewSessions.RowHeadersWidth = 51;
            this.dataGridViewSessions.RowTemplate.Height = 24;
            this.dataGridViewSessions.Size = new System.Drawing.Size(997, 355);
            this.dataGridViewSessions.TabIndex = 11;
            // 
            // groupBoxModifierDetruire
            // 
            this.groupBoxModifierDetruire.BackColor = System.Drawing.Color.Transparent;
            this.groupBoxModifierDetruire.Controls.Add(this.buttonAjouterSession);
            this.groupBoxModifierDetruire.Controls.Add(this.buttonSupprimerSession);
            this.groupBoxModifierDetruire.Controls.Add(this.buttonModifierSession);
            this.groupBoxModifierDetruire.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxModifierDetruire.Location = new System.Drawing.Point(27, 26);
            this.groupBoxModifierDetruire.Name = "groupBoxModifierDetruire";
            this.groupBoxModifierDetruire.Size = new System.Drawing.Size(272, 110);
            this.groupBoxModifierDetruire.TabIndex = 12;
            this.groupBoxModifierDetruire.TabStop = false;
            this.groupBoxModifierDetruire.Text = "Ajouter Modifier Détruire";
            // 
            // groupBoxTriage
            // 
            this.groupBoxTriage.BackColor = System.Drawing.Color.Transparent;
            this.groupBoxTriage.Controls.Add(this.radioButtonFQCSF);
            this.groupBoxTriage.Controls.Add(this.radioButtonSessionCroissant);
            this.groupBoxTriage.Controls.Add(this.radioButtonSessionDecroissant);
            this.groupBoxTriage.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxTriage.Location = new System.Drawing.Point(27, 159);
            this.groupBoxTriage.Name = "groupBoxTriage";
            this.groupBoxTriage.Size = new System.Drawing.Size(272, 170);
            this.groupBoxTriage.TabIndex = 13;
            this.groupBoxTriage.TabStop = false;
            this.groupBoxTriage.Text = "Trier par :";
            // 
            // radioButtonFQCSF
            // 
            this.radioButtonFQCSF.AutoSize = true;
            this.radioButtonFQCSF.Location = new System.Drawing.Point(17, 116);
            this.radioButtonFQCSF.Name = "radioButtonFQCSF";
            this.radioButtonFQCSF.Size = new System.Drawing.Size(203, 29);
            this.radioButtonFQCSF.TabIndex = 0;
            this.radioButtonFQCSF.Text = "Homolog. FQCSF";
            this.radioButtonFQCSF.UseVisualStyleBackColor = true;
            // 
            // radioButtonSessionCroissant
            // 
            this.radioButtonSessionCroissant.AutoSize = true;
            this.radioButtonSessionCroissant.Location = new System.Drawing.Point(17, 81);
            this.radioButtonSessionCroissant.Name = "radioButtonSessionCroissant";
            this.radioButtonSessionCroissant.Size = new System.Drawing.Size(216, 29);
            this.radioButtonSessionCroissant.TabIndex = 0;
            this.radioButtonSessionCroissant.Text = "Date et Heure (^)";
            this.radioButtonSessionCroissant.UseVisualStyleBackColor = true;
            // 
            // radioButtonSessionDecroissant
            // 
            this.radioButtonSessionDecroissant.AutoSize = true;
            this.radioButtonSessionDecroissant.Checked = true;
            this.radioButtonSessionDecroissant.Location = new System.Drawing.Point(17, 46);
            this.radioButtonSessionDecroissant.Name = "radioButtonSessionDecroissant";
            this.radioButtonSessionDecroissant.Size = new System.Drawing.Size(212, 29);
            this.radioButtonSessionDecroissant.TabIndex = 0;
            this.radioButtonSessionDecroissant.TabStop = true;
            this.radioButtonSessionDecroissant.Text = "Date et Heure (v)";
            this.radioButtonSessionDecroissant.UseVisualStyleBackColor = true;
            this.radioButtonSessionDecroissant.CheckedChanged += new System.EventHandler(this.radioButtonAny_CheckedChanged);
            // 
            // RencontreForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.ClientSize = new System.Drawing.Size(1369, 450);
            this.Controls.Add(this.groupBoxModifierDetruire);
            this.Controls.Add(this.dataGridViewSessions);
            this.Controls.Add(this.buttonTerminer);
            this.Controls.Add(this.labelTotalSessions);
            this.Controls.Add(this.labelSessions);
            this.Controls.Add(this.groupBoxTriage);
            this.MaximumSize = new System.Drawing.Size(1387, 497);
            this.MinimumSize = new System.Drawing.Size(1387, 497);
            this.Name = "RencontreForm";
            this.Text = "Rencontres";
            this.Load += new System.EventHandler(this.RencontreForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSessions)).EndInit();
            this.groupBoxModifierDetruire.ResumeLayout(false);
            this.groupBoxTriage.ResumeLayout(false);
            this.groupBoxTriage.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label labelSessions;
        private System.Windows.Forms.Button buttonTerminer;
        private System.Windows.Forms.Button buttonModifierSession;
        private System.Windows.Forms.Button buttonSupprimerSession;
        private System.Windows.Forms.Button buttonAjouterSession;
        private System.Windows.Forms.Label labelTotalSessions;
        private System.Windows.Forms.DataGridView dataGridViewSessions;
        private System.Windows.Forms.GroupBox groupBoxModifierDetruire;
        private System.Windows.Forms.GroupBox groupBoxTriage;
        private System.Windows.Forms.RadioButton radioButtonFQCSF;
        private System.Windows.Forms.RadioButton radioButtonSessionCroissant;
        private System.Windows.Forms.RadioButton radioButtonSessionDecroissant;
    }
}