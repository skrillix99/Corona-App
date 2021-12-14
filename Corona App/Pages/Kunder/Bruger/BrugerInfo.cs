using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Corona_App.Pages.Kunder //Lavet Af Cecilie
{
    public enum kommuner { Roskilde, Greve, Lejre }
    public class BrugerInfo
    {
        private int _id;
        private string _navn;
        private string _mobilnummer;
        private string _adresse;
        private string _adgangskode;
        private string _email;

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        //validering på navn og de andre properties.
        [Required]
        [RegularExpression(@"\D*", ErrorMessage = "Navn skal skrives med bogstaver")]
        [MinLength(2, ErrorMessage = "Skal indeholde minimum 2 tegn")]
        public string Navn
        {
            get { return _navn; }
            set { _navn = value; }
        }

        [Required]
        [RegularExpression(@"\w*", ErrorMessage = "Tlf nummer skal skrives med tal")]
        [MinLength(8, ErrorMessage = "Dit nummer skal være 8 tegn")]
        [MaxLength(8)]
        public string Mobilnummer
        {
            get { return _mobilnummer; }
            set { _mobilnummer = value; }
        }

        [Required]
       // [RegularExpression(@"^[0-9]+\s+([a-zA-Z]+|[a-zA-Z]+\s[a-zA-Z]+)$", ErrorMessage ="Ugyldig Adresse")]
        [MinLength(5, ErrorMessage = "Skal indeholde vejnavn og nummer")]
        [MaxLength(50)]
        public string Adresse
        {
            get { return _adresse; }
            set { _adresse = value; }
        }
        [Required]
        [MinLength(8, ErrorMessage = "Skal indeholde minumum 8 tegn")]
        [DataType(DataType.Password)]
        public string Adgangskode
        {
            get { return _adgangskode; }
            set { _adgangskode = value; }
        }

        //validering med at der skal være noget før @ og noget efter @.
        [Required]
        [RegularExpression(@"[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,}$", ErrorMessage = "Ugyldig email")]
        [MinLength(6, ErrorMessage ="Din email skal indeholde minimum 6 tegn")]
        [EmailAddress]
        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }

        public kommuner Kommune
        {
            get;
            set;
        }

        public BrugerInfo()
        {

        }

        //konstruktør med parameter
        public BrugerInfo(string Navn, string Mobilnummer, string Adresse, string Adgangskode, string Email)
        {
            _navn = Navn;
            _mobilnummer = Mobilnummer;
            _adresse = Adresse;
            _adgangskode = Adgangskode;
            _email = Email;
        }

        public string Tostring()
        {
            return $"Navn = {Navn}, Mobilnummer = {Mobilnummer}, Adresse = {Adresse}, Adgangskode = {Adgangskode}, Email = {Email}";
        }
    }
}