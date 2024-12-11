

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
    public int Total { get; }
    public bool HasNextPage => PageNumber * PageSize < Total;
    public bool HasPreviousPage => PageNumber > 1;

    //public async Task<PaginatedResult<TValue>> CreateAsync(IQueryable<TValue> query, int pageSize, int pageNumber)
    //{
    //    var items = await query.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();
    //}

}
