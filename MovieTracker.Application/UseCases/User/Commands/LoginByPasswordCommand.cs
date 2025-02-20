using MovieTracker.Application.Contracts.MediatrR;
using MovieTracker.Application.Contracts.Repositories;
using MovieTracker.Application.Errors;
using MovieTracker.Application.Wrappers;

namespace MovieTracker.Application.UseCases.User.Commands;
public record LoginByPasswordCommand(string Username, string Password) : ICommand;


public class LoginByPasswordCommandHandler(IRepository<Domain.Entities.User> userRepository) : ICommandHandler<LoginByPasswordCommand>
{
    public async Task<Result> Handle(LoginByPasswordCommand request, CancellationToken cancellationToken)
    {
        var user = await userRepository.GetAsync(x => x.Username == request.Username);
        if (user is null)
        {
            return Result.Failure(Error.BadRequest(), "Wrong Username or Password");
        }

        string passwordHash = request.Password;

        if(request.Password != user.Password)
        {
            return Result.Failure(Error.BadRequest(), "Wrong Username or Password");
        }





        return Result.Success();
    }
}
