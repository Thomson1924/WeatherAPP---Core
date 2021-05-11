using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeatherAPP___Core.Data;
using WeatherAPP___Core.Interfaces;
using WeatherAPP___Core.Models;

namespace WeatherAPP___Core.Services
{
    public class Save : ISave
    {
        private readonly ApplicationDbContext _context;
        public Save(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> SaveAsync(Main main)
        {
            
            
                _context.Add(main);
               await _context.SaveChangesAsync();

            return true;
            
        }
    }
}
