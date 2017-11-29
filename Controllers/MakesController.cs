using Microsoft.AspNetCore.Mvc;
using vega.Models;
using System.Collections.Generic;
using vega.Persistence;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using vega.Models.Resources;

namespace Vega.Controllers
{

    public class VehiclesController:Controller
    {
        private readonly VegaDbContext _vegaDbContext;

        public VehiclesController(VegaDbContext vegaDbContext)
        {
            this._vegaDbContext = vegaDbContext;
        }
        
        [HttpGet("api/vehicles/makes")]
        public async Task<IEnumerable<MakeResource>> GetMakesAsync()
        {
            var makes= await _vegaDbContext.Makes.Include(m=>m.Models).ToListAsync();
            return AutoMapper.Mapper.Map<List<MakeResource>>(makes);

        }

        [HttpGet("api/vehicles/features")]
        public async Task<IEnumerable<Feature>> GetFeatures()
        {
            return await _vegaDbContext.Features.ToListAsync();
        }
    }
}