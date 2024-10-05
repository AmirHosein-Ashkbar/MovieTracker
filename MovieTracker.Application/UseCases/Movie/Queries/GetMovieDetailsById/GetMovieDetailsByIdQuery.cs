using MediatR;
using MovieTracker.Application.Contracts.ExternalApisServices;
using MovieTracker.Application.UseCases.Movie.Dtos;

namespace MovieTracker.Application.UseCases.Movie.Queries.GetMovieDetailsById;

public record GetMovieDetailsByIdQuery(int Id) : IRequest<MovieDetailsDto>;


public class GetMovieDetailsByIdQueryHandler(ITMDBApiService TMDBApiService) : IRequestHandler<GetMovieDetailsByIdQuery, MovieDetailsDto>
{
    public async Task<MovieDetailsDto> Handle(GetMovieDetailsByIdQuery request, CancellationToken cancellationToken)
    {
        var response = await TMDBApiService.GetMovieDetailsById(request.Id);
        return response;
    }
}

