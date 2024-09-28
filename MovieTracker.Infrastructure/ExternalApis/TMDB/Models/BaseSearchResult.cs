namespace MovieTracker.Infrastructure.ExternalApis.TMDB.Models;

public class BaseSearchResult<T>
{
    public int Page { get; set; }
    public List<T> Results { get; set; }
    public int TotalPages { get; set; }
    public int TotalResults { get; set; }
}
