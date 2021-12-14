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
        //gør at den kan finde vores json fil
        private string _filename = @"wwwroot\Kunde.json";

        public List<BrugerInfo> Bruger { get; private set; }


        // læser json fil til ende, om brugeren findes
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

        //metode til at gemme til json fil og skrive i filen.
        private void StoreToJson()
        {
            using (var file = File.Create(_filename))
            {
                var writer = new Utf8JsonWriter(file, new JsonWriterOptions());
                JsonSerializer.Serialize(writer, Bruger);
            }
        }

        // kommer selv med et nyt id udfra det max id der allerede findes
        public BrugerInfo GetSingle(int id)
        {
            return Bruger.Find(k => k.Id == id);
        }

        //metode for at lave en bruger og gem den til json.
        public void Create(BrugerInfo b)
        {
            Bruger.Add(b);
            StoreToJson();
        }

        // metode for at slette bruger, og fjerne den fra json fil
        public void Delete(BrugerInfo b)
        {
            BrugerInfo g = GetSingle(b.Id);
            Bruger.Remove(g);
            StoreToJson();
        }
        
        // metode for updatere bruger, opdatere brugeren med det specifikke id nr, og gemmer den igen i json
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
