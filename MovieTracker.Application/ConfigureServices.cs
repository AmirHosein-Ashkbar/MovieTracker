using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using MovieTracker.Application.Behaviours;

namespace MovieTracker.Application;
public static class ConfigureServices
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        var assembly = typeof(ConfigureServices).Assembly;
        
        services.AddMediatR(configuration =>
        {
            configuration.RegisterServicesFromAssembly(assembly);
            configuration.AddOpenBehavior(typeof(ExceptionHandlingPipelineBehaviour<,>));
            configuration.AddOpenBehavior(typeof(LoggingPipelineBehaviour<,>));
            configuration.AddOpenBehavior(typeof(ValidationPipelineBehaviour<,>));
        });
        
        services.AddValidatorsFromAssembly(assembly);




        return services;
    }
}
