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
            comboBoxRencontres.DataSource = null;
            comboBoxRencontres.DataSource = controleur.GererRencontres(null, controleur.lister, orderBy);
        }
    }
}
