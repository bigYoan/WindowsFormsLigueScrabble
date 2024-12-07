using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsLigueScrabble
{
    internal class LienTableSession
    {
        int idTable;
        int idSession;

        public int IdTable { get => idTable; set => idTable = value; }
        public int IdSession { get => idSession; set => idSession = value; }
    }
}
