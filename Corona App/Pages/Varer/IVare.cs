using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
    }
}