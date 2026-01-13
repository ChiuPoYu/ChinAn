using WebApi.Models.DBModels;
using WebApi.Models.ViewModels.Web;

namespace WebApi.Repositories.Interfaces;

/// <summary>
/// 定義預約資料的資料存取介面。
/// </summary>
public interface IBookingRepository
{
    /// <summary>
    /// 獲得所有預約清單
    /// </summary>
    /// <returns>預約清單。</returns>
    Task<List<BookingViewModel>> GetAllBookingsAsync();

    /// <summary>
    /// 根據 ID 獲得預約資料
    /// </summary>
    /// <param name="bookingId">預約 ID。</param>
    /// <returns>預約資料。</returns>
    Task<BookingViewModel?> GetBookingByIdAsync(int bookingId);

    /// <summary>
    /// 新增預約資料
    /// </summary>
    /// <param name="booking">預約資料。</param>
    Task AddBookingAsync(Booking booking);

    /// <summary>
    /// 更新預約資料
    /// </summary>
    /// <param name="booking">預約資料</param>
    Task UpdateBookingAsync(Booking booking);

    /// <summary>
    /// 刪除預約資料
    /// </summary>
    /// <param name="bookingId">預約編號</param>
    Task DeleteBookingAsync(int bookingId);
}