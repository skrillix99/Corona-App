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
        public string ErrorMsg { get; set; }

        public SletModel(IVare katalog)
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
        public IActionResult OnPost(int id)
        {
            try
            {
                Varer = _katalog.GetSingle(id);
                _katalog.Delete(Varer);
            }
            catch (ArgumentNullException e)
            {
                ErrorMsg = e.ParamName;
            }

            return RedirectToPage("Katalog");
        }
    }
}
