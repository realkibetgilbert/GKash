using Microsoft.EntityFrameworkCore;
using UserService.Application.Features.Auth.Commands;
using UserService.Domain.Interfaces;
using UserService.Infrastructure.Persistance;
using UserService.Infrastructure.Repositories;
using UserService.Infrastructure.Services;

var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();
var connectionString = builder.Configuration.GetConnectionString("UserDbConnection");

if (string.IsNullOrEmpty(connectionString))
{
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine("[? Aspire] No connection string was provided!");
    Console.ResetColor();
}
else
{
    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine($"[? Aspire] Connection string injected: {connectionString}");
    Console.ResetColor();
}
builder.Services.AddDbContext<UserDbContext>(options =>
    options.UseSqlServer(connectionString));
// Add services to the container.
builder.Services.AddStackExchangeRedisCache(options =>
{
    options.Configuration = builder.Configuration.GetConnectionString("cache");
}); 
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromHours(12);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});
builder.Services.AddHttpClient("infobip", client =>
{
    client.BaseAddress = new Uri(builder.Configuration["Infobip:BaseUrl"]!);
});

// Domain -> Infrastructure bindings
builder.Services.AddScoped<ISmsSender, InfobipSmsSender>();
builder.Services.AddScoped<IOtpService, OtpService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();

// MediatR
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<SendOtpCommand>());
builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
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
app.UseSession();
app.MapControllers();

app.Run();
