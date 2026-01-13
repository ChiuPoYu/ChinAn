using WebApi.Models.ParamModels;
using WebApi.Models.Views.App;

namespace WebApi.Services.Interfaces.App;

/// <summary>
/// 定義客戶業務服務介面
/// </summary>
public interface ICustomerSerivce
{
    /// <summary>
    /// 根據 ID 獲得客戶資料
    /// </summary>
    /// <param name="id">客戶 ID</param>
    /// <returns>客戶資料</returns>
    Task<CustomerView> GetCustomerByIdAsync(int id);

    /// <summary>
    /// 取得所有客戶清單
    /// </summary>
    /// <returns>客戶清單</returns>
    Task<List<CustomerView>> GetAllCustomersAsync();

    /// <summary>
    /// 創建新的客戶
    /// </summary>
    /// <param name="param">創建客戶的參數</param>
    Task CreateCustomerAsync(CreateCustomerParam param);

    /// <summary>
    /// 更新客戶資料
    /// </summary>
    /// <param name="param">更新客戶的參數</param>
    Task UpdateCustomerAsync(UpdateCustomerParam param);

    /// <summary>
    /// 刪除客戶資料
    /// </summary>
    /// <param name="id">客戶編號</param>
    Task DeleteCustomerAsync(int id);
}
