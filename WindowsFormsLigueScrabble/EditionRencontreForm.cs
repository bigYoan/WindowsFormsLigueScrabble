﻿using System;
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
using Mysqlx.Session;
using MySqlX.XDevAPI.Common;
using Org.BouncyCastle.Bcpg;
using Org.BouncyCastle.Tls;

namespace WindowsFormsLigueScrabble
{
    internal partial class EditionRencontreForm : Form
    {
        Controleur controleur = new Controleur();
        Rencontre rencontreAModifier = new Rencontre();
        bool modeAjoutNouvelleSession = false;
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

        int modificationAFaire = 100;
        int ajouterNouvelleSession = 0;
        int ajouterTableEtPartie = 1;
        int ajouterJoueursSeulement = 2;

        public EditionRencontreForm(Controleur controleurX, Rencontre rencontreAModifierX)
        {
            InitializeComponent();
            controleur = controleurX;
            rencontreAModifier = rencontreAModifierX;
        }

        private int VerifierModificationAFaire(Rencontre rencontreAModifier)
        {
            if (rencontreAModifier == null) { return ajouterNouvelleSession; }
            if (rencontreAModifier.Id_Table == 0 || rencontreAModifier.Id_Joute == 0)
            {
                return ajouterTableEtPartie;
            }
            return ajouterJoueursSeulement;
        }

        private void EditionRencontreForm_Load(object sender, EventArgs e)
        {
            rencontres = controleur.GererRencontres(null, 0, 0, null, controleur.lister, orderBySessions);
            modificationAFaire = VerifierModificationAFaire(rencontreAModifier);
            ReglerAffichageEtControles();
            AjusterProprietesDataGridViewSessions();
        }

        private void ReglerAffichageEtControles()
        {
            InitialiserLesListesComboBoxJoueurs();
            RemplirLesComboBoxJoueurs();
            MettreAJourAnciensJoueurs();

            if (modificationAFaire == ajouterNouvelleSession)
            {
                dataGridViewRencontres.DataSource = controleur.rencontres;
                dateTimePickerNewSession.Enabled = true;
                comboBoxHeure.Enabled = true;
                comboBoxRonde.Enabled = true;
                comboBoxPupitre.Enabled = true;
                dateTimePickerNewSession.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
                comboBoxHeure.SelectedIndex = -1;
            }
            if (modificationAFaire == ajouterTableEtPartie) 
            {
                AfficherLesDonneesDeRencontreAModifier(rencontreAModifier);
                dateTimePickerNewSession.Enabled = false;

                comboBoxHeure.Enabled = false;
                //if (rencontreAModifier.Id_Joute != 0) comboBoxRonde.Enabled = false;
                //if (rencontreAModifier.Id_Table != 0) comboBoxPupitre.Enabled = false;
            }
            if (modificationAFaire == ajouterJoueursSeulement)
            {
                AfficherLesDonneesDeRencontreAModifier(rencontreAModifier);
                dateTimePickerNewSession.Enabled = false;
                comboBoxHeure.Enabled = false;
                comboBoxPupitre.Enabled = false;
                comboBoxRonde.Enabled= false;

            }
        }

        private void AfficherLesDonneesDeRencontreAModifier(Rencontre rencontreAModifier)
        {
            //Rencontre rencontreAAfficher = controleur.TrouverRencontre(rencontreAModifier.IdSession);
            dateTimePickerNewSession.Value = rencontreAModifier.DateDeJeu;
            comboBoxHeure.Text = Convert.ToString(rencontreAModifier.DateDeJeu.Hour) + "h";
            if (rencontreAModifier.Id_Joute != 0) comboBoxRonde.Text = rencontreAModifier.NoJoute.ToString();
            if (rencontreAModifier.Id_Table != 0) comboBoxPupitre.Text = rencontreAModifier.NoTable.ToString();

            List<RencontresDataGrid> rencontresDansDataGrid = new List<RencontresDataGrid>();
            foreach (var rencontreAVerifier in rencontres)
            {
                if (rencontreAVerifier.Session.DateDeJeu == rencontreAModifier.DateDeJeu &&
                    rencontreAVerifier.Session.DateNouvelle == rencontreAModifier.DateNouvelle)
                {
                    rencontresDansDataGrid.Add(rencontreAVerifier);
                }
            }
            dataGridViewRencontres.DataSource = rencontresDansDataGrid;
            dataGridViewRencontres.ClearSelection();
        }

