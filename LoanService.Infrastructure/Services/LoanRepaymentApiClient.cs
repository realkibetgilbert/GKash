using Azure;
using LoanService.Application.Dtos.Repayments;
using LoanService.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Net.Http.Json;
using System.Text;
using static System.Net.WebRequestMethods;

namespace LoanService.Infrastructure.Services
{
    public class LoanRepaymentApiClient : ILoanRepaymentApi
    {

        private readonly HttpClient _http;

        public LoanRepaymentApiClient(HttpClient http)
        {
            _http = http;
        }

        public async Task CreateRepaymentAsync(CreateRepaymentDto dto)
        {
            await _http.PostAsJsonAsync("/api/repayments", dto);
        }
    }
}
