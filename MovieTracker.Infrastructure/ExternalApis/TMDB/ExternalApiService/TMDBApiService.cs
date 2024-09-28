using MovieTracker.Application.Contracts.ExternalApisServices;
using MovieTracker.Application.UseCases.Movie.Dtos;
using MovieTracker.Infrastructure.ExternalApis.TMDB.ApiCall;


namespace MovieTracker.Infrastructure.ExternalApis.TMDB.ExternalApiService;
public class TMDBApiService(ITMDBApiCall TMDBApiCall) : ITMDBApiService
{



    public async Task<List<MovieSearchDto>> GetMovieByName(string name)
    {
        var response = await TMDBApiCall.GetMovieByName(name);
        var movieList = response.Results.Select(m => new MovieSearchDto
        (
            TMDBId: m.Id,
            PosterPath: m.PosterPath,
            BackdropPath: m.BackdropPath,
            OriginalLanguage: m.OriginalLanguage,
            OriginalTitle: m.OriginalTitle,
            Overview: m.Overview,
            Popularity: m.Popularity,
            ReleaseDate: m.ReleaseDate,
            Title: m.Title
        )).OrderByDescending(m => m.Popularity).ToList();

        return movieList;

    }
}
