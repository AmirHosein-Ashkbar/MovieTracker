using MediatR;
using MovieTracker.Application.Contracts.ExternalApisServices;
using MovieTracker.Application.Errors;
using MovieTracker.Application.UseCases.Movie.Dtos;
using MovieTracker.Application.Wrappers;


namespace MovieTracker.Application.UseCases.Movie.Queries.GetMovieByName;
public record GetMovieByNameQuery( string name ) : IRequest<Result<List<MovieSearchDto>>>;



public class GetMovieByNameQueryHandler(ITMDBApiService movieDbService) : IRequestHandler<GetMovieByNameQuery, Result<List<MovieSearchDto>>>
{
    public async Task<Result<List<MovieSearchDto>>> Handle(GetMovieByNameQuery request, CancellationToken cancellationToken)
    {
        var response = await movieDbService.GetMovieByName(request.name);

        if (response.Count <= 0)
            return Error.NotFound();

        return response;
    }
}