using MovieTracker.Application.Contracts.ExternalApisServices;
using MovieTracker.Application.Contracts.MediatrR;
using MovieTracker.Application.Wrappers;


namespace MovieTracker.Application.UseCases.Movie.Queries;
public record GetMovieByNameQuery(string name) : IQuery;



public class GetMovieByNameQueryHandler(ITMDBApiService movieDbService) : IQueryHandler<GetMovieByNameQuery>
{
    public async Task<Result> Handle(GetMovieByNameQuery request, CancellationToken cancellationToken)
    {
        var response = await movieDbService.GetMovieByName(request.name);

        if (response.Count <= 0 || response is null)
            return Result.Failure(Domain.Enums.StatusCode.NotFound, "error occured");


        return Result.Success(response);
    }
}