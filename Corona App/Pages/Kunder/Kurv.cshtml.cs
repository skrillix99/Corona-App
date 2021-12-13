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
        public VarerCRUD _varerCRUD; // null, check Anders

        public List<Vare> KundensVare { get; set; }
        
        //public List<Vare> JsonReader()
        //{
        //    return _varerCRUD.ReadJson();
        //}

        public void OnGet()
        {
            //KundensVare = JsonReader();
            //KundensVare = _varerCRUD.KundensVare;
        }
    }
}
