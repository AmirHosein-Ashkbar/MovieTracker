using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.Extensions.Options;
using MovieTracker.Infrastructure.Settings;
using RestSharp.Authenticators;
using RestSharp;

namespace MovieTracker.API.HealthChecks;

public class TMDBHealthCheck : IHealthCheck
{
    private readonly TMDBSettings _settings;

    public TMDBHealthCheck(IOptionsSnapshot<TMDBSettings> settings) 
    {
        _settings = settings.Value;
    }
    public Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default)
    
    {
        var clientOptions = new RestClientOptions(_settings.BaseUrl)
        {
            Authenticator = new JwtAuthenticator(_settings.Token)
        };
        var client = new RestClient(clientOptions);
        var request = new RestRequest($"movie/76");
        try
        {
            var response = client.GetAsync(request).Result;

            if(IsSuccessfull(response))
                return Task.FromResult(HealthCheckResult.Healthy("TMDb is Healthy"));

            return Task.FromResult(HealthCheckResult.Unhealthy("TMDb is Unhealthy"));

        }
        catch (Exception ex)
        {
            return Task.FromResult(HealthCheckResult.Unhealthy("TMDb is Unhealthy", ex));

        }
    }

    private static bool IsSuccessfull(RestResponse response)
    {
        if(response.IsSuccessful == false)
            return false;
        if(response.IsSuccessStatusCode == false) 
            return false;
        if(response.StatusCode != System.Net.HttpStatusCode.OK)
            return false;
        if(response.Content == null) 
            return false;  

        return true;
    }
}
