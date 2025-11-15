var builder = DistributedApplication.CreateBuilder(args);

var cache = builder.AddRedis("cache");

var usersSqlConnection = builder.AddSqlServer("UserDbConnection")
                 .WithDataVolume()
                 .AddDatabase("GKashDb");
var loanSqlConnection = builder.AddSqlServer("LoanDbConnection")
                 .WithDataVolume()
                 .AddDatabase("GKashDb");

var apiService = builder.AddProject<Projects.GKash_ApiService>("apiservice")
    .WithHttpHealthCheck("/health");

builder.AddProject<Projects.GKash_Web>("webfrontend")
    .WithExternalHttpEndpoints()
    .WithHttpHealthCheck("/health")
    .WithReference(cache)
    .WaitFor(cache)
    .WithReference(apiService)
    .WaitFor(apiService);


builder.AddProject<Projects.UserService_API>("userservice-api")
       .WithReference(usersSqlConnection)
       .WithReference(cache)
       .WaitFor(usersSqlConnection);

builder.AddProject<Projects.LoanService_API>("loanservice-api")
       .WithReference(loanSqlConnection)
       .WithReference(cache)
       .WaitFor(loanSqlConnection);

builder.Build().Run();
