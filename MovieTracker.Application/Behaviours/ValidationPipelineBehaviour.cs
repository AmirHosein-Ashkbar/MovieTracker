using MediatR;
using FluentValidation;
using System.ComponentModel.DataAnnotations;
using MovieTracker.Application.Wrappers;
using MovieTracker.Application.Errors;

namespace MovieTracker.Application.Behaviours;

public class ValidationPipelineBehaviour<TRequest, TResponse>(IEnumerable<IValidator<TRequest>> validators)
    : IPipelineBehavior<TRequest, TResponse>
    where TRequest : notnull, IRequest<TResponse>
    where TResponse : Result<TResponse>
{
    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        var context = new ValidationContext<TRequest>(request);
        if (validators.Any()) 
        {
            var validationResults = await Task.WhenAll(
               validators.Select(v =>
                   v.ValidateAsync(context, cancellationToken))).ConfigureAwait(false);

            var failures = validationResults
                .Where(r => r.Errors.Count > 0)
                .SelectMany(r => r.Errors)
                .ToList();
            var errors = new List<Error>();
            if (failures.Count > 0)
                throw new FluentValidation.ValidationException(failures);
        }
        return await next();
    }

}
