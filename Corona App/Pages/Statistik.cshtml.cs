using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Corona_App.Pages.Kunder.Bruger;
using Corona_App.Pages.Kunder;

namespace Corona_App.Pages
{
    public class StatistikModel : PageModel
    {
        private string _filename = @"wwwroot\Kunde.json";
        private string _bestilling = @"wwwroot\BestillingJson.json";


        public List<BrugerInfo> Hent() //Læser json filen omkring brugerne og henter information fra den
        {
            return BrugerCRUD.JsonFileRead(_filename);
        }

        public List<BrugerInfo> HentBesilling()
        {
            return BrugerCRUD.JsonFileRead(_bestilling);
        }


        public int AntalBrugere
        {
            get { return Hent().Count; }
        }

        public int AntalBestillinger
        {
            get { return HentBesilling().Count; }
        }
        public void OnGet()
        {

        }
    }
}