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
            _katelog.UpdateLokation(Mobil);
            return RedirectToPage($"/Kunder/Kurv/{_katelog.GetKundeId(Mobil)}");
        }
    }
}
