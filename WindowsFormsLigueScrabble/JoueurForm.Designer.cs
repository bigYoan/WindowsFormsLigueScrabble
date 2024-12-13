namespace WindowsFormsLigueScrabble
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(JoueurForm));
            this.dataGridViewJoueurs = new System.Windows.Forms.DataGridView();
            this.textBoxCodeJoueur = new System.Windows.Forms.TextBox();
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
            this.groupBoxTriage = new System.Windows.Forms.GroupBox();
            this.radioButtonFqcsf = new System.Windows.Forms.RadioButton();
            this.radioButtonPseudo = new System.Windows.Forms.RadioButton();
            this.radioButtonNom = new System.Windows.Forms.RadioButton();
            this.radioButtonCodeJoueur = new System.Windows.Forms.RadioButton();
            this.labelNoFqcfs = new System.Windows.Forms.Label();
            this.checkBoxCacherNom = new System.Windows.Forms.CheckBox();
            this.timerDuree = new System.Windows.Forms.Timer(this.components);
            this.timerFlash = new System.Windows.Forms.Timer(this.components);
            this.textBoxNoFqcsf = new System.Windows.Forms.TextBox();
            this.buttonEffacer = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewJoueurs)).BeginInit();
            this.groupBoxTriage.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridViewJoueurs
            // 
            this.dataGridViewJoueurs.BackgroundColor = System.Drawing.Color.DeepSkyBlue;
            this.dataGridViewJoueurs.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridViewJoueurs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewJoueurs.Location = new System.Drawing.Point(18, 80);
            this.dataGridViewJoueurs.Name = "dataGridViewJoueurs";
            this.dataGridViewJoueurs.RowHeadersWidth = 51;
            this.dataGridViewJoueurs.RowTemplate.Height = 24;
            this.dataGridViewJoueurs.Size = new System.Drawing.Size(529, 275);
            this.dataGridViewJoueurs.TabIndex = 0;
            this.dataGridViewJoueurs.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewJoueurs_CellClick);
            // 
            // textBoxCodeJoueur
            // 
            this.textBoxCodeJoueur.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.textBoxCodeJoueur.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxCodeJoueur.Location = new System.Drawing.Point(22, 38);
            this.textBoxCodeJoueur.MaxLength = 1;
            this.textBoxCodeJoueur.Name = "textBoxCodeJoueur";
            this.textBoxCodeJoueur.Size = new System.Drawing.Size(50, 36);
            this.textBoxCodeJoueur.TabIndex = 1;
            this.textBoxCodeJoueur.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBoxCodeJoueur.TextChanged += new System.EventHandler(this.AnyTextBoxTextChanged);
            this.textBoxCodeJoueur.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxCodeJoueur_KeyPress);
            this.textBoxCodeJoueur.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBoxCodeJoueur_KeyUp);
            // 
            // textBoxNom
            // 
            this.textBoxNom.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.textBoxNom.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxNom.Location = new System.Drawing.Point(95, 38);
            this.textBoxNom.Name = "textBoxNom";
            this.textBoxNom.Size = new System.Drawing.Size(163, 36);
            this.textBoxNom.TabIndex = 1;
            this.textBoxNom.TextChanged += new System.EventHandler(this.AnyTextBoxTextChanged);
            // 
            // textBoxPseudo
            // 
            this.textBoxPseudo.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.textBoxPseudo.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxPseudo.Location = new System.Drawing.Point(338, 38);
            this.textBoxPseudo.Name = "textBoxPseudo";
            this.textBoxPseudo.Size = new System.Drawing.Size(163, 36);
            this.textBoxPseudo.TabIndex = 1;
            // 
            // labelIDCode
            // 
            this.labelIDCode.AutoSize = true;
            this.labelIDCode.Location = new System.Drawing.Point(21, 15);
            this.labelIDCode.Name = "labelIDCode";
            this.labelIDCode.Size = new System.Drawing.Size(46, 16);
            this.labelIDCode.TabIndex = 2;
            this.labelIDCode.Text = "Code :";
            // 
            // labelNom
            // 
            this.labelNom.AutoSize = true;
            this.labelNom.Location = new System.Drawing.Point(96, 15);
            this.labelNom.Name = "labelNom";
            this.labelNom.Size = new System.Drawing.Size(60, 16);
            this.labelNom.TabIndex = 2;
            this.labelNom.Text = "Prénom :";
            // 
            // labelPseudo
            // 
            this.labelPseudo.AutoSize = true;
            this.labelPseudo.Location = new System.Drawing.Point(340, 15);
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
            this.buttonAjouterJoueur.Location = new System.Drawing.Point(641, 34);
            this.buttonAjouterJoueur.Name = "buttonAjouterJoueur";
            this.buttonAjouterJoueur.Size = new System.Drawing.Size(45, 44);
            this.buttonAjouterJoueur.TabIndex = 3;
            this.buttonAjouterJoueur.UseVisualStyleBackColor = false;
            this.buttonAjouterJoueur.Click += new System.EventHandler(this.buttonAjouterJoueur_Click);
            this.buttonAjouterJoueur.MouseHover += new System.EventHandler(this.buttonConfirmMouseHover);
            // 
            // buttonTerminer
            // 
            this.buttonTerminer.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonTerminer.BackgroundImage")));
            this.buttonTerminer.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonTerminer.FlatAppearance.BorderSize = 0;
            this.buttonTerminer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonTerminer.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonTerminer.Location = new System.Drawing.Point(641, 93);
            this.buttonTerminer.Name = "buttonTerminer";
            this.buttonTerminer.Size = new System.Drawing.Size(147, 45);
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
            this.buttonSupprimerJoueur.Location = new System.Drawing.Point(692, 34);
            this.buttonSupprimerJoueur.Name = "buttonSupprimerJoueur";
            this.buttonSupprimerJoueur.Size = new System.Drawing.Size(45, 44);
            this.buttonSupprimerJoueur.TabIndex = 3;
            this.buttonSupprimerJoueur.Text = "–";
            this.buttonSupprimerJoueur.UseVisualStyleBackColor = false;
            this.buttonSupprimerJoueur.Click += new System.EventHandler(this.buttonRetirerJoueur_Click);
            this.buttonSupprimerJoueur.MouseHover += new System.EventHandler(this.buttonConfirmMouseHover);
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
            this.buttonModifierJoueur.Location = new System.Drawing.Point(743, 33);
            this.buttonModifierJoueur.Name = "buttonModifierJoueur";
            this.buttonModifierJoueur.Size = new System.Drawing.Size(45, 44);
            this.buttonModifierJoueur.TabIndex = 3;
            this.buttonModifierJoueur.UseVisualStyleBackColor = false;
            this.buttonModifierJoueur.Click += new System.EventHandler(this.buttonModifierJoueur_Click);
            this.buttonModifierJoueur.MouseHover += new System.EventHandler(this.buttonConfirmMouseHover);
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
            // groupBoxTriage
            // 
            this.groupBoxTriage.BackColor = System.Drawing.Color.Transparent;
            this.groupBoxTriage.Controls.Add(this.radioButtonFqcsf);
            this.groupBoxTriage.Controls.Add(this.radioButtonPseudo);
            this.groupBoxTriage.Controls.Add(this.radioButtonNom);
            this.groupBoxTriage.Controls.Add(this.radioButtonCodeJoueur);
            this.groupBoxTriage.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxTriage.Location = new System.Drawing.Point(574, 198);
            this.groupBoxTriage.Name = "groupBoxTriage";
            this.groupBoxTriage.Size = new System.Drawing.Size(191, 234);
            this.groupBoxTriage.TabIndex = 5;
            this.groupBoxTriage.TabStop = false;
            this.groupBoxTriage.Text = "Trier par ...";
            // 
            // radioButtonFqcsf
            // 
            this.radioButtonFqcsf.AutoSize = true;
            this.radioButtonFqcsf.Location = new System.Drawing.Point(19, 176);
            this.radioButtonFqcsf.Name = "radioButtonFqcsf";
            this.radioButtonFqcsf.Size = new System.Drawing.Size(118, 29);
            this.radioButtonFqcsf.TabIndex = 3;
            this.radioButtonFqcsf.TabStop = true;
            this.radioButtonFqcsf.Text = "# FQCSF";
            this.radioButtonFqcsf.UseVisualStyleBackColor = true;
            this.radioButtonFqcsf.CheckedChanged += new System.EventHandler(this.radioButtonAny_CheckedChanged);
            // 
            // radioButtonPseudo
            // 
            this.radioButtonPseudo.AutoSize = true;
            this.radioButtonPseudo.Location = new System.Drawing.Point(19, 133);
            this.radioButtonPseudo.Name = "radioButtonPseudo";
            this.radioButtonPseudo.Size = new System.Drawing.Size(147, 29);
            this.radioButtonPseudo.TabIndex = 2;
            this.radioButtonPseudo.TabStop = true;
            this.radioButtonPseudo.Text = "Pseudo/Nom";
            this.radioButtonPseudo.UseVisualStyleBackColor = true;
            this.radioButtonPseudo.CheckedChanged += new System.EventHandler(this.radioButtonAny_CheckedChanged);
            // 
            // radioButtonNom
            // 
            this.radioButtonNom.AutoSize = true;
            this.radioButtonNom.Location = new System.Drawing.Point(19, 92);
            this.radioButtonNom.Name = "radioButtonNom";
            this.radioButtonNom.Size = new System.Drawing.Size(101, 29);
            this.radioButtonNom.TabIndex = 1;
            this.radioButtonNom.TabStop = true;
            this.radioButtonNom.Text = "Prénom";
            this.radioButtonNom.UseVisualStyleBackColor = true;
            this.radioButtonNom.CheckedChanged += new System.EventHandler(this.radioButtonAny_CheckedChanged);
            // 
            // radioButtonCodeJoueur
            // 
            this.radioButtonCodeJoueur.AutoSize = true;
            this.radioButtonCodeJoueur.Location = new System.Drawing.Point(19, 48);
            this.radioButtonCodeJoueur.Name = "radioButtonCodeJoueur";
            this.radioButtonCodeJoueur.Size = new System.Drawing.Size(127, 29);
            this.radioButtonCodeJoueur.TabIndex = 0;
            this.radioButtonCodeJoueur.TabStop = true;
            this.radioButtonCodeJoueur.Text = "Code Club";
            this.radioButtonCodeJoueur.UseVisualStyleBackColor = true;
            this.radioButtonCodeJoueur.CheckedChanged += new System.EventHandler(this.radioButtonAny_CheckedChanged);
            // 
            // labelNoFqcfs
            // 
            this.labelNoFqcfs.AutoSize = true;
            this.labelNoFqcfs.Location = new System.Drawing.Point(513, 15);
            this.labelNoFqcfs.Name = "labelNoFqcfs";
            this.labelNoFqcfs.Size = new System.Drawing.Size(64, 16);
            this.labelNoFqcfs.TabIndex = 2;
            this.labelNoFqcfs.Text = "#FQCSF :";
            // 
            // checkBoxCacherNom
            // 
            this.checkBoxCacherNom.AutoSize = true;
            this.checkBoxCacherNom.CheckAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.checkBoxCacherNom.Location = new System.Drawing.Point(268, 11);
            this.checkBoxCacherNom.Name = "checkBoxCacherNom";
            this.checkBoxCacherNom.Size = new System.Drawing.Size(57, 53);
            this.checkBoxCacherNom.TabIndex = 6;
            this.checkBoxCacherNom.Text = "Cacher\r\nprénom";
            this.checkBoxCacherNom.UseVisualStyleBackColor = true;
            // 
            // timerDuree
            // 
            this.timerDuree.Interval = 2000;
            this.timerDuree.Tick += new System.EventHandler(this.timerDuree_Tick);
            // 
            // timerFlash
            // 
            this.timerFlash.Interval = 250;
            this.timerFlash.Tick += new System.EventHandler(this.timerFlash_Tick);
            // 
            // textBoxNoFqcsf
            // 
            this.textBoxNoFqcsf.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.textBoxNoFqcsf.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxNoFqcsf.Location = new System.Drawing.Point(516, 38);
            this.textBoxNoFqcsf.Name = "textBoxNoFqcsf";
            this.textBoxNoFqcsf.Size = new System.Drawing.Size(105, 36);
            this.textBoxNoFqcsf.TabIndex = 7;
            // 
            // buttonEffacer
            // 
            this.buttonEffacer.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonEffacer.BackgroundImage")));
            this.buttonEffacer.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonEffacer.FlatAppearance.BorderSize = 0;
            this.buttonEffacer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonEffacer.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonEffacer.Location = new System.Drawing.Point(641, 144);
            this.buttonEffacer.Name = "buttonEffacer";
            this.buttonEffacer.Size = new System.Drawing.Size(147, 45);
            this.buttonEffacer.TabIndex = 4;
            this.buttonEffacer.Text = "Effacer";
            this.buttonEffacer.UseVisualStyleBackColor = true;
            this.buttonEffacer.Click += new System.EventHandler(this.ButtonEffacer_Click);
            // 
            // JoueurForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.textBoxNoFqcsf);
            this.Controls.Add(this.groupBoxTriage);
            this.Controls.Add(this.buttonEffacer);
            this.Controls.Add(this.buttonTerminer);
            this.Controls.Add(this.buttonModifierJoueur);
            this.Controls.Add(this.buttonSupprimerJoueur);
            this.Controls.Add(this.buttonAjouterJoueur);
            this.Controls.Add(this.labelPseudo);
            this.Controls.Add(this.labelNom);
            this.Controls.Add(this.labelNombreJoueurs);
            this.Controls.Add(this.labelNoFqcfs);
            this.Controls.Add(this.labelIDCode);
            this.Controls.Add(this.textBoxNom);
            this.Controls.Add(this.textBoxPseudo);
            this.Controls.Add(this.textBoxCodeJoueur);
            this.Controls.Add(this.dataGridViewJoueurs);
            this.Controls.Add(this.checkBoxCacherNom);
            this.Name = "JoueurForm";
            this.Text = "Joueurs";
            this.Load += new System.EventHandler(this.JoueurForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewJoueurs)).EndInit();
            this.groupBoxTriage.ResumeLayout(false);
            this.groupBoxTriage.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewJoueurs;
        private System.Windows.Forms.TextBox textBoxCodeJoueur;
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
        private System.Windows.Forms.GroupBox groupBoxTriage;
        private System.Windows.Forms.RadioButton radioButtonPseudo;
        private System.Windows.Forms.RadioButton radioButtonNom;
        private System.Windows.Forms.RadioButton radioButtonCodeJoueur;
        private System.Windows.Forms.Label labelNoFqcfs;
        private System.Windows.Forms.CheckBox checkBoxCacherNom;
        private System.Windows.Forms.Timer timerDuree;
        private System.Windows.Forms.Timer timerFlash;
        private System.Windows.Forms.RadioButton radioButtonFqcsf;
        private System.Windows.Forms.TextBox textBoxNoFqcsf;
        private System.Windows.Forms.Button buttonEffacer;
    }
}