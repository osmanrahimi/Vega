using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using vega.Models;
using vega.Models.Resources;
using vega.Persistence;

namespace vega.Controllers
{
    [Route("/api/vehicles/")]
    public class VehiclesController : Controller
    {
        private readonly IMapper mapper;
        private readonly VegaDbContext vegaDbContext;

        public VehiclesController(IMapper mapper, VegaDbContext vegaDbContext)
        {
            this.mapper = mapper;
            this.vegaDbContext = vegaDbContext;
        }
        [HttpPost]
        public async Task<IActionResult> CrateVehicle(VehicleResource vehiclesResource)
        {
            var vehicle = mapper.Map<VehicleResource, Vehicle>(vehiclesResource);
            this.vegaDbContext.Vehicles.Add(vehicle);
            await this.vegaDbContext.SaveChangesAsync();
            return Ok(vehicle);
        }
    }
}