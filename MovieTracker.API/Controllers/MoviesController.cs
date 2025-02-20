using Microsoft.AspNetCore.Mvc;
using MovieTracker.Application.UseCases.Movie.Queries;
using System.Net.Mime;

namespace MovieTracker.API.Controllers;

public class MoviesController : BaseController
{
    [HttpGet]
    [Route("search")]
    [Consumes(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Get([FromQuery] string name) => 
        await SendAsync(new GetMovieByNameQuery(name));


    [HttpGet]
    [Route("get/{Id}")]
    [Consumes(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Get([FromRoute] int Id) =>
        await SendAsync(new GetMovieDetailsByIdQuery(Id));
}
