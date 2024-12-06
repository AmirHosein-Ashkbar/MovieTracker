

using MovieTracker.Application.Errors;

namespace MovieTracker.Application.Wrappers;

public class PaginatedResult<TValue> : Result<List<TValue>>
{
    public PaginatedResult(List<TValue> value, int pageNumber, int pageSize, bool isSuccess, Error error, string message = "") : base(value, isSuccess, error, message)
    {
        PageNumber = pageNumber;
        PageSize = pageSize;
        Total = Value.Count;
    }
    public int PageNumber { get; }
    public int PageSize { get; }
    public int Total { get; set; }
}
