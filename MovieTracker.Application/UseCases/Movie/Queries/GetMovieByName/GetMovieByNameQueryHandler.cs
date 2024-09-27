using MediatR;
using MovieTracker.Application.Contracts.ExternalApisServices;
using MovieTracker.Application.UseCases.Movie.Dtos;


namespace MovieTracker.Application.UseCases.Movie.Queries.GetMovieByName;
public class GetMovieByNameQueryHandler(IMovieDbApiService movieDbService) : IRequestHandler<GetMovieByNameQuery, List<MovieSearchDto>>
{
   
    public async Task<List<MovieSearchDto>> Handle(GetMovieByNameQuery request, CancellationToken cancellationToken)
    {
        var response = await movieDbService.GetMovieByName(request.name);
        return response;
    }
}
