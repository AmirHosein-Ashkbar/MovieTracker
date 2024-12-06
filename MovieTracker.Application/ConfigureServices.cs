
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using MovieTracker.Application.Behaviours;

namespace MovieTracker.Application;
public static class ConfigureServices
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        var assembly = typeof(ConfigureServices).Assembly;
        services.AddMediatR(configuration => configuration.RegisterServicesFromAssembly(assembly));
        
        services.AddScoped(
            typeof(IPipelineBehavior<,>), 
            typeof(LoggingPipelineBehaviour<,>));




        return services;
    }
}
