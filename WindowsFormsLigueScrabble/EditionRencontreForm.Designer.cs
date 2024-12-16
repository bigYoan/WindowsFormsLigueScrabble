namespace WindowsFormsLigueScrabble
{
    partial class EditionRencontreForm
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
            this.labelDateSession = new System.Windows.Forms.Label();
            this.labelJoueur1 = new System.Windows.Forms.Label();
            this.labelJoueur2 = new System.Windows.Forms.Label();
            this.labelJoueur3 = new System.Windows.Forms.Label();
            this.labelPupitre = new System.Windows.Forms.Label();
            this.labelRonde = new System.Windows.Forms.Label();
            this.labelHeure = new System.Windows.Forms.Label();
            this.labelJoueur4 = new System.Windows.Forms.Label();
            this.panelPupitre = new System.Windows.Forms.Panel();
            this.labelTablePanel = new System.Windows.Forms.Label();
            this.labelPlayer1 = new System.Windows.Forms.Label();
            this.labelPlayer3 = new System.Windows.Forms.Label();
            this.labelPlayer2 = new System.Windows.Forms.Label();
            this.labelPlayer4 = new System.Windows.Forms.Label();
            this.labelPlace2 = new System.Windows.Forms.Label();
            this.labelPlace4 = new System.Windows.Forms.Label();
            this.labelPlace3 = new System.Windows.Forms.Label();
            this.labelPlace1 = new System.Windows.Forms.Label();
            this.buttonConfirmerAjout = new System.Windows.Forms.Button();
            this.buttonEffacer = new System.Windows.Forms.Button();
            this.buttonQuitter = new System.Windows.Forms.Button();
            this.dateTimePickerNewSession = new System.Windows.Forms.DateTimePicker();
            this.comboBoxHeure = new System.Windows.Forms.ComboBox();
            this.comboBoxRonde = new System.Windows.Forms.ComboBox();
            this.comboBoxPupitre = new System.Windows.Forms.ComboBox();
            this.comboBoxJoueur1 = new System.Windows.Forms.ComboBox();
            this.comboBoxJoueur3 = new System.Windows.Forms.ComboBox();
            this.comboBoxJoueur4 = new System.Windows.Forms.ComboBox();
            this.comboBoxJoueur2 = new System.Windows.Forms.ComboBox();
            this.buttonQuitterTout = new System.Windows.Forms.Button();
            this.labelSession = new System.Windows.Forms.Label();
            this.dataGridViewRencontres = new System.Windows.Forms.DataGridView();
            this.panelPupitre.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewRencontres)).BeginInit();
            this.SuspendLayout();
            // 
            // labelDateSession
            // 
            this.labelDateSession.AutoSize = true;
            this.labelDateSession.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDateSession.Location = new System.Drawing.Point(44, 263);
            this.labelDateSession.Name = "labelDateSession";
            this.labelDateSession.Size = new System.Drawing.Size(75, 25);
            this.labelDateSession.TabIndex = 1;
            this.labelDateSession.Text = "Date :";
            // 
            // labelJoueur1
            // 
            this.labelJoueur1.AutoSize = true;
            this.labelJoueur1.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelJoueur1.Location = new System.Drawing.Point(44, 441);
            this.labelJoueur1.Name = "labelJoueur1";
            this.labelJoueur1.Size = new System.Drawing.Size(134, 25);
            this.labelJoueur1.TabIndex = 3;
            this.labelJoueur1.Text = "Joueur (1) :";
            // 
            // labelJoueur2
            // 
            this.labelJoueur2.AutoSize = true;
            this.labelJoueur2.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelJoueur2.Location = new System.Drawing.Point(479, 441);
            this.labelJoueur2.Name = "labelJoueur2";
            this.labelJoueur2.Size = new System.Drawing.Size(134, 25);
            this.labelJoueur2.TabIndex = 5;
            this.labelJoueur2.Text = "Joueur (2) :";
            // 
            // labelJoueur3
            // 
            this.labelJoueur3.AutoSize = true;
            this.labelJoueur3.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelJoueur3.Location = new System.Drawing.Point(44, 490);
            this.labelJoueur3.Name = "labelJoueur3";
            this.labelJoueur3.Size = new System.Drawing.Size(134, 25);
            this.labelJoueur3.TabIndex = 7;
            this.labelJoueur3.Text = "Joueur (3) :";
            // 
            // labelPupitre
            // 
            this.labelPupitre.AutoSize = true;
            this.labelPupitre.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPupitre.Location = new System.Drawing.Point(44, 338);
            this.labelPupitre.Name = "labelPupitre";
            this.labelPupitre.Size = new System.Drawing.Size(175, 25);
            this.labelPupitre.TabIndex = 9;
            this.labelPupitre.Text = "Pupitre (table) :";
            // 
            // labelRonde
            // 
            this.labelRonde.AutoSize = true;
            this.labelRonde.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelRonde.Location = new System.Drawing.Point(44, 378);
            this.labelRonde.Name = "labelRonde";
            this.labelRonde.Size = new System.Drawing.Size(207, 25);
            this.labelRonde.TabIndex = 11;
            this.labelRonde.Text = "Ronde (no partie) :";
            // 
            // labelHeure
            // 
            this.labelHeure.AutoSize = true;
            this.labelHeure.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelHeure.Location = new System.Drawing.Point(44, 301);
            this.labelHeure.Name = "labelHeure";
            this.labelHeure.Size = new System.Drawing.Size(89, 25);
            this.labelHeure.TabIndex = 13;
            this.labelHeure.Text = "Heure :";
            // 
            // labelJoueur4
            // 
            this.labelJoueur4.AutoSize = true;
            this.labelJoueur4.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelJoueur4.Location = new System.Drawing.Point(479, 490);
            this.labelJoueur4.Name = "labelJoueur4";
            this.labelJoueur4.Size = new System.Drawing.Size(134, 25);
            this.labelJoueur4.TabIndex = 15;
            this.labelJoueur4.Text = "Joueur (4) :";
            // 
            // panelPupitre
            // 
            this.panelPupitre.BackColor = System.Drawing.Color.Maroon;
            this.panelPupitre.Controls.Add(this.labelTablePanel);
            this.panelPupitre.Location = new System.Drawing.Point(551, 257);
            this.panelPupitre.Name = "panelPupitre";
            this.panelPupitre.Size = new System.Drawing.Size(303, 100);
            this.panelPupitre.TabIndex = 16;
            // 
            // labelTablePanel
            // 
            this.labelTablePanel.AutoSize = true;
            this.labelTablePanel.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTablePanel.ForeColor = System.Drawing.Color.SeaShell;
            this.labelTablePanel.Location = new System.Drawing.Point(98, 42);
            this.labelTablePanel.Name = "labelTablePanel";
            this.labelTablePanel.Size = new System.Drawing.Size(74, 20);
            this.labelTablePanel.TabIndex = 17;
            this.labelTablePanel.Text = "Table :";
            // 
            // labelPlayer1
            // 
            this.labelPlayer1.AutoSize = true;
            this.labelPlayer1.BackColor = System.Drawing.Color.Maroon;
            this.labelPlayer1.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPlayer1.ForeColor = System.Drawing.Color.SeaShell;
            this.labelPlayer1.Location = new System.Drawing.Point(583, 260);
            this.labelPlayer1.Name = "labelPlayer1";
            this.labelPlayer1.Size = new System.Drawing.Size(95, 20);
            this.labelPlayer1.TabIndex = 17;
            this.labelPlayer1.Text = "(Place 1)";
            // 
            // labelPlayer3
            // 
            this.labelPlayer3.AutoSize = true;
            this.labelPlayer3.BackColor = System.Drawing.Color.Maroon;
            this.labelPlayer3.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPlayer3.ForeColor = System.Drawing.Color.SeaShell;
            this.labelPlayer3.Location = new System.Drawing.Point(583, 335);
            this.labelPlayer3.Name = "labelPlayer3";
            this.labelPlayer3.Size = new System.Drawing.Size(95, 20);
            this.labelPlayer3.TabIndex = 17;
            this.labelPlayer3.Text = "(Place 3)";
            // 
            // labelPlayer2
            // 
            this.labelPlayer2.AutoSize = true;
            this.labelPlayer2.BackColor = System.Drawing.Color.Maroon;
            this.labelPlayer2.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPlayer2.ForeColor = System.Drawing.Color.SeaShell;
            this.labelPlayer2.Location = new System.Drawing.Point(728, 260);
            this.labelPlayer2.Name = "labelPlayer2";
            this.labelPlayer2.Size = new System.Drawing.Size(95, 20);
            this.labelPlayer2.TabIndex = 17;
            this.labelPlayer2.Text = "(Place 2)";
            // 
            // labelPlayer4
            // 
            this.labelPlayer4.AutoSize = true;
            this.labelPlayer4.BackColor = System.Drawing.Color.Maroon;
            this.labelPlayer4.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPlayer4.ForeColor = System.Drawing.Color.SeaShell;
            this.labelPlayer4.Location = new System.Drawing.Point(728, 335);
            this.labelPlayer4.Name = "labelPlayer4";
            this.labelPlayer4.Size = new System.Drawing.Size(95, 20);
            this.labelPlayer4.TabIndex = 17;
            this.labelPlayer4.Text = "(Place 4)";
            // 
            // labelPlace2
            // 
            this.labelPlace2.AutoSize = true;
            this.labelPlace2.BackColor = System.Drawing.Color.IndianRed;
            this.labelPlace2.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPlace2.ForeColor = System.Drawing.Color.Yellow;
            this.labelPlace2.Location = new System.Drawing.Point(741, 227);
            this.labelPlace2.Name = "labelPlace2";
            this.labelPlace2.Size = new System.Drawing.Size(0, 20);
            this.labelPlace2.TabIndex = 18;
            // 
            // labelPlace4
            // 
            this.labelPlace4.AutoSize = true;
            this.labelPlace4.BackColor = System.Drawing.Color.IndianRed;
            this.labelPlace4.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPlace4.ForeColor = System.Drawing.Color.Yellow;
            this.labelPlace4.Location = new System.Drawing.Point(741, 370);
            this.labelPlace4.Name = "labelPlace4";
            this.labelPlace4.Size = new System.Drawing.Size(0, 20);
            this.labelPlace4.TabIndex = 19;
            // 
            // labelPlace3
            // 
            this.labelPlace3.AutoSize = true;
            this.labelPlace3.BackColor = System.Drawing.Color.IndianRed;
            this.labelPlace3.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPlace3.ForeColor = System.Drawing.Color.Yellow;
            this.labelPlace3.Location = new System.Drawing.Point(568, 367);
            this.labelPlace3.Name = "labelPlace3";
            this.labelPlace3.Size = new System.Drawing.Size(0, 20);
            this.labelPlace3.TabIndex = 20;
            // 
            // labelPlace1
            // 
            this.labelPlace1.AutoSize = true;
            this.labelPlace1.BackColor = System.Drawing.Color.IndianRed;
            this.labelPlace1.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPlace1.ForeColor = System.Drawing.Color.Yellow;
            this.labelPlace1.Location = new System.Drawing.Point(568, 227);
            this.labelPlace1.Name = "labelPlace1";
            this.labelPlace1.Size = new System.Drawing.Size(0, 20);
            this.labelPlace1.TabIndex = 21;
            // 
            // buttonConfirmerAjout
            // 
            this.buttonConfirmerAjout.BackColor = System.Drawing.Color.Yellow;
            this.buttonConfirmerAjout.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonConfirmerAjout.Location = new System.Drawing.Point(34, 544);
            this.buttonConfirmerAjout.Name = "buttonConfirmerAjout";
            this.buttonConfirmerAjout.Size = new System.Drawing.Size(185, 48);
            this.buttonConfirmerAjout.TabIndex = 22;
            this.buttonConfirmerAjout.Text = "Confirmer";
            this.buttonConfirmerAjout.UseVisualStyleBackColor = false;
            this.buttonConfirmerAjout.Click += new System.EventHandler(this.buttonConfirmerAjout_Click);
            // 
            // buttonEffacer
            // 
            this.buttonEffacer.BackColor = System.Drawing.Color.Lime;
            this.buttonEffacer.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonEffacer.Location = new System.Drawing.Point(256, 544);
            this.buttonEffacer.Name = "buttonEffacer";
            this.buttonEffacer.Size = new System.Drawing.Size(185, 48);
            this.buttonEffacer.TabIndex = 22;
            this.buttonEffacer.Text = "Recommencer";
            this.buttonEffacer.UseVisualStyleBackColor = false;
            this.buttonEffacer.Click += new System.EventHandler(this.buttonEffacer_Click);
            // 
            // buttonQuitter
            // 
            this.buttonQuitter.BackColor = System.Drawing.Color.Red;
            this.buttonQuitter.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonQuitter.Location = new System.Drawing.Point(479, 544);
            this.buttonQuitter.Name = "buttonQuitter";
            this.buttonQuitter.Size = new System.Drawing.Size(185, 48);
            this.buttonQuitter.TabIndex = 22;
            this.buttonQuitter.Text = "Fermer";
            this.buttonQuitter.UseVisualStyleBackColor = false;
            this.buttonQuitter.Click += new System.EventHandler(this.buttonFermer_Click);
            // 
            // dateTimePickerNewSession
            // 
            this.dateTimePickerNewSession.CalendarFont = new System.Drawing.Font("Verdana", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePickerNewSession.CalendarMonthBackground = System.Drawing.SystemColors.Info;
            this.dateTimePickerNewSession.CalendarTitleBackColor = System.Drawing.Color.Aquamarine;
            this.dateTimePickerNewSession.CustomFormat = "dd MMM";
            this.dateTimePickerNewSession.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePickerNewSession.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerNewSession.Location = new System.Drawing.Point(260, 260);
            this.dateTimePickerNewSession.Name = "dateTimePickerNewSession";
            this.dateTimePickerNewSession.Size = new System.Drawing.Size(133, 32);
            this.dateTimePickerNewSession.TabIndex = 23;
            this.dateTimePickerNewSession.Value = new System.DateTime(2024, 11, 1, 0, 0, 0, 0);
            // 
            // comboBoxHeure
            // 
            this.comboBoxHeure.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxHeure.FormattingEnabled = true;
            this.comboBoxHeure.Items.AddRange(new object[] {
            "20h",
            "19h",
            "18h",
            "15h",
            "14h",
            "13h"});
            this.comboBoxHeure.Location = new System.Drawing.Point(260, 298);
            this.comboBoxHeure.Name = "comboBoxHeure";
            this.comboBoxHeure.Size = new System.Drawing.Size(59, 33);
            this.comboBoxHeure.TabIndex = 24;
            // 
            // comboBoxRonde
            // 
            this.comboBoxRonde.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxRonde.FormattingEnabled = true;
            this.comboBoxRonde.Items.AddRange(new object[] {
            "1",
            "2",
            "3"});
            this.comboBoxRonde.Location = new System.Drawing.Point(260, 375);
            this.comboBoxRonde.Name = "comboBoxRonde";
            this.comboBoxRonde.Size = new System.Drawing.Size(59, 33);
            this.comboBoxRonde.TabIndex = 25;
            // 
            // comboBoxPupitre
            // 
            this.comboBoxPupitre.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxPupitre.FormattingEnabled = true;
            this.comboBoxPupitre.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8"});
            this.comboBoxPupitre.Location = new System.Drawing.Point(260, 335);
            this.comboBoxPupitre.Name = "comboBoxPupitre";
            this.comboBoxPupitre.Size = new System.Drawing.Size(59, 33);
            this.comboBoxPupitre.TabIndex = 26;
            // 
            // comboBoxJoueur1
            // 
            this.comboBoxJoueur1.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxJoueur1.FormattingEnabled = true;
            this.comboBoxJoueur1.Items.AddRange(new object[] {
            "20h",
            "19h",
            "18h",
            "15h",
            "14h",
            "13h"});
            this.comboBoxJoueur1.Location = new System.Drawing.Point(196, 438);
            this.comboBoxJoueur1.Name = "comboBoxJoueur1";
            this.comboBoxJoueur1.Size = new System.Drawing.Size(227, 33);
            this.comboBoxJoueur1.TabIndex = 27;
            this.comboBoxJoueur1.SelectionChangeCommitted += new System.EventHandler(this.AnyComboBoxJoueur_SelectionChangeCommitted);
            // 
            // comboBoxJoueur3
            // 
            this.comboBoxJoueur3.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxJoueur3.FormattingEnabled = true;
            this.comboBoxJoueur3.Items.AddRange(new object[] {
            "20h",
            "19h",
            "18h",
            "15h",
            "14h",
            "13h"});
            this.comboBoxJoueur3.Location = new System.Drawing.Point(196, 487);
            this.comboBoxJoueur3.Name = "comboBoxJoueur3";
            this.comboBoxJoueur3.Size = new System.Drawing.Size(227, 33);
            this.comboBoxJoueur3.TabIndex = 28;
            this.comboBoxJoueur3.SelectionChangeCommitted += new System.EventHandler(this.AnyComboBoxJoueur_SelectionChangeCommitted);
            // 
            // comboBoxJoueur4
            // 
            this.comboBoxJoueur4.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxJoueur4.FormattingEnabled = true;
            this.comboBoxJoueur4.Items.AddRange(new object[] {
            "20h",
            "19h",
            "18h",
            "15h",
            "14h",
            "13h"});
            this.comboBoxJoueur4.Location = new System.Drawing.Point(644, 487);
            this.comboBoxJoueur4.Name = "comboBoxJoueur4";
            this.comboBoxJoueur4.Size = new System.Drawing.Size(227, 33);
            this.comboBoxJoueur4.TabIndex = 30;
            this.comboBoxJoueur4.SelectionChangeCommitted += new System.EventHandler(this.AnyComboBoxJoueur_SelectionChangeCommitted);
            // 
            // comboBoxJoueur2
            // 
            this.comboBoxJoueur2.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxJoueur2.FormattingEnabled = true;
            this.comboBoxJoueur2.Items.AddRange(new object[] {
            "20h",
            "19h",
            "18h",
            "15h",
            "14h",
            "13h"});
            this.comboBoxJoueur2.Location = new System.Drawing.Point(644, 438);
            this.comboBoxJoueur2.Name = "comboBoxJoueur2";
            this.comboBoxJoueur2.Size = new System.Drawing.Size(227, 33);
            this.comboBoxJoueur2.TabIndex = 29;
            this.comboBoxJoueur2.SelectionChangeCommitted += new System.EventHandler(this.AnyComboBoxJoueur_SelectionChangeCommitted);
            // 
            // buttonQuitterTout
            // 
            this.buttonQuitterTout.BackColor = System.Drawing.Color.DarkRed;
            this.buttonQuitterTout.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonQuitterTout.ForeColor = System.Drawing.Color.Yellow;
            this.buttonQuitterTout.Location = new System.Drawing.Point(699, 544);
            this.buttonQuitterTout.Name = "buttonQuitterTout";
            this.buttonQuitterTout.Size = new System.Drawing.Size(185, 48);
            this.buttonQuitterTout.TabIndex = 22;
            this.buttonQuitterTout.Text = "Quitter";
            this.buttonQuitterTout.UseVisualStyleBackColor = false;
            this.buttonQuitterTout.Click += new System.EventHandler(this.buttonQuitter_Click);
            // 
            // labelSession
            // 
            this.labelSession.AutoSize = true;
            this.labelSession.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSession.Location = new System.Drawing.Point(255, 227);
            this.labelSession.Name = "labelSession";
            this.labelSession.Size = new System.Drawing.Size(89, 25);
            this.labelSession.TabIndex = 1;
            this.labelSession.Text = "Session";
            // 
            // dataGridViewRencontres
            // 
            this.dataGridViewRencontres.BackgroundColor = System.Drawing.Color.IndianRed;
            this.dataGridViewRencontres.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridViewRencontres.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewRencontres.Location = new System.Drawing.Point(26, 12);
            this.dataGridViewRencontres.Name = "dataGridViewRencontres";
            this.dataGridViewRencontres.RowHeadersWidth = 51;
            this.dataGridViewRencontres.RowTemplate.Height = 24;
            this.dataGridViewRencontres.Size = new System.Drawing.Size(885, 190);
            this.dataGridViewRencontres.TabIndex = 31;
            // 
            // EditionRencontreForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.BackColor = System.Drawing.Color.IndianRed;
            this.ClientSize = new System.Drawing.Size(925, 622);
            this.Controls.Add(this.dataGridViewRencontres);
            this.Controls.Add(this.comboBoxJoueur4);
            this.Controls.Add(this.comboBoxJoueur2);
            this.Controls.Add(this.comboBoxJoueur3);
            this.Controls.Add(this.comboBoxJoueur1);
            this.Controls.Add(this.comboBoxPupitre);
            this.Controls.Add(this.comboBoxRonde);
            this.Controls.Add(this.comboBoxHeure);
            this.Controls.Add(this.dateTimePickerNewSession);
            this.Controls.Add(this.buttonQuitterTout);
            this.Controls.Add(this.buttonQuitter);
            this.Controls.Add(this.buttonEffacer);
            this.Controls.Add(this.buttonConfirmerAjout);
            this.Controls.Add(this.labelPlace2);
            this.Controls.Add(this.labelPlace4);
            this.Controls.Add(this.labelPlace3);
            this.Controls.Add(this.labelPlace1);
            this.Controls.Add(this.labelPlayer2);
            this.Controls.Add(this.labelPlayer4);
            this.Controls.Add(this.labelPlayer3);
            this.Controls.Add(this.labelPlayer1);
            this.Controls.Add(this.panelPupitre);
            this.Controls.Add(this.labelJoueur4);
            this.Controls.Add(this.labelHeure);
            this.Controls.Add(this.labelRonde);
            this.Controls.Add(this.labelPupitre);
            this.Controls.Add(this.labelJoueur3);
            this.Controls.Add(this.labelJoueur2);
            this.Controls.Add(this.labelJoueur1);
            this.Controls.Add(this.labelSession);
            this.Controls.Add(this.labelDateSession);
            this.Name = "EditionRencontreForm";
            this.Text = "Edition/Modification Rencontres";
            this.Load += new System.EventHandler(this.EditionRencontreForm_Load);
            this.panelPupitre.ResumeLayout(false);
            this.panelPupitre.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewRencontres)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label labelDateSession;
        private System.Windows.Forms.Label labelJoueur1;
        private System.Windows.Forms.Label labelJoueur2;
        private System.Windows.Forms.Label labelJoueur3;
        private System.Windows.Forms.Label labelPupitre;
        private System.Windows.Forms.Label labelRonde;
        private System.Windows.Forms.Label labelHeure;
        private System.Windows.Forms.Label labelJoueur4;
        private System.Windows.Forms.Panel panelPupitre;
        private System.Windows.Forms.Label labelPlayer1;
        private System.Windows.Forms.Label labelTablePanel;
        private System.Windows.Forms.Label labelPlayer3;
        private System.Windows.Forms.Label labelPlayer2;
        private System.Windows.Forms.Label labelPlayer4;
        private System.Windows.Forms.Label labelPlace2;
        private System.Windows.Forms.Label labelPlace4;
        private System.Windows.Forms.Label labelPlace3;
        private System.Windows.Forms.Label labelPlace1;
        private System.Windows.Forms.Button buttonConfirmerAjout;
        private System.Windows.Forms.Button buttonEffacer;
        private System.Windows.Forms.Button buttonQuitter;
        private System.Windows.Forms.DateTimePicker dateTimePickerNewSession;
        private System.Windows.Forms.ComboBox comboBoxHeure;
        private System.Windows.Forms.ComboBox comboBoxRonde;
        private System.Windows.Forms.ComboBox comboBoxPupitre;
        private System.Windows.Forms.ComboBox comboBoxJoueur1;
        private System.Windows.Forms.ComboBox comboBoxJoueur3;
        private System.Windows.Forms.ComboBox comboBoxJoueur4;
        private System.Windows.Forms.ComboBox comboBoxJoueur2;
        private System.Windows.Forms.Button buttonQuitterTout;
        private System.Windows.Forms.Label labelSession;
        private System.Windows.Forms.DataGridView dataGridViewRencontres;
    }
}