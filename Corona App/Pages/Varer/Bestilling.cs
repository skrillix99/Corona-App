using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using System.Text.Json;
using System.ComponentModel.DataAnnotations;
using Corona_App.Pages.Kunder;

namespace Corona_App.Pages.Varer
{
    public class Bestilling : IComparable<Vare>
    {

        public Bestilling(int vareNr)
        {
            VareNr = vareNr;
            Pris = 0;
            Navn = "";
            Kategori = 0;
        }
        public int Id
        {
            get; set;
        }

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
        [Required]
        public kommuner lokation
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