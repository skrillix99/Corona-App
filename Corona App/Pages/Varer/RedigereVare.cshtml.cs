using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Corona_App.Pages.Varer
{
    public class RedigereVareModel : PageModel
    {
        private IKatalog _katalog;
        [BindProperty]
        public Vare Varer { get; set; }
        public RedigereVareModel(IKatalog katalog)
        {
            _katalog = katalog;
        }
        public void OnGet(int id)
        {
            Varer = _katalog.GetSingle(id);
        }
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _katalog.Update(Varer);

            return RedirectToPage("Katalog");
        }
    }
}
