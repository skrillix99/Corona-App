using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Corona_App.Pages.Varer.VarerCRUD
{
    public class LisetOverVareModel : PageModel
    {
        private IVare _katelog;
        public List<Vare> Varer { get; set; }

        public LisetOverVareModel(IVare katelog)
        {
            _katelog = katelog;
        }
        public void OnGet()
        {
            Varer = _katelog.Varer;
        }
    }
}
