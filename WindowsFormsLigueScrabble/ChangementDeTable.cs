using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsLigueScrabble
{
    internal class ChangementDeTable
    {
        int idNewTable;
        int idOldTable;
        bool tableChangee;

        public int IdNewTable { get => idNewTable; set => idNewTable = value; }
        public int IdOldTable { get => idOldTable; set => idOldTable = value; }
        public bool TableChangee { get => tableChangee; set => tableChangee = value; }
    }
}
