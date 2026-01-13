using System.ComponentModel.DataAnnotations;
using WebApi.Models.Enums;

namespace WebApi.Models.ParamModels
{
    /// <summary>
    /// 更新預約參數模型
    /// </summary>
    public class UpdateBookingParam
    {
        /// <summary>
        /// 預約編號
        /// </summary>
        [Required(ErrorMessage = "預約編號為必填項")]
        public required int Id { get; set; }

        /// <summary>
        /// 員工編號
        /// </summary>
        public int? EmployeeId { get; set; }

        /// <summary>
        /// 車輛編號
        /// </summary>
        public int? VehicleId { get; set; }

        /// <summary>
        /// 預約日期
        /// </summary>
        public DateTime? BookingDate { get; set; }

        /// <summary>
        /// 預約狀態
        /// </summary>
        public BookingStatus? Status { get; set; }
    }
}
