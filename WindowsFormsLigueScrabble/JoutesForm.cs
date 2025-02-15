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
    internal partial class JoutesForm : Form
    {
        Controleur controleur;
        public JoutesForm(Controleur controleurX)
        {
            InitializeComponent();
            controleur = controleurX;
        }
        private void JoutesForm_Load(object sender, EventArgs e)
        {
            RendreInvisibleTousDataGrid();
        }

        private void RendreInvisibleTousDataGrid()
        {
            dataGridViewJoueurs.Visible = false;
            dataGridViewJoutes.Visible = false;
        }

        private void sToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void joueurToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dataGridViewJoueurs.Visible = true;
            dataGridViewJoueurs.DataSource = null;
            dataGridViewJoueurs.DataSource = controleur.GererJoueur(null, controleur.lister, "ORDER BY Nom");
            dataGridViewJoueurs.RowHeadersVisible = false;
            //dataGridViewJoueurs.Columns["IdJoueur"].Visible = false;
            dataGridViewJoueurs.Columns["CacherNom"].Visible = false;
            dataGridViewJoueurs.Columns["Pseudo"].Visible = false;
            dataGridViewJoueurs.Columns["Nom"].HeaderText = "Nom du joueur";
            dataGridViewJoueurs.Columns["CodeJoueur"].HeaderText = "Code du joueur";
            //dataGridViewJoueurs.Columns["IdJoueur"].Visible = false;
            dataGridViewJoueurs.Columns["NoFQCSF"].Visible = false;
            dataGridViewJoueurs.Columns["FQCSF"].Visible = false;
            dataGridViewJoueurs.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void dataGridViewJoueurs_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridViewJoueurs.Visible = false;
            int idJoueurChoisi = int.Parse(dataGridViewJoueurs["IdJoueur", dataGridViewJoueurs.CurrentRow.Index].Value.ToString());
            string nomJoueurChoisi = dataGridViewJoueurs["Nom", dataGridViewJoueurs.CurrentRow.Index].Value.ToString();

            AfficherPartiesJoueurChoisi(idJoueurChoisi, nomJoueurChoisi);
        }

        private void AfficherPartiesJoueurChoisi(int idJoueurChoisi, string nomJoueurChoisi)
        {
            RendreInvisibleTousDataGrid();
            dataGridViewJoutes.Visible = true;
            FormatterDataGridViewJoutes();
            string commande = "WHERE Id_Joueur = " + idJoueurChoisi;
            List<Partie> parties = new List<Partie>();
            List<Partie> partiesBidon = new List<Partie>();
            List<LienJouteScoreJoueur> lienJouteScoreJoueurs = controleur.ListerLiensJouteScoreJoueur(null, commande);
            foreach (var lienChoisi in lienJouteScoreJoueurs)
            {
                partiesBidon = controleur.ListerJoute(lienChoisi.IdJoute);
                parties.Add(partiesBidon[0]);
            }
            dataGridViewJoutes.DataSource = parties;
            dataGridViewJoutes.Visible = true;
            dataGridViewJoutes.Rows[0].HeaderCell.Value = nomJoueurChoisi;
        }

        private void FormatterDataGridViewJoutes()
        {
            dataGridViewJoutes.RowHeadersWidth = 100;
            
        }
    }
}
