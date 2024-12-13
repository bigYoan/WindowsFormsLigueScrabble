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
    internal partial class ScoresForm : Form
    {
        Controleur controleur;
        Rencontre rencontreAjoutScores;
        public ScoresForm(Controleur controleurX, Rencontre rencontreAAjouterScoresX)
        {
            InitializeComponent();
            controleur = controleurX;
            rencontreAjoutScores = rencontreAAjouterScoresX;
        }
    }
}
