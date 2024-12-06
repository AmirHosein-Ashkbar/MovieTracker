using MovieTracker.Application.Errors;

namespace MovieTracker.Application.Wrappers;
public interface IResult
{
    public bool IsSuccess { get; }
    public string Message { get; } 
    public Error Error { get; }
}
