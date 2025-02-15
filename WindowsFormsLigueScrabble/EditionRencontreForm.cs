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
using Microsoft.Win32.SafeHandles;
using Mysqlx.Session;
using MySqlX.XDevAPI.Common;
using MySqlX.XDevAPI.Relational;
using Org.BouncyCastle.Bcpg;
using Org.BouncyCastle.Tls;

namespace WindowsFormsLigueScrabble
{
    internal partial class EditionRencontreForm : Form
    {
        Controleur controleur = new Controleur();
        public Rencontre rencontreAModifier = new Rencontre();
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

        int modificationAFaire = 100;
        int ajouterNouvelleSession = 0;
        int ajouterTableEtPartie = 1;
        int ajouterJoueursSeulement = 2;
        int ajouterJoueursAvecPartieExistante = 3;

        public EditionRencontreForm(Controleur controleurX, Rencontre rencontreAModifierX)
        {
            InitializeComponent();
            controleur = controleurX;
            rencontreAModifier = rencontreAModifierX;
        }

        private void EditionRencontreForm_Load(object sender, EventArgs e)
        {
            ReglerAffichageEtControles(rencontreAModifier);
            AjusterProprietesDataGridViewSessions();

            if (rencontreAModifier == null)
            {
                modeAjoutNouvelleSession = true;
                rencontreAModifier = new Rencontre();
            }
            modificationAFaire = VerifierModificationAFaire(rencontreAModifier);

        }
        private int VerifierModificationAFaire(Rencontre rencontreAModifier)
        {
            int j1 = comboBoxJoueur1.SelectedItem == null ? 0 : 1;
            int j2 = comboBoxJoueur2.SelectedItem == null ? 0 : 1;
            int j3 = comboBoxJoueur3.SelectedItem == null ? 0 : 1;
            int j4 = comboBoxJoueur4.SelectedItem == null ? 0 : 1;

            if (modeAjoutNouvelleSession) { return ajouterNouvelleSession; }
            if (rencontreAModifier.Id_Table == 0 || rencontreAModifier.Id_Joute == 0)
            {
                return ajouterTableEtPartie;
            }
            else if (j1 + j2 + j3 + j4 >= 3) { return ajouterJoueursAvecPartieExistante; }
            else return ajouterJoueursSeulement;
        }
        private void ReglerAffichageEtControles(Rencontre rencontreAAfficher)
        {
            InitialiserLesListesComboBoxJoueurs();
            RemplirLesComboBoxJoueurs();

            // Temporaire :   afficher pour ajouter nouvelle session seulement

            labelInstructions.Text = "Ajouter une nouvelle session.";
            AfficherLesDonneesDeRencontreAModifier(rencontreAAfficher);
            dateTimePickerNewSession.Enabled = true;
            comboBoxHeure.Enabled = true;
            comboBoxRonde.Enabled = true;
            comboBoxPupitre.Enabled = true;
            dateTimePickerNewSession.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            comboBoxHeure.SelectedIndex = -1;




            //if (rencontreAAfficher == null)
            //{
            //    labelInstructions.Text = "Ajouter une nouvelle session.";
            //    AfficherLesDonneesDeRencontreAModifier(rencontreAAfficher);
            //    dateTimePickerNewSession.Enabled = true;
            //    comboBoxHeure.Enabled = true;
            //    comboBoxRonde.Enabled = true;
            //    comboBoxPupitre.Enabled = true;
            //    dateTimePickerNewSession.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            //    comboBoxHeure.SelectedIndex = -1;
            //}
            //else
            //{
            //    //labelInstructions.Text = "Ajouter des joueurs à une session.";
            //    AfficherLesDonneesDeRencontreAModifier(rencontreAAfficher);
            //    if (rencontreAAfficher.Id_Table == 0) comboBoxPupitre.Enabled = false;
            //    if (rencontreAAfficher.Id_Joute == 0) comboBoxRonde.Enabled = false;
            //    //if (rencontreAAfficher.Joueurs == null) comboBoxJoueur1.Enabled = false;
            //    dateTimePickerNewSession.Enabled = false;
            //    comboBoxHeure.Enabled = false;
            //    //comboBoxPupitre.Enabled = false;
            //    //comboBoxRonde.Enabled = false;
            //}
            //if (modificationAFaire == ajouterTableEtPartie) 
            //{
            //    labelInstructions.Text = "Ajouter une table, une partie et joueurs(optionnels) à une session.";
            //    rencontres = controleur.GererRencontres(null, 0, 0, null, controleur.lister, orderBySessions);
            //    AfficherLesDonneesDeRencontreAModifier(rencontreAModifier);
            //    dateTimePickerNewSession.Enabled = false;

            //    comboBoxHeure.Enabled = false;
            //}
            //if (modificationAFaire == ajouterJoueursSeulement)
            //{
            //    labelInstructions.Text = "Ajouter des joueurs à une session.";
            //    rencontres = controleur.GererRencontres(null, rencontreAModifier.Id_Table, rencontreAModifier.Id_Joute, null, controleur.lister, orderBySessions);
            //    AfficherLesDonneesDeRencontreAModifier(rencontreAModifier);
            //    dateTimePickerNewSession.Enabled = false;
            //    comboBoxHeure.Enabled = false;
            //    comboBoxPupitre.Enabled = false;
            //    comboBoxRonde.Enabled= false;
            //}
        }

