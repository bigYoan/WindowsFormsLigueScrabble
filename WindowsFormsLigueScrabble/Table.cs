using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsLigueScrabble
{
    internal class Table
    {
        int iDTable;
        int noTable;
        string reglesTable;

        public int IDTable { get => iDTable; set => iDTable = value; }
        public int NoTable { get => noTable; set => noTable = value; }
        public string ReglesTable { get => reglesTable; set => reglesTable = value; }
    }
}
