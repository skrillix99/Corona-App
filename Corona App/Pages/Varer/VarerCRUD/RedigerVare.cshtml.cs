using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Corona_App.Pages.Varer //Lavet Af Marcus
{
    public class RedigereVareModel : PageModel 
    {
        private IVare _katalog;
        [BindProperty]
        public Vare Varer { get; set; }
        public string ErrorMsg { get; set; }
        public RedigereVareModel(IVare katalog)
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
                if (!ModelState.IsValid)
                {
                    return Page();
                }

                _katalog.Update(Varer);
            }
            catch (Exception e)
            {
                ErrorMsg = e.Message;
            }
            return RedirectToPage("/Varer/KatalogVarer/Katalog");
        }
    }
}