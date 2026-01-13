using System.ComponentModel.DataAnnotations;

namespace WebApi.Models.ParamModels
{
    /// <summary>
    /// Represents the parameters required for creating or updating a maintenance record.
    /// </summary>
    public class MaintenanceRecordParam
    {
        /// <summary>
        /// 車輛Id
        /// </summary>
        [Required]
        public required string VehicleId { get; set; }

        /// <summary>
        /// 員工編號
        /// </summary>
        [Required]
        public required int EmployeeId { get; set; }

        /// <summary>
        /// 保養日期
        /// </summary>
        [Required]
        public required DateOnly Date { get; set; }

        /// <summary>
        /// 里程數
        /// </summary>
        [Required]
        public required int Mileage { get; set; }

        /// <summary>
        /// 保養項目
        /// </summary>
        [Required]
        public required string MaintenanceItems { get; set; }

        /// <summary>
        /// 保養說明
        /// </summary>
        [Required]
        public required string Description { get; set; }

        /// <summary>
        /// 總花費
        /// </summary>
        [Required]
        public required int Cost { get; set; }

        
    }
}
