using Microsoft.AspNetCore.Http;

namespace MovieTracker.Application.Errors;

public record Error
{
    private Error(string code, string description, ErrorType type, int statusCode)
    {
        Code = code;
        Description = description;
        Type = type;
        StatusCode = statusCode;
    }
    public string Code { get; set; }
    public string Description { get; set; }
    public ErrorType Type { get; set; }
    public int StatusCode { get; set; }
    public static Error None()
        => new Error(string.Empty, string.Empty, ErrorType.None, 0);

    public static Error BadRequest(string code = "BadRequest", string description = "BadRequest.")
       => new Error(code, description, ErrorType.BadRequest, StatusCodes.Status400BadRequest);

    public static Error Unprocessable(string code = "Unprocessable", string description = "Request is unprocessable.")
       => new Error(code, description, ErrorType.Unprocessable, StatusCodes.Status422UnprocessableEntity);

    public static Error Unexpected(string code = "Unexpected", string description = "An unexpected error happend.")
        => new Error(code, description, ErrorType.Unexpected, StatusCodes.Status500InternalServerError);

    public static Error Validation(string code = "Validation", string description = "A one or more validation error happend.")
        => new Error(code, description, ErrorType.Validation, StatusCodes.Status400BadRequest);

    public static Error Failure(string code = "Failure", string description = "A failure happend.")
    => new Error(code, description, ErrorType.Failure, StatusCodes.Status500InternalServerError);

    public static Error NotFound(string code = "NotFound", string description = "The requested resource not found.")
    => new Error(code, description, ErrorType.NotFound, StatusCodes.Status404NotFound);

    public static Error Unauthorized(string code = "Unauthorized", string description = "You're not authorized.")
    => new Error(code, description, ErrorType.Unauthorized, StatusCodes.Status401Unauthorized);

    public static Error Forbidden(string code = "Forbidden", string description = "You're Forbidden.")
    => new Error(code, description, ErrorType.Forbidden, StatusCodes.Status403Forbidden);

    public static Error Conflict(string code = "Conflict", string description = "Conflict.")
   => new Error(code, description, ErrorType.Forbidden, StatusCodes.Status409Conflict);

}
public enum ErrorType
{
    None = 0,
    BadRequest = 1,
    Unprocessable = 2,
    Conflict = 3,
    Validation = 4,
    NotFound = 5,
    Unauthorized = 6,
    Forbidden = 7, 
    Unexpected = 8,
    Failure = 9,
}
