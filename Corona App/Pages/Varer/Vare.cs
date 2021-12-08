using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Corona_App.Pages.Varer
{
    public enum Katagoris { Frugt, Grøntsager, Kartofler_løg, Færdig_salater, Smoothies }

    public class Vare : IComparable<Vare>
    {

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
        public Katagoris Kategori
        {
            get;
            set;
        }

        public string IdName
        {
            get;
            set;
        }
        public string IdNameCol
        {
            get;
            set;
        }

        public int CompareTo(Vare other)
        {
            return Kategori - other.Kategori;
        }
    }
}