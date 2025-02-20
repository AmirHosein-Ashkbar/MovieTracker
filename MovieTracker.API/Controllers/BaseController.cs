using MediatR;
using Microsoft.AspNetCore.Mvc;
using MovieTracker.Application.Wrappers;
using MovieTracker.API.Extensions;

namespace MovieTracker.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class BaseController : ControllerBase
{
    private ISender _mediator;
    private ISender Mediator => _mediator ??= HttpContext.RequestServices.GetRequiredService<ISender>();


    protected async Task<IActionResult> SendAsync<TValue>(IRequest<Result<TValue>> request, CancellationToken ct = default)
    {
        var result = await Mediator.Send(request, ct);
        if (!result.IsSuccess)
            return result.ToProblemDetails();


        return Ok(result);
    }
    protected async Task<IActionResult> SendAsync(IRequest<Result> request, CancellationToken ct = default)
    {
        var result = await Mediator.Send(request, ct);
        if (!result.IsSuccess)
            return result.ToProblemDetails();


        return Ok(result);
    }

}
