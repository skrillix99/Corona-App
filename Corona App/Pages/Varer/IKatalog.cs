using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Corona_App.Pages.Varer
{
    public interface IKatalog
    {
        List<Vare> Varer { get; }
        Vare GetSingel(int vareNr);
        void Create(Vare obj);
        void Update(Vare vare);
        void Delete();
    }
}
