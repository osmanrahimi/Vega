using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using vega.Models;

namespace vega.Core
{
   public interface IVehicleRepository
    {
        Task<Vehicle> Get(int id, bool includeRelated=false);
        void Add(Vehicle vehicle);
        void Delete(Vehicle vehicle);
    }
}
