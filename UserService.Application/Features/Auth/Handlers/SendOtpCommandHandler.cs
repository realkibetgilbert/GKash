using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using UserService.Application.Features.Auth.Commands;
using UserService.Domain.Interfaces;

namespace UserService.Application.Features.Auth.Handlers
{
    public class SendOtpCommandHandler : IRequestHandler<SendOtpCommand, Unit>
    {
        private readonly IOtpService _otpService;

        public SendOtpCommandHandler(IOtpService otpService)
        {
            _otpService = otpService;
        }

        public async Task<Unit> Handle(SendOtpCommand request, CancellationToken cancellationToken)
        {
            await _otpService.GenerateAndSendOtpAsync(request.PhoneNumber, cancellationToken);
            return Unit.Value;
        }
    }

}
