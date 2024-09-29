

namespace MovieTracker.Application.UseCases.Movie.Dtos;

public record MovieDetailsDto(
    int TMDBId,
    string PosterPath,
    string BackdropPath,
    string OriginalLanguage,
    int Duration,
    string TagLine,
    string Status,
    List<string> OriginCountry,
    string OriginalTitle,
    string Overview,
    double Popularity,
    string ReleaseDate,
    string Title);
