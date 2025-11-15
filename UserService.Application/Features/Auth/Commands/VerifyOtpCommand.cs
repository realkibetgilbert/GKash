using MediatR;
using UserService.Application.Dtos.Auth;

namespace UserService.Application.Features.Auth.Commands
{
    public record VerifyOtpCommand(string PhoneNumber, string Otp) : IRequest<LoginResultDto>;

}
