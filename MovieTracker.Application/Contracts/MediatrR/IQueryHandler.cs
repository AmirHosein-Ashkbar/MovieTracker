using MediatR;
using MovieTracker.Application.Wrappers;

namespace MovieTracker.Application.Contracts.MediatrR;
public interface IQueryHandler<TQuery, TResponse> : IRequestHandler<TQuery, Result<TResponse>>
    where TQuery : IQuery<TResponse>    
{
}
