namespace WebApi.Models.Views.Web
{
    /// <summary>
    /// 預約清單視圖模型
    /// </summary>
    public class BookingListView
    {
        /// <summary>
        /// 預約清單
        /// </summary>
        public required List<BookingView> Bookings { get; set; }
    }
}
