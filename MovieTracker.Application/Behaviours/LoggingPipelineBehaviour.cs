using MediatR;
using Microsoft.Extensions.Logging;
using MovieTracker.Application.Wrappers;
using System.Diagnostics;

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
        string requestName = typeof(TRequest).Name;

        _logger.LogInformation("Processing request {RequestName}", requestName);

        Stopwatch sw = Stopwatch.StartNew();
        var result = await next();
        sw.Stop();
        var executionTime = sw.Elapsed.TotalMilliseconds;

        if (result.IsSuccess)
        {
            _logger.LogInformation("Completed request {Request} in  took: {} Milliseconds", requestName, executionTime);
        }
        else
        {
            _logger.LogError("Completed request {RequestName} with error: {Error}", requestName, result.Error);

        }
        
            
        return result;
        
    }
}
