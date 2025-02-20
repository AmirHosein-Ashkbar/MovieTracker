using MovieTracker.Application.Contracts.MediatrR;
using MovieTracker.Application.Wrappers;

namespace MovieTracker.Application.UseCases.User.Commands.SendOtp;
public record SendOtpCommand() : ICommand;

public class SendOtpCommandHandler : ICommandHandler<SendOtpCommand>
{
    public Task<Result> Handle(SendOtpCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}