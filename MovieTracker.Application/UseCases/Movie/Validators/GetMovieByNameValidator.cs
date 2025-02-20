using FluentValidation;
using MovieTracker.Application.UseCases.Movie.Queries;

namespace MovieTracker.Application.UseCases.Movie.Validators;
public class GetMovieByNameValidator : AbstractValidator<GetMovieByNameQuery>
{
    public GetMovieByNameValidator()
    {
        RuleFor(x => x.name).NotEmpty().NotNull();
    }
}
