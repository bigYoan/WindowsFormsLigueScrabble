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
    internal partial class RencontreForm : Form
    {
        Controleur controleur;
        string orderBy = "ORDER BY Date_Rencontre DESC";
        public RencontreForm(Controleur controleurX)
        {
            InitializeComponent();
            controleur = controleurX;
        }

        private void RencontreForm_Load(object sender, EventArgs e)
        {
            RemplirComboBoxRencontre();
            dateTimePickerNewSession.Value = TrouverProchainMercredi();
        }

        private DateTime TrouverProchainMercredi()
        {
            DateTime aujourdhui = DateTime.Today;
            // The (... + 7) % 7 ensures we end up with a value in the range [0, 6]
            int nombreJoursDIciProchainMercredi = ((int)DayOfWeek.Wednesday - (int)aujourdhui.DayOfWeek + 7) % 7;
            DateTime mercrediProchain = aujourdhui.AddDays(nombreJoursDIciProchainMercredi);
            return mercrediProchain;
        }

        private void RemplirComboBoxRencontre()
        {
            List<Rencontre> listeBidon = controleur.GererRencontres(null, controleur.lister, orderBy);
            List<RencontresDataGrid> listeDataGrid = new List<RencontresDataGrid>();
            foreach (var rencontreAAjouter in listeBidon)
            {
                RencontresDataGrid tess = new RencontresDataGrid();
                tess.RencontreDataGrid = rencontreAAjouter;
                tess.NombreJoueurs = 3;
                tess.Table = 2;
                tess.Homologation = true;
                tess.ScoreGagnant = 345;
                tess.Ronde = 1;
                tess.Gagnant = "Marc";
                listeDataGrid.Add(tess);
            }
           
            dataGridViewSessions.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewSessions.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewSessions.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewSessions.DataSource = listeDataGrid;
            dataGridViewSessions.Columns["RencontreDataGrid"].HeaderText = "Date";
            dataGridViewSessions.Columns["jourRencontre"].HeaderText = "Jour";
            dataGridViewSessions.Columns["heureRencontre"].HeaderText = "Heure";
            dataGridViewSessions.Columns["nombreJoueurs"].HeaderText = "Nombre\nJoueurs"; 
            dataGridViewSessions.Columns["scoreGagnant"].HeaderText = "Score";
            dataGridViewSessions.Columns["homologation"].HeaderText = "FQCSF\nhomologué";

            dataGridViewSessions.RowHeadersVisible = false;
            dataGridViewSessions.ReadOnly = true;
            


            comboBoxSession.DataSource = null;
            //comboBoxSession.DataSource = listeDataGrid;
            comboBoxSession.DataSource = controleur.GererRencontres(null, controleur.lister, orderBy);
            comboBoxSession.SelectedIndex = 0;
            labelTotalSessions.Text = comboBoxSession.Items.Count.ToString() + " rencontres total.";
        }

        private void buttonAjouterSession_Click(object sender, EventArgs e)
        {
            EditionRencontreForm editionRencontreForm = new EditionRencontreForm(controleur);
            editionRencontreForm.ShowDialog();
            //if (comboBoxSession.SelectedItem != null)
            //{
            //    dateTimePickerNewSession.Visible = true;

            //    Rencontre nouvelleSession = new Rencontre();
            //    nouvelleSession.DateDeJeu = dateTimePickerNewSession.Value;
            //    nouvelleSession.DateNouvelle = dateTimePickerNewSession.Value;
            //    controleur.GererRencontres(nouvelleSession, controleur.ajouter, orderBy);
            //    RemplirComboBoxRencontre();
            //    dateTimePickerNewSession.Visible = false;
            //}
        }

        private void buttonSupprimerSession_Click(object sender, EventArgs e)
        {

        }

        private void buttonTerminer_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
