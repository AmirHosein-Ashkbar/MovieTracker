
namespace MovieTracker.Application.Errors;

public class Error
{
    private Error(string code, string description, ErrorType type)
    {
        Code = code;
        Description = description;
        Type = type;
    }
    public string Code { get; set; }
    public string Description { get; set; }
    public ErrorType Type { get; set; }
    public string StatusCode { get; set; }

    public static Error Unexpected(string code = "Unexpected", string description = "An unexpected error happend.")
        => new Error(code, description, ErrorType.Unexpected);

    public static Error Validation(string code = "Validation", string description = "A one or more validation error happend.")
        => new Error(code, description, ErrorType.Unexpected);

}
public enum ErrorType
{
    Failure,
    Unexpected,
    Conflict,
    Validation,
    NotFound,
    Unauthorized,
    Forbidden 
}
