using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace Corona_App.Pages.Varer
{
    public class VarerCRUD : IKatalog
    {
        private string _filename = @"wwwroot\VarerJson.json";
        private string _filenameBestilling = @"wwwroot\BestillingJson.json";

        public List<Vare> Varer { get; private set; }

        public List<Vare> KundensVare { get; set; }

        public VarerCRUD()
        {
            try
            {
                using (var file = File.OpenText(_filename))
                {
                    Varer = JsonSerializer.Deserialize<List<Vare>>(file.ReadToEnd());
                }
            }
            catch (Exception)
            {
                Varer = new List<Vare>();

            }
            KundensVare = new List<Vare>();
        }

        public Vare GetSingle(int vareNr)
        {
            if (vareNr == 0)
            {
                throw new KeyNotFoundException("Det angivede vareNr er ikke gyldig");
            }
                return Varer.Find(k => k.VareNr == vareNr);
        }

        public void Create(Vare obj)
        {
            if (obj == null)
            {
                throw new ArgumentNullException("Der var fejl i at oprette den nye vare.");
            }
            Varer.Add(obj);
            StoreToJson();
        }
        public void TilføjVareTilBestilling(int tilføj)
        {
            if (tilføj == 0)
            {
                throw new KeyNotFoundException("Varen findes ikke eller der skete en fejl");
            }
            
            KundensVare.Add(GetSingle(tilføj));
            StoreToJsonBestilling();
        }

        public void Delete(Vare vare)
        {
            if(vare == null)
            {
                throw new ArgumentNullException("Den angivede vare er ikke gyldig");
            }
            Vare Get = GetSingle(vare.VareNr);
            Varer.Remove(Get); 
            StoreToJson();
        }

        public void Update(Vare vare)
        {
            if(vare == null)
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
        private void StoreToJson()
        {
            using (var file = File.Create(_filename))
            {
                var writer = new Utf8JsonWriter(file, new JsonWriterOptions());
                JsonSerializer.Serialize(writer, Varer);
            }   
        }
        private void StoreToJsonBestilling()
        {
            using (var file = File.Create(_filenameBestilling))
            {
                var writer = new Utf8JsonWriter(file, new JsonWriterOptions());
                JsonSerializer.Serialize(writer, KundensVare);
            }
        }

        public List<Vare> Search(string searchText)
        {
            if(String.IsNullOrWhiteSpace(searchText))
            {
                return Varer;
                throw new ArgumentNullException("Der er fejl i din søgning");
            }
            return Varer.FindAll(k => k.Navn.ToLower() == searchText.ToLower() || k.Kategori.ToString().ToLower() == searchText.ToLower());
        }        
    }
}