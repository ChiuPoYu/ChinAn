using Microsoft.EntityFrameworkCore;
using WebApi.Models.DBModels;
using WebApi.Models.ParamModels;
using WebApi.Repositories.Interfaces;
using WebApi.Services.Interfaces.App;
using WebApi.Models.ViewModels.App;
using WebApi.Models.Views.App;

namespace WebApi.Services.App
{
    public class MaintenanceService : IMaintenanceService
    {
        private readonly IMaintenanceRepository _maintenanceRepository;

        public MaintenanceService(IMaintenanceRepository maintenanceRepository)
        {
            _maintenanceRepository = maintenanceRepository;
        }

        public async Task<List<MaintenanceRecordView>> GetMaintenanceRecordsByPlateNumberAsync(string plateNumber)
        {
            try
            {
                var reuslt = await _maintenanceRepository.GetMaintenanceRecordsByPlateNumberAsync(plateNumber);
                if (reuslt == null)
                {
                    throw new Exception("No maintenance records found for the given plate number.");
                }
                var maintenanceRecordViews = reuslt.Select(record => new MaintenanceRecordView
                {
                    VehicleId = record.VehicleId,
                    Date = record.Date,
                    Mileage = record.Mileage,
                    MaintenanceItems = record.MaintenanceItems.Select(item => new MaintenanceItemView
                    {
                        itemName = item.ItemName,
                        amount = item.Amount,
                        price = item.Price,
                        typeName = item.Product.Specification
                    }).ToList(),
                    Description = record.Description,
                    Cost = record.Cost,
                    Technician = record.Technician
                }).ToList();

                return maintenanceRecordViews;
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while retrieving maintenance records.", ex);
            }
        }
        public async Task InsertMaintenanceRecordAsync(MaintenanceRecordParam record)
        {
            
        }
    }
}