        private void AjusterProprietesDataGridViewSessions()
        {
            dataGridViewRencontres.Columns["Table"].DisplayIndex = 3;

            dataGridViewRencontres.Columns["Gagnant"].Visible = false;
            dataGridViewRencontres.Columns["ScoreGagnant"].Visible = false;
            dataGridViewRencontres.Columns["homologation"].Visible = false;
            dataGridViewRencontres.ColumnHeadersDefaultCellStyle.Font = new Font("Verdana", 9);
            dataGridViewRencontres.DefaultCellStyle.Font = new Font("Verdana", 12);
            dataGridViewRencontres.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewRencontres.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewRencontres.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            dataGridViewRencontres.Columns["IdSession"].Visible = false;
            dataGridViewRencontres.Columns["Id_Table"].Visible = false;
            dataGridViewRencontres.Columns["Id_Ronde"].Visible = false;
            dataGridViewRencontres.Columns["Session"].HeaderText = "Date";
            dataGridViewRencontres.Columns["jourRencontre"].HeaderText = "Jour";
            dataGridViewRencontres.Columns["heureRencontre"].HeaderText = "Heure";
            dataGridViewRencontres.Columns["nombreJoueurs"].HeaderText = "Nombre\nJoueurs";
            dataGridViewRencontres.Columns["scoreGagnant"].HeaderText = "Score";
            dataGridViewRencontres.Columns["homologation"].HeaderText = "FQCSF\nhomologué";
            dataGridViewRencontres.Columns["nombreJoueurs"].DefaultCellStyle.Format = "###.##";
            dataGridViewRencontres.Columns["Table"].DefaultCellStyle.Format = "###.##";
            dataGridViewRencontres.Columns["Ronde"].DefaultCellStyle.Format = "###.##";
            dataGridViewRencontres.Columns["scoreGagnant"].DefaultCellStyle.Format = "###.##";
            dataGridViewRencontres.RowHeadersVisible = false;
            dataGridViewRencontres.ReadOnly = true;
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
            if (!VerifierLesDonnees()) return;
            int heureDansComboBox = ConvertirComboBoxHeure();
            DateTime dateDansPicker = dateTimePickerNewSession.Value.AddHours(heureDansComboBox);

             

            // Ajout d'une nouvelle session, avec nouvelle table et nouvelle partie
            if (modificationAFaire == ajouterNouvelleSession)
            {
                if (!VerifierLesDonnees()) return;

                DonneesRencontre nouvellesDonneesRencontre = new DonneesRencontre();

                int heureNouvelle = ConvertirComboBoxHeure();
                nouvellesDonneesRencontre.DateEtHeure = dateTimePickerNewSession.Value.AddHours(heureNouvelle);
                int.TryParse((string)comboBoxPupitre.SelectedItem, out int result);
                nouvellesDonneesRencontre.NoTable = result;
                int.TryParse((string)comboBoxRonde.SelectedItem, out result);
                nouvellesDonneesRencontre.NoPartie = result;

               

                LienTableSession lienTableSession = new LienTableSession();
                List<LienTableSession> liensTableSession = new List<LienTableSession>();

                //Vérifier si lien existe déjà
                bool lienExiste = controleur.VerifierLiens(nouvellesDonneesRencontre);
                if (!lienExiste)
                {
                    rencontres = AjouterNouvelleSession(nouvellesDonneesRencontre);
                    dataGridViewRencontres.DataSource = rencontres;
                    dataGridViewRencontres.ClearSelection();
                }
                else MessageBox.Show("Existe déjà");
            }

            //Pour ajouter des joueurs, on ne touche pas à la date, heure, table et joute
            if (modificationAFaire == ajouterJoueursSeulement)  
            {
                bool changerTable = VerifierSiChangementDeTable(rencontreAModifier).TableChangee;
                bool changerJoute = VerifierSiChangementDeJoute(rencontreAModifier).JouteChangee;
                

                DonneesRencontre donneesRencontreAModifier = new DonneesRencontre();
                donneesRencontreAModifier.DateEtHeure = rencontreAModifier.DateDeJeu;
                donneesRencontreAModifier.IdTable = rencontreAModifier.Id_Table;
                donneesRencontreAModifier.IdJoute = rencontreAModifier.Id_Joute;

                List<Joueur> joueursAJouter = AjouterJoueursDansPartie();
                int rencontreAffectee = controleur.ModifierRencontrePartieJoueur(donneesRencontreAModifier, joueursAJouter);
                if (rencontreAffectee == 0) { MessageBox.Show("Créer nouvelle partie"); }
                else MessageBox.Show("Partie déjà créée");

                // verifier si on doit créer un nouveau lien session_table_game
                LiensSessionTablePartie lienExistant = controleur.TrouverLiens(donneesRencontreAModifier);
                if (lienExistant == null)
                {
                    int lienCree = controleur.CreerLienSession_Table_Game(donneesRencontreAModifier);
                }
                AfficherLesDonneesDeRencontreAModifier(rencontreAModifier);
                
            }
            
        }

