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
        public IKatalog _katelog;

        public List<Bestilling> KundensVare { get; set; }
        [BindProperty]
        public BrugerInfo b { get; set; }

        [BindProperty]
        public string SearchText { get; set; }

        public KurvModel(IKatalog katelog)
        {
            _katelog = katelog;
        }

        public void OnGet()
        {
            KundensVare = _katelog.KundensVare;
        }

        public IActionResult OnGetSlet(int vareNr) // sletter varen fra kundens bestilling
        {
            _katelog.SletVareFraBestilling(vareNr); 
            KundensVare = _katelog.KundensVare;
            return RedirectToPage("kurv");
        }

        public IActionResult OnPost()
        {
            KundensVare = _katelog.SearchBestilling(b);

            return Page();
        }
    }
}