using MovieTracker.Application.Contracts.MediatrR;
using MovieTracker.Application.Wrappers;

namespace MovieTracker.Application.UseCases.User.Commands.VerifyOtp;
public record VerifyOtpCommand() : ICommand;


public class VerifyOtpCommandHandler : ICommandHandler<VerifyOtpCommand>
{
    public Task<Result> Handle(VerifyOtpCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}


