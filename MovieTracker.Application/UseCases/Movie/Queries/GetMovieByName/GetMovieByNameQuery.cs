using MediatR;
using MovieTracker.Application.Contracts.ExternalApisServices;
using MovieTracker.Application.Contracts.MediatrR;
using MovieTracker.Application.Errors;
using MovieTracker.Application.UseCases.Movie.Dtos;
using MovieTracker.Application.Wrappers;


namespace MovieTracker.Application.UseCases.Movie.Queries.GetMovieByName;
public record GetMovieByNameQuery(string name) : IQuery<List<MovieSearchDto>>;



public class GetMovieByNameQueryHandler(ITMDBApiService movieDbService) : IQueryHandler<GetMovieByNameQuery, List<MovieSearchDto>>
{
    public async Task<Result<List<MovieSearchDto>>> Handle(GetMovieByNameQuery request, CancellationToken cancellationToken)
    {
        var response = await movieDbService.GetMovieByName(request.name);

        if (response.Count <= 0 || response is null)
            return Error.NotFound();

        return response;
    }
}