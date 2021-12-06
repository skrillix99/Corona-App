using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Corona_App.Pages.Varer
{
    public class KatalogModel : PageModel
    {        
        private IKatalog _katalog;

        public List<Vare> Varer { get; private set; }

        [BindProperty]
        public string Search { get; set; }        
        public KatalogModel(IKatalog katalog)
        {
            _katalog = katalog;
        }
        
        public IActionResult OnGet()
        {
            Varer = _katalog.Varer;

            return Page();
        }
        public IActionResult OnPost()
        {
            if(!String.IsNullOrWhiteSpace(Search))
            {
                Varer = _katalog.Search(Search);
            }            
            return Page();
        }
    }
}
