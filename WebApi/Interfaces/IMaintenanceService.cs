using WebApi.Models;

namespace WebApi.Interfaces
{
    public interface IMaintenanceService
    {
        /// <summary>
        /// 取得所有車輛(不含保養紀錄)
        /// </summary>
        /// <returns></returns>
        Task<List<Vehicle>> GetAllVehiclesAsync();


        // 其他方法...
        /// <summary>
        /// 取得特定車輛保養紀錄
        /// </summary>
        /// <param name="plateNumber"></param>
        /// <returns></returns>
        Task<List<MaintenanceRecord>> GetMaintenanceRecordsByPlateNumberAsync(string plateNumber);


        /// <summary>
        /// 取得所有客戶資料
        /// </summary>
        /// <returns></returns>
        Task<List<Customer>> GetAllCustomersAsync();

        /// <summary>
        /// 插入新的保養紀錄
        /// </summary>
        /// <param name="record"></param>
        /// <returns></returns>
        Task<MaintenanceRecord> InsertMaintenanceRecordAsync(MaintenanceRecord record);

        /// <summary>
        /// 建立或取得使用者
        /// </summary>
        /// <param name="customer"></param>
        /// <returns></returns>
        Task<Customer> GetOrCreateUserAsync(Customer customer);

        /// <summary>
        /// 建立或取得車輛
        /// </summary>
        /// <param name="vehicle"></param>
        /// <returns></returns>
        Task<Vehicle> GetOrCreateVehicleAsync(Vehicle vehicle);
    }
}
