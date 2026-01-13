using System.ComponentModel.DataAnnotations;

namespace WebApi.Models.ParamModels
{
    /// <summary>
    /// 新增客戶參數模型
    /// </summary>
    public class CreateCustomerParam
    {
        /// <summary>
        /// 客戶姓名
        /// </summary>
        [Required(ErrorMessage = "客戶姓名為必填項")]
        [MaxLength(50, ErrorMessage = "客戶姓名長度不可超過50個字元")]
        public required string Name { get; set; }

        /// <summary>
        /// 客戶電話
        /// </summary>
        [Required(ErrorMessage = "客戶電話為必填項")]
        [MaxLength(20, ErrorMessage = "客戶電話長度不可超過20個字元")]
        public required string Phone { get; set; }

        /// <summary>
        /// 客戶電子郵件
        /// </summary>
        [Required(ErrorMessage = "客戶電子郵件為必填項")]
        [MaxLength(100, ErrorMessage = "客戶電子郵件長度不可超過100個字元")]
        [EmailAddress(ErrorMessage = "請輸入有效的電子郵件格式")]
        public required string Email { get; set; }
    }
}
