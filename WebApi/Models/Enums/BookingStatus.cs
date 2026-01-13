namespace WebApi.Models.Enums
{
    /// <summary>
    /// 預約狀態
    /// </summary>
    public enum BookingStatus
    {
        Pending,     // 待確認
        Confirmed,   // 已確認
        Completed,   // 已完成
        Cancelled    // 已取消
    }
}
