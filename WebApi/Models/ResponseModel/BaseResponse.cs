namespace WebApi.Models.ResponseModel;

public class BaseResponse
{
    public bool Success { get; protected set; }
    public string? Message { get; protected set; }
    public string? ErrorCode { get; protected set; }

    protected BaseResponse(bool success, string? message = null, string? errorCode = null)
    {
        Success = success;
        Message = message;
        ErrorCode = errorCode;
    }
}
