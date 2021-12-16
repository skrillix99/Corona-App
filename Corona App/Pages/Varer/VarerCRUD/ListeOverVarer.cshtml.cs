using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Corona_App.Pages.Varer.VarerCRUD
{
    public class ListeOverVarerModel : PageModel //Lavet Af Marcus
    {
        private IVare _katelog;
        public List<Vare> Varer { get; set; }

        public ListeOverVarerModel(IVare katelog)
        {
            _katelog = katelog;
        }
        public void OnGet()
        {
            Varer = _katelog.Varer;
        }
    }
}
