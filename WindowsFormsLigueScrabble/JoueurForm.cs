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
    public partial class JoueurForm : Form
    {
        Controleur controleur;
        DB_Manager db_manager = new DB_Manager();
        List<Joueur> joueurs = new List<Joueur>();

        public JoueurForm(Controleur controleurX)
        {
            InitializeComponent();
            controleur = controleurX;
        }

        private void buttonAjouterJoueur_Click(object sender, EventArgs e)
        {
            string IdCode = textBoxIdCode.Text;
            string nom = textBoxNom.Text;
            string pseudo = textBoxPseudo.Text;
            Joueur nouveauJoueur = new Joueur(IdCode, nom, pseudo);
            joueurs.Add(nouveauJoueur);
            dataGridViewAjoutJoueur.DataSource = null;
            dataGridViewAjoutJoueur.DataSource = controleur.AjouterJoueur(nouveauJoueur, 1);
            
        }

        private void textBoxIdCode_TextChanged(object sender, EventArgs e)
        {

        }

        private void buttonTerminer_Click(object sender, EventArgs e)
        {
            db_manager.AjouterJoueurDansBD(joueurs);
            this.Close();
        }

        private void AjoutJoueurForm_Load(object sender, EventArgs e)
        {
            dataGridViewAjoutJoueur.DataSource = controleur.AjouterJoueur(null, 0); //0 : rien ajouter    1 : ajouter
        }
    }
}
