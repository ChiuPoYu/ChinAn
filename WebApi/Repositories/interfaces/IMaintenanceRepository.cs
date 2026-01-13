
using WebApi.Models.ViewModels.App;
using WebApi.Models.Views.App;

namespace WebApi.Repositories.Interfaces
{
    public interface IMaintenanceRepository
    {
        Task<List<MaintenanceRecordViewModel>> GetMaintenanceRecordsByPlateNumberAsync(string plateNumber);
    }
}