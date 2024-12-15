using MovieTracker.API.HealthChecks;

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
        return services;

    }




}
