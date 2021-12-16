using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Corona_App.Pages.Varer
{
    public class CreateVareModel : PageModel
    {
        private IVare _vareCRUD;

        [BindProperty]
        public Vare Varer { get; set; }
        public string ErrorMsg { get; set; }

        public CreateVareModel(IVare katalog)
        {
            _vareCRUD = katalog;
        }
        public IActionResult OnGet()
        {
            return Page();
        }

        public IActionResult OnPost()
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return Page();
                }
                Varer.VareNr = _vareCRUD.Varer.Max(k => k.VareNr) + 1; // sætter VareNr til at altid være 1 højrere end det højste der findes i forvejen
                _vareCRUD.Create(Varer);
            }
            catch (ArgumentNullException e)
            {
                ErrorMsg = e.ParamName;
            }
            return RedirectToPage("/Varer/KatalogVarer/Katalog");

        }
    }
}