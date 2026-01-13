namespace WebApi.Resources
{
    /// <summary>
    /// 提供一個標準化的回應訊息結構。
    /// </summary>
    public class ResponseMessage
    {
        /// <summary>
        /// 成功訊息。
        /// </summary>
        public const string Success = "成功";
        public const string SuccessCode = "200";

        #region 400 Bad Request Messages 相關訊息

        /// <summary>
        /// 無效參數。
        /// </summary>
        public const string InvalidParameter = "無效的參數";
        public const string InvalidParameterCode = "40001";

        #endregion

        #region 401 Unauthorized Messages 相關訊息
        /// <summary>
        /// Token無效。
        /// </summary>
        public const string InvaliViewken = "無效的令牌";
        public const string InvaliViewkenCode = "40101";


        #endregion

        #region 404 Not Found Messages 相關訊息
        /// <summary>
        /// 找不到車輛資料。
        /// </summary>
        public const string VehicleNotFound = "找不到車輛資料";
        public const string VehicleNotFoundCode = "40401";
        #endregion

        #region 500 Internal Server Error Messages 相關訊息
        /// <summary>
        /// 資料庫異常。
        /// </summary>
        public const string DatabaseError = "資料庫錯誤";
        public const string DatabaseErrorCode = "50001";

        #endregion 

        /// <summary>
        /// 禁止存取。
        /// </summary>
        public const string Forbidden = "禁止存取";
        public const string ForbiddenCode = "403";

        /// <summary>
        /// 請求超時。
        /// </summary>
        public const string RequestTimeout = "請求超時";
        public const string RequestTimeoutCode = "408";
    }
}
