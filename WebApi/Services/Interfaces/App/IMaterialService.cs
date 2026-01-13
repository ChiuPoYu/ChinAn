using WebApi.Models.ParamModels;
using WebApi.Models.ViewModels.App;
using WebApi.Models.Views.App;

namespace WebApi.Services.Interfaces.App
{
    /// <summary>
    /// 定義材料業務服務介面
    /// </summary>
    public interface IMaterialService
    {
        /// <summary>
        /// 取得所有材料清單
        /// </summary>
        /// <returns>材料清單</returns>
        Task<List<MaterialView>> GetAllAsync();

        /// <summary>
        /// 根據 ID 獲得材料資料
        /// </summary>
        /// <param name="id">材料 ID</param>
        /// <returns>材料資料</returns>
        Task<MaterialView> GetByIdAsync(int id);

        /// <summary>
        /// 新增材料資料
        /// </summary>
        /// <param name="param">新增材料的參數</param>
        Task CreateAsync(CreateMaterialParam param);

        /// <summary>
        /// 更新材料資料
        /// </summary>
        /// <param name="param">更新材料的參數</param>
        Task UpdateAsync(UpdateMaterialParam param);

        /// <summary>
        /// 刪除材料資料
        /// </summary>
        /// <param name="id">材料編號</param>
        Task DeleteAsync(int id);
    }
}
