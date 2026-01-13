using WebApi.Models.Enums;

namespace WebApi.Models.ViewModels.Web
{
    /// <summary>
    /// 預約資料視圖模型（Repository 層使用）
    /// </summary>
    public class BookingViewModel
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; } = string.Empty;
        public int VehicleId { get; set; }
        public string PlateNumber { get; set; } = string.Empty;
        public DateTime BookingDate { get; set; }
        public BookingStatus Status { get; set; }
    }
}
