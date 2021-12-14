using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;


namespace Corona_App.Pages.Kunder.Bruger //Lavet Af Cecilie
{
    public class OpretKundeModel : PageModel
    {

        private string _filename = @"wwwroot\Kunde.json"; //Finder lokationen af json filen og gør vi kan komme i kontakt med den

        //binder brugerinfo property, så informationen kan bruges
        [BindProperty]
        public BrugerInfo b { get; set; }

        // interface kunde, kan nu bruges her
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
            
                if (Hent().Exists(k => k.Email == b.Email || k.Mobilnummer == b.Mobilnummer || k.Adresse == b.Adresse))
                {
                return Page();
                }
            

            if (!ModelState.IsValid)
            {
                return Page();
            }

            // hvis id på bruger er lig med 0, gør id til 1 ellers tag max id og plus med 1 for den næste oprettede bruger.
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

