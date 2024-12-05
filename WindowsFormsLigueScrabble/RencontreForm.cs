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
        }

        private void RemplirComboBoxRencontre()
        {
            comboBoxSession.DataSource = null;
            comboBoxSession.DataSource = controleur.GererRencontres(null, controleur.lister, orderBy);
            comboBoxSession.SelectedIndex = 0;
            labelTotalSessions.Text = comboBoxSession.Items.Count.ToString() + " rencontres total.";
        }

        private void buttonAjouterSession_Click(object sender, EventArgs e)
        {
            if (comboBoxSession.SelectedItem != null)
            {
                dateTimePickerNewSession.Visible = true;

                Rencontre nouvelleSession = new Rencontre();
                nouvelleSession.DateDeJeu = dateTimePickerNewSession.Value;
                nouvelleSession.DateNouvelle = dateTimePickerNewSession.Value;
                controleur.GererRencontres(nouvelleSession, controleur.ajouter, orderBy);
                RemplirComboBoxRencontre();
                dateTimePickerNewSession.Visible = false;
            }
        }
    }
}
