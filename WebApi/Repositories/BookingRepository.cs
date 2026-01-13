using WebApi.Models.DBModels;
using WebApi.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using WebApi.Models.ViewModels.Web;

namespace WebApi.Repositories;

/// <summary>
/// 預約資料的資料存取實作。
/// </summary>
public class BookingRepository : IBookingRepository
{
    private readonly AppDbContext _context;

    public BookingRepository(AppDbContext context)
    {
        _context = context;
    }

    /// <inheritdoc />
    public async Task<List<BookingViewModel>> GetAllBookingsAsync()
    {
        return await _context.Bookings
            .Include(b => b.Employee)
            .Include(b => b.Vehicle)
            .Select(b => new BookingViewModel
            {
                Id = b.Id,
                EmployeeId = b.EmployeeId,
                EmployeeName = b.Employee.Name,
                VehicleId = b.VehicleId,
                PlateNumber = b.Vehicle.PlateNumber,
                BookingDate = b.BookingDate,
                Status = b.Status
            })
            .ToListAsync();
    }

    /// <inheritdoc />
    public async Task<BookingViewModel?> GetBookingByIdAsync(int bookingId)
    {
        return await _context.Bookings
            .Include(b => b.Employee)
            .Include(b => b.Vehicle)
            .Where(b => b.Id == bookingId)
            .Select(b => new BookingViewModel
            {
                Id = b.Id,
                EmployeeId = b.EmployeeId,
                EmployeeName = b.Employee.Name,
                VehicleId = b.VehicleId,
                PlateNumber = b.Vehicle.PlateNumber,
                BookingDate = b.BookingDate,
                Status = b.Status
            })
            .FirstOrDefaultAsync();
    }

    /// <inheritdoc />
    public async Task AddBookingAsync(Booking booking)
    {
        await _context.Bookings.AddAsync(booking);
        await _context.SaveChangesAsync();
    }

    /// <inheritdoc />
    public async Task UpdateBookingAsync(Booking booking)
    {
        _context.Bookings.Update(booking);
        await _context.SaveChangesAsync();
    }

    /// <inheritdoc />
    public async Task DeleteBookingAsync(int bookingId)
    {
        var booking = await _context.Bookings.FindAsync(bookingId);
        if (booking != null)
        {
            _context.Bookings.Remove(booking);
            await _context.SaveChangesAsync();
        }
    }
}