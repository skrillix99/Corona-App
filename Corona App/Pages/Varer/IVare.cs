using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Corona_App.Pages.Kunder;

namespace Corona_App.Pages.Varer //Lavet Af Marcus
{
    public interface IVare
    {

        List<Vare> Varer { get; }
        Vare GetSingle(int vareNr);
        void Create(Vare obj);
        void Update(Vare vare);
        void Delete(Vare vare);
        List<Vare> Search(string searchText);

        void UpdateLokation(string mobil);
        List<Bestilling> KundensVare { get; }
        void TilføjVareTilBestilling(int tilføj);
        void SletVareFraBestilling(int vareNr);
        List<Bestilling> SearchBestilling(BrugerInfo b);
    }
}