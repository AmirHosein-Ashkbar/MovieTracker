using System.Reflection.Metadata.Ecma335;
using MediatR;
using MovieTracker.Application.Contracts.ExternalApisServices;
using MovieTracker.Application.Contracts.MediatrR;
using MovieTracker.Application.Errors;
using MovieTracker.Application.UseCases.Movie.Dtos;
using MovieTracker.Application.Wrappers;

namespace MovieTracker.Application.UseCases.Movie.Queries;

public record GetMovieDetailsByIdQuery(int Id) : IQuery<MovieDetailsDto>;


public class GetMovieDetailsByIdQueryHandler(ITMDBApiService TMDBApiService) : IQueryHandler<GetMovieDetailsByIdQuery, MovieDetailsDto>
{
    public async Task<Result<MovieDetailsDto>> Handle(GetMovieDetailsByIdQuery request, CancellationToken cancellationToken)
    {
        var response = await TMDBApiService.GetMovieDetailsById(request.Id);
        if (response.TMDBId == 0)
            return Result.Failure<MovieDetailsDto>();
        return response;
    }
}

