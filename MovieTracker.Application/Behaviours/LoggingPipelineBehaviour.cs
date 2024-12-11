using MediatR;
using Microsoft.Extensions.Logging;
using MovieTracker.Application.Wrappers;

namespace MovieTracker.Application.Behaviours;

public class LoggingPipelineBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : class
    where TResponse : Result
    {
    private readonly ILogger<LoggingPipelineBehaviour<TRequest, TResponse>> _logger;

    public LoggingPipelineBehaviour(ILogger<LoggingPipelineBehaviour<TRequest, TResponse>> logger)
    {
        _logger = logger;
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        var start = DateTime.UtcNow;
        try
        {
            var result = await next();
            var end = DateTime.UtcNow;
            _logger.LogInformation($"{typeof(TRequest).Name} took: {(end - start).Milliseconds} Milliseconds");
            if (!result.IsSuccess)
                _logger.LogError($"{result.Error} ");
            return result;
        }
        catch (Exception ex)
        {

            _logger.LogCritical("Unexpected error happend: {Error}", ex);
            throw ex ?? new Exception("Unexpected error happend");
        }
        
    }
}
