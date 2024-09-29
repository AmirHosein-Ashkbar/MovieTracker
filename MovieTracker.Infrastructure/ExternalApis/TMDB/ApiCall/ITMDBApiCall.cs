using MovieTracker.Infrastructure.ExternalApis.TMDB.Models;


namespace MovieTracker.Infrastructure.ExternalApis.TMDB.ApiCall;
public interface ITMDBApiCall
{
    Task<BaseSearchResult<TMDBMovieSearch>> GetMovieByName(string name);
    Task<TMDBMovieDetails> GetMovieDetailsById(int Id);

}
