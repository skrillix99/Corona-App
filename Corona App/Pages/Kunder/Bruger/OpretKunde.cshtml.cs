using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Corona_App.Pages.Kunder;
using Corona_App.Pages;

namespace Corona_App.Pages.Kunder.Bruger //Lavet Af Cecilie
{
    public class OpretKundeModel : PageModel
    {

        private string _filename = @"wwwroot\Kunde.json"; //Finder lokationen af json filen og gør vi kan komme i kontakt med den

        [BindProperty]
        public BrugerInfo b { get; set; }

        public string ErrorMsg { get; set; }

        private IKunde _kunde;

        public OpretKundeModel(IKunde k)
        {
            _kunde = k;
        }

        public void OnGet()
        {
        }

        public List<BrugerInfo> Hent() //Læser json filen og henter information fra den
        {
            return BrugerCRUD.JsonFileRead(_filename);
        }

        public IActionResult OnPost()
        {
                if (Hent().Exists(k => k.Email == b.Email || k.Adgangskode == b.Adgangskode || k.Mobilnummer == b.Mobilnummer))
                {
                ErrorMsg = "gty";
                    return Page();
                }

            if (!ModelState.IsValid)
            {
                return Page();
            } 
           
            if (b.Id == 0)
            {
                b.Id = 1;
            }
            b.Id = _kunde.Bruger.Max(k => k.Id) + 1;

            _kunde.Create(b);

            return RedirectToPage("/Index");
            
        }
    }
}

