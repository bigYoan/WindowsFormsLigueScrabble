using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Org.BouncyCastle.Tls;

namespace WindowsFormsLigueScrabble
{
    internal partial class EditionRencontreForm : Form
    {
        Controleur controleur = new Controleur();
        
        string orderBy = "ORDER BY ID_Joueur";
        List<Rencontre> rencontres= new List<Rencontre>();
        List<Joueur> listeJoueursOriginale = new List<Joueur>();
        List<Joueur> listeJoueur1 = new List<Joueur>();
        List<Joueur> listeJoueur2 = new List<Joueur>();
        List<Joueur> listeJoueur3 = new List<Joueur>();
        List<Joueur> listeJoueur4 = new List<Joueur>();

        Joueur ancienJoueur;
        Joueur ancienJoueur2;
        Joueur ancienJoueur3;
        Joueur ancienJoueur4;

        public EditionRencontreForm(Controleur controleurX)
        {
            InitializeComponent();
            controleur = controleurX;
        }

        private void EditionRencontreForm_Load(object sender, EventArgs e)
        {
            rencontres = controleur.GererRencontres(null, controleur.lister, "");
            dateTimePickerNewSession.Value = TrouverMercrediProchain();
            comboBoxHeure.SelectedIndex = 1;
            InitialiserLesListesComboBoxJoueurs();
            RemplirLesComboBoxJoueurs();
            MettreAJourAnciensJoueurs();
        }

        private DateTime TrouverMercrediProchain()
        {
            DateTime aujourdhui = DateTime.Today;
            // The (... + 7) % 7 ensures we end up with a value in the range [0, 6]
            int nombreJoursDIciProchainMercredi = ((int)DayOfWeek.Wednesday - (int)aujourdhui.DayOfWeek + 7) % 7;
            DateTime mercrediProchain = aujourdhui.AddDays(nombreJoursDIciProchainMercredi);
            return mercrediProchain;
        }

        private void MettreAJourAnciensJoueurs()
        {
            //if (comboBoxJoueur1.SelectedItem != null) ancienJoueur1 = (comboBoxJoueur1.SelectedItem as Joueur);
            //if (comboBoxJoueur2.SelectedItem != null) ancienJoueur2 = (comboBoxJoueur2.SelectedItem as Joueur);
            //if (comboBoxJoueur3.SelectedItem != null) ancienJoueur3 = (comboBoxJoueur3.SelectedItem as Joueur);
            //if (comboBoxJoueur4.SelectedItem != null) ancienJoueur4 = (comboBoxJoueur4.SelectedItem as Joueur);
        }

        private void InitialiserLesListesComboBoxJoueurs()
        {
            listeJoueursOriginale = controleur.GererJoueur(null, controleur.lister, orderBy);
            Joueur joueurBidon = new Joueur("","(vide)","(vide)");
            listeJoueur1.AddRange(listeJoueursOriginale); listeJoueur1.Add(joueurBidon);
            listeJoueur2.AddRange(listeJoueursOriginale); listeJoueur2.Add(joueurBidon);
            listeJoueur3.AddRange(listeJoueursOriginale); listeJoueur3.Add(joueurBidon);
            listeJoueur4.AddRange(listeJoueursOriginale); listeJoueur4.Add(joueurBidon);
        }

        private void RemplirLesComboBoxJoueurs()
        {
            //List<Joueur> joueurs = controleur.GererJoueur(null, controleur.lister, orderBy);
            comboBoxJoueur1.DataSource = listeJoueur1;
            comboBoxJoueur1.SelectedIndex = -1; 
            comboBoxJoueur2.DataSource = listeJoueur2;
            comboBoxJoueur2.SelectedIndex = -1; 
            comboBoxJoueur3.DataSource = listeJoueur3;
            comboBoxJoueur3.SelectedIndex = -1; 
            comboBoxJoueur4.DataSource = listeJoueur4;
            comboBoxJoueur4.SelectedIndex = -1;
        }

        private void buttonConfirmerAjout_Click(object sender, EventArgs e)
        {
            if (!VérifierLesDonnees()) return;
            MessageBox.Show("Veuillez confirmer les données suivantes :\n");
            Rencontre nouvelleRencontre = new Rencontre();
            nouvelleRencontre.DateNouvelle = dateTimePickerNewSession.Value;
            nouvelleRencontre.DateDeJeu = dateTimePickerNewSession.Value;
            LienTableSession lienTableSession = new LienTableSession();
            List<LienTableSession> liensTableSession = new List<LienTableSession>();
            liensTableSession.AddRange(controleur.ListerLiens("Table_Session"));
        }

        private bool VérifierLesDonnees()
        {
            bool dateOk = dateTimePickerNewSession.Value > DateTime.Now;
            bool heureOk = comboBoxHeure.SelectedItem != null;
            bool pupitreOk = comboBoxPupitre.SelectedItem != null;
            bool rondeOk = comboBoxRonde.SelectedItem != null;
            bool joueursok = (comboBoxJoueur1.SelectedItem != null) && (comboBoxJoueur2.SelectedItem != null);

            if (!(dateOk && heureOk && pupitreOk && rondeOk && joueursok)) { MessageBox.Show("Erreur de données."); return false; }
            return true;
        }

        private void buttonEffacer_Click(object sender, EventArgs e)
        {
            DialogResult approuveChangement = MessageBox.Show("Effacer toutes les données ?\nConfirmer...", "Attention!", MessageBoxButtons.OKCancel);
            if (approuveChangement == DialogResult.Cancel) return;
            dateTimePickerNewSession.Value = TrouverMercrediProchain();
            comboBoxHeure.SelectedIndex = 1;
            comboBoxRonde.SelectedIndex = -1;
            comboBoxPupitre.SelectedIndex = -1;
            comboBoxJoueur1.SelectedIndex = -1;
            comboBoxJoueur3.SelectedIndex = -1;
            comboBoxJoueur2.SelectedIndex = -1;
            comboBoxJoueur4.SelectedIndex = -1;
            RemplirLesComboBoxJoueurs();
            labelPlace1.Text = string.Empty; 
            labelPlace2.Text = string.Empty; 
            labelPlace3.Text = string.Empty;
            labelPlace4.Text = string.Empty;
        }

        

