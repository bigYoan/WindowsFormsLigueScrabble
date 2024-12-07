using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsLigueScrabble
{
    internal class LiensSessionTablePartie
    {
        int idSession;
        DateTime dateSession;
        int idTable;
        int noTable;
        int idPartie;
        int noPartie;

        public int IdSession { get => idSession; set => idSession = value; }
        public DateTime DateSession { get => dateSession; set => dateSession = value; }
        public int IdTable { get => idTable; set => idTable = value; }
        public int NoTable { get => noTable; set => noTable = value; }
        public int IdPartie { get => idPartie; set => idPartie = value; }
        public int NoPartie { get => noPartie; set => noPartie = value; }
    }
}
