using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Corona_App.Pages.Kunder.Bruger
{
    public class SletBrugerModel : PageModel
    {
        //binder brugerinfor, s� info kan bruges
        [BindProperty]
        public BrugerInfo b { get; set; }

        //interface kan bruges
        private IKunde _kunde;

        public SletBrugerModel(IKunde k)
        {
            _kunde = k;
        }

        //g�r at vi kan f� fat i brugerens specifikke id
        public void OnGet(int id)
        {
            b = _kunde.GetSingle(id);
        }

        public IActionResult OnPost()
        {

                _kunde.Delete(b);
                return RedirectToPage("/Index");
        
        }

    }
}