using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Corona_App.Pages.Kunder //Lavet Af Cecilie
{
    public interface IKunde
    {
        void Create(BrugerInfo b);
        void Update(BrugerInfo b);
        void Delete(BrugerInfo b);
        BrugerInfo GetSingle(int id);
        List<BrugerInfo> Bruger { get; }
    }
}