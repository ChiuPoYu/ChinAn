namespace WebApi.Resources
{
    /// <summary>
    /// Appsettings 名稱常數。
    /// </summary>
    public class AppSettingsKey
    {
        /// <summary>
        /// 資料庫連線字串
        /// </summary>
        public const string DBConnection = "ConnectionStrings:DefaultConnection";

        /// <summary>
        /// 使用者前端網址
        /// </summary>
        public const string UserWebUrl = "WebUrl:UserWebUrl";

        /// <summary>
        /// 員工前端網址
        /// </summary>
        public const string EmpWebUrl = "WebUrl:EmpWebUrl";

        /// <summary>
        /// Web API 網址
        /// </summary>
        public const string WebApiUrl = "WebUrl:WebApiUrl";

        /// <summary>
        /// 允許的來源（CORS）
        /// </summary>
        public const string AllowedOrigins = "AllowedOrigins";

        /// <summary>
        /// 來源名稱（CORS）
        /// </summary>
        public const string CorsPolicyName = "CorsPolicyName";

        /// <summary>
        /// JWT 設定 - Issuer
        /// </summary>
        public const string JwtIssuer = "Jwt:Issuer";

        /// <summary>
        /// JWT 設定 - Audience
        /// </summary>
        public const string JwtAudience = "Jwt:Audience";

        /// <summary>
        /// JWT 設定 - SecretKey
        /// </summary>
        public const string JwtSecretKey = "Jwt:SecretKey";

    }
}
