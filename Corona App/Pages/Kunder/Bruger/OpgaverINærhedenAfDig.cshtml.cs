using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Corona_App.Pages.Varer;

namespace Corona_App.Pages.Kunder.Bruger //Lavet Af Marcus & Jonathan
{
    public class OpgaverINærhedenAfDigModel : PageModel
    {
        private IVare _katelog;
        private IKunde _kunde;

        public int AntalVare { get; set; }
        public double SamletPris { get; set; }
        public List<Bestilling> KundensVare { get; set; }
        [BindProperty]
        public BrugerInfo b { get; set; }
        [BindProperty]
        public List<BrugerInfo> bList { get; set; }

        public OpgaverINærhedenAfDigModel(IVare katelog, IKunde kunde)
        {
            _katelog = katelog;
            _kunde = kunde;
        }

        public void OnGet()
        {
            bList = _kunde.Bruger;


            KundensVare = _katelog.KundensVare;
            SamletPris = _katelog.CalcAllPrice();
            b = _kunde.GetSingle(3);
        }

        public void OnPost()
        {
            bList = _katelog.SearchBestilling(b);
        }
    }
}