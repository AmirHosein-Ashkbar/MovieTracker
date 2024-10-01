using ErrorOr;
using MediatR;
using MovieTracker.Application.UseCases.Movie.Dtos;

namespace MovieTracker.Application.UseCases.Movie.Queries.GetMovieDetailsById;

public record GetMovieDetailsByIdQuery(int Id) : IRequest<MovieDetailsDto> ; 

