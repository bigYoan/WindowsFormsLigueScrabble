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
        DateTime idSession;

        public int IdTable { get => idTable; set => idTable = value; }
        public DateTime IdSession { get => idSession; set => idSession = value; }
    }
}
