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
            catch (Exception e)
            {
                Varer = new List<Vare>();
            }
        }

        public Vare GetSingle(int vareNr)
        {
            return Varer.Find(k => k.VareNr == vareNr);
        }

        public void Create(Vare obj)
        {
            Varer.Add(obj);
            StoreToJson();
        }

        public void Delete(Vare vare)
        {
            Vare Get = GetSingle(vare.VareNr);
            if(Get.VareNr == null || Get.VareNr == 0)
            {
                throw new ArgumentNullException("Den angivede vare er ikke gyldig");
            }
            Varer.Remove(Get); 
            StoreToJson();
        }

        public void Update(Vare vare)
        {
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
    }
}
