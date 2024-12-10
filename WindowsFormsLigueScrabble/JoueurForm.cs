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
                if (textBoxIdCode.Text.Length == 0 || textBoxNom.Text.Length == 0)
                {
                    MessageBox.Show("ID code et Nom invalides");
                    return false;
                }
                foreach (var joueurDejaInscrit in controleur.joueurs)
                {
                    if ((joueurDejaInscrit.Nom == textBoxNom.Text && joueurDejaInscrit.Pseudo.Length == 0) || (joueurDejaInscrit.Pseudo.Length != 0 && joueurDejaInscrit.Pseudo == textBoxPseudo.Text))
                    {
                        MessageBox.Show("Erreur : Noms et/ou Pseudos déjà utilisés");
                        return false;
                    }
                }
            }
            if (ordre == 2) //Pour modifier un nouveau joueur
            {

                if (textBoxIdCode.Text == "")
                {
                    MessageBox.Show("Choisir un joueur dans la liste.");
                    return false;
                }
                else
                {
                    bool idOK = textBoxIdCode.Text == ancienJoueurAModifier.CodeJoueur;
                    bool nomChange = textBoxNom.Text != "" && textBoxNom.Text != ancienJoueurAModifier.Nom;
                    bool pseudoChange = textBoxPseudo.Text != ancienJoueurAModifier.Pseudo;
                    bool cacherNomChange = checkBoxCacherNom.Checked != ancienJoueurAModifier.CacherNom;
                    bool FqcsfChange = textBoxNoFqcsf.Text != ancienJoueurAModifier.Fqcsf;
                    if (!(idOK && (nomChange || pseudoChange || cacherNomChange || FqcsfChange)))
                    {
                        MessageBox.Show("le ID Code ne peut pas être changé ou\nIl n'y a aucun changement apporté.");
                        return false;
                    }
                    else
                    {
                        nouveauJoueurAModifier.IdJoueur = dataGridViewJoueurs.
                        nouveauJoueurAModifier.CodeJoueur = textBoxIdCode.Text;
                        nouveauJoueurAModifier.Nom = textBoxNom.Text;
                        nouveauJoueurAModifier.Pseudo = textBoxPseudo.Text;
                        nouveauJoueurAModifier.CacherNom = checkBoxCacherNom.Checked;
                        nouveauJoueurAModifier.Fqcsf = textBoxNoFqcsf.Text;
                    }
                }
            }
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
            dataGridViewJoueurs.DataSource = null;
            dataGridViewJoueurs.DataSource = controleur.GererJoueur(null, controleur.lister, orderBy);
            MettreAJourDataGridView();
        }
    }

}

