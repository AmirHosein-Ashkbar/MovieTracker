using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieTracker.Application.UseCases.Movie.Dtos;
public record MovieDto(
    Guid Id,
    string ExternalId,
    string Name,
    string Description,
    int Duration,
    int ReleaseYear);

