using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Org.BouncyCastle.Tls;

namespace WindowsFormsLigueScrabble
{
    internal partial class EditionRencontreForm : Form
    {
        Controleur controleur = new Controleur();
        Rencontre rencontreAModifier = new Rencontre();
        bool modeAjoutSession = false;
        bool modeAjoutJoueursSeulement = false;
        string orderByJoueurs = "ORDER BY ID_Joueur";
        string orderBySessions = "ORDER BY Session.Date_Session DESC, _Table.No_Table; ";
        List<RencontresDataGrid> rencontres= new List<RencontresDataGrid>();
        List<Joueur> listeJoueursOriginale = new List<Joueur>();
        List<Joueur> listeJoueur1 = new List<Joueur>();
        List<Joueur> listeJoueur2 = new List<Joueur>();
        List<Joueur> listeJoueur3 = new List<Joueur>();
        List<Joueur> listeJoueur4 = new List<Joueur>();

        Joueur ancienJoueur;
        Joueur ancienJoueur2;
        Joueur ancienJoueur3;
        Joueur ancienJoueur4;

        public EditionRencontreForm(Controleur controleurX, Rencontre rencontreAModifierX)
        {
            InitializeComponent();
            controleur = controleurX;
            rencontreAModifier = rencontreAModifierX;
            if (rencontreAModifier != null) modeAjoutJoueursSeulement = true;
            else modeAjoutJoueursSeulement = false;
            modeAjoutSession = !modeAjoutJoueursSeulement;
        }

        private void EditionRencontreForm_Load(object sender, EventArgs e)
        {
            rencontres = controleur.GererRencontres(null, 0, 0, null, controleur.lister, orderBySessions);
            ReglerAffichageEtControles();
        }

        private void ReglerAffichageEtControles()
        {
            if (modeAjoutSession)
            {
                dateTimePickerNewSession.Value = TrouverMercrediProchain();
                comboBoxHeure.SelectedIndex = 1;
                InitialiserLesListesComboBoxJoueurs();
                RemplirLesComboBoxJoueurs();
                MettreAJourAnciensJoueurs();
            }
            if (modeAjoutJoueursSeulement) 
            {
                dateTimePickerNewSession.Enabled = false;
                comboBoxHeure.Enabled = false;
                Rencontre rencontreAAfficher = new Rencontre();
                rencontreAAfficher = controleur.TrouverRencontre(rencontreAModifier.IdSession);
                dateTimePickerNewSession.Value = rencontreAAfficher.DateDeJeu;
                comboBoxHeure.Text = Convert.ToString(rencontreAAfficher.DateDeJeu.Hour) + "h";
            }
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
            listeJoueursOriginale = controleur.GererJoueur(null, controleur.lister, orderByJoueurs);
            Joueur joueurBidon = new Joueur("","(vide)","(vide)");
            listeJoueur1.AddRange(listeJoueursOriginale); listeJoueur1.Add(joueurBidon);
            listeJoueur2.AddRange(listeJoueursOriginale); listeJoueur2.Add(joueurBidon);
            listeJoueur3.AddRange(listeJoueursOriginale); listeJoueur3.Add(joueurBidon);
            listeJoueur4.AddRange(listeJoueursOriginale); listeJoueur4.Add(joueurBidon);
        }

        private void RemplirLesComboBoxJoueurs()
        {
            //List<Joueur> joueurs = controleur.GererJoueur(null, controleur.lister, orderByJoueurs);
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
            if (modeAjoutSession)
            {
                if (!VérifierLesDonnees()) return;

                DonneesRencontre nouvellesDonneesRencontre = new DonneesRencontre();

                int heureNouvelle = ConvertirComboBoxHeure();
                nouvellesDonneesRencontre.DateEtHeure = dateTimePickerNewSession.Value.AddHours(heureNouvelle);
                int.TryParse((string)comboBoxPupitre.SelectedItem, out int result);
                nouvellesDonneesRencontre.Table = result;
                int.TryParse((string)comboBoxRonde.SelectedItem, out result);
                nouvellesDonneesRencontre.Partie = result;

                LienTableSession lienTableSession = new LienTableSession();
                List<LienTableSession> liensTableSession = new List<LienTableSession>();

                //Vérifier si lien existe déjà
                bool lienExiste = controleur.VerifierLiens(nouvellesDonneesRencontre);
                if (!lienExiste)
                {
                    rencontres = AjouterNouvelleSession(nouvellesDonneesRencontre);
                }
                else MessageBox.Show("Existe déjà");
            }
            

        }

