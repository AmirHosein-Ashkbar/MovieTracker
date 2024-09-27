using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieTracker.Application.UseCases.Movie.Dtos;
public record MovieSearchDto(int TMDBId,
    string PosterPath,
    string BackdropPath,
    string OriginalLanguage,
    string OriginalTitle,
    string Overview,
    double Popularity,
    string ReleaseDate,
    string Title);