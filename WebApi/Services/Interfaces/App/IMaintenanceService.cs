using WebApi.Models.ParamModels;
using WebApi.Models.Views.App;

namespace WebApi.Services.Interfaces.App
{
    public interface IMaintenanceService
    {
        /// <summary>
        /// 取得特定車輛保養紀錄
        /// </summary>
        /// <param name="plateNumber"></param>
        /// <returns></returns>
        public Task<List<MaintenanceRecordView>> GetMaintenanceRecordsByPlateNumberAsync(string plateNumber);

        /// <summary>
        /// 插入新的保養紀錄
        /// </summary>
        /// <param name="record"></param>
        /// <returns></returns>
        public Task InsertMaintenanceRecordAsync(MaintenanceRecordParam record);

    }
}
