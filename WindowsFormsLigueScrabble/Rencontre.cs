using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsLigueScrabble
{
    internal class Rencontre
    {
        int idSession;
        DateTime dateDeJeu;
        DateTime dateNouvelle;
        int id_Table;
        int id_Joute;
        int noTable;
        int noJoute;
        //int heureNouvelle;

        public DateTime DateDeJeu { get => dateDeJeu; set => dateDeJeu = value; }
        public DateTime DateNouvelle { get => dateNouvelle; set => dateNouvelle = value; }
        public int IdSession { get => idSession; set => idSession = value; }
        public int Id_Table { get => id_Table; set => id_Table = value; }
        public int Id_Joute { get => id_Joute; set => id_Joute = value; }
        public int NoTable { get => noTable; set => noTable = value; }
        public int NoJoute { get => noJoute; set => noJoute = value; }

        //public int HeureNouvelle { get => heureNouvelle; set => heureNouvelle = value; }

        public override string ToString()
        {
            return dateDeJeu.ToString("D");
        }
    }
}
