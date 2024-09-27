namespace MovieTracker.API.Extensions;

public static class ServiceCollectionExtension
{
    public static IServiceCollection AddSwagger(this IServiceCollection services)
    {
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
        return services;
    }
}
