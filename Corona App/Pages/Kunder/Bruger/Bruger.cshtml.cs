using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Corona_App.Pages.Shared.Kunder
{
    public class BrugerModel : PageModel
    {

        public IActionResult OnGet()
        {
            return Page();
        }

        public void OnPost()
        {

        }
    }
}
