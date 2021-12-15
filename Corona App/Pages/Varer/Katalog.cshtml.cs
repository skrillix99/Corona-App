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
        public string ErrorMsg { get; set; }       
        public KatalogModel(IKatalog katalog)
        {           
            _katalog = katalog;
        }
        
        public IActionResult OnGet()
        {
            try
            {                
                Varer = _katalog.Varer;
                Varer.Sort();
            }
            catch (Exception e)
            {
                ErrorMsg = e.Message;
            }

            return Page();
        }

        
        public IActionResult OnGetBuyNow(int vareNr) // tilføjer varen til KundensVare (bestillinger)
        {
            _katalog.TilføjVareTilBestilling(vareNr);
            return RedirectToPage("katalog");
        }
        public IActionResult OnPost()
        {
            try
            {                
                Varer = _katalog.Search(Search);
            }
            
            catch (ArgumentNullException n)
            {
                ErrorMsg = n.ParamName;
            }
            
            return Page();
        }
    }
}
