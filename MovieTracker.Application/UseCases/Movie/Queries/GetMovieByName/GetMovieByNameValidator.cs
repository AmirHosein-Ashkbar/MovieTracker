using FluentValidation;


namespace MovieTracker.Application.UseCases.Movie.Queries.GetMovieByName;
public class GetMovieByNameValidator : AbstractValidator<GetMovieByNameQuery>
{
    public GetMovieByNameValidator()
    {
        RuleFor(x => x.name).NotEmpty().NotNull();    
    }
}
