using System.ComponentModel.DataAnnotations;

namespace WebApi.Models.ParamModels
{
    /// <summary>
    /// 新增預約參數模型
    /// </summary>
    public class CreateBookingParam
    {
        /// <summary>
        /// 員工編號
        /// </summary>
        [Required(ErrorMessage = "員工編號為必填項")]
        public required int EmployeeId { get; set; }

        /// <summary>
        /// 車輛編號
        /// </summary>
        [Required(ErrorMessage = "車輛編號為必填項")]
        public required int VehicleId { get; set; }

        /// <summary>
        /// 預約日期
        /// </summary>
        [Required(ErrorMessage = "預約日期為必填項")]
        public required DateTime BookingDate { get; set; }
    }
}
