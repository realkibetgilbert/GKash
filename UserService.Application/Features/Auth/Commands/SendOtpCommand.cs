using MediatR;

namespace UserService.Application.Features.Auth.Commands
{
    public record SendOtpCommand(string PhoneNumber) : IRequest<Unit>;
}
