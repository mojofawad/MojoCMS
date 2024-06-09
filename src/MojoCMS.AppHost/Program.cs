var builder = DistributedApplication.CreateBuilder(args);

var apiService = builder.AddProject<Projects.MojoCMS_ApiService>("apiservice");

builder.AddProject<Projects.MojoCMS_Web>("webfrontend")
    .WithExternalHttpEndpoints()
    .WithReference(apiService);

builder.Build().Run();
