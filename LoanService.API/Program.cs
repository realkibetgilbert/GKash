using LoanService.Application.Features.Loans.Handlers;
using LoanService.Application.Interfaces;
using LoanService.Domain.Interfaces;
using LoanService.Infrastructure.Persistence;
using LoanService.Infrastructure.Repositories;
using LoanService.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();

var connectionString = builder.Configuration.GetConnectionString("GkashDbConnection");

builder.Services.AddDbContext<LoanDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddScoped<ILoanRepository, LoanRepository>();
builder.Services.AddMediatR(cfg =>
    cfg.RegisterServicesFromAssembly(typeof(ApplyLoanCommandHandler).Assembly));
builder.Services.AddHttpClient<ILoanRepaymentApi, LoanRepaymentApiClient>(client =>
{
    client.BaseAddress = new Uri("https://loanrepayment-api"); 
});

builder.Services.AddControllers();
builder.Services.AddOpenApi();

var app = builder.Build();

app.MapDefaultEndpoints();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
