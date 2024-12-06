using MediatR;
using MovieTracker.Application.Contracts.ExternalApisServices;
using MovieTracker.Application.Errors;
using MovieTracker.Application.UseCases.Movie.Dtos;
using MovieTracker.Application.Wrappers;

namespace MovieTracker.Application.UseCases.Movie.Queries.GetMovieDetailsById;

public record GetMovieDetailsByIdQuery(int Id) : IRequest<Result<MovieDetailsDto>>;


public class GetMovieDetailsByIdQueryHandler(ITMDBApiService TMDBApiService) : IRequestHandler<GetMovieDetailsByIdQuery, Result<MovieDetailsDto>>
{
    public async Task<Result<MovieDetailsDto>> Handle(GetMovieDetailsByIdQuery request, CancellationToken cancellationToken)
    {
        var response = await TMDBApiService.GetMovieDetailsById(request.Id);
        if (response.TMDBId == 0)
            return Error.NotFound();
        return response;
    }
}

