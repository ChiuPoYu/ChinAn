namespace WebApi.Models.ViewModels.App
{
    public class MaterailViewModel
    {
            public int Id { get; set; }
            public string Type { get; set; } = string.Empty;   // 類型 (例如: 機油)
            public string Brand { get; set; } = string.Empty;  // 品牌
            public string Model { get; set; } = string.Empty;  // 型號
            public decimal Price { get; set; }                 // 價格
            public int Quantity { get; set; }                  // 數量
            public string ImageUrl { get; set; } = string.Empty; // 圖片連結
        }
    
}
