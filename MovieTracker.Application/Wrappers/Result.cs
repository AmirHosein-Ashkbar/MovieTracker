
using MovieTracker.Application.Errors;

namespace MovieTracker.Application.Wrappers;

public class Result : IResult   
{
    public bool IsSuccess { get; }
    public string Message { get; } = string.Empty;
    public Error Error { get; }

    protected Result(bool isSuccess, Error error, string message = "")
    {
        if(isSuccess && error != Error.None() ||
            !isSuccess && error == Error.None())
        {
            throw new ArgumentException("Invalid error", nameof(error));
        }

        IsSuccess = isSuccess;
        Error = error;
        Message = message;
    }

    public static Result Success() => new Result(true, Error.None());
    
    public static Result Success<TValue>(List<TValue> values, int pageNumber, int pageSize) => new PaginatedResult<TValue>(values, pageNumber, pageSize, true, Error.None());

    public static Result<TValue> Success<TValue>(TValue value) => 
        new Result<TValue>(value, true, Error.None(), "");


    public static Result Failure(string message = "Failure") =>
        new Result(false, Error.BadRequest(), message);

    public static Result Failure(Error error, string message = "Failure") => 
        new Result(false, error, message);

    public static Result<TValue> Failure<TValue>(Error error, string message = "Failure") =>
        new Result<TValue>(default, false, error, message);




}

public class Result<TValue> : Result
{
    private readonly TValue? _value;

    public Result(TValue? value, bool isSuccess, Error error, string message) : base(isSuccess, error, message) 
    {
        _value = value;
    }

    public TValue Value => IsSuccess
        ? _value!
        : throw new InvalidOperationException("the value of a failure result can't be accessed.");

    public static implicit operator Result<TValue>(TValue data) => Result<TValue>.Success(data);

    public static implicit operator Result<TValue>(Error error) => Result<TValue>.Failure<TValue>(error);
}





