using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Corona_App.Pages.Varer
{
    public class Vare
    {
        private int _vareNr;
        private int _pris;
        private string _navn;
        private string _katagori;

        public Vare()
        {

        }
        public Vare(int vareNr, int pris, string navn, string katagori)
        {
            _vareNr = vareNr;
            _pris = pris;
            _navn = navn;
            _katagori = katagori;
        }

        public int VareNr
        {
            get => _vareNr;
            set => _vareNr = value;
        }
        public int Pris
        {
            get => _pris;
            set => _pris = value;
        }
        public string Navn
        {
            get => _navn;
            set => _navn = value;
        }
        public string Kategori
        {
            get => _katagori;
            set => _katagori = value;
        }

}
}
