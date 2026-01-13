using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebApi.Models.DBModels;

/// <summary>
/// 商品資料
/// </summary>
public class Product
{
    [Key]
    [Comment("商品編號")]
    public int Id { get; set; }

    [MaxLength(50)]
    [Comment("商品名稱")]
    public string Name { get; set; }

    [MaxLength(30)]
    [Comment("品牌")]
    public string Brand { get; set; }

    [MaxLength(50)]
    [Comment("規格")]
    public string Specification { get; set; }

    [Column(TypeName = "decimal(10,2)")]
    [Comment("價格")]
    public decimal Price { get; set; }

    [Comment("庫存數量")]
    public int InventoryQuantity { get; set; }
}