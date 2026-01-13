using WebApi.Models.DBModels;
using WebApi.Models.ViewModels.App;

namespace WebApi.Repositories.Interfaces
{
    /// <summary>
    /// 定義材料資料的資料存取介面
    /// </summary>
    public interface IMaterialRepository
    {
        /// <summary>
        /// 取得所有材料清單
        /// </summary>
        /// <returns>材料清單</returns>
        Task<List<MaterailViewModel>> GetAllMaterialsAsync();

        /// <summary>
        /// 根據 ID 獲得材料資料
        /// </summary>
        /// <param name="id">材料 ID</param>
        /// <returns>材料資料</returns>
        Task<MaterailViewModel?> GetMaterialByIdAsync(int id);

        /// <summary>
        /// 新增材料資料
        /// </summary>
        /// <param name="product">材料資料</param>
        Task AddMaterialAsync(Product product);

        /// <summary>
        /// 更新材料資料
        /// </summary>
        /// <param name="product">材料資料</param>
        Task UpdateMaterialAsync(Product product);

        /// <summary>
        /// 刪除材料資料
        /// </summary>
        /// <param name="id">材料編號</param>
        Task DeleteMaterialAsync(int id);
    }
}
