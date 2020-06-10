using NostalgiaApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NostalgiaApp.Data
{
    public interface INostalgiaDao
    {
        List<Nostalgia> GetNostalgias();
        void SaveNostalgia(Nostalgia nostalgia);
    }
}
