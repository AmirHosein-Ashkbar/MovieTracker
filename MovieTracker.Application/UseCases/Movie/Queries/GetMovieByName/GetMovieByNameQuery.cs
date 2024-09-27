using MediatR;
using MovieTracker.Application.UseCases.Movie.Dtos;


namespace MovieTracker.Application.UseCases.Movie.Queries.GetMovieByName;
public record GetMovieByNameQuery( string name ) : IRequest<List<MovieSearchDto>>;
