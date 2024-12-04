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
        //List<Joueur> joueurs = new List<Joueur>();

        public JoueurForm(Controleur controleurX)
        {
            InitializeComponent();
            controleur = controleurX;
            
            textBoxNom.Height = 100;
        }

        private void buttonAjouterJoueur_Click(object sender, EventArgs e)
        {
            ValiderLesTextBox(1);
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
            controleur.GererJoueur(nouveauJoueur, 1);
            MettreAJourDataGridView();
            AjusterFocusDataGridView(nouveauJoueur.IdCode);
        }

        private bool ValiderLesTextBox(int ordre)
        {
            if (ordre == 1)
            {
                if (textBoxIdCode.Text.Length == 0 || textBoxNom.Text.Length == 0)
                {
                    MessageBox.Show("ID code et Nom invalides");
                    return false;
                }
                foreach (var joueurDejaInscrit in controleur.joueurs)
                {
                    if (joueurDejaInscrit.Nom == textBoxNom.Text || (joueurDejaInscrit.Pseudo.Length != 0 && joueurDejaInscrit.Pseudo == textBoxPseudo.Text))
                    {
                        MessageBox.Show("Erreur : Noms et/ou Pseudos déjà utilisés");
                    }
                }
            }
            return true;
        }

        private bool VerifierDuplicationID(string idCode)
        {
            foreach (var joueurAVerifier in controleur.joueurs)
            {
                if (idCode == joueurAVerifier.IdCode) return true;
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
                if (dataGridViewJoueurs["IdCode", rangee].Value.ToString() == idCode) rangeeTrouvee = rangee;
            }
            return rangeeTrouvee;
        }

        private void buttonTerminer_Click(object sender, EventArgs e)
        {
            //db_manager.AjouterJoueurDansBD(joueurs);
            this.Close();
        }

        private void AjoutJoueurForm_Load(object sender, EventArgs e)
        {
            //joueurs = controleur.GererJoueur(null, 0);// 0:rien ajouter    1:ajouter
            MettreAJourDataGridView();
        }

        private void MettreAJourDataGridView()
        {
            dataGridViewJoueurs.DataSource = null;
            dataGridViewJoueurs.DataSource = controleur.joueurs;
            dataGridViewJoueurs.RowHeadersVisible = false;
            dataGridViewJoueurs.ClearSelection();
            labelNombreJoueurs.Text = "Nombre de joueurs : ";
            labelNombreJoueurs.Text += (controleur.joueurs.Count).ToString();
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

        private void buttonRetirerJoueur_Click(object sender, EventArgs e)
        {
            Joueur joueurARetirer = new Joueur();
            joueurARetirer.IdCode = dataGridViewJoueurs["IDCode", dataGridViewJoueurs.CurrentRow.Index].Value.ToString();
            joueurARetirer.Nom = dataGridViewJoueurs["Nom", dataGridViewJoueurs.CurrentRow.Index].Value.ToString();
            joueurARetirer.Pseudo = dataGridViewJoueurs["Pseudo", dataGridViewJoueurs.CurrentRow.Index].Value.ToString();
            
            string rubrique = "ID Code : " + joueurARetirer.IdCode + "\nNom : " + joueurARetirer.Nom + " (" + joueurARetirer.Pseudo + ")\n";
            if (controleur.DemandeDeConfirmationDeSuppression(rubrique)) 
            {
                controleur.GererJoueur(joueurARetirer, 2);
                MettreAJourDataGridView();
            }
        }
    }
}

