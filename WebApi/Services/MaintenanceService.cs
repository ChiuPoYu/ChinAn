using WebApi.Models;
using Microsoft.EntityFrameworkCore;
using WebApi.Services.Interfaces;

namespace WebApi.Services
{
    public class MaintenanceService : IMaintenanceService
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

        
        public async Task<List<Vehicle>> GetAllVehiclesAsync()
        {
           return await _context.Vehicles.ToListAsync();
        }


        public async Task<List<Customer>> GetAllCustomersAsync()
        {
            return await _context.Customers.ToListAsync();
        }

        public async Task<MaintenanceRecord> InsertMaintenanceRecordAsync(MaintenanceRecord record)
        {
            _context.MaintenanceRecords.Add(record);
            await _context.SaveChangesAsync();
            return record;
        }

        public async Task<Customer> GetOrCreateUserAsync(Customer customer)
        {
            var existing = await _context.Customers.FirstOrDefaultAsync(u => u.Id == customer.Id);
            if (existing != null) return existing;
            _context.Customers.Add(customer);
            await _context.SaveChangesAsync();
            return customer;
        }

        public async Task<Vehicle> GetOrCreateVehicleAsync(Vehicle vehicle)
        {
            var existing = await _context.Vehicles.FirstOrDefaultAsync(v => v.PlateNumber == vehicle.PlateNumber);
            if (existing != null) return existing;
            _context.Vehicles.Add(vehicle);
            await _context.SaveChangesAsync();
            return vehicle;
        }
    }
}
