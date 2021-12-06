﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Corona_App.Pages.Kunder.Bruger;

namespace Corona_App.Pages.Kunder
{
    public interface IKunde
    {
        void Create(BrugerInfo b);
        void Update(BrugerInfo b);
        void Delete(BrugerInfo b);
        List<BrugerInfo> Bruger { get; }
    }
}
