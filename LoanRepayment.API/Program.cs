using LoanRepayment.Application.Features.Repayments.Commands;
using LoanRepayment.Domain.Interfaces;
using LoanRepayment.Infrastructure.Persistence;
using LoanRepayment.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();

var connectionString = builder.Configuration.GetConnectionString("GkashDbConnection");

builder.Services.AddDbContext<RepaymentDbContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddScoped<IRepaymentRepository, RepaymentRepository>();

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<CreateRepaymentCommand>());

builder.Services.AddControllers();

builder.Services.AddOpenApi();

var app = builder.Build();

app.MapDefaultEndpoints();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
