using MediatR;

namespace LoanService.Application.Features.Loans.Commands
{
    public record ApproveLoanCommand(long LoanId) : IRequest<bool>;
    
        
    
}
