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

        public FormConsole()
        {
            InitializeComponent();
        }

        private void buttonConnect_Click(object sender, EventArgs e)
        {
            try
            {
                string maConnexionString = "Server=localhost;Database=Ligue_Scrabble;Uid=SU_Scrabble;Pwd=ABCD";
                MySqlConnection sqlConnexion = new MySqlConnection(maConnexionString);
                sqlConnexion.Open();
                sqlConnexion.Close();
                MessageBox.Show("Connecté");
            }
            catch (Exception)
            {
                MessageBox.Show("Connexion échouée");
                //throw;
            }
            
        }

        private void buttonAjouterJoueur_Click(object sender, EventArgs e)
        {
            AjoutJoueurForm ajoutJoueurForm = new AjoutJoueurForm(controleur);
            ajoutJoueurForm.ShowDialog();
        }
    }
}
