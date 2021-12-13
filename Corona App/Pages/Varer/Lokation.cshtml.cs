using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Corona_App.Pages.Varer
{
    public class LokationModel : PageModel
    {
        private IKatalog _katelog;

        [BindProperty]
        public string Lokation { get; set; }

        public LokationModel(IKatalog katelog)
        {
            _katelog = katelog;
        }
        public void OnGet(int id)
        {

        }

        public IActionResult OnPost(int id)
        {
            _katelog.UpdateLokation(Lokation, id);
            return RedirectToPage("/Kunder/Kurv");
        }
    }
}
