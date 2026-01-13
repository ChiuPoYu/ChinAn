using System.ComponentModel.DataAnnotations;

namespace WebApi.Models.ParamModels
{
    /// <summary>
    /// 更新客戶參數模型
    /// </summary>
    public class UpdateCustomerParam
    {
        /// <summary>
        /// 客戶編號
        /// </summary>
        [Required(ErrorMessage = "客戶編號為必填項")]
        public required int Id { get; set; }

        /// <summary>
        /// 客戶姓名
        /// </summary>
        [MaxLength(50, ErrorMessage = "客戶姓名長度不可超過50個字元")]
        public string? Name { get; set; }

        /// <summary>
        /// 客戶電話
        /// </summary>
        [MaxLength(20, ErrorMessage = "客戶電話長度不可超過20個字元")]
        public string? Phone { get; set; }

        /// <summary>
        /// 客戶電子郵件
        /// </summary>
        [MaxLength(100, ErrorMessage = "客戶電子郵件長度不可超過100個字元")]
        [EmailAddress(ErrorMessage = "請輸入有效的電子郵件格式")]
        public string? Email { get; set; }
    }
}
