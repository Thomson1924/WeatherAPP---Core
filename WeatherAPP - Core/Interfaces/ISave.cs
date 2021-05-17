using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeatherAPP___Core.Models;

namespace WeatherAPP___Core.Interfaces
{
   public interface ISave
    {
        Task<bool> SaveAsync(Main main);


    }
}