        private void MettreAJourPlacesAuPupitre()
        {
            if (comboBoxJoueur1.SelectedItem != null) labelPlace1.Text = comboBoxJoueur1.SelectedItem.ToString();
            if (comboBoxJoueur2.SelectedItem != null) labelPlace2.Text = comboBoxJoueur2.SelectedItem.ToString();
            if (comboBoxJoueur3.SelectedItem != null) labelPlace3.Text = comboBoxJoueur3.SelectedItem.ToString();
            if (comboBoxJoueur4.SelectedItem != null) labelPlace4.Text = comboBoxJoueur4.SelectedItem.ToString();

        }

        private int GetAncienIndex(ComboBox comboBoxJoueur)
        {
            if (comboBoxJoueur.SelectedItem != null) { return comboBoxJoueur.SelectedIndex; }
            else return -1;
        }

        private void MessageErreurChoixJoueur(ComboBox comboBoxChoisie)
        {
            MessageBox.Show("Ce joueur est déjà choisi.");
            comboBoxChoisie.SelectedIndex = -1;
        }

        private void buttonQuitter_Click(object sender, EventArgs e)
        {
            Environment.Exit(1);
        }

        private void buttonFermer_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void labelPlace2_Click(object sender, EventArgs e)
        {

        }

        private void AnyComboBoxJoueur_SelectionChangeCommitted(object sender, EventArgs e)
        {
            int ancienIndex;

            ComboBox comboBoxChoisie = sender as ComboBox;
            Joueur joueurChoisi = comboBoxChoisie.SelectedItem as Joueur;

            if (comboBoxJoueur1 != comboBoxChoisie)
            {
                if (joueurChoisi == comboBoxJoueur1.SelectedItem as Joueur) { MessageErreurChoixJoueur(comboBoxChoisie); return; }
                //else
                //{
                //    ancienIndex = GetAncienIndex(comboBoxJoueur1);
                //    for (int index = 0; index < listeJoueur1.Count; index++)
                //    {
                //        if (listeJoueur1[index].ToString() == joueurChoisi.ToString())
                //        {
                //            listeJoueur1.RemoveAt(index);
                //            if (ancienJoueur != null) listeJoueur1.Add(ancienJoueur);
                //            comboBoxJoueur1.DataSource = null;
                //            comboBoxJoueur1.DataSource = listeJoueur1;
                //            comboBoxJoueur1.SelectedIndex = ancienIndex;
                //        }
                //    }
                //}
            }
            if (comboBoxJoueur2 != comboBoxChoisie)
            {
                if (joueurChoisi == comboBoxJoueur2.SelectedItem as Joueur) { MessageErreurChoixJoueur(comboBoxChoisie); return; }
                //else
                //{
                //    ancienIndex = GetAncienIndex(comboBoxJoueur2);
                //    for (int index = 0; index < listeJoueur2.Count; index++)
                //    {
                //        if (listeJoueur2[index].ToString() == joueurChoisi.ToString())
                //        {
                //            listeJoueur2.RemoveAt(index);
                //            if (ancienJoueur != null) listeJoueur2.Add(ancienJoueur);
                //            comboBoxJoueur2.DataSource = null;
                //            comboBoxJoueur2.DataSource = listeJoueur2;
                //            comboBoxJoueur2.SelectedIndex = ancienIndex;
                //        }
                //    }
                //}
            }

            if (comboBoxJoueur3 != comboBoxChoisie)
            {
                if (joueurChoisi == comboBoxJoueur3.SelectedItem as Joueur) { MessageErreurChoixJoueur(comboBoxChoisie); return; }
                //else
                //{
                //    ancienIndex = GetAncienIndex(comboBoxJoueur3);
                //    for (int index = 0; index < listeJoueur3.Count; index++)
                //    {
                //        if (listeJoueur3[index].ToString() == joueurChoisi.ToString())
                //        {
                //            listeJoueur3.RemoveAt(index);
                //            if (ancienJoueur != null) listeJoueur3.Add(ancienJoueur);
                //            comboBoxJoueur3.DataSource = null;
                //            comboBoxJoueur3.DataSource = listeJoueur3;
                //            comboBoxJoueur3.SelectedIndex = ancienIndex;
                //        }
                //    }
                //}
            }
            if (comboBoxJoueur4 != comboBoxChoisie)
            {
                if (joueurChoisi == comboBoxJoueur4.SelectedItem as Joueur) { MessageErreurChoixJoueur(comboBoxChoisie); return; }
                //else
                //{
                //    ancienIndex = GetAncienIndex(comboBoxJoueur4);
                //    for (int index = 0; index < listeJoueur4.Count; index++)
                //    {
                //        if (listeJoueur4[index].ToString() == joueurChoisi.ToString())
                //        {
                //            listeJoueur4.RemoveAt(index);
                //            if (ancienJoueur != null) listeJoueur4.Add(ancienJoueur);
                //            comboBoxJoueur4.DataSource = null;
                //            comboBoxJoueur4.DataSource = listeJoueur4;
                //            comboBoxJoueur4.SelectedIndex = ancienIndex;
                //        }
                //    }
                //}
            }
            ancienJoueur = comboBoxChoisie.SelectedItem as Joueur;
            MettreAJourPlacesAuPupitre();

        }

    }
}
