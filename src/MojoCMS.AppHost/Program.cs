var builder = DistributedApplication.CreateBuilder(args);

var db = builder.AddPostgres("postgres").AddDatabase("cmsdb");
// var apiService = builder.AddProject<Projects.MojoCMS_ApiService>("apiservice");
var api = builder.AddProject<Projects.MojoCMS_API>("api")
    .WithReference(db);

// TODO: Build Migrations Service

// builder.AddProject<Projects.MojoCMS_Web>("webfrontend")
//     .WithExternalHttpEndpoints()
//     .WithReference(apiService);


builder.AddNpmApp("frontend", "MojoCMS.App")
    .WithReference(api)
    .WithHttpEndpoint(env: "PORT")
    .WithExternalHttpEndpoints()
    .PublishAsDockerFile();

builder.Build().Run();
