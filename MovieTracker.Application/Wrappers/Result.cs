using MovieTracker.Application.Errors;
using MovieTracker.Domain.Enums;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MovieTracker.Application.Wrappers;

public class Result : IResult
{
    public object? Value { get; set; } = null;
    public bool IsSuccess { get; }
    public string Message { get; } = string.Empty;
    public long Total { get; }
    public string? Error { get; }
    public StatusCode StatusCode { get; } = StatusCode.OK;

    protected Result(bool isSuccess, StatusCode statusCode, string? error, string message = "")
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


    protected Result(object value, bool isSuccess, StatusCode statusCode, string? error, string message = "") : this(isSuccess, statusCode, error, message)
    {
        Value = value;
    }


    public static Result Success() => new Result(true, StatusCode.OK, null);
    public static Result Success(StatusCode statusCode) => new Result(true, statusCode, null);
    public static Result Success(object value) => new Result(value, true, StatusCode.OK, null);
    public static Result Success(StatusCode statusCode, object value) => new Result(value, true, statusCode, null);

    public static Result<TValue> Success<TValue>(TValue value) => 
        new Result<TValue>(value, true, StatusCode.OK,  null, "");
    public static Result<TValue> Success<TValue>(StatusCode statusCode, TValue value) =>
       new Result<TValue>(value, true, statusCode, null, "");

    public static Result Failure(string error = "Failure") =>
        new Result(false, StatusCode.BadRequest, error, "");

    public static Result Failure(StatusCode statusCode, string error = "Failure") => 
        new Result(false, statusCode, error, "");

    public static Result<TValue> Failure<TValue>(string error = "Failure") =>
   new Result<TValue>(default, false, StatusCode.BadRequest, error, "");
    public static Result<TValue> Failure<TValue>(StatusCode statusCode, string error = "Failure") =>
        new Result<TValue>(default, false, statusCode, error, "");


}

public class Result<TValue> : Result
{
    private readonly TValue? _value;

    public Result(TValue? value, bool isSuccess, StatusCode statusCode, string? error, string message) : base(isSuccess, statusCode, error, message) 
    {
        _value = value;
    } 

    public TValue Value => IsSuccess
        ? _value!
        : throw new InvalidOperationException("the value of a failure result can't be accessed.");

    public static implicit operator Result<TValue>(TValue data) => Result<TValue>.Success(data);
    //public static implicit operator Result(TValue data) => Result.Success<TValue>(data);

    //public static implicit operator Result<TValue>(Error error) => Result<TValue>.Failure<TValue>(error);
}





