namespace WebApi.Models.ResponseModel;

public class ListResponse<T> : BaseResponse
{
    public IReadOnlyList<T> Items { get; }
    public int TotalCount { get; }

    public ListResponse(IEnumerable<T> items, string? message = null)
        : base(true, message)
    {
        Items = items.ToList();
        TotalCount = Items.Count;
    }

    public static ListResponse<T> Empty(string? message = "No data")
        => new ListResponse<T>(Array.Empty<T>(), message);
}


