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

        public KurvModel(IKatalog katelog)
        {
            _katelog = katelog;
        }

        public List<Bestilling> JsonReader()
        {
            return _katelog.ReadJson();
        }

        public void OnGet()
        {
            KundensVare = JsonReader();
            KundensVare = _katelog.KundensVare;
        }

        public IActionResult OnGetTest(int vareNr)
        {
            _katelog.SletVareFraBestilling(vareNr);
            KundensVare = _katelog.KundensVare;
            return RedirectToPage("kurv");
        }
    }
}
