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


        public List<BrugerInfo> Hent() //Læser json filen og henter information fra den
        {
            return BrugerCRUD.JsonFileRead(_filename);
        }


        public int AntalBrugere
        {
            get { return Hent().Count; }
        }
        public void OnGet()
        {

        }
    }
}