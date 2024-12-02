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
    public partial class AjoutJoueurForm : Form
    {
        Controleur controleur;
        List<Joueur> joueurs = new List<Joueur>();

        public AjoutJoueurForm(Controleur controleurX)
        {
            InitializeComponent();
            controleur = controleurX;
        }

        private void buttonAjouterJoueur_Click(object sender, EventArgs e)
        {
            char IdCode = textBoxIdCode.Text[0];
            string nom = textBoxNom.Text;
            string pseudo = textBoxPseudo.Text;
            Joueur nouveauJoueur = new Joueur(IdCode, nom, pseudo);
            dataGridViewAjoutJoueur.DataSource = null;
            dataGridViewAjoutJoueur.DataSource = controleur.AjouterJoueur(nouveauJoueur, 1);
            
        }

        private void textBoxIdCode_TextChanged(object sender, EventArgs e)
        {

        }

        private void buttonTerminer_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AjoutJoueurForm_Load(object sender, EventArgs e)
        {
            dataGridViewAjoutJoueur.DataSource = controleur.AjouterJoueur(null, 0); //0 : rien ajouter    1 : ajouter
        }
    }
}
