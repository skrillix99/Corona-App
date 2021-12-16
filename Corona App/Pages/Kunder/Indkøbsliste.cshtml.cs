using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Corona_App.Pages.Varer //Lavet Af Marcus
{
    public class IndkøbslisteModel : PageModel
    {
        private IVare _katelog;
        public List<Bestilling> b { get; set; }
        public string ErrorMsg { get; set; }

        public IndkøbslisteModel(IVare katelog)
        {
            _katelog = katelog;
        }

        public void OnGet()
        {
            b = _katelog.KundensVare.FindAll(k => k.Id == 7);
        }
        public IActionResult OnGetSlet(int vareNr)
        {
            try
            {
                _katelog.SletVareFraBestilling(vareNr);
                b = _katelog.KundensVare.FindAll(k => k.Id == 7);
            }
            catch (ArgumentNullException n)
            {
                ErrorMsg = n.ParamName;
            }
            return Page();
        }

        public void OnPost()
        {
            b = _katelog.KundensVare.FindAll(k => k.Id == 7);
        }
    }
}
