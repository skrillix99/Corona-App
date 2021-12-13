using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Corona_App.Pages.Kunder;
using Corona_App.Pages.Kunder.Bruger;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Corona_App.Pages.Kunder // Lavet Af Cecilie
{
    public class BrugerModel : PageModel
    {

        [BindProperty]
        public BrugerInfo b { get; set; }

        private IKunde _kunde;

        public BrugerModel(IKunde k)
        {
            _kunde = k;
        }

        public void OnGet(int id)
        {
            b = _kunde.GetSingle(id);
        }

        public IActionResult OnPost()
        {

            if (ModelState.IsValid)
            {
                _kunde.Update(b);
                //return Page();
                return RedirectToPage("/Kunder/Bruger/Velkommen");
            }

            _kunde.Delete(b);

            //_kunde.Update(b);
            //_kunde.Delete(b);

            return RedirectToPage("/Index");
        }

    }
}