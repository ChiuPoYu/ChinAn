namespace WebApi.Models.Views.App
{
    /// <summary>
    /// 材料資料視圖模型
    /// </summary>
    public class MaterialView
    {
        /// <summary>
        /// 商品編號
        /// </summary>
        public required int Id { get; set; }

        /// <summary>
        /// 商品名稱
        /// </summary>
        public required string Name { get; set; }

        /// <summary>
        /// 品牌
        /// </summary>
        public required string Brand { get; set; }

        /// <summary>
        /// 規格
        /// </summary>
        public required string Specification { get; set; }

        /// <summary>
        /// 價格
        /// </summary>
        public required decimal Price { get; set; }

        /// <summary>
        /// 庫存數量
        /// </summary>
        public required int InventoryQuantity { get; set; }
    }
}
