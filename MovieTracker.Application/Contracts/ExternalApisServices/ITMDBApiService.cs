using MovieTracker.Application.UseCases.Movie.Dtos;

namespace MovieTracker.Application.Contracts.ExternalApisServices;
public interface ITMDBApiService
{
    Task<List<MovieSearchDto>> GetMovieByName(string name);
    Task<MovieDetailsDto> GetMovieDetailsById(int Id);
}
