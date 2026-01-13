using WebApi.Models.DBModels;
using WebApi.Models.ViewModels.App;

namespace WebApi.Repositories.Interfaces;

/// <summary>
/// 定義客戶資料的資料存取介面。
/// </summary>
public interface ICustomerRepository
{
    /// <summary>
    /// 根據 ID 獲得客戶資料。
    /// </summary>
    /// <param name="id">客戶 ID。</param>
    /// <returns>客戶資料。</returns>
    Task<CustomerViewModel?> GetCustomerByIdAsync(int id);

    /// <summary>
    /// 取得所有客戶清單
    /// </summary>
    /// <returns>客戶清單</returns>
    Task<List<CustomerViewModel>> GetAllCustomersAsync();

    /// <summary>
    /// 新增客戶資料。
    /// </summary>
    /// <param name="customer">客戶資料。</param>
    Task AddCustomerAsync(Customer customer);

    /// <summary>
    /// 更新客戶資料
    /// </summary>
    /// <param name="customer">客戶資料</param>
    Task UpdateCustomerAsync(Customer customer);

    /// <summary>
    /// 刪除客戶資料
    /// </summary>
    /// <param name="id">客戶編號</param>
    Task DeleteCustomerAsync(int id);
}