        private void AfficherLesDonneesDeRencontreAModifier(Rencontre rencontreAModifier)
        {
            if (rencontreAModifier == null)
            {
                dataGridViewRencontres.DataSource = controleur.GererRencontres(null, 0, 0, null, controleur.lister, orderBySessions);
                return;
            }
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
            //Rencontre rencontreAModifier = new Rencontre();
            modificationAFaire = VerifierModificationAFaire(rencontreAModifier);

            // Temporaire :   seulement ajouter nouvelle session avec joueurs pour l'instant sans vérifier les intrants

            if (!VerifierLesDonnees()) return;

            // Ajouter nouvelles Date, heure , table et partie
            Rencontre nouvelleRencontre = new Rencontre();
            int heureNouvelle = ConvertirComboBoxHeure();
            nouvelleRencontre.DateNouvelle = dateTimePickerNewSession.Value.AddHours(heureNouvelle);
            int.TryParse((string)comboBoxPupitre.SelectedItem, out int result);
            int noTable = result;
            int.TryParse((string)comboBoxRonde.SelectedItem, out result);
            int noPartie = result;

            // Verifier si la rencontre existe déjà
            List<RencontresDataGrid> rencontreExiste = controleur.GererRencontres(nouvelleRencontre, noTable, noPartie, null, controleur.verifierSiExiste, "");
            if (rencontreExiste == null)
            {
                MessageBox.Show("Existe déjà"); return;
            }

            // Créer nouvelle session
            List<RencontresDataGrid> sessions = new List<RencontresDataGrid>();
            sessions = controleur.GererRencontres(nouvelleRencontre, noTable, noPartie, AjouterJoueursDansPartie(), controleur.ajouter, orderBySessions);

            // Ajouter joueurs à la session

            //int lignesAffectees = controleur.GererJoute(sessions[sessions.Count-1].Session, AjouterJoueursDansPartie());

            // Afficher la nouvelle session
            dataGridViewRencontres.DataSource = controleur.GererRencontres(null, 0, 0, null, controleur.lister, orderBySessions);

            //int idScore = controleur.CreerLienJouteScoreJoueurDansBD(rencontreAModifier);


            //// Ajout d'une nouvelle session, avec nouvelle table et nouvelle partie
            //if (modificationAFaire == ajouterNouvelleSession)
            //{
            //    if (!VerifierLesDonnees()) return;

            //    DonneesRencontre nouvellesDonneesRencontre = new DonneesRencontre();

            //    int heureNouvelle = ConvertirComboBoxHeure();
            //    nouvellesDonneesRencontre.DateEtHeure = dateTimePickerNewSession.Value.AddHours(heureNouvelle);
            //    int.TryParse((string)comboBoxPupitre.SelectedItem, out int result);
            //    nouvellesDonneesRencontre.NoTable = result;
            //    int.TryParse((string)comboBoxRonde.SelectedItem, out result);
            //    nouvellesDonneesRencontre.NoPartie = result;

            //    LienTableSession lienTableSession = new LienTableSession();
            //    List<LienTableSession> liensTableSession = new List<LienTableSession>();

            //    //Vérifier si lien existe déjà
            //    bool lienExiste = controleur.VerifierLiens(nouvellesDonneesRencontre);
            //    if (!lienExiste)
            //    {
            //        rencontres = AjouterNouvelleSession(nouvellesDonneesRencontre);
            //        dataGridViewRencontres.DataSource = rencontres;
            //        dataGridViewRencontres.ClearSelection();

            //        // Préparer si on veut ajouter des joueurs
            //        RencontresDataGrid rencontreBidon = rencontres.ElementAt(rencontres.Count - 1);
            //        rencontreAModifier.IdSession = rencontreBidon.IdSession;
            //        rencontreAModifier.Id_Joute = rencontreBidon.Id_Ronde;
            //        rencontreAModifier.NoJoute = rencontreBidon.Ronde;
            //        rencontreAModifier.Id_Table = rencontreBidon.Id_Table;
            //        rencontreAModifier.NoTable = rencontreBidon.Table;
            //        rencontreAModifier.DateNouvelle = rencontreBidon.Session.DateNouvelle;
            //        rencontreAModifier.DateDeJeu = rencontreBidon.Session.DateDeJeu;
            //        modeAjoutNouvelleSession = false;

            //        modificationAFaire = VerifierModificationAFaire(rencontreAModifier);
            //    }
            //    else MessageBox.Show("Existe déjà");
            //}

            ////Pour ajouter des joueurs sans toucher à date, heure, table et joute
            //if (modificationAFaire == ajouterJoueursAvecPartieExistante)  
            //{
            //    if (!VerifierLesDonnees()) return;
            //    List<Joueur> joueursAJouter = AjouterJoueursDansPartie();
            //    int lignesDbAffectees = controleur.GererJoute(rencontreAModifier, joueursAJouter);
            //    if (lignesDbAffectees != 0) 
            //    { 
            //        MessageBox.Show("Ajout réussi."); 
            //    }
            //    else { MessageBox.Show("Ajout impossible."); }
            //    AfficherLesDonneesDeRencontreAModifier(rencontreAModifier);
            //    int idScore = controleur.CreerLienJouteScoreJoueurDansBD(rencontreAModifier);
            //}

            //if (modificationAFaire == ajouterJoueursSeulement)
            //{
            //    if (!VerifierLesDonnees()) return;

            //    RencontresDataGrid rencontreBidon = rencontres.ElementAt(rencontres.Count - 1);
            //    rencontreAModifier.IdSession = rencontreBidon.IdSession;
            //    rencontreAModifier.Id_Joute = rencontreBidon.Id_Ronde;
            //    rencontreAModifier.NoJoute = rencontreBidon.Ronde;
            //    rencontreAModifier.Id_Table = rencontreBidon.Id_Table;
            //    rencontreAModifier.NoTable = rencontreBidon.Table;
            //    rencontreAModifier.DateNouvelle = rencontreBidon.Session.DateNouvelle;
            //    rencontreAModifier.DateDeJeu = rencontreBidon.Session.DateDeJeu;

            //    List<Joueur> joueursAJouter = AjouterJoueursDansPartie();
            //    int lignesDbAffectees = controleur.GererJoute(rencontreAModifier, joueursAJouter);
            //    if (lignesDbAffectees != 0)
            //    {
            //        MessageBox.Show("Ajout réussi.");
            //    }
            //    else { MessageBox.Show("Ajout impossible."); }
            //    AfficherLesDonneesDeRencontreAModifier(rencontreAModifier);
            //    int idScore = controleur.CreerLienJouteScoreJoueurDansBD(rencontreAModifier);
            //}
        }

