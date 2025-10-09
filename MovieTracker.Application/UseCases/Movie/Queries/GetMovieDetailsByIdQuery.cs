using MovieTracker.Application.Contracts.ExternalApisServices;
using MovieTracker.Application.Contracts.MediatrR;
using MovieTracker.Application.Wrappers;

namespace MovieTracker.Application.UseCases.Movie.Queries;

public record GetMovieDetailsByIdQuery(int Id) : IQuery;


public class GetMovieDetailsByIdQueryHandler(ITMDBApiService TMDBApiService) : IQueryHandler<GetMovieDetailsByIdQuery>
{
    public async Task<Result> Handle(GetMovieDetailsByIdQuery request, CancellationToken cancellationToken)
    {
        var response = await TMDBApiService.GetMovieDetailsById(request.Id);
        if (response.TMDBId == 0)
            return Result.Failure("No movie was found.");
        return Result.Success(response);
    }
}

