using MediatR;
using Microsoft.AspNetCore.Mvc;
using MovieTracker.Application.UseCases.Movie.Queries.GetMovieByName;
using MovieTracker.Application.UseCases.Movie.Queries.GetMovieDetailsById;
using System.Net.Mime;

namespace MovieTracker.API.Controllers;

public class MoviesController(IMediator mediatr) : BaseController
{
    [HttpGet]
    [Route("search")]
    [Consumes(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Get([FromQuery] string name)
    {
        var result = await mediatr.Send(new GetMovieByNameQuery(name));
        return Ok(result);
    }


    [HttpGet]
    [Route("get/{Id}")]
    [Consumes(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Get([FromRoute] int Id)
    {
        var result = await mediatr.Send(new GetMovieDetailsByIdQuery(Id));
        return Ok(result);
    }
}
