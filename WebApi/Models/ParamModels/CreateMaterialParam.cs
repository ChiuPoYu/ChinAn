using System.ComponentModel.DataAnnotations;

namespace WebApi.Models.ParamModels
{
    /// <summary>
    /// 新增材料參數模型
    /// </summary>
    public class CreateMaterialParam
    {
        /// <summary>
        /// 商品名稱
        /// </summary>
        [Required(ErrorMessage = "商品名稱為必填項")]
        [MaxLength(50, ErrorMessage = "商品名稱長度不可超過50個字元")]
        public required string Name { get; set; }

        /// <summary>
        /// 品牌
        /// </summary>
        [Required(ErrorMessage = "品牌為必填項")]
        [MaxLength(30, ErrorMessage = "品牌長度不可超過30個字元")]
        public required string Brand { get; set; }

        /// <summary>
        /// 規格
        /// </summary>
        [Required(ErrorMessage = "規格為必填項")]
        [MaxLength(50, ErrorMessage = "規格長度不可超過50個字元")]
        public required string Specification { get; set; }

        /// <summary>
        /// 價格
        /// </summary>
        [Required(ErrorMessage = "價格為必填項")]
        [Range(0, double.MaxValue, ErrorMessage = "價格必須大於或等於0")]
        public required decimal Price { get; set; }

        /// <summary>
        /// 庫存數量
        /// </summary>
        [Required(ErrorMessage = "庫存數量為必填項")]
        [Range(0, int.MaxValue, ErrorMessage = "庫存數量必須大於或等於0")]
        public required int InventoryQuantity { get; set; }
    }
}
