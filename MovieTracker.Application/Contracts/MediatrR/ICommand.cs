using MediatR;
using MovieTracker.Application.Wrappers;

namespace MovieTracker.Application.Contracts.MediatrR;
public interface ICommand : IRequest<Result>
{
}


public interface ICommand<TResponse> : IRequest<Result<TResponse>>
{
}
