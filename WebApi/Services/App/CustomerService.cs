using WebApi.Models.DBModels;
using WebApi.Models.ParamModels;
using WebApi.Models.Views.App;
using WebApi.Repositories.Interfaces;
using WebApi.Services.Interfaces.App;

namespace WebApi.Services.App;

/// <summary>
/// 客戶業務服務實作。
/// </summary>
public class CustomerService : ICustomerSerivce
{
    private readonly ICustomerRepository _customerRepository;

    public CustomerService(ICustomerRepository customerRepository)
    {
        _customerRepository = customerRepository;
    }

    /// <inheritdoc />
    public async Task<CustomerView> GetCustomerByIdAsync(int id)
    {
        try
        {
            var customer = await _customerRepository.GetCustomerByIdAsync(id);
            if (customer == null)
            {
                throw new Exception($"Customer with ID {id} not found.");
            }

            return new CustomerView
            {
                Id = customer.Id,
                Name = customer.Name,
                Email = customer.Email,
                Phone = customer.Phone
            };
        }
        catch (Exception ex)
        {
            throw new Exception("An error occurred while retrieving customer.", ex);
        }
    }

    /// <inheritdoc />
    public async Task<List<CustomerView>> GetAllCustomersAsync()
    {
        try
        {
            var customers = await _customerRepository.GetAllCustomersAsync();
            return customers.Select(c => new CustomerView
            {
                Id = c.Id,
                Name = c.Name,
                Email = c.Email,
                Phone = c.Phone
            }).ToList();
        }
        catch (Exception ex)
        {
            throw new Exception("An error occurred while retrieving customers.", ex);
        }
    }

    /// <inheritdoc />
    public async Task CreateCustomerAsync(CreateCustomerParam param)
    {
        try
        {
            var customer = new Customer
            {
                Name = param.Name,
                Email = param.Email,
                Phone = param.Phone,
                CreateDateTime = DateTime.UtcNow
            };

            await _customerRepository.AddCustomerAsync(customer);
        }
        catch (Exception ex)
        {
            throw new Exception("An error occurred while creating customer.", ex);
        }
    }

    /// <inheritdoc />
    public async Task UpdateCustomerAsync(UpdateCustomerParam param)
    {
        try
        {
            var existingCustomer = await _customerRepository.GetCustomerByIdAsync(param.Id);
            if (existingCustomer == null)
            {
                throw new Exception($"Customer with ID {param.Id} not found.");
            }

            var customer = new Customer
            {
                Id = param.Id,
                Name = param.Name ?? existingCustomer.Name,
                Email = param.Email ?? existingCustomer.Email,
                Phone = param.Phone ?? existingCustomer.Phone,
                UpdateDateTime = DateTime.UtcNow
            };

            await _customerRepository.UpdateCustomerAsync(customer);
        }
        catch (Exception ex)
        {
            throw new Exception("An error occurred while updating customer.", ex);
        }
    }

    /// <inheritdoc />
    public async Task DeleteCustomerAsync(int id)
    {
        try
        {
            var customer = await _customerRepository.GetCustomerByIdAsync(id);
            if (customer == null)
            {
                throw new Exception($"Customer with ID {id} not found.");
            }

            await _customerRepository.DeleteCustomerAsync(id);
        }
        catch (Exception ex)
        {
            throw new Exception("An error occurred while deleting customer.", ex);
        }
    }
}