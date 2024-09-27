using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MovieTracker.Application.Contracts.ExternalApisServices;
using MovieTracker.Infrastructure.ExternalApis.MovieDb.ApiCall;
using MovieTracker.Infrastructure.ExternalApis.MovieDb.ExternalApiService;
using MovieTracker.Infrastructure.Settings;


namespace MovieTracker.Infrastructure;
public static class ConfigureServices
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IMovieDbApiCall, MovieDbApiCall>();
        services.AddScoped<IMovieDbApiService, MovieDbApiService>();
        services.Configure<MovieDbSettings>(configuration.GetSection(MovieDbSettings.Name));

        return services;
    }
}
