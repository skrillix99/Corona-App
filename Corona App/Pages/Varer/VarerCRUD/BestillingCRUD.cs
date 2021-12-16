using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using System.Text.Json;

namespace Corona_App.Pages.Varer.VarerCRUD //Lavet Af Marcus
{
    public class BestillingCRUD
    {
        public class bestillingCRUD
        {
            private string _filename = @"wwwroot\BestillingJson.json";

            public List<Vare> KundensVarer { get; private set; }

            public bestillingCRUD()
            {
                try
                {
                    using (var file = File.OpenText(_filename))
                    {
                        KundensVarer = JsonSerializer.Deserialize<List<Vare>>(file.ReadToEnd());
                    }
                }
                catch (Exception)
                {
                    KundensVarer = new List<Vare>();
                }
            }

            private void StoreToJson()
            {
                using (var file = File.Create(_filename))
                {
                    var writer = new Utf8JsonWriter(file, new JsonWriterOptions());
                    JsonSerializer.Serialize(writer, KundensVarer);
                }
            }

            public void TilføjVareTilBestilling(Vare tilføj)
            {
                if (tilføj == null)
                {
                    throw new ArgumentNullException("Varen blev findes ikke eller der skete en fejl");
                }
                KundensVarer.Add(tilføj);
                StoreToJson();
            }

        }
    }
}