        private List<Joueur> AjouterJoueursDansPartie()
        {
            List<Joueur> joueurs = new List<Joueur>();

            Joueur joueur1 = comboBoxJoueur1.SelectedItem as Joueur;
            if (joueur1 != null && joueur1.Nom.Replace(" ", "") != "(vide)") { joueurs.Add(joueur1); }

            Joueur joueur2 = comboBoxJoueur2.SelectedItem as Joueur;
            if (joueur2 != null && joueur2.Nom.Replace(" ", "") != "(vide)") { joueurs.Add(joueur2); }

            Joueur joueur3 = comboBoxJoueur3.SelectedItem as Joueur;
            if (joueur3 != null && joueur3.Nom.Replace(" ", "") != "(vide)") { joueurs.Add(joueur3); }

            Joueur joueur4 = comboBoxJoueur4.SelectedItem as Joueur;
            if (joueur4 != null && joueur4.Nom.Replace(" ", "") != "(vide)") { joueurs.Add(joueur4); }

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
            int heure = heureOk ? ConvertirComboBoxHeure() : 0;
            heureOk &= heure > 12;
            bool pupitreOk = comboBoxPupitre.SelectedItem != null;
            bool rondeOk = comboBoxRonde.SelectedItem != null;
            int nbJoueurs = AjouterJoueursDansPartie().Count;
            bool joueursOk = nbJoueurs > 2;

            bool ajoutOk = false;

            string erreurDate = string.Empty;
            string erreurHeure = string.Empty;
            string erreurPupitre = string.Empty;
            string erreurRonde = string.Empty;
            string erreurJoueurs = string.Empty;
            string erreurNbJoueurs = string.Empty;

            if (!heureOk)
            {
                erreurHeure = "Choisir une heure pour la session.\n";
            }
            if (!pupitreOk || !rondeOk)
            {
                erreurPupitre = ("Impossible d'ajouter une nouvelle session sans table(s) ni partie(s).\n");
            }
            if (!joueursOk)
            {
                if (nbJoueurs == 0)
                {
                    erreurJoueurs = ("Ajouter des joueurs à la session.\n");
                }
                else if (nbJoueurs <= 2)
                {
                    erreurNbJoueurs ="Le nombre de joueurs est insuffisant (3 min.)\n";
                }
            }
            if (!(dateOk && heureOk && pupitreOk && rondeOk && joueursOk))
            {
                MessageBox.Show("Erreur de données :\n\n" + erreurHeure + erreurPupitre + erreurJoueurs + erreurNbJoueurs);
            }
            else
            {
                ajoutOk = controleur.DemandeDeConfirmation("Prêt à créer une session avec les joueurs affichés?");
            }
            return ajoutOk;
        }

        private void buttonEffacer_Click(object sender, EventArgs e)
        {
            if (modificationAFaire == ajouterNouvelleSession)
            {
                DialogResult approuveChangement = MessageBox.Show("Effacer toutes les données ?\nConfirmer...", "Attention!", MessageBoxButtons.OKCancel);
                if (approuveChangement == DialogResult.Cancel) return;
                dateTimePickerNewSession.Value = TrouverMercrediProchain();
                comboBoxHeure.SelectedIndex = -1;
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
            MettreAJourPlacesAuPupitre();
        }
    }
}
