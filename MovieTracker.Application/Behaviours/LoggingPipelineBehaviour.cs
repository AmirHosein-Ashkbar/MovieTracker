using MediatR;
using Microsoft.Extensions.Logging;
using MovieTracker.Application.Wrappers;

namespace MovieTracker.Application.Behaviours;

public class LoggingPipelineBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : notnull, IRequest<TResponse>
    where TResponse : Result<TResponse>
{
    private readonly ILogger<LoggingPipelineBehaviour<TRequest, TResponse>> _logger;

    public LoggingPipelineBehaviour(ILogger<LoggingPipelineBehaviour<TRequest, TResponse>> logger)
    {
        _logger = logger;
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        var start = DateTime.UtcNow;
        var result = await next();
        var end = DateTime.UtcNow;
        _logger.LogInformation($"{typeof(TRequest).Name} took: {(end - start).Milliseconds} Milliseconds");
        if (!result.IsSuccess)
            _logger.LogError($"{result.Errors} ");
        return result;
    }
}
