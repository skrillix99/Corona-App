using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Corona_App.Pages.Kunder
{
    public class OpretKundeModel : PageModel
    {
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

        public IActionResult OnPost()
        {
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
