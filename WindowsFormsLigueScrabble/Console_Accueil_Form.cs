using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;


namespace WindowsFormsLigueScrabble
{
    public partial class FormConsole : Form
    {
        Controleur controleur = new Controleur();
        List<Joueur> joueurs = new List<Joueur>();
        string utilisateur;

        public FormConsole()
        {
            InitializeComponent();
            utilisateur = "SU_Scrabble";
        }
        private void FormConsole_Load(object sender, EventArgs e)
        {
            EssayerConnexionBD(utilisateur);
            this.Shown += new EventHandler(FormConsole_Shown);
        }
        private void EssayerConnexionBD(string utilisateur)
        {
            try
            {
                string maConnexionString = "Server=localhost;Database=Ligue_Scrabble;Uid="+utilisateur+";Pwd=ABCD";
                MySqlConnection sqlConnexion = new MySqlConnection(maConnexionString);
                sqlConnexion.Open();
                sqlConnexion.Close();
                //MessageBox.Show("Connecté à la base de données");
                labelConnexion.Text += utilisateur + " connecté.";
            }
            catch (Exception)
            {
                MessageBox.Show("Connexion échouée");
                //throw;
            }
            
        }


        private void buttonJoueurs_Click(object sender, EventArgs e)
        {
            JoueurForm ajoutJoueurForm = new JoueurForm(controleur);
            ajoutJoueurForm.ShowDialog();
        }

        private void timerDelai_Tick(object sender, EventArgs e)
        {
            timerDelai.Stop();
            timerFlash.Stop();
            labelConnexion.Visible = true;
        }

        private void timerFlash_Tick(object sender, EventArgs e)
        {
            labelConnexion.Visible = !labelConnexion.Visible;
        }

        private void FormConsole_Shown(Object sender, EventArgs e)
        {
            timerFlash.Enabled = true;
            timerFlash.Start();
            timerDelai.Enabled = true;
            timerDelai.Start();
        }

        private void buttonRencontres_Click(object sender, EventArgs e)
        {
            RencontreForm rencontreForm = new RencontreForm(controleur);
            rencontreForm.ShowDialog();
        }

        private void buttonQuitter_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonParties_Click(object sender, EventArgs e)
        {
            PartieForm partieForm = new PartieForm();
            partieForm.ShowDialog();
        }

        private void buttonTables_Click(object sender, EventArgs e)
        {
            AfficherMessageNonDisponible();
        }

        private void AfficherMessageNonDisponible()
        {
            MessageBox.Show("Cette fonctionnalité n'est pas disponible...", "En construction.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void buttonStats_Click(object sender, EventArgs e)
        {
            AfficherMessageNonDisponible();
        }

        private void buttonScores_Click(object sender, EventArgs e)
        {
            AfficherMessageNonDisponible();
        }
    }
}
