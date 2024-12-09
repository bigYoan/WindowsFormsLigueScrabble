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
        string orderBy = "ORDER BY session.Date_Session DESC";
        public RencontreForm(Controleur controleurX)
        {
            InitializeComponent();
            controleur = controleurX;
        }

        private void RencontreForm_Load(object sender, EventArgs e)
        {
            RemplirDataGridViewRencontre();
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

        private void RemplirDataGridViewRencontre()
        {
            List<RencontresDataGrid> listeSessions = new List<RencontresDataGrid>();
            //if (listeRecue == null)
            //{
            //    listeSessions = controleur.GererRencontres(null, 0, 0, null, controleur.lister, orderBy);
            //}
            //else listeSessions = listeRecue;



            dataGridViewSessions.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewSessions.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewSessions.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewSessions.DataSource = controleur.rencontres;
            //dataGridViewSessions.Columns["IdSession"].Visible = false; 
            dataGridViewSessions.Columns["Session"].HeaderText = "Date";
            dataGridViewSessions.Columns["jourRencontre"].HeaderText = "Jour";
            dataGridViewSessions.Columns["heureRencontre"].HeaderText = "Heure";
            dataGridViewSessions.Columns["nombreJoueurs"].HeaderText = "Nombre\nJoueurs"; 
            dataGridViewSessions.Columns["scoreGagnant"].HeaderText = "Score";
            dataGridViewSessions.Columns["homologation"].HeaderText = "FQCSF\nhomologué";
            dataGridViewSessions.Columns["nombreJoueurs"].DefaultCellStyle.Format = "###.##";
            dataGridViewSessions.Columns["Table"].DefaultCellStyle.Format = "###.##";
            dataGridViewSessions.Columns["Ronde"].DefaultCellStyle.Format = "###.##";
            dataGridViewSessions.Columns["scoreGagnant"].DefaultCellStyle.Format = "###.##";


            dataGridViewSessions.RowHeadersVisible = false;
            dataGridViewSessions.ReadOnly = true;

            comboBoxSession.DataSource = null;
            comboBoxSession.DataSource = controleur.GererRencontres(null, 0, 0, null, controleur.lister, orderBy);
            comboBoxSession.SelectedIndex = 0;
            labelTotalSessions.Text = comboBoxSession.Items.Count.ToString() + " rencontres total.";
        }

        private void buttonAjouterSession_Click(object sender, EventArgs e)
        {
            EditionRencontreForm editionRencontreForm = new EditionRencontreForm(controleur);
            editionRencontreForm.ShowDialog();
            RemplirDataGridViewRencontre();
        }

        private void buttonSupprimerSession_Click(object sender, EventArgs e)
        {
            Rencontre rencontreASupprimer = new Rencontre();
            rencontreASupprimer.IdSession = (int)dataGridViewSessions["IdSession", dataGridViewSessions.CurrentRow.Index].Value;
            int partieASupprimer = (int)dataGridViewSessions["Id_Ronde", dataGridViewSessions.CurrentRow.Index].Value;
            int tableASupprimer = (int)dataGridViewSessions["Id_Table", dataGridViewSessions.CurrentRow.Index].Value;
            int lignesAffectees = 0;
            List<RencontresDataGrid> listeSessions = controleur.GererRencontres(rencontreASupprimer, tableASupprimer, partieASupprimer, null, controleur.supprimer, orderBy);
            RemplirDataGridViewRencontre();

        }

        private void buttonTerminer_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
