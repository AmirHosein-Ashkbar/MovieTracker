using Microsoft.AspNetCore.Mvc;
using MovieTracker.Application.UseCases.Movie.Queries;
using MovieTracker.Application.UseCases.User.Commands;
using System.Net.Mime;

namespace MovieTracker.API.Controllers;
public class UsersController : BaseController
{
    [HttpPost]
    [Route("signup")]
    [Consumes(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> SignUp([FromBody] string name) =>
         await SendAsync(new GetMovieByNameQuery(name));



    [HttpPost]
    [Route("loginbypassword")]
    [Consumes(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> LoginByPassword([FromBody] LoginByPasswordCommand command) =>
         await SendAsync(command);

    [HttpPost]
    [Route("loginbyotp")]
    [Consumes(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> LoginByOtp([FromBody] string name) =>
         await SendAsync(new GetMovieByNameQuery(name));

}
