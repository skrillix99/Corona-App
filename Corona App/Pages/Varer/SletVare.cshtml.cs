using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Corona_App.Pages.Varer
{
    public class SletModel : PageModel
    {
        private IKatalog _katalog;
        [BindProperty]
        public Vare Varer { get; set; }
        public string ErrorMsg { get; set; }

        public SletModel(IKatalog katalog)
        {
            _katalog = katalog;
        }
        public void OnGet(int id)
        {
            try
            {
                Varer = _katalog.GetSingle(id);
            }
            catch (Exception e)
            {
                ErrorMsg = e.Message;
            }
        }
        public IActionResult OnPost()
        {
            try
            {
                _katalog.Delete(Varer);
            }
            catch (Exception e)
            {
                ErrorMsg = e.Message;
            }

            return RedirectToPage("Katalog");
        }
    }
}
