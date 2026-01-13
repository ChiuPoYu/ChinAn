using Microsoft.EntityFrameworkCore;
using WebApi.Models.DBModels;
using WebApi.Models.ViewModels.App;
using WebApi.Repositories.Interfaces;

namespace WebApi.Repositories
{
    public class MaintenanceRepository : IMaintenanceRepository
    {
        private readonly AppDbContext _context;

        public MaintenanceRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<MaintenanceRecordViewModel>> GetMaintenanceRecordsByPlateNumberAsync(string plateNumber)
        {
            var records = await _context.MaintenanceRecords
                .Where(r => r.Vehicle.PlateNumber == plateNumber)
                .Select(r => new MaintenanceRecordViewModel
                {
                    VehicleId = r.VehicleId,
                    Date = DateOnly.Parse(r.CreateDateTime.ToString()),
                    Mileage = r.Mileage,
                    MaintenanceItems = r.MaintenanceItems,
                    Description = r.Description,
                    Cost = r.TotalCost,
                    Technician = r.Employee.Name
                })
                .ToListAsync<MaintenanceRecordViewModel>();

            return records;
        }

        // Repository methods can be added here if needed in the future.
    }
}