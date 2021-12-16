using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Corona_App.Pages.Varer;

namespace Corona_App.Pages.Kunder.Bruger //Lavet Af Marcus & Jonathan
{
    public class NuværendeOpgaveModel : PageModel
    {
        public IVare _katelog;

        public List<Bestilling> KundensVare { get; set; }
        [BindProperty]
        public List<Bestilling> b { get; set; }

        [BindProperty]
        public string SearchText { get; set; }

        public NuværendeOpgaveModel(IVare katelog)
        {
            _katelog = katelog;
        }

        public void OnGet()
        {
            b = _katelog.KundensVare.FindAll(k => k.Id == 7);
            KundensVare = _katelog.KundensVare;
        }

        public IActionResult OnGetSlet()
        {
            KundensVare = _katelog.KundensVare;
            return RedirectToPage("kurv");
        }

    }
}