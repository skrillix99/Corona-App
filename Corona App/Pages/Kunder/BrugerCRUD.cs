﻿using System;
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

        private void StoreToJson()
        {
            using (var file = File.Create(_filename))
            {
                var writer = new Utf8JsonWriter(file, new JsonWriterOptions());
                JsonSerializer.Serialize(writer, Bruger);
            }
        }

        public BrugerInfo GetSingle(BrugerInfo tlf)
        {
            return Bruger.Find(k => k.TlfNummer == tlf.TlfNummer);
        }

        public void Create(BrugerInfo b)
        {
            Bruger.Add(b);
            StoreToJson();
        }

        public void Delete(BrugerInfo b)
        {
            Bruger.Remove(b);
            StoreToJson();
        }

        public void Update(BrugerInfo b)
        {
            BrugerInfo get = GetSingle(b);
            get.TlfNummer = b.TlfNummer;

            get.Navn = b.Navn;
            get.Adresse = b.Adresse;
            get.Adgangskode = b.Adgangskode;
            get.Email = b.Email;

            StoreToJson();
        }

    }
}
