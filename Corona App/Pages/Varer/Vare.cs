using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Corona_App.Pages.Varer
{
    public enum Kategoris { Frugt, Grøntsager, Kartofler_løg, Færdig_salater, Smoothies }
    public class Vare
    {
        //private int _vareNr;
        //private int _pris;
        //private string _navn;
        //private string _katagori;

        //public Vare()
        //{

        //}
        //public Vare(int vareNr, int pris, string navn, string katagori)
        //{
        //    _vareNr = vareNr;
        //    _pris = pris;
        //    _navn = navn;
        //    _katagori = katagori;
        //}

        [Required]
        [RegularExpression(@"\d*", ErrorMessage = "Det må kun være tal.")]
        [Range(1, int.MaxValue, ErrorMessage = "Skal være minimum 1 tegn.")]
        public int VareNr
        {
            get;
            set;
        }
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Det må ikke være 0 eller negativ værdi.")]
        public int Pris
        {
            get;
            set;
        }
        [Required]
        [RegularExpression(@"\D*", ErrorMessage = "Der må ikke være tal i navnet.")]
        [StringLength(25, MinimumLength = 1, ErrorMessage = "Skal være minimum 1 tegn og max 25.")]
        public string Navn
        {
            get;
            set;
        }
        [Required]
        // todo selector?
        public Kategoris Kategori
        {
            get;
            set;
        }

    }
}