using LoanRepayment.Domain.Entities;
using LoanRepayment.Domain.Interfaces;
using LoanRepayment.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoanRepayment.Infrastructure.Repositories
{
    public class RepaymentRepository : IRepaymentRepository
    {
        private readonly RepaymentDbContext _context;

        public RepaymentRepository(RepaymentDbContext context)
        {
            _context = context;
        }

        public async Task<Repayment> AddAsync(Repayment repayment)
        {
            _context.LoanRepayments.Add(repayment);
            await _context.SaveChangesAsync();
            return repayment;
        }

        public async Task<Repayment?> GetByIdAsync(long id)
        {
            return await _context.LoanRepayments.FindAsync(id);
        }

        public async Task<IEnumerable<Repayment>> GetByLoanIdAsync(long loanId)
        {
            return await _context.LoanRepayments
                                 .Where(r => r.LoanId == loanId)
                                 .ToListAsync();
        }

        public async Task UpdateAsync(Repayment repayment)
        {
            _context.LoanRepayments.Update(repayment);
            await _context.SaveChangesAsync();
        }
    }
}
