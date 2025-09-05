
using MovieTracker.Application.Errors;

namespace MovieTracker.Application.Wrappers;

public class Result : IResult   
{
    public object? Value { get; set; } = null;
    public bool IsSuccess { get; }
    public string Message { get; } = string.Empty;
    public long Total { get; }
    public Error? Error { get; }

    protected Result(bool isSuccess, Error? error, string message = "")
    {
        if (isSuccess && error is not null ||
           !isSuccess && error is null)
        {
            throw new ArgumentException("Invalid error", nameof(error));
        }

        IsSuccess = isSuccess;
        Error = error;
        Message = message;
    }


    protected Result(object value, bool isSuccess, Error? error, string message = "") : this(isSuccess, error, message)
    {
        Value = value;
    }


    public static Result Success() => new Result(true, null);
    public static Result Success(object value) => new Result(value, true, null);
    

    public static Result<TValue> Success<TValue>(TValue value) => 
        new Result<TValue>(value, true, null, "");


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





