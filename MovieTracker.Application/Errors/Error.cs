
using Microsoft.AspNetCore.Http;

namespace MovieTracker.Application.Errors;

public class Error
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
    Failure = 1,
    Unexpected = 2,
    Conflict = 3,
    Validation = 4,
    NotFound = 5,
    Unauthorized = 6,
    Forbidden = 7 
}
