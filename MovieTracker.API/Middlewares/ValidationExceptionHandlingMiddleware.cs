
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using System;

namespace MovieTracker.API.Middlewares;

public class ValidationExceptionHandlingMiddleware : IMiddleware
{
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
		try
		{
            await next(context);
        }
        catch (ValidationException exception)
		{
            var problemDetails = new ProblemDetails
            {
                Status = StatusCodes.Status400BadRequest,
                Type = "ValidationFailure",
                Title = "Validation error",
                Detail = "One or more validation errors has occurred"
            };

            if (exception.Errors is not null)
            {
                problemDetails.Extensions["errors"] = exception.Errors.Select(x => new { x.PropertyName, x.ErrorMessage });
            }

            context.Response.StatusCode = StatusCodes.Status400BadRequest;

            await context.Response.WriteAsJsonAsync(problemDetails);
        }
    }
}
