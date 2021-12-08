using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Corona_App.Pages.Varer
{
    public class KatalogModel : PageModel
    {        
        private IKatalog _katalog;
        private List<string> _idName;
        private List<string> _idNameCol;

        public List<Vare> Varer { get; private set; }

        [BindProperty]
        public string Search { get; set; }        
        public string ErrorMsg { get; set; }
        public string IdName { get; set; }
        public string IdNameCol { get; set; }        
        public KatalogModel(IKatalog katalog)
        {
            _idName = new List<string>();
            _idName.Add(new("headingOne"));
            _idName.Add(new("headingTwo"));
            _idName.Add(new("headingThree"));
            _idName.Add(new("headingFour"));
            _idName.Add(new("headingFive"));

            _idNameCol = new List<string>();
            _idNameCol.Add(new("collapseOne"));
            _idNameCol.Add(new("collapseTwo"));
            _idNameCol.Add(new("collapseThree"));
            _idNameCol.Add(new("collapseFour"));
            _idNameCol.Add(new("collapseFive"));
            _katalog = katalog;
        }
        
        public IActionResult OnGet()
        {
            try
            {
                Varer = _katalog.Varer;
                Varer.Sort();
            }
            catch (Exception e)
            {
                ErrorMsg = e.Message;
            }

            return Page();
        }
        public IActionResult OnPost()
        {
            try
            {                
                Varer = _katalog.Search(Search);                
            }
            catch (ArgumentNullException e)
            {
                ErrorMsg = e.Message;
            }
            
            return Page();
        }
    }
}
