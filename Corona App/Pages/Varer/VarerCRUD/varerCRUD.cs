using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using Corona_App.Pages.Kunder;

namespace Corona_App.Pages.Varer
{
    public class varerCRUD : IVare
    {
        // sti til Json filer
        private string _filename = @"wwwroot\VarerJson.json";
        private string _filenameBestilling = @"wwwroot\BestillingJson.json";
        private string _filenameKunde = @"wwwroot\Kunde.json";

        public List<Vare> Varer { get; private set; } // listen af vare

        public List<Bestilling> KundensVare { get; private set; }// listen af varene som en kunde har tilføjet til kurv (bestillinger)

        public varerCRUD()
        {
            try
            {
                using (var file = File.OpenText(_filename)) // laver json filens indhold om til en List<Vare>
                {
                    Varer = JsonSerializer.Deserialize<List<Vare>>(file.ReadToEnd());
                }
            }
            catch (Exception)
            {
                Varer = new List<Vare>();

            }

            try
            {
                using (var file = File.OpenText(_filenameBestilling)) // laver json filens indhold om til en List<bestilling>
                {
                    KundensVare = JsonSerializer.Deserialize<List<Bestilling>>(file.ReadToEnd());
                }
            }
            catch (Exception)
            {
                KundensVare = new List<Bestilling>();
            }
        }

        private void StoreToJson() // opretter/redigere og sletter i json filen for Varer
        {
            using (var file = File.Create(_filename))
            {
                var writer = new Utf8JsonWriter(file, new JsonWriterOptions());
                JsonSerializer.Serialize(writer, Varer);
            }
        }
        private void StoreToJsonBestilling() // opretter/redigere og sletter i json filen for KundensVare
        {
            using (var file = File.Create(_filenameBestilling))
            {
                var writer = new Utf8JsonWriter(file, new JsonWriterOptions());
                JsonSerializer.Serialize(writer, KundensVare);
            }
        }


        public Vare GetSingle(int vareNr) // henter den specifikke vare fra Varer
        {
            if (vareNr == 0)
            {
                throw new KeyNotFoundException("Det angivede vareNr er ikke gyldig");
            }
            return Varer.Find(k => k.VareNr == vareNr);
        }


        public void Create(Vare obj) // opretter en ny vare til Varer
        {
            if (obj == null)
            {
                throw new ArgumentNullException("Der var fejl i at oprette den nye vare.");
            }
            Varer.Add(obj);
            StoreToJson();
        }
        public void Delete(Vare vare) // sletter den angivede vare fra Varer
        {
            if (vare == null)
            {
                throw new ArgumentNullException("Den angivede vare er ikke gyldig");
            }
            Vare Get = GetSingle(vare.VareNr);
            Varer.Remove(Get);
            StoreToJson();
        }
        public void Update(Vare vare) // redigere den angivede vare fra Varer
        {
            if (vare == null)
            {
                throw new ArgumentNullException("Den angivet vare findes ikke eller at der skete en fejl i at læse varen.");
            }
            Vare Get = GetSingle(vare.VareNr);

            Get.VareNr = vare.VareNr;
            Get.Pris = vare.Pris;
            Get.Navn = vare.Navn;
            Get.Kategori = vare.Kategori;

            StoreToJson();
        }


        public void TilføjVareTilBestilling(int tilføj) // tilføjer en vare til KundensVare
        {
            if (tilføj == 0)
            {
                throw new KeyNotFoundException("Varen findes ikke eller der skete en fejl"); // todo
            }

            KundensVare.Add(new Bestilling(tilføj));

            foreach (Bestilling Get in KundensVare.FindAll(k => k.VareNr == tilføj))
            {
                Vare Dry = Varer.Find(k => k.VareNr == tilføj);

                Get.Pris = Dry.Pris;
                Get.Navn = Dry.Navn;
                Get.Kategori = Dry.Kategori;
            }
            StoreToJsonBestilling();
        }

        public void SletVareFraBestilling(int vareNr) // sletter den angivede vare fra KundensVare
        {
            if (!KundensVare.Exists(k => k.VareNr == vareNr))
            {
                throw new ArgumentNullException("Den angivede vare er ikke gyldig");
            }
            Bestilling Get = KundensVare.Find(k => k.VareNr == vareNr);
            KundensVare.Remove(Get);
            StoreToJsonBestilling();
        }
        public void UpdateLokation(string mobil) // redigere den angivede vare fra KundensVare
        {
            BrugerInfo Get = BrugerCRUD.JsonFileRead(_filenameKunde).Find(k => k.Mobilnummer == mobil);
            foreach (Bestilling l in KundensVare)
            {
                if (l.Id == 0)
                {
                    l.lokation = Get.Kommune;
                    l.Id = Get.Id;
                }
            }
            StoreToJsonBestilling();
        }


        public List<Vare> Search(string searchText) // viser den/de vare fra Varer som indholder enten det navn eller kategroi man har søgt efter
        {
            if (String.IsNullOrWhiteSpace(searchText))
            {
                return Varer;
                throw new ArgumentNullException("Der er fejl i din søgning");
            }
            return Varer.FindAll(k => k.Navn.ToLower() == searchText.ToLower() || k.Kategori.ToString().ToLower() == searchText.ToLower());
        }

        public List<Bestilling> SearchBestilling(BrugerInfo b) // viser den/de vare fra Bestillinger som indholder enten det navn eller kategroi man har søgt efter
        {
            if (b == null)
            {
                return KundensVare;
                throw new ArgumentNullException("Der er fejl i din søgning");
            }
            return KundensVare.FindAll(k => k.lokation == b.Kommune);
        }

    }
}