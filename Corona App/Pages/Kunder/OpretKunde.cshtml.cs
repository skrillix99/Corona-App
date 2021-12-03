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
        [BindProperty]
        public BrugerInfo b { get; set; }

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

            _kunde.Create(b);

            return RedirectToPage("/Index");
        }
    }
}
