using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieTracker.Application.Errors;
using MovieTracker.Application.Wrappers;
using IResult = Microsoft.AspNetCore.Http.IResult;

namespace MovieTracker.API.Extensions;

public static class ResultExtensions
{
    public static IActionResult ToProblemDetails(this Result result)
    {
        if (result.IsSuccess)
            throw new InvalidOperationException();

        var problem = new ProblemDetails
        {
            Status = result.Error.StatusCode,
            Title = result.Error.Type.ToString(),
            Type = GetType(result.Error.Type),
            Extensions = new Dictionary<string, object?>
            {
                {"errors", new { result.Error.Description } },
            }
        };

        return new ObjectResult(problem);

    }

    static string GetType(ErrorType errorType) =>
        errorType switch
        {
            ErrorType.NotFound => "https://datatracker.ietf.org/doc/html/rfc9110#name-404-not-found",
            ErrorType.Conflict => "https://datatracker.ietf.org/doc/html/rfc9110#name-409-conflict",
            ErrorType.Forbidden => "https://datatracker.ietf.org/doc/html/rfc9110#name-403-forbidden",
            ErrorType.Unauthorized => "https://datatracker.ietf.org/doc/html/rfc9110#name-401-unauthorized",
            ErrorType.Validation => "https://datatracker.ietf.org/doc/html/rfc9110#name-400-bad-request",
            ErrorType.BadRequest => "https://datatracker.ietf.org/doc/html/rfc9110#name-400-bad-request",
            ErrorType.Unexpected => "https://datatracker.ietf.org/doc/html/rfc9110#name-500-internal-server-error",
            ErrorType.Failure => "https://datatracker.ietf.org/doc/html/rfc9110#name-500-internal-server-error",
            ErrorType.Unprocessable => "https://datatracker.ietf.org/doc/html/rfc9110#name-422-unprocessable-content",
        };
}
