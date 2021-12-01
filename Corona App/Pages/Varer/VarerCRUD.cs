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


        public void Create()
        {
            throw new NotImplementedException();
        }

        public void Delete()
        {
            throw new NotImplementedException();
        }

        public void Update()
        {
            throw new NotImplementedException();
        }
    }
}
