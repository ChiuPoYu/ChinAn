using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/vehicles")]
    public class VehiclesController : ControllerBase
    {
        private static readonly Dictionary<string, VehicleData> PlateNumberToVehicleData = new(StringComparer.OrdinalIgnoreCase)
        {
            ["ABC-1234"] = new VehicleData
            {
                PlateNumber = "ABC-1234",
                Model = "Toyota Camry",
                Owner = "王小明",
                CurrentMileage = 85000,
                MaintenanceRecords = new List<MaintenanceRecord>
                {
                    new()
                    {
                        Id = 1,
                        Date = "2024-01-15",
                        Mileage = 82000,
                        MaintenanceItems = new [] { "oil_change", "filter_change", "brake_check" },
                        Description = "定期保養，更換機油及濾清器，檢查煞車系統",
                        Cost = 2500,
                        Technician = "李技師"
                    },
                    new()
                    {
                        Id = 2,
                        Date = "2023-10-20",
                        Mileage = 78000,
                        MaintenanceItems = new [] { "tire_check", "battery_check", "engine_check" },
                        Description = "輪胎檢查及電瓶檢測，引擎系統檢查",
                        Cost = 1800,
                        Technician = "陳技師"
                    },
                    new()
                    {
                        Id = 3,
                        Date = "2023-07-10",
                        Mileage = 75000,
                        MaintenanceItems = new [] { "oil_change", "air_conditioning", "electrical_system" },
                        Description = "機油更換，冷氣系統保養，電系檢查",
                        Cost = 3200,
                        Technician = "張技師"
                    },
                    new()
                    {
                        Id = 4,
                        Date = "2023-04-05",
                        Mileage = 72000,
                        MaintenanceItems = new [] { "transmission_check", "electrical_system" },
                        Description = "變速箱檢查，電系系統維護",
                        Cost = 2800,
                        Technician = "王技師"
                    },
                    new()
                    {
                        Id = 5,
                        Date = "2023-01-20",
                        Mileage = 68000,
                        MaintenanceItems = new [] { "oil_change", "filter_change", "tire_check" },
                        Description = "定期保養，機油更換，輪胎檢查",
                        Cost = 2200,
                        Technician = "李技師"
                    }
                }
            }
        };

        [HttpGet("{plateNumber}")]
        public IActionResult GetVehicleInfo([FromRoute] string plateNumber)
        {
            if (!PlateNumberToVehicleData.TryGetValue(plateNumber, out var data))
            {
                return NotFound(new { message = "Vehicle not found" });
            }

            var result = new
            {
                plateNumber = data.PlateNumber,
                model = data.Model,
                owner = data.Owner,
                currentMileage = data.CurrentMileage
            };

            return Ok(result);
        }

        [HttpGet("{plateNumber}/maintenance")]
        public IActionResult GetMaintenanceRecords([FromRoute] string plateNumber, [FromQuery] string? date)
        {
            if (!PlateNumberToVehicleData.TryGetValue(plateNumber, out var data))
            {
                return NotFound(new { message = "Vehicle not found" });
            }

            IEnumerable<MaintenanceRecord> records = data.MaintenanceRecords;
            if (!string.IsNullOrWhiteSpace(date))
            {
                records = records.Where(r => string.Equals(r.Date, date, StringComparison.Ordinal));
            }

            return Ok(records);
        }

        [HttpGet("{plateNumber}/maintenance/dates")]
        public IActionResult GetAvailableDates([FromRoute] string plateNumber)
        {
            if (!PlateNumberToVehicleData.TryGetValue(plateNumber, out var data))
            {
                return NotFound(new { message = "Vehicle not found" });
            }

            var dates = data.MaintenanceRecords
                .Select(r => r.Date)
                .Distinct()
                .OrderByDescending(d => d)
                .ToList();

            return Ok(dates);
        }

        private sealed class VehicleData
        {
            public string PlateNumber { get; set; } = string.Empty;
            public string Model { get; set; } = string.Empty;
            public string Owner { get; set; } = string.Empty;
            public int CurrentMileage { get; set; }
            public List<MaintenanceRecord> MaintenanceRecords { get; set; } = new();
        }

        private sealed class MaintenanceRecord
        {
            public int Id { get; set; }
            public string Date { get; set; } = string.Empty; // yyyy-MM-dd
            public int Mileage { get; set; }
            public IEnumerable<string> MaintenanceItems { get; set; } = Array.Empty<string>();
            public string? Description { get; set; }
            public int? Cost { get; set; }
            public string? Technician { get; set; }
        }
    }
}



