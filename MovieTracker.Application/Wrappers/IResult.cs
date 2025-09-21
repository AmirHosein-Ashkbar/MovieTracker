using MovieTracker.Domain.Enums;

namespace MovieTracker.Application.Wrappers;
public interface IResult
{
    public StatusCode StatusCode { get; }
    public bool IsSuccess { get; }
    public string Message { get; } 
    public string? Error { get; }
}
