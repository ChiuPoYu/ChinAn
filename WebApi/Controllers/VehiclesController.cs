using Microsoft.AspNetCore.Mvc;
using WebApi.Models;
using WebApi.Services;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/vehicles")]
    public class VehiclesController : ControllerBase
    {
        private readonly MaintenanceService _maintenanceService;

        public VehiclesController(MaintenanceService maintenanceService)
        {
            _maintenanceService = maintenanceService;
        }

        [HttpGet("{plateNumber}")]
        public async Task<ActionResult<List<Vehicle>>> Get(string plateNumber)
        {
            var vehicle = await _maintenanceService.GetMaintenanceRecordsByPlateNumberAsync(plateNumber);
            if (vehicle == null)
                return NotFound();
            return Ok(vehicle);
        }
    }
}



