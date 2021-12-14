using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Corona_App.Pages.Kunder // Lavet Af Cecilie
{
    public class BrugerModel : PageModel
    {
        //binder brugerinfor, så info kan bruges
        [BindProperty]
        public BrugerInfo b { get; set; }

        //interface kan bruges
        private IKunde _kunde;

        public BrugerModel(IKunde k)
        {
            _kunde = k;
        }

        //gør at vi kan få fat i brugerens specifikke id
        public void OnGet(int id)
        {
            b = _kunde.GetSingle(id);
        }

        public IActionResult OnPost()
        {

            //opdatere bruger hvis brugerens info findes i systemet
            if (ModelState.IsValid)
            {
                _kunde.Update(b);
     
                return RedirectToPage("/Kunder/Bruger/Velkommen");
            }

            return Page();

        }

    }
}