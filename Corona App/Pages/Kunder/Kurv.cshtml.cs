using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Corona_App.Pages.Varer;

namespace Corona_App.Pages.Kunder
{
    public class KurvModel : PageModel
    {
        public IVare _katelog;

        public List<Bestilling> KundensVare { get; set; }
        [BindProperty]
        public List<Bestilling> b { get; set; }

        [BindProperty]
        public string SearchText { get; set; }

        public KurvModel(IVare katelog)
        {
            _katelog = katelog;
        }

        public void OnGet(int id)
        {
            b = _katelog.KundensVare.FindAll(k => k.Id == id);
            KundensVare = _katelog.KundensVare;
        }

        public IActionResult OnGetSlet(int vareNr) // sletter varen fra kundens bestilling
        {
            _katelog.SletVareFraBestilling(vareNr);
            KundensVare = _katelog.KundensVare;
            return RedirectToPage("kurv");
        }

    }
}