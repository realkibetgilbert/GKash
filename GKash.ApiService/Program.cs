using LoanRepayment.Infrastructure.Persistence;
using LoanService.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using UserService.Infrastructure.Persistance;

var builder = WebApplication.CreateBuilder(args);

// Add service defaults & Aspire client integrations.
builder.AddServiceDefaults();
builder.Services.AddDbContext<UserDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("GkashDbConnection")));
builder.Services.AddDbContext<LoanDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("GkashDbConnection")));
builder.Services.AddDbContext<RepaymentDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("GkashDbConnection")));
// Add services to the container.
builder.Services.AddProblemDetails();

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseExceptionHandler();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.MapDefaultEndpoints();

app.Run();

