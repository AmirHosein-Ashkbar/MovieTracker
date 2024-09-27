using MovieTracker.Infrastructure.ExternalApis.MovieDb.Models;
using RestSharp;


namespace MovieTracker.Infrastructure.ExternalApis.MovieDb.ApiCall;
public interface IMovieDbApiCall
{
    Task<BaseSearchResult<TMDBMovieSearch>> GetMovieByName(string name);

}
