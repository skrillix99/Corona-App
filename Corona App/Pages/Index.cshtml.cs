﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Corona_App.Pages.Kunder;
using System.Text.RegularExpressions;

namespace Corona_App.Pages //Lavet Af Anders
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        private string _filename = @"wwwroot\Kunde.json"; //Finder lokationen af json filen og gør vi kan komme i kontakt med den


        [BindProperty]
        public LogInd Logind { get; set; }

        public class LogInd
        {
            [Required(ErrorMessage = "Du skal udfylde e-mail feltet")]
            [RegularExpression(@"\S+@\S+", ErrorMessage = "Din e-mail skal indeholde et @")]   //Giver e-mailfeltet en fejl, hvis der mangler et @   
            [MinLength(10, ErrorMessage = "Din e-mail skal være mindst 10 tegn")]
            public string Email { get; set; }


            [Required(ErrorMessage = "Du skal udfylde adgangskode feltet.")]        //Giver fejl hvis adgangskoden er under 8 tegn eller ikke passer med json filen
            [MinLength(8, ErrorMessage = "Din Adgangskode skal indeholde minumum 8 tegn.")]
            [DataType(DataType.Password)]
            public string Adgangskode { get; set; }
        }

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public List<BrugerInfo> Hent() //Læser json filen og henter information fra den
        {
            return BrugerCRUD.JsonFileRead(_filename);
        }

        public void OnGet()
        {

        }

        public IActionResult OnPost() //Når man trykker på log-ind knappen, kører denne kode
        {
            if (Hent().Exists(k => k.Email == Logind.Email && k.Adgangskode == Logind.Adgangskode)) //Hvis emailen og adgangskoden man indtaster, matcher 1 kontos email og adgangskode, kommer man videre. Hvis ikke så forbliver man på siden og får en fejl meddelse.
            {
                return RedirectToPage("/Kunder/Bruger/Velkommen"); //TO DO ÆNDRE PATHEN TIL VELKOMMEN SIDEN. 
            }
                return Page();
        }
    }
}