using FluentValidation;
using MovieTracker.API.HealthChecks;
using MovieTracker.API.Middlewares;

namespace MovieTracker.API.Extensions;

public static class ServiceCollectionExtension
{
    public static IServiceCollection AddSwagger(this IServiceCollection services)
    {
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
        return services;
    }

    public static IServiceCollection AddHealthCheck(this IServiceCollection services)
    {
        services.AddHealthChecks()
        .AddCheck<TMDBHealthCheck>("TMDB")
        .AddCheck<SampleHealthCheck>("sample");

        return services;
    }

    public static IServiceCollection AddMiddlewares(this IServiceCollection services)
    {
        services.AddTransient<ValidationExceptionHandlingMiddleware>();        
        return services;

    }




}
