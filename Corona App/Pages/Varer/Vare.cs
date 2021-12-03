using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

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

        [Required]
        [RegularExpression(@"\W*", ErrorMessage ="Det må kun være tal.")]
        [MinLength(1, ErrorMessage ="Skal være minimum 1 tegn.")]
        public int VareNr
        {
            get => _vareNr;
            set => _vareNr = value;
        }
        [Required]
        [Range(1, int.MaxValue, ErrorMessage ="Det må ikke være en negativ værdi.")]
        [MinLength(1, ErrorMessage ="Skal være minimum 1 tegn.")]
        public int Pris
        {
            get => _pris;
            set => _pris = value;
        }
        [Required]
        [RegularExpression(@"\D*", ErrorMessage ="Der må ikke være tal i navnet.")]
        [MinLength(1, ErrorMessage ="Skal være minimum 1 tegn.")]
        public string Navn
        {
            get => _navn;
            set => _navn = value;
        }
        [Required]
        [MinLength(1, ErrorMessage ="Skal være minimum 1 tegn.")]
        // todo selector?
        public string Kategori
        {
            get => _katagori;
            set => _katagori = value;
        }

}
}
