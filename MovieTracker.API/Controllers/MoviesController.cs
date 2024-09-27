using MediatR;
using Microsoft.AspNetCore.Mvc;
using MovieTracker.Application.UseCases.Movie.Queries.GetMovieByName;
using System.Net.Mime;

namespace MovieTracker.API.Controllers;

public class MoviesController(IMediator mediatr) : BaseController
{
    [HttpGet]
    [Route("getall")]
    [Consumes(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Get([FromQuery] string name)
    {
        var result = await mediatr.Send(new GetMovieByNameQuery(name));
        return Ok(result);
    }
}
