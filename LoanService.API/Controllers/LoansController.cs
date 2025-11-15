using LoanService.Application.Features.Loans.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace LoanService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoansController : ControllerBase
    {
        private readonly IMediator _mediator;

        public LoansController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("apply")]
        public async Task<IActionResult> ApplyLoan([FromBody] ApplyLoanCommand command)
        {
            var loan = await _mediator.Send(command);
            return Ok(loan);
        }
        [HttpPost("{loanId}/approve")]
        public async Task<IActionResult> ApproveLoan(long loanId)
        {
            var result = await _mediator.Send(new ApproveLoanCommand(loanId));
            if (!result) return BadRequest("Loan not found or not pending.");

            return Ok("Loan approved successfully.");
        }


    }
}
