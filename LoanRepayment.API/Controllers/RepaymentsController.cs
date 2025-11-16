using LoanRepayment.Application.Dtos.Repayments;
using LoanRepayment.Application.Features.Repayments.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace LoanRepayment.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RepaymentsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public RepaymentsController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost]
        public async Task<IActionResult> CreateRepayment([FromBody] CreateRepaymentDto dto)
        {
            var command = new CreateRepaymentCommand(
                dto.LoanId,
                dto.UserId,
                dto.TotalPayable,
                dto.InterestAmount,
                dto.DueDate
            );

            await _mediator.Send(command);
            return Ok();
        }
    }
}
