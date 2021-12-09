using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Corona_App.Pages.Varer //Lavet Af Marcus
{
    public class SletModel : PageModel
    {
        private IVare _katalog;
        [BindProperty]
        public Vare Varer { get; set; }

        public SletModel(IVare katalog)
        {
            _katalog = katalog;
        }
        public void OnGet(int id)
        {
            Varer = _katalog.GetSingle(id);
        }
        public IActionResult OnPost()
        {
            _katalog.Delete(Varer);

            return RedirectToPage("/Varer/KatalogVarer/Katalog");
        }
    }
}