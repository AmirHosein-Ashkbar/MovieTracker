
using MovieTracker.Application.Errors;
using System.Reflection.Metadata.Ecma335;

namespace MovieTracker.Application.Wrappers;

public class Result<T>
{
    public bool IsSuccess { get; }
    public T Data { get; }
    public string Message { get; }
    public List<Error> Errors { get; }

    private Result(T data)
    {
        IsSuccess = true;
        Data = data;
        Message = string.Empty;
        Errors = new List<Error>();
    }

    private Result(string message, List<Error> errors)
    {
        IsSuccess = false;
        Data = default;
        Message = message;
        Errors = errors;
    }

    public static Result<T> Success(T data)
    {

        return new Result<T>(data);
    }

    public static Result<T> Failure(string message, Error error) => 
        new Result<T>(message, new List<Error> { error });

    public static Result<T> Failure(string message, List<Error> errors) =>
        new Result<T>(message, errors);
    

    public static implicit operator Result<T>(T data) => Result<T>.Success(data);

    public static implicit operator Result<T>(Error error) => Result<T>.Failure("Error", error);

    public static implicit operator Result<T>(List<Error> errors) => Result<T>.Failure("Error",errors);
}
