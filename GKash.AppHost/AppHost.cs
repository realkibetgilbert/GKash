var builder = DistributedApplication.CreateBuilder(args);

var cache = builder.AddRedis("cache");

var sqlConnection = builder.AddSqlServer("GkashDbConnection")
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
       .WithReference(sqlConnection)
       .WithReference(cache)
       .WaitFor(sqlConnection);

var loanRepaymentService = builder.AddProject<Projects.LoanRepayment_API>("loanrepayment-api")
       .WithReference(sqlConnection)
       .WithReference(cache)
       .WaitFor(sqlConnection);

var loanService = builder.AddProject<Projects.LoanService_API>("loanservice-api")
      .WithReference(sqlConnection)
      .WithReference(cache)
      .WaitFor(sqlConnection);

loanService.WithReference(loanRepaymentService);

builder.Build().Run();
