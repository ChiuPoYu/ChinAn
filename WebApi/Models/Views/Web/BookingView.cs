using WebApi.Models.Enums;

namespace WebApi.Models.Views.Web
{
    /// <summary>
    /// 預約資料視圖模型
    /// </summary>
    public class BookingView
    {
        /// <summary>
        /// 預約編號
        /// </summary>
        public required int Id { get; set; }

        /// <summary>
        /// 員工編號
        /// </summary>
        public required int EmployeeId { get; set; }

        /// <summary>
        /// 員工姓名
        /// </summary>
        public required string EmployeeName { get; set; }

        /// <summary>
        /// 車輛編號
        /// </summary>
        public required int VehicleId { get; set; }

        /// <summary>
        /// 車牌號碼
        /// </summary>
        public required string PlateNumber { get; set; }

        /// <summary>
        /// 預約日期
        /// </summary>
        public required DateTime BookingDate { get; set; }

        /// <summary>
        /// 預約狀態
        /// </summary>
        public required BookingStatus Status { get; set; }
    }
}