        private List<RencontresDataGrid> AjouterNouvelleSession(DonneesRencontre nouvellesDonneesRencontre)
        {
            if (modeAjoutSession)
            {
                Rencontre nouvelleRencontre = new Rencontre();
                nouvelleRencontre.DateNouvelle = nouvellesDonneesRencontre.DateEtHeure;
                nouvelleRencontre.DateDeJeu = nouvellesDonneesRencontre.DateEtHeure;
                int noTable = nouvellesDonneesRencontre.Table;
                int noPartie = nouvellesDonneesRencontre.Partie;
                List<Joueur> joueurs = new List<Joueur>();
                int nbSessionsAvantAjout = rencontres.Count;
                List<RencontresDataGrid> sessions = new List<RencontresDataGrid>();
                sessions = controleur.GererRencontres(nouvelleRencontre, noTable, noPartie, joueurs, controleur.ajouter, orderBySessions);
                return sessions;
            }
            return null;
           
        }

        private int ConvertirComboBoxHeure()
        {
            //La validation a été faite auparavant
            string heure = comboBoxHeure.SelectedItem as string;
            return int.Parse(Regex.Match(heure, @"\d+").Value);
        }

        private bool VérifierLesDonnees()
        {
            bool dateOk = dateTimePickerNewSession.Value !=null;
            bool heureOk = comboBoxHeure.SelectedItem != null;
            bool pupitreOk = comboBoxPupitre.SelectedItem != null;
            bool rondeOk = comboBoxRonde.SelectedItem != null;
            bool joueursok = (comboBoxJoueur1.SelectedItem != null) && (comboBoxJoueur2.SelectedItem != null);

            bool ajoutOk = false;

            if (dateOk && heureOk && !pupitreOk && !rondeOk && !joueursok)
            {
                ajoutOk = controleur.DemandeDeConfirmation("Créer une session sans tables, sans joueurs, et sans parties?");
            }
            if ((dateOk && heureOk && pupitreOk && !rondeOk && !joueursok))
            {
                ajoutOk = controleur.DemandeDeConfirmation("Créer une session sans joueurs et sans parties?");
            }
            if (dateOk && heureOk && pupitreOk && rondeOk && !joueursok)
            {
                ajoutOk = controleur.DemandeDeConfirmation("Créer une session sans joueurs?");
            }
            if (dateOk && heureOk && joueursok && (!pupitreOk || !rondeOk)) { MessageBox.Show("Erreur de données.\nTable et Partie manquantes."); }

            return ajoutOk;
        }

        private void buttonEffacer_Click(object sender, EventArgs e)
        {
            if (modeAjoutSession)
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
        }

        private void MettreAJourPlacesAuPupitre()
        {
            if (comboBoxJoueur1.SelectedItem != null) labelPlace1.Text = comboBoxJoueur1.SelectedItem.ToString();
            if (comboBoxJoueur2.SelectedItem != null) labelPlace2.Text = comboBoxJoueur2.SelectedItem.ToString();
            if (comboBoxJoueur3.SelectedItem != null) labelPlace3.Text = comboBoxJoueur3.SelectedItem.ToString();
            if (comboBoxJoueur4.SelectedItem != null) labelPlace4.Text = comboBoxJoueur4.SelectedItem.ToString();
        }

        private void MessageErreurChoixJoueur(ComboBox comboBoxChoisie, Joueur joueurChoisi)
        {
            if (joueurChoisi.Pseudo != "(vide)")
            {
                MessageBox.Show("Ce joueur est déjà choisi.");
                comboBoxChoisie.SelectedIndex = -1;
            }
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
            ComboBox comboBoxChoisie = sender as ComboBox;
            Joueur joueurChoisi = comboBoxChoisie.SelectedItem as Joueur;

            if (comboBoxJoueur1 != comboBoxChoisie)
            {
                if (joueurChoisi == comboBoxJoueur1.SelectedItem as Joueur) { MessageErreurChoixJoueur(comboBoxChoisie, joueurChoisi); return; }
            }
            if (comboBoxJoueur2 != comboBoxChoisie)
            {
                if (joueurChoisi == comboBoxJoueur2.SelectedItem as Joueur) { MessageErreurChoixJoueur(comboBoxChoisie, joueurChoisi); return; }
            }
            if (comboBoxJoueur3 != comboBoxChoisie)
            {
                if (joueurChoisi == comboBoxJoueur3.SelectedItem as Joueur) { MessageErreurChoixJoueur(comboBoxChoisie, joueurChoisi); return; }
            }
            if (comboBoxJoueur4 != comboBoxChoisie)
            {
                if (joueurChoisi == comboBoxJoueur4.SelectedItem as Joueur) { MessageErreurChoixJoueur(comboBoxChoisie, joueurChoisi); return; }
            }
            ancienJoueur = comboBoxChoisie.SelectedItem as Joueur;
            MettreAJourPlacesAuPupitre();
        }
        

    }
}
