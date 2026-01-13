namespace WebApi.Models.ResponseModel;
public class ResultResponse : BaseResponse
{
    public ResultResponse(bool success = true, string? message = null, string? errorCode = null)
        : base(success, message, errorCode)
    {
    }
}

