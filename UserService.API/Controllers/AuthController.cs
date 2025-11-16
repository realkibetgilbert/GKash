using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UserService.Application.Dtos.Auth;
using UserService.Application.Features.Auth.Commands;

namespace UserService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AuthController(IMediator mediator) => _mediator = mediator;

        [HttpPost("send-otp")]
        public async Task<IActionResult> SendOtp([FromBody] SendOtpRequest req)
        {
            if (string.IsNullOrWhiteSpace(req.PhoneNumber)) return BadRequest("Phone number required");

            await _mediator.Send(new SendOtpCommand(req.PhoneNumber));
            return Ok(new { message = "OTP sent (if number verified in trial)" });
        }

        [HttpPost("verify-otp")]
        public async Task<IActionResult> VerifyOtp([FromBody] VerifyOtpRequest req)
        {
            if (string.IsNullOrWhiteSpace(req.PhoneNumber) || string.IsNullOrWhiteSpace(req.Otp))
                return BadRequest("Phone number and OTP are required");

            var result = await _mediator.Send(new VerifyOtpCommand(req.PhoneNumber, req.Otp));
            if (result.Message != "OK") return Unauthorized(new { message = "Invalid OTP" });

            
            HttpContext.Session.SetString("UserId", result.UserId.ToString());
            HttpContext.Session.SetString("PhoneNumber", req.PhoneNumber);

            return Ok(new { userId = result.UserId, isProfileComplete = result.IsProfileComplete });
        }
    }
}
