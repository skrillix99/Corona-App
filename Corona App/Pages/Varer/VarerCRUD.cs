using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace Corona_App.Pages.Varer
{
    public class VarerCRUD : IKatalog
    {

        private string _filename = @"wwwroot\VarerJson.json";


        public List<Vare> Varer { get; private set; }

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
        }

        public Vare GetSingle(int vareNr)
        {
            if (vareNr == 0)
            {
                throw new ArgumentNullException("Det angivede vareNr er ikke gyldig");
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

        public void Delete(Vare vare)
        {
            Vare Get = GetSingle(vare.VareNr);
            if(Get.VareNr == 0)
            {
                throw new ArgumentNullException("Den angivede vare er ikke gyldig");
            }
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

        public List<Vare> Search(string searchText)
        {
            if(String.IsNullOrWhiteSpace(searchText))
            {
                return new List<Vare>();
                throw new ArgumentNullException("Der er fejl i søgning");
            }           
            return Varer.FindAll(k => k.Navn == searchText);
        }        
    }
}
