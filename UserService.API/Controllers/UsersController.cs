using MediatR;
using Microsoft.AspNetCore.Mvc;
using UserService.Application.Features.Profile.Commands;

namespace UserService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UsersController(IMediator mediator) => _mediator = mediator;
        [HttpPost("complete-profile")]
        public async Task<IActionResult> CompleteProfile([FromBody] CompleteUserProfileCommand cmd)
        {
            var result = await _mediator.Send(cmd);

            if (!result)
                return BadRequest("Failed to complete profile.");

            return Ok("Profile completed successfully.");
        }
    }
}