        private ChangementDeJoute VerifierSiChangementDeJoute(Rencontre rencontreAModifier)
        {
            ChangementDeJoute changementDeJoute = new ChangementDeJoute();
            int.TryParse((string)comboBoxRonde.SelectedItem, out int result);
            int rondeDansComboBox = result;
            int rondeDansRencontreAModifier = rencontreAModifier.Id_Joute;
            if (rondeDansComboBox != rondeDansRencontreAModifier)
            {
                changementDeJoute.IdOldJoute = changementDeJoute.IdNewJoute;
                changementDeJoute.IdNewJoute = rondeDansComboBox;
                changementDeJoute.JouteChangee = true;
            }
            else
            {
                changementDeJoute.JouteChangee = false;
            }
            return changementDeJoute;
        }

        private ChangementDeTable VerifierSiChangementDeTable(Rencontre rencontreAModifier)
        {
            ChangementDeTable changementDeTable = new ChangementDeTable();
            int.TryParse((string)comboBoxPupitre.SelectedItem, out int result);
            int noTableDansComboBox = result;
            int noTableDansRencontreAModifier = rencontreAModifier.NoTable;
            if (noTableDansComboBox != noTableDansRencontreAModifier)
            {
                changementDeTable.IdOldTable = changementDeTable.IdNewTable;
                changementDeTable.IdNewTable = noTableDansComboBox;
                changementDeTable.TableChangee = true;
            }
            else
            {
                changementDeTable.TableChangee = false;
            }
            return changementDeTable;
        }

        private List<Joueur> AjouterJoueursDansPartie()
        {
            List<Joueur> joueurs = new List<Joueur>();
            joueurs.Add(comboBoxJoueur1.SelectedItem as Joueur);
            joueurs.Add(comboBoxJoueur2.SelectedItem as Joueur);
            joueurs.Add(comboBoxJoueur3.SelectedItem as Joueur);
            joueurs.Add(comboBoxJoueur4.SelectedItem as Joueur);
            return joueurs;
        }

        private List<RencontresDataGrid> AjouterNouvelleSession(DonneesRencontre nouvellesDonneesRencontre)
        {
            if (modificationAFaire == ajouterNouvelleSession)
            {
                Rencontre nouvelleRencontre = new Rencontre();
                nouvelleRencontre.DateNouvelle = nouvellesDonneesRencontre.DateEtHeure;
                nouvelleRencontre.DateDeJeu = nouvellesDonneesRencontre.DateEtHeure;
                int noTable = nouvellesDonneesRencontre.NoTable;
                int noPartie = nouvellesDonneesRencontre.NoPartie;
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

        private bool VerifierLesDonnees()
        {
            bool dateOk = dateTimePickerNewSession.Value !=null;
            bool heureOk = comboBoxHeure.SelectedItem != null;
            bool pupitreOk = comboBoxPupitre.SelectedItem != null;
            bool rondeOk = comboBoxRonde.SelectedItem != null;
            bool joueursok = (comboBoxJoueur1.SelectedItem != null) && (comboBoxJoueur2.SelectedItem != null);

            bool ajoutOk = false;

            if (!pupitreOk || !rondeOk)
            {
                MessageBox.Show("Impossible d'ajouter une nouvelle session sans table(s) ni partie(s).");
                return false;
            }
            if (dateOk && heureOk && pupitreOk && rondeOk && !joueursok)
            {
                ajoutOk = controleur.DemandeDeConfirmation("Créer une session sans joueurs?");
            }
            if (dateOk && heureOk && joueursok && (!pupitreOk || !rondeOk)) { MessageBox.Show("Erreur de données.\nTable et/ou Partie manquantes."); }

            return ajoutOk;
        }

        private void buttonEffacer_Click(object sender, EventArgs e)
        {
            if (modificationAFaire == ajouterNouvelleSession)
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
