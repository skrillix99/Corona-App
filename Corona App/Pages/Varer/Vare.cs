using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Corona_App.Pages.Varer
{
    public abstract class Vare
    {
        public int VareNr
        {
            get;
            set;
        }
        public int Pris
        {
            get;
            set;
        }
        public string Navn
        {
            get;
            set;
        }
        public string Kategori
        {
            get;
            set;
        }

}
}
