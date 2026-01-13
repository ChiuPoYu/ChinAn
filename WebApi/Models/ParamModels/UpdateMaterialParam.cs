using System.ComponentModel.DataAnnotations;

namespace WebApi.Models.ParamModels
{
    /// <summary>
    /// 更新材料參數模型
    /// </summary>
    public class UpdateMaterialParam
    {
        /// <summary>
        /// 商品編號
        /// </summary>
        [Required(ErrorMessage = "商品編號為必填項")]
        public required int Id { get; set; }

        /// <summary>
        /// 商品名稱
        /// </summary>
        [MaxLength(50, ErrorMessage = "商品名稱長度不可超過50個字元")]
        public string? Name { get; set; }

        /// <summary>
        /// 品牌
        /// </summary>
        [MaxLength(30, ErrorMessage = "品牌長度不可超過30個字元")]
        public string? Brand { get; set; }

        /// <summary>
        /// 規格
        /// </summary>
        [MaxLength(50, ErrorMessage = "規格長度不可超過50個字元")]
        public string? Specification { get; set; }

        /// <summary>
        /// 價格
        /// </summary>
        [Range(0, double.MaxValue, ErrorMessage = "價格必須大於或等於0")]
        public decimal? Price { get; set; }

        /// <summary>
        /// 庫存數量
        /// </summary>
        [Range(0, int.MaxValue, ErrorMessage = "庫存數量必須大於或等於0")]
        public int? InventoryQuantity { get; set; }
    }
}
