
namespace MovieTracker.Application.Wrappers;

public class Result<T>
{
    private readonly T? _data;
    private readonly string _message;
    private readonly List<string> _errors;
    private readonly bool _isSuccess;

    private Result(T data)
    {
        _isSuccess = false;
        _data = data;
        _message = string.Empty;
        _errors = new List<string>();
    }

    private Result(string message, List<string> error)
    {
        _isSuccess = false;
        _data = default;
        _message = message;
        _errors = new List<string>();
    }

    public static Result<T> Success(T data)
    {

        return new Result<T>(data);
    }

}
