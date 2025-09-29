using MediatR;
using MovieTracker.Application.Wrappers;

namespace MovieTracker.Application.Contracts.MediatrR;
public interface IQuery: IRequest<Result>
{
}

public interface IQuery<TResponse> : IRequest<Result<TResponse>>
{
}
