using WebApi.Models.DBModels;
using WebApi.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using WebApi.Models.ViewModels.App;

namespace WebApi.Repositories;

/// <summary>
/// 客戶資料的資料存取實作。
/// </summary>
public class CustomerRepository : ICustomerRepository
{
    private readonly AppDbContext _context;

    public CustomerRepository(AppDbContext context)
    {
        _context = context;
    }

    /// <inheritdoc />
    public async Task<CustomerViewModel?> GetCustomerByIdAsync(int id)
    {
        return await _context.Customers
            .Where(c => c.Id == id)
            .Select(c => new CustomerViewModel
            {
                Id = c.Id,
                Name = c.Name ?? string.Empty,
                Phone = c.Phone ?? string.Empty,
                Email = c.Email ?? string.Empty
            })
            .FirstOrDefaultAsync();
    }

    /// <inheritdoc />
    public async Task<List<CustomerViewModel>> GetAllCustomersAsync()
    {
        return await _context.Customers
            .Select(c => new CustomerViewModel
            {
                Id = c.Id,
                Name = c.Name ?? string.Empty,
                Phone = c.Phone ?? string.Empty,
                Email = c.Email ?? string.Empty
            })
            .ToListAsync();
    }

    /// <inheritdoc />
    public async Task AddCustomerAsync(Customer customer)
    {
        await _context.Customers.AddAsync(customer);
        await _context.SaveChangesAsync();
    }

    /// <inheritdoc />
    public async Task UpdateCustomerAsync(Customer customer)
    {
        _context.Customers.Update(customer);
        await _context.SaveChangesAsync();
    }

    /// <inheritdoc />
    public async Task DeleteCustomerAsync(int id)
    {
        var customer = await _context.Customers.FindAsync(id);
        if (customer != null)
        {
            _context.Customers.Remove(customer);
            await _context.SaveChangesAsync();
        }
    }
}