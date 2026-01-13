namespace WebApi.Models.ViewModels.App
{
    /// <summary>
    /// 客戶資料視圖模型（Repository 層使用）
    /// </summary>
    public class CustomerViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
    }
}
