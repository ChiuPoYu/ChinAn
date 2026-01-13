using WebApi.Models.DBModels;
using WebApi.Models.Enums;
using WebApi.Models.ParamModels;
using WebApi.Models.Views.Web;
using WebApi.Repositories.Interfaces;
using WebApi.Services.Interfaces.Web;

namespace WebApi.Services.Web;

/// <summary>
/// 預約業務服務實作。
/// </summary>
public class BookingService : IBookingSerive
{
    private readonly IBookingRepository _bookingRepository;

    public BookingService(IBookingRepository bookingRepository)
    {
        _bookingRepository = bookingRepository;
    }

    /// <inheritdoc />
    public async Task<List<BookingView>> GetBookingListAsync()
    {
        try
        {
            var bookings = await _bookingRepository.GetAllBookingsAsync();
            return bookings.Select(b => new BookingView
            {
                Id = b.Id,
                EmployeeId = b.EmployeeId,
                EmployeeName = b.EmployeeName,
                VehicleId = b.VehicleId,
                PlateNumber = b.PlateNumber,
                BookingDate = b.BookingDate,
                Status = b.Status
            }).ToList();
        }
        catch (Exception ex)
        {
            throw new Exception("An error occurred while retrieving bookings.", ex);
        }
    }

    /// <inheritdoc />
    public async Task<BookingView> GetBookingByIdAsync(int bookingId)
    {
        try
        {
            var booking = await _bookingRepository.GetBookingByIdAsync(bookingId);
            if (booking == null)
            {
                throw new Exception($"Booking with ID {bookingId} not found.");
            }

            return new BookingView
            {
                Id = booking.Id,
                EmployeeId = booking.EmployeeId,
                EmployeeName = booking.EmployeeName,
                VehicleId = booking.VehicleId,
                PlateNumber = booking.PlateNumber,
                BookingDate = booking.BookingDate,
                Status = booking.Status
            };
        }
        catch (Exception ex)
        {
            throw new Exception("An error occurred while retrieving booking.", ex);
        }
    }

    /// <inheritdoc />
    public async Task CreateBookingAsync(CreateBookingParam param)
    {
        try
        {
            var booking = new Booking
            {
                EmployeeId = param.EmployeeId,
                VehicleId = param.VehicleId,
                BookingDate = param.BookingDate,
                Status = BookingStatus.Pending
            };

            await _bookingRepository.AddBookingAsync(booking);
        }
        catch (Exception ex)
        {
            throw new Exception("An error occurred while creating booking.", ex);
        }
    }

    /// <inheritdoc />
    public async Task UpdateBookingAsync(UpdateBookingParam param)
    {
        try
        {
            var existingBooking = await _bookingRepository.GetBookingByIdAsync(param.Id);
            if (existingBooking == null)
            {
                throw new Exception($"Booking with ID {param.Id} not found.");
            }

            var booking = new Booking
            {
                Id = param.Id,
                EmployeeId = param.EmployeeId ?? existingBooking.EmployeeId,
                VehicleId = param.VehicleId ?? existingBooking.VehicleId,
                BookingDate = param.BookingDate ?? existingBooking.BookingDate,
                Status = param.Status ?? existingBooking.Status
            };

            await _bookingRepository.UpdateBookingAsync(booking);
        }
        catch (Exception ex)
        {
            throw new Exception("An error occurred while updating booking.", ex);
        }
    }

    /// <inheritdoc />
    public async Task CancelBookingAsync(int bookingId)
    {
        try
        {
            var booking = await _bookingRepository.GetBookingByIdAsync(bookingId);
            if (booking == null)
            {
                throw new Exception($"Booking with ID {bookingId} not found.");
            }

            await _bookingRepository.DeleteBookingAsync(bookingId);
        }
        catch (Exception ex)
        {
            throw new Exception("An error occurred while canceling booking.", ex);
        }
    }
}