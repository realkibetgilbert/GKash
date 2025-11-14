var builder = DistributedApplication.CreateBuilder(args);

var cache = builder.AddRedis("cache");

var apiService = builder.AddProject<Projects.GKash_ApiService>("apiservice")
    .WithHttpHealthCheck("/health");

builder.AddProject<Projects.GKash_Web>("webfrontend")
    .WithExternalHttpEndpoints()
    .WithHttpHealthCheck("/health")
    .WithReference(cache)
    .WaitFor(cache)
    .WithReference(apiService)
    .WaitFor(apiService);


builder.AddProject<Projects.UserService_API>("userservice-api");

builder.Build().Run();
