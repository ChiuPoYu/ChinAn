using WebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace WebApi.Services
{
    public class MaintenanceService
    {
        private readonly AppDbContext _context;

        public MaintenanceService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<MaintenanceRecord>> GetMaintenanceRecordsByPlateNumberAsync(string plateNumber)
        {
            return await _context.MaintenanceRecords
                .Where(m => m.PlateNumber == plateNumber)
                .ToListAsync();
        }

        
    }
}
