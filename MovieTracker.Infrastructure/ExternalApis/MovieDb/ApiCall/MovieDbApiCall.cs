using Azure;
using Azure.Core.Pipeline;
using Microsoft.Extensions.Options;
using MovieTracker.Infrastructure.ExternalApis.MovieDb.Models;
using MovieTracker.Infrastructure.Settings;
using Newtonsoft.Json;
using RestSharp;
using RestSharp.Authenticators;

namespace MovieTracker.Infrastructure.ExternalApis.MovieDb.ApiCall;
public class MovieDbApiCall : IMovieDbApiCall
{
    private MovieDbSettings _settings;
    private RestClientOptions _clientOptions;

    public MovieDbApiCall(IOptionsSnapshot<MovieDbSettings> settings)
    {
        _settings = settings.Value;

        _clientOptions = new RestClientOptions(_settings.BaseUrl)
        {
            Authenticator = new JwtAuthenticator(_settings.Token)
        };
    }
    public async Task<BaseSearchResult<TMDBMovieSearch>> GetMovieByName(string name)
    {
        var client = new RestClient(_clientOptions);
        var request = new RestRequest($"search/movie");
        request.AddQueryParameter("query", name);
        request.AddQueryParameter("include_adult", false);
        try
        {
            var response = await client.GetAsync(request);
            var result = JsonConvert.DeserializeObject<BaseSearchResult<TMDBMovieSearch>>(response.Content);
            return result;
        }
        catch (Exception ex)
        {
            throw ex;
        }

        
    }
}
