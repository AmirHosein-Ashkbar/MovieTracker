using MediatR;
using MovieTracker.Application.Wrappers;

namespace MovieTracker.Application.Contracts.MediatrR;
public interface ICommandHandler<TCommand> : IRequestHandler<TCommand, Result> where TCommand : ICommand<Result>
{
}


public interface ICommandHandler<TCommand, TResponse> : 
    IRequestHandler<TCommand, Result<TResponse>> 
    where TCommand : ICommand<TResponse>
{
}