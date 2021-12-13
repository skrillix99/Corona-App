using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using System.Text.Json;

namespace Corona_App.Pages.Kunder
{
    public class BrugerCRUD : IKunde
    {
        private string _filename = @"wwwroot\Kunde.json";

        public List<BrugerInfo> Bruger { get; private set; }

        public BrugerCRUD()
        {
            try
            {
                using (var file = File.OpenText(_filename))
                {
                    Bruger = JsonSerializer.Deserialize<List<BrugerInfo>>(file.ReadToEnd());
                }
            }
            catch (Exception e)
            {
                Bruger = new List<BrugerInfo>();
            }
        }

        public static List<BrugerInfo> JsonFileRead(string fileName)
        {
            using (var file = File.OpenText(fileName))
            {
                return JsonSerializer.Deserialize<List<BrugerInfo>>(file.ReadToEnd());
            }
        }
        private void StoreToJson()
        {
            using (var file = File.Create(_filename))
            {
                var writer = new Utf8JsonWriter(file, new JsonWriterOptions());
                JsonSerializer.Serialize(writer, Bruger);
            }
        }

        public BrugerInfo GetSingle(int id)
        {
            return Bruger.Find(k => k.Id == id);
        }

        public void Create(BrugerInfo b)
        {
            Bruger.Add(b);
            StoreToJson();
        }

        public void Delete(BrugerInfo b)
        {
            BrugerInfo g = GetSingle(b.Id);
            Bruger.Remove(g);
            StoreToJson();
        }

        public void Update(BrugerInfo b)
        {
            BrugerInfo get = GetSingle(b.Id);
            get.Mobilnummer = b.Mobilnummer;

            get.Navn = b.Navn;
            get.Adresse = b.Adresse;
            get.Adgangskode = b.Adgangskode;
            get.Email = b.Email;

            StoreToJson();
        }

    }
}