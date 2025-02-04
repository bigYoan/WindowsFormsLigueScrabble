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
        public static ToolTip toolTipActionne = new ToolTip();
        string orderBy = "ORDER BY session.Date_Session DESC, _Table.No_Table";
        public RencontreForm(Controleur controleurX)
        {
            InitializeComponent();
            controleur = controleurX;
        }

        private void RencontreForm_Load(object sender, EventArgs e)
        {
            RemplirDataGridViewRencontre();
        }

        private void RemplirDataGridViewRencontre()
        {
            dataGridViewSessions.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewSessions.ColumnHeadersDefaultCellStyle.Font = new Font("Verdana", 9);
            dataGridViewSessions.DefaultCellStyle.Font = new Font("Verdana", 12);
            dataGridViewSessions.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewSessions.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewSessions.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            dataGridViewSessions.DataSource = controleur.rencontres;
            dataGridViewSessions.Columns["Table"].DisplayIndex = 3;
            dataGridViewSessions.Columns["IdSession"].Visible = false;
            dataGridViewSessions.Columns["Id_Table"].Visible = false;
            //dataGridViewSessions.Columns["Id_Ronde"].Visible = false;
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
            string totalRencontres = " rencontres total.";
            if (controleur.rencontres.Count == 0) totalRencontres = "aucune rencontre.";
            if (controleur.rencontres.Count == 1) totalRencontres = "1 rencontre.";
            else totalRencontres = controleur.rencontres.Count.ToString() + " rencontres.";
            labelTotalSessions.Text = totalRencontres;
        }
        private void buttonAjouterSession_Click(object sender, EventArgs e)
        {
            Rencontre rencontreVide = new Rencontre();
            EditionRencontreForm editionRencontreForm = new EditionRencontreForm(controleur, null);
            editionRencontreForm.ShowDialog();
            RemplirDataGridViewRencontre();
        }

        private void buttonSupprimerSession_Click(object sender, EventArgs e)
        {
            Rencontre rencontreASupprimer = new Rencontre();
            if (controleur.rencontres.Count == 0) return;
            rencontreASupprimer.IdSession = (int)dataGridViewSessions["IdSession", dataGridViewSessions.CurrentRow.Index].Value;
            Rencontre dateSessionASupprimer = (Rencontre)dataGridViewSessions["Session", dataGridViewSessions.CurrentRow.Index].Value;
            int partieASupprimer = (int)dataGridViewSessions["Id_Ronde", dataGridViewSessions.CurrentRow.Index].Value;
            int rondeASupprimer = (int)dataGridViewSessions["Ronde", dataGridViewSessions.CurrentRow.Index].Value;
            int noTableASupprimer = (int)dataGridViewSessions["Table", dataGridViewSessions.CurrentRow.Index].Value;
            int tableASupprimer = (int)dataGridViewSessions["Id_Table", dataGridViewSessions.CurrentRow.Index].Value;
            string rubrique = "Supprimer la session du " + dateSessionASupprimer.DateNouvelle.ToString("M") 
                                + ", Ronde : " + rondeASupprimer
                                + ", Table : " + tableASupprimer
                                + " ?\n";
            bool supprimerOk = controleur.DemandeDeConfirmation(rubrique);
            if (!supprimerOk) { return; }
            List<RencontresDataGrid> listeSessions = controleur.GererRencontres(rencontreASupprimer, tableASupprimer, partieASupprimer, null, controleur.supprimer, orderBy);
            RemplirDataGridViewRencontre();
        }

        private void buttonModifierSession_Click(object sender, EventArgs e)
        {
            Rencontre rencontreAModifier = new Rencontre();
            if (controleur.rencontres.Count == 0) return;
            rencontreAModifier = (Rencontre)dataGridViewSessions["Session", dataGridViewSessions.CurrentRow.Index].Value;
            rencontreAModifier.IdSession = (int)dataGridViewSessions["IdSession", dataGridViewSessions.CurrentRow.Index].Value;
            rencontreAModifier.Id_Joute = (int)dataGridViewSessions["Id_Ronde", dataGridViewSessions.CurrentRow.Index].Value;
            rencontreAModifier.Id_Table = (int)dataGridViewSessions["Id_Table", dataGridViewSessions.CurrentRow.Index].Value;
            rencontreAModifier.NoTable = (int)dataGridViewSessions["table", dataGridViewSessions.CurrentRow.Index].Value;
            rencontreAModifier.NoJoute = (int)dataGridViewSessions["ronde", dataGridViewSessions.CurrentRow.Index].Value;
            int nombreDeJoueurs = (int)dataGridViewSessions["NombreJoueurs", dataGridViewSessions.CurrentRow.Index].Value;
            if (nombreDeJoueurs != 0)
            {
                string rubrique = "Vous allez être dirigé vers la page d'ajout de scores.";
                if (!controleur.DemandeDeConfirmation(rubrique)) return;
                ScoresForm scoresForm = new ScoresForm(controleur, rencontreAModifier);
                scoresForm.ShowDialog();
                RemplirDataGridViewRencontre();
                return;
            }
            EditionRencontreForm editionRencontreForm = new EditionRencontreForm(controleur, rencontreAModifier);
            editionRencontreForm.ShowDialog();
            RemplirDataGridViewRencontre();
        }
        private void buttonTerminer_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void radioButtonAny_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonSessionDecroissant.Checked) orderBy = "ORDER BY session.Date_Session DESC, _Table.No_Table";
            if (radioButtonSessionCroissant.Checked) orderBy = "ORDER BY session.Date_Session, _Table.No_Table";
            if (radioButtonFQCSF.Checked) orderBy = "";
            dataGridViewSessions.DataSource = null;
            dataGridViewSessions.DataSource = controleur.GererRencontres(null, 0, 0, null, controleur.lister, orderBy);
            RemplirDataGridViewRencontre ();
        }
        private void buttonConfirmMouseHover(object sender, EventArgs e)
        {
            toolTipActionne.SetToolTip(buttonAjouterSession, "Ajouter nouvelle session");
            toolTipActionne.SetToolTip(buttonSupprimerSession, "Supprimer session");
            toolTipActionne.SetToolTip(buttonModifierSession, "Ajouter joueurs");
        }

        
    }
}
