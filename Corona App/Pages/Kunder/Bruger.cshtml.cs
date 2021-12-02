using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Corona_App.Pages.Shared.Kunder
{
    public class BrugerModel : PageModel
    {
        private string _navn;
        private string _tlfnummer;
        private string _adresse;
        private string _adgangskode;
        private string _email;

        public string Navn
        {
            get { return _navn; }
            set { _navn = value; }
        }

        public string TlfNummer
        {
            get { return _tlfnummer; }
            set { _tlfnummer = value; }
        }

        public string Adresse 
        {
            get { return _adresse; }
            set { _adresse = value; } 
        }

        public string Adgangskode 
        {
            get { return _adgangskode; }
            set { _adgangskode = value; } 
        }

        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }

        public BrugerModel()
        {

        }

        public BrugerModel(string Navn, string Tlfnummer, string Adresse, string Adgangskode, string Email)
        {
            _navn = Navn;
            _tlfnummer = Tlfnummer;
            _adresse = Adresse;
            _adgangskode = Adgangskode;
            _email = Email;
        }

        public string Tostring()
        {
            return $"Navn = {Navn}, Tlfnummer = {TlfNummer}, Adresse = {Adresse}, Adgangskode = {Adgangskode}, Email = {Email}";
        }

        public void OnGet()
        {

        }

        public void OnPost()
        {

        }
    }
}
