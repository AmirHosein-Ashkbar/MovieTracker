using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace MovieTracker.API.Filters;

public class ValidationExceptionHandlingFilter : IAsyncExceptionFilter
{
    public async Task OnExceptionAsync(ExceptionContext context)
    {
        if (context.Exception is ValidationException validationException)
        {
            var problemDetails = new ProblemDetails
            {
                Status = StatusCodes.Status400BadRequest,
                Title = "Validation error",
                Type = "https://datatracker.ietf.org/doc/html/rfc9110#name-400-bad-request",
                Detail = "One or more validation errors has occurred"
            };

            if (validationException.Errors is not null)
            {
                problemDetails.Extensions["errors"] = validationException.Errors.Select(x => new { x.PropertyName, x.ErrorMessage });
            }

            context.HttpContext.Response.StatusCode = StatusCodes.Status400BadRequest;

            await context.HttpContext.Response.WriteAsJsonAsync(problemDetails);
        } 
    }
}
