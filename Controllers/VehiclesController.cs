using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using vega.Core;
using vega.Models;
using vega.Models.Resources;

namespace vega.Controllers
{
    [Route("/api/vehicles/")]
    public class VehiclesController : Controller
    {
        private readonly IMapper mapper;
        private readonly IVehicleRepository repository;
        private readonly IUnitOfWork unitOfWork;

        public VehiclesController(IMapper mapper, IVehicleRepository repository,IUnitOfWork unitOfWork)
        {
            this.mapper = mapper;
            this.repository = repository;
            this.unitOfWork = unitOfWork;
        }
        [HttpPost]
        public async Task<IActionResult> CrateVehicle([FromBody]SaveVehicleResource vehiclesResource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var vehicle = mapper.Map<SaveVehicleResource, Vehicle>(vehiclesResource);
            vehicle.LastUpdate = DateTime.Now;
            this.repository.Add(vehicle);
            await this.unitOfWork.CompleteAsync();

            vehicle = await repository.Get(vehicle.Id);

            var result = mapper.Map<Vehicle, VehicleResource>(vehicle);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateVehicle(int id, [FromBody] SaveVehicleResource vehiclesResource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var vehicle = await repository.Get(id);
            vehicle = mapper.Map<SaveVehicleResource, Vehicle>(vehiclesResource, vehicle);
            vehicle.LastUpdate = DateTime.Now;
            await this.unitOfWork.CompleteAsync();
            var result = mapper.Map<Vehicle, SaveVehicleResource>(vehicle);
            return Ok(result);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var vehicle = await repository.Get(id,false);
            if (vehicle == null)
                return NotFound();
            repository.Delete(vehicle);
            await unitOfWork.CompleteAsync();
            return Ok(id);
        }

        public async Task<IActionResult> GetVehicle(int id)
        {
            var vehicle = await repository.Get(id);
            if (vehicle == null)
                return NotFound();
            var vehicleResource = mapper.Map<Vehicle, VehicleResource>(vehicle);
            return Ok(vehicleResource);
        }
    }
}