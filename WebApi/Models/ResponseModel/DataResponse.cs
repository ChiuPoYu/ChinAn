namespace WebApi.Models.ResponseModel;
public class DataResponse<T> : BaseResponse
{
    public T? Data { get; }

    public DataResponse(T data, string? message = null)
        : base(true, message)
    {
        Data = data;
    }

    public static DataResponse<T> Fail(string message, string? errorCode = null)
        => new DataResponse<T>(default!)
        {
            Success = false,
            Message = message,
            ErrorCode = errorCode
        };
}

