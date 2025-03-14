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
    internal partial class StatsForm : Form
    {
        Controleur controleur;
        List<Joueur> joueurs = new List<Joueur>();
        List<Partie> parties = new List<Partie>();

        public StatsForm(Controleur controleurX)
        {
            InitializeComponent();
            controleur = controleurX;
        }

        private void StatsForm_Load(object sender, EventArgs e)
        {
            EffacerTousLesControles();
            parties = controleur.ListerJoutes(controleur.lister);
        }

        private void EffacerTousLesControles()
        {
            comboBoxChoixJoueur.Visible = false;
        }

        private void fermerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void joueurToolStripMenuItem_Click(object sender, EventArgs e)
        {
            comboBoxChoixJoueur.Visible = true;
            joueurs = controleur.GererJoueur(null, controleur.lister, "ORDER BY Code_Joueur");
            comboBoxChoixJoueur.DataSource = joueurs;
            comboBoxChoixJoueur.SelectedIndex = -1;
            
        }

        private void comboBoxChoixJoueur_SelectionChangeCommitted(object sender, EventArgs e)
        {
            
            Joueur joueurChoisi = comboBoxChoixJoueur.SelectedItem as Joueur;
            DeterminerLesOccurencesEntreJoueurs(joueurChoisi);
        }

        private void DeterminerLesOccurencesEntreJoueurs(Joueur joueurChoisi)
        {
            int[,] occurences = new int[joueurs.Count + 1, joueurs.Count + 1];
            foreach (var partieAVerifier in parties)
            {
                if (partieAVerifier.Idjoueur1 == joueurChoisi.IdJoueur)
                {
                    occurences[joueurChoisi.IdJoueur, partieAVerifier.Idjoueur2]++;
                    occurences[joueurChoisi.IdJoueur, partieAVerifier.Idjoueur3]++;
                    occurences[joueurChoisi.IdJoueur, partieAVerifier.Idjoueur4]++;
                }
                if (partieAVerifier.Idjoueur2 == joueurChoisi.IdJoueur)
                {
                    occurences[joueurChoisi.IdJoueur, partieAVerifier.Idjoueur1]++;
                    occurences[joueurChoisi.IdJoueur, partieAVerifier.Idjoueur3]++;
                    occurences[joueurChoisi.IdJoueur, partieAVerifier.Idjoueur4]++;
                }
                if (partieAVerifier.Idjoueur3 == joueurChoisi.IdJoueur)
                {
                    occurences[joueurChoisi.IdJoueur, partieAVerifier.Idjoueur1]++;
                    occurences[joueurChoisi.IdJoueur, partieAVerifier.Idjoueur2]++;
                    occurences[joueurChoisi.IdJoueur, partieAVerifier.Idjoueur4]++;
                }
                if (partieAVerifier.Idjoueur4 == joueurChoisi.IdJoueur)
                {
                    occurences[joueurChoisi.IdJoueur, partieAVerifier.Idjoueur1]++;
                    occurences[joueurChoisi.IdJoueur, partieAVerifier.Idjoueur2]++;
                    occurences[joueurChoisi.IdJoueur, partieAVerifier.Idjoueur3]++;
                }
            }
        }
    }
}
