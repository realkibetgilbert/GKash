using MediatR;
using UserService.Application.Dtos.Auth;
using UserService.Application.Features.Auth.Commands;
using UserService.Domain.Entities;
using UserService.Domain.Interfaces;

namespace UserService.Application.Features.Auth.Handlers
{
    public class VerifyOtpCommandHandler : IRequestHandler<VerifyOtpCommand, LoginResultDto>
    {
        private readonly IOtpService _otpService;
        private readonly IUserRepository _userRepository;

        public VerifyOtpCommandHandler(IOtpService otpService, IUserRepository userRepository)
        {
            _otpService = otpService;
            _userRepository = userRepository;
        }

        public async Task<LoginResultDto> Handle(VerifyOtpCommand request, CancellationToken cancellationToken)
        {
            var valid = await _otpService.ValidateOtpAsync(request.PhoneNumber, request.Otp, cancellationToken);
            if (!valid)
                return new LoginResultDto { Message = "Invalid OTP" };

            var user = await _userRepository.GetByPhoneAsync(request.PhoneNumber, cancellationToken);
            if (user == null)
            {
                user = new User
                {
                    PhoneNumber = request.PhoneNumber,
                    DateCreated = DateTime.UtcNow,
                    IsProfileComplete = false,
                    LastLogin = DateTime.UtcNow
                };

                user = await _userRepository.CreateAsync(user, cancellationToken);
            }
            else
            {
                user.LastLogin = DateTime.UtcNow;
                await _userRepository.UpdateAsync(user, cancellationToken);
            }

            return new LoginResultDto
            {
                UserId = user.Id,
                IsProfileComplete = user.IsProfileComplete,
                Message = "OK"
            };
        }
    }
}
