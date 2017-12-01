using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using vega.Models;

namespace vega.Persistence
{
    public class VehicleRepository: IVehicleRepository
    {
        private readonly VegaDbContext context;

        public VehicleRepository(VegaDbContext context)
        {
            this.context = context;
        }

        public void Add(Vehicle vehicle)
        {
            this.context.Vehicles.Add(vehicle);
        }

        public void Delete(Vehicle vehicle)
        {
            this.context.Vehicles.Remove(vehicle);
        }

        public async Task<Vehicle> Get(int id, bool includeRelated = false)
        {
            if (includeRelated != false)
                return await this.context.Vehicles.FindAsync(id);

            return  await this.context.Vehicles
              .Include(i => i.Features)
              .ThenInclude(vf => vf.Feature)
              .Include(i => i.Model)
              .ThenInclude(m => m.Make)
              .SingleOrDefaultAsync(v => v.Id == id);

        }
    }
}
