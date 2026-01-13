namespace WebApi.Models.Views.App
{
    /// <summary>
    /// 客戶資料視圖模型
    /// </summary>
    public class CustomerView
    {
        /// <summary>
        /// 客戶編號
        /// </summary>
        public required int Id { get; set; }

        /// <summary>
        /// 客戶姓名
        /// </summary>
        public required string Name { get; set; }

        /// <summary>
        /// 客戶電話
        /// </summary>
        public required string Phone { get; set; }

        /// <summary>
        /// 客戶電子郵件
        /// </summary>
        public required string Email { get; set; }
    }
}
