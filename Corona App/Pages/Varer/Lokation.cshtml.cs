using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Corona_App.Pages.Varer //Lavet Af Marcus
{
    public class LokationModel : PageModel
    {
        private IVare _katelog;

        public string ErrorMsg
        {
            get; set;
        }

        [BindProperty]
        public string Mobil { get; set; }
        public LokationModel(IVare katelog)
        {
            _katelog = katelog;
        }
        public void OnGet()
        {

        }

        public IActionResult OnPost()
        {
            try
            {
                _katelog.UpdateLokation(Mobil);
            }
            catch (ArgumentNullException ae)
            {
                ErrorMsg = ae.ParamName;
            }
            return RedirectToPage("/Kunder/Indkøbsliste");

        }
    }
}