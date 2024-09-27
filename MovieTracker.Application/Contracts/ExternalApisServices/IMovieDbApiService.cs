using MovieTracker.Application.UseCases.Movie.Dtos;

namespace MovieTracker.Application.Contracts.ExternalApisServices;
public interface IMovieDbApiService
{
    Task<List<MovieSearchDto>> GetMovieByName(string name);
}
