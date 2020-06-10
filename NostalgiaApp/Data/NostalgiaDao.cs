using Microsoft.EntityFrameworkCore;
using NostalgiaApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NostalgiaApp.Data
{
    public class NostalgiaDao : INostalgiaDao
    {

        private ApplicationDbContext _context;

        public NostalgiaDao(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Nostalgia> GetNostalgias()
        {
            return GetNostalgiasAsync().Result.ToList();
        }

        private async Task<List<Nostalgia>> GetNostalgiasAsync()
        {
            return await _context.Nostalgias.ToListAsync();            
        }

        public void SaveNostalgia(Nostalgia nostalgia)
        {
            _context.Nostalgias.Add(nostalgia);
            _context.SaveChanges();
        }
    }
}
