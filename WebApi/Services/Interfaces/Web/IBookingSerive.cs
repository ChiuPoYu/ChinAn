using WebApi.Models.ParamModels;
using WebApi.Models.Views.Web;

namespace WebApi.Services.Interfaces.Web;

/// <summary>
/// 定義預約業務服務介面。
/// </summary>
public interface IBookingSerive
{
    /// <summary>
    /// 獲得預約清單。
    /// </summary>
    /// <returns>預約清單。</returns>
    Task<List<BookingView>> GetBookingListAsync();

    /// <summary>
    /// 根據 ID 獲得預約資料
    /// </summary>
    /// <param name="bookingId">預約 ID</param>
    /// <returns>預約資料</returns>
    Task<BookingView> GetBookingByIdAsync(int bookingId);

    /// <summary>
    /// 創建新的預約。
    /// </summary>
    /// <param name="param">創建預約的參數。</param>
    Task CreateBookingAsync(CreateBookingParam param);

    /// <summary>
    /// 更新預約資料
    /// </summary>
    /// <param name="param">更新預約的參數</param>
    Task UpdateBookingAsync(UpdateBookingParam param);

    /// <summary>
    /// 取消預約。
    /// </summary>
    /// <param name="bookingId">預約 ID。</param>
    Task CancelBookingAsync(int bookingId);
}