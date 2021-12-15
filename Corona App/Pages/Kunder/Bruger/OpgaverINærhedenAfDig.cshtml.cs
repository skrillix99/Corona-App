using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Corona_App.Pages.Varer;

namespace Corona_App.Pages.Kunder.Bruger
{
    public class OpgaverINærhedenAfDigModel : PageModel
    {
        private IKatalog _katelog;
        private IKunde _kunde;

        public int AntalVare { get; set; }
        public double SamletPris { get; set; }
        public BrugerInfo b { get; set; }

        public OpgaverINærhedenAfDigModel(IKatalog katelog, IKunde kunde)
        {
            _katelog = katelog;
            _kunde = kunde;
        }

        public void OnGet()
        {
            if(_katelog.KundensVare.FindAll(k => k.Id == 7).Count == 1)
            {
                AntalVare = 1;
            }
            AntalVare = _katelog.KundensVare.FindAll(k => k.Id == 7).Count;
            SamletPris = _katelog.CalcAllPrice();
            b = _kunde.GetSingle(7);
        }
    }
}