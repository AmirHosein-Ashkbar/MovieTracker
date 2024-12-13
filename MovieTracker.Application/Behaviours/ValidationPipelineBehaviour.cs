using MediatR;
using FluentValidation;
using System.ComponentModel.DataAnnotations;
using MovieTracker.Application.Wrappers;
using MovieTracker.Application.Errors;
using FluentValidation.Results;
using System.Threading;
using System.Reflection;
using Microsoft.Extensions.Logging;

namespace MovieTracker.Application.Behaviours;

public class ValidationPipelineBehaviour<TRequest, TResponse>(IEnumerable<IValidator<TRequest>> validators,
    ILogger<LoggingPipelineBehaviour<TRequest, TResponse>> logger)
    : IPipelineBehavior<TRequest, TResponse>
    where TRequest : class
    where TResponse : Result
{
    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(next);

        if (validators.Any())
        {
            var context = new ValidationContext<TRequest>(request);

            var validationResults = await Task.WhenAll(
                validators.Select(v =>
                    v.ValidateAsync(context, cancellationToken))).ConfigureAwait(false);

            var failures = validationResults
                .Where(r => r.Errors.Count > 0)
                .SelectMany(r => r.Errors)
                .ToList();

            if (failures.Count > 0)
            {
                logger.LogError("Validation Error: {Error}", failures.Select(x => new { x.PropertyName, x.ErrorMessage }).ToList());
                throw new FluentValidation.ValidationException(failures);
            }
                
        }
        return await next().ConfigureAwait(false);
    }
}
