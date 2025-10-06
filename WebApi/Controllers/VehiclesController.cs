using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi.Interfaces;
using WebApi.Models;
using WebApi.Models.DtoModels;
using WebApi.Services;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/vehicles")]
    public class VehiclesController : ControllerBase
    {
        private readonly IMaintenanceService _maintenanceService;

        public VehiclesController(IMaintenanceService maintenanceService)
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

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var vehicles = await _maintenanceService.GetAllVehiclesAsync();
            if (vehicles == null || vehicles.Count == 0)
                return NotFound();
            return Ok(vehicles);
        }


        [HttpGet("customers")]
        public async Task<ActionResult> GetCustomersAsync()
        {
            var customers = await _maintenanceService.GetAllCustomersAsync();
            if (customers == null || customers.Count == 0)
                return NotFound();
            return Ok(customers);
        }

        [HttpPost("maintenance/insert")]
        public async Task<ActionResult<MaintenanceRecord>> InsertMaintenanceRecord([FromBody] MaintenanceRecordDto request)
        {
            try
            {

                var record = new MaintenanceRecord
                {
                    PlateNumber = request.PlateNumber,
                    UserId = request.UserId,
                    Date = request.Date,
                    Mileage = request.Mileage,
                    MaintenanceItems = request.MaintenanceItems,
                    Description = request.Description,
                    Cost = request.Cost,
                    Technician = request.Technician,
                    CreateDateTime = DateTime.Now,
                    UpdateDateTime = DateTime.Now
                };

                var result = await _maintenanceService.InsertMaintenanceRecordAsync(record);
                return CreatedAtAction(nameof(Get), new { plateNumber = result.PlateNumber }, result);
            }
            catch (DbUpdateException ex)
            {
                return BadRequest("找不到對應的 Customer 或 Vehicle，請確認資料正確。" + ex.Message);
            }
        }
    }
}



