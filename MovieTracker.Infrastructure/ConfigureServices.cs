using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MovieTracker.Application.Contracts.ExternalApisServices;
using MovieTracker.Infrastructure.ExternalApis.TMDB.ApiCall;
using MovieTracker.Infrastructure.ExternalApis.TMDB.ExternalApiService;
using MovieTracker.Infrastructure.Settings;


namespace MovieTracker.Infrastructure;
public static class ConfigureServices
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<ITMDBApiCall, TMDBApiCall>();
        services.AddScoped<ITMDBApiService, TMDBApiService>();
        services.Configure<TMDBSettings>(configuration.GetSection(TMDBSettings.Name));

        return services;
    }
}
