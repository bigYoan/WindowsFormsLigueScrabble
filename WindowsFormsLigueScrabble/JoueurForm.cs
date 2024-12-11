using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsLigueScrabble
{
    internal partial class JoueurForm : Form
    {
        Controleur controleur;
        public static ToolTip toolTipActionne = new ToolTip();
        Joueur ancienJoueurAModifier = new Joueur();
        Joueur nouveauJoueurAModifier = new Joueur();
        string orderBy = "ORDER BY Nom";
        string erreurDeTextBox = string.Empty;
        Color couleurDepartTextBoxIDCode;



        public JoueurForm(Controleur controleurX)
        {
            InitializeComponent();
            controleur = controleurX;
        }
        private void JoueurForm_Load(object sender, EventArgs e)
        {
            MettreAJourDataGridView();
            radioButtonNom.Checked = true;
        }

        private void buttonAjouterJoueur_Click(object sender, EventArgs e)
        {
            if (ValiderLesTextBox(1))
            {
                string IdCode = textBoxIdCode.Text;
                if (VerifierDuplicationID(IdCode))
                {
                    MessageBox.Show("L'identificateur est déjà utilisé.");
                    AjusterFocusDataGridView(IdCode);
                    return;
                }
                string nom = textBoxNom.Text;
                string pseudo = textBoxPseudo.Text;
                Joueur nouveauJoueur = new Joueur(IdCode, nom, pseudo);
                nouveauJoueur.CacherNom = checkBoxCacherNom.Checked;
                nouveauJoueur.Fqcsf = textBoxNoFqcsf.Text;
                controleur.GererJoueur(nouveauJoueur, controleur.ajouter, orderBy);
                MettreAJourDataGridView();
                AjusterFocusDataGridView(nouveauJoueur.CodeJoueur);
            }
        }

        private void buttonRetirerJoueur_Click(object sender, EventArgs e)
        {
            if (textBoxIdCode.Text.Replace(" ", "").Length == 0)
            {
                MessageBox.Show("Choisir un joueur dans la liste.");
                return;
            }
            Joueur joueurARetirer = new Joueur();
            joueurARetirer.IdJoueur = (int)dataGridViewJoueurs["IDJoueur", dataGridViewJoueurs.CurrentRow.Index].Value;
            joueurARetirer.Nom = dataGridViewJoueurs["Nom", dataGridViewJoueurs.CurrentRow.Index].Value.ToString();
            joueurARetirer.Pseudo = dataGridViewJoueurs["Pseudo", dataGridViewJoueurs.CurrentRow.Index].Value.ToString();

            string rubrique = "Code Joueur : " + joueurARetirer.CodeJoueur + "\nNom : " + joueurARetirer.Nom + " (" + joueurARetirer.Pseudo + ")\n";
            if (controleur.DemandeDeConfirmation(rubrique))
            {
                controleur.GererJoueur(joueurARetirer, controleur.supprimer, orderBy);
                MettreAJourDataGridView();
            }
        }

        private void buttonModifierJoueur_Click(object sender, EventArgs e)
        {
            bool changementOK = ValiderLesTextBox(2);
            if (changementOK) 
            {
                string rubrique = "Modifier ancien : " + ancienJoueurAModifier.Nom + " " + ancienJoueurAModifier.Pseudo+ "\nPar nouveau : " + nouveauJoueurAModifier.Nom + " " + nouveauJoueurAModifier.Pseudo + "\n";
                if (controleur.DemandeDeConfirmation(rubrique))
                {
                    dataGridViewJoueurs.DataSource = null;
                    dataGridViewJoueurs.DataSource = controleur.GererJoueur(nouveauJoueurAModifier, controleur.modifier, orderBy);
                    MettreAJourDataGridView();
                    AjusterFocusDataGridView(nouveauJoueurAModifier.CodeJoueur);
                    ancienJoueurAModifier.Nom = nouveauJoueurAModifier.Nom;
                    ancienJoueurAModifier.Pseudo = nouveauJoueurAModifier.Pseudo;
                }
            }
        }

        private void buttonTerminer_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private bool ValiderLesTextBox(int ordre)
        {
            if (ordre == 1) //Pour ajouter un nouveau joueur
            {
                if (textBoxIdCode.Text.Replace(" ", "").Length == 0)
                {
                    couleurDepartTextBoxIDCode = textBoxIdCode.BackColor;
                    timerDuree.Enabled = true;
                    timerDuree.Start();
                    timerFlash.Enabled = true;
                    timerFlash.Start();
                    MessageBox.Show("Un nouveau code de club est requis.");
                    return false;
                }
                foreach (var joueurDejaInscrit in controleur.joueurs)
                {
                    bool codeJoueurValide = VerifierValiditeCodeJoueur(joueurDejaInscrit);
                    bool pseudoValide = VerifierValiditeDuPseudo(joueurDejaInscrit);
                    bool nomValide = VerifierValiditeDuNom(joueurDejaInscrit);
                    bool noFqcsfValide = VerifierValiditeFqcsf(joueurDejaInscrit);
                    if (!codeJoueurValide || !pseudoValide || !nomValide || !noFqcsfValide)
                    {
                        MessageBox.Show(erreurDeTextBox);
                        return false;
                    }
                }
                return true;
               

            }
            if (ordre == 2) //Pour modifier un nouveau joueur
            {
                if (textBoxIdCode.Text.Replace(" ", "").Length == 0)
                {
                    MessageBox.Show("Choisir un joueur dans la liste.");
                    return false;
                }
                else
                {
                    bool codeJoueurOK = textBoxIdCode.Text == ancienJoueurAModifier.CodeJoueur;
                    bool nomChange = textBoxNom.Text != "" && textBoxNom.Text != ancienJoueurAModifier.Nom;
                    bool pseudoChange = textBoxPseudo.Text != ancienJoueurAModifier.Pseudo;
                    bool pseudoVide = textBoxPseudo.Text.Replace(" ", "").Length == 0; 
                    bool cacherNomChange = checkBoxCacherNom.Checked != ancienJoueurAModifier.CacherNom;
                    bool FqcsfChange = textBoxNoFqcsf.Text != ancienJoueurAModifier.Fqcsf;

                    if (!(codeJoueurOK && (nomChange || pseudoChange || cacherNomChange || FqcsfChange)))
                    {
                        MessageBox.Show("le ID Code ne doit pas être changé ou\nAucun changement apporté.");
                        return false;
                    }

                    foreach (var joueurDejaInscrit in controleur.joueurs)
                    {
                        bool pseudoValide = true;
                        if (pseudoChange) pseudoValide = VerifierValiditeDuPseudo(joueurDejaInscrit);

                        bool nomValide = true;
                        if (nomChange) nomValide = VerifierValiditeDuNom(joueurDejaInscrit);

                        bool noFqcsfValide = true;
                        if (FqcsfChange) noFqcsfValide = VerifierValiditeFqcsf(joueurDejaInscrit);

                        if (!pseudoValide || !nomValide || !noFqcsfValide)
                        {
                            MessageBox.Show(erreurDeTextBox);
                            return false;
                        }
                    }
                    // Tout est validé :
                    nouveauJoueurAModifier.IdJoueur = (int)dataGridViewJoueurs["IdJoueur", dataGridViewJoueurs.CurrentRow.Index].Value;
                    nouveauJoueurAModifier.CodeJoueur = textBoxIdCode.Text;
                    nouveauJoueurAModifier.Nom = textBoxNom.Text;
                    nouveauJoueurAModifier.Pseudo = textBoxPseudo.Text;
                    nouveauJoueurAModifier.CacherNom = checkBoxCacherNom.Checked;
                    nouveauJoueurAModifier.Fqcsf = textBoxNoFqcsf.Text;
                }
            }
            return true;
        }

        private bool VerifierValiditeFqcsf(Joueur joueurDejaInscrit)
        {
            bool memesFqcsf = false;
            int sizeFQ = textBoxNoFqcsf.Text.Replace(" ","").Length;
            if (sizeFQ != 4 && sizeFQ !=0) { erreurDeTextBox = "Le # FQCSF doit être de 4 caractères."; return false; }
            if (textBoxNoFqcsf.Text.Length != 0) memesFqcsf = textBoxNoFqcsf.Text == joueurDejaInscrit.Fqcsf;
            if (memesFqcsf) { erreurDeTextBox = "Le numéro FQCSF est déjà utilisé."; return false; }

            return true;
        }

        private bool VerifierValiditeDuNom(Joueur joueurDejaInscrit)
        {
            bool nomVide = textBoxNom.Text.Length == 0;
            if (nomVide) { erreurDeTextBox = "Il faut un prénom."; return false; }

            bool nomsDifferents = textBoxNom.Text != textBoxPseudo.Text;
            if (!nomsDifferents) { erreurDeTextBox = "Le prénom et le pseudo doivent être différents."; return false; }

            bool nomDejaUtilise = textBoxNom.Text == joueurDejaInscrit.Nom;
            bool pseudoDejaUtilise = textBoxPseudo.Text == joueurDejaInscrit.Pseudo;
            if (nomDejaUtilise && pseudoDejaUtilise) { erreurDeTextBox = "Le prénom et le pseudo sont déjà utilisés.\nIl faut un autre prénom ou pseudo."; return false; }
            

            if (nomDejaUtilise && !pseudoDejaUtilise) { erreurDeTextBox = "Avertissement : le prénom du joueur est utilisé plusieurs fois.\nUtiliser le pseudo pour différencier."; return true; }
            return true;
        }

        private bool VerifierValiditeDuPseudo(Joueur joueurDejaInscrit)
        {
            bool pseudoDejaUtilise = false;
            if (textBoxPseudo.Text.Length != 0) pseudoDejaUtilise = textBoxPseudo.Text == joueurDejaInscrit.Pseudo;
            if (pseudoDejaUtilise) { erreurDeTextBox = "Ce pseudo est déjà utilisé."; return false; }

            bool textesPareils = textBoxPseudo.Text == textBoxNom.Text;
            if (textesPareils) { erreurDeTextBox = "Le prénom et le pseudo doivent être différents."; return false; }

            bool nomCache = checkBoxCacherNom.Checked == true;
            bool pseudoVide = textBoxPseudo.Text.Length == 0;
            if (nomCache && pseudoVide) { erreurDeTextBox = "Il faut un pseudo pour l'option \"Prénom Caché\"."; return false; }
            
            return true;
        }


        private bool VerifierValiditeCodeJoueur(Joueur joueurAVerifier)
        {
            bool codeValide = textBoxIdCode.Text.Length != 0 && textBoxIdCode.Text != joueurAVerifier.CodeJoueur;
            if (!codeValide) 
            { 

                erreurDeTextBox = "Le code de club est déjà utilisé.";
                return false; }
            return true;
        }

        private bool VerifierDuplicationID(string codeJoueur)
        {
            foreach (var joueurAVerifier in controleur.joueurs)
            {
                if (codeJoueur == joueurAVerifier.CodeJoueur) return true;
            }
            return false;
        }

        private void AjusterFocusDataGridView(string idCode)
        {
            int rangee = ChercherRangeeDansDataGridView(idCode);
            dataGridViewJoueurs.ClearSelection();
            dataGridViewJoueurs.CurrentCell = dataGridViewJoueurs.Rows[rangee].Cells[0];
        }

        private int ChercherRangeeDansDataGridView(string idCode)
        {
            int rangeeTrouvee = 0;
            for (int rangee = 0; rangee < dataGridViewJoueurs.Rows.Count; rangee++)
            {
                if (dataGridViewJoueurs["CodeJoueur", rangee].Value.ToString() == idCode) rangeeTrouvee = rangee;
            }
            return rangeeTrouvee;
        }

        private void MettreAJourDataGridView()
        {
            dataGridViewJoueurs.DataSource = null;
            dataGridViewJoueurs.ReadOnly = true;
            dataGridViewJoueurs.DataSource = controleur.joueurs;
            dataGridViewJoueurs.RowHeadersVisible = false;
            dataGridViewJoueurs.Columns["IdJoueur"].Visible = false;
            dataGridViewJoueurs.Columns["noFqcsf"].Visible = false;
            dataGridViewJoueurs.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewJoueurs.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewJoueurs.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewJoueurs.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewJoueurs.Columns["CodeJoueur"].HeaderText = "Code\nClub";
            dataGridViewJoueurs.Columns["Nom"].HeaderText = "Prenom";
            dataGridViewJoueurs.Columns["Pseudo"].HeaderText = "Pseudo\n(ou Nom)";
            dataGridViewJoueurs.Columns["CacherNom"].HeaderText = "Masquer\nprénom";
            dataGridViewJoueurs.Columns["Fqcsf"].HeaderText = "FQCSF";
            dataGridViewJoueurs.ClearSelection();
            labelNombreJoueurs.Text = "Nombre de joueurs : ";
            labelNombreJoueurs.Text += (controleur.joueurs.Count).ToString();
            textBoxIdCode.Text = string.Empty;
            textBoxNom.Text = string.Empty;
            textBoxPseudo.Text = string.Empty;
            checkBoxCacherNom.Checked = false;
            textBoxNoFqcsf.Text = string.Empty;
        }

        private void textBoxIdCode_KeyUp(object sender, KeyEventArgs e)
        {
            TextBox currentContainer = ((TextBox)sender);
            int caretPosition = currentContainer.SelectionStart;
            currentContainer.Text = currentContainer.Text.ToUpper();
            currentContainer.SelectionStart = caretPosition++;
        }

        private void textBoxIdCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            Char pressedKey = e.KeyChar;
            if (Char.IsControl(pressedKey) || (Char.IsLetter(pressedKey)))
            {
                // Caractères alphabet (a - Z) ou de contrôle (BackSpace, par exemple) acceptés.
                e.Handled = false;
            }
            else
                // Empêche le caractère d'être entré.
                e.Handled = true;
        }

        private void dataGridViewJoueurs_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            ancienJoueurAModifier.IdJoueur = (int)dataGridViewJoueurs["IdJoueur", dataGridViewJoueurs.CurrentRow.Index].Value;
            ancienJoueurAModifier.CodeJoueur = dataGridViewJoueurs["CodeJoueur", dataGridViewJoueurs.CurrentRow.Index].Value.ToString();
            ancienJoueurAModifier.Nom = dataGridViewJoueurs["Nom", dataGridViewJoueurs.CurrentRow.Index].Value.ToString();
            ancienJoueurAModifier.Pseudo = dataGridViewJoueurs["Pseudo", dataGridViewJoueurs.CurrentRow.Index].Value.ToString();
            ancienJoueurAModifier.Fqcsf = dataGridViewJoueurs["FQCSF", dataGridViewJoueurs.CurrentRow.Index ].Value.ToString();
            bool cacherNom = (bool)dataGridViewJoueurs["CacherNom", dataGridViewJoueurs.CurrentRow.Index ].Value;
            ancienJoueurAModifier.CacherNom = cacherNom;
            textBoxIdCode.Text = ancienJoueurAModifier.CodeJoueur;
            textBoxNom.Text = ancienJoueurAModifier.Nom;
            textBoxPseudo.Text = ancienJoueurAModifier.Pseudo;
            textBoxNoFqcsf.Text = ancienJoueurAModifier.Fqcsf;
            checkBoxCacherNom.Checked = cacherNom;
            
        }
        private void buttonConfirmMouseHover(object sender, EventArgs e)
        {
            toolTipActionne.SetToolTip(buttonAjouterJoueur, "Ajouter");
            toolTipActionne.SetToolTip(buttonSupprimerJoueur, "Supprimer");
            toolTipActionne.SetToolTip(buttonModifierJoueur, "Modifier");

        }

        private void radioButtonAny_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonIDCode.Checked) orderBy = "ORDER BY ID_Joueur";
            if (radioButtonNom.Checked) orderBy = "ORDER BY Nom";
            if (radioButtonPseudo.Checked) orderBy = "ORDER By Pseudo";
            if (radioButtonFqcsf.Checked) orderBy = "ORDER By FQCSF Desc";
            dataGridViewJoueurs.DataSource = null;
            dataGridViewJoueurs.DataSource = controleur.GererJoueur(null, controleur.lister, orderBy);
            MettreAJourDataGridView();
        }

        private void timerDuree_Tick(object sender, EventArgs e)
        {
            timerFlash.Enabled = false;
            textBoxIdCode.BackColor = couleurDepartTextBoxIDCode;
            timerDuree.Enabled = false;
        }

        private void timerFlash_Tick(object sender, EventArgs e)
        {
            if (textBoxIdCode.BackColor == couleurDepartTextBoxIDCode) textBoxIdCode.BackColor = Color.Red;
            else textBoxIdCode.BackColor = couleurDepartTextBoxIDCode;
        }
    }

}

