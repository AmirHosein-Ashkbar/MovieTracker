using MediatR;
using Microsoft.Extensions.Logging;

namespace MovieTracker.Application.Behaviours;

public class LoggingPipelineBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : notnull, IRequest<TResponse>
{
    private readonly ILogger<LoggingPipelineBehaviour<TRequest, TResponse>> _logger;

    public LoggingPipelineBehaviour(ILogger<LoggingPipelineBehaviour<TRequest, TResponse>> logger)
    {
        _logger = logger;
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        _logger.LogInformation($"Starting request {typeof(TRequest).Name}, {DateTime.UtcNow}");
        var result = await next();
        _logger.LogInformation($"Completed request {typeof(TRequest).Name}, {DateTime.UtcNow}");
        _logger.LogError("error rrrrrrldrlelrel;re;");
        return result;
    }
}
