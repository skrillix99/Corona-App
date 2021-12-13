using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Corona_App.Pages.Kunder;

namespace Corona_App.Pages.Varer
{
    public class LokationModel : PageModel
    {
        private IKatalog _katelog;
        private IKunde _kunde;

        [BindProperty]
        public string Lokation { get; set; }

        [BindProperty]
        public string Mobil { get; set; }
        public LokationModel(IKatalog katelog)
        {
            _katelog = katelog;
        }
        public void OnGet()
        {

        }

        public IActionResult OnPost()
        {
            _katelog.UpdateLokation(Lokation, Mobil);
            return RedirectToPage("/Kunder/Kurv");
        }
    }
}
