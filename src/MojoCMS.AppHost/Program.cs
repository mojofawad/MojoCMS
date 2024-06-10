var builder = DistributedApplication.CreateBuilder(args);

var pgPassword = builder.AddParameter("postgresql-password", secret: true);

var postgres = builder.AddPostgres("postgres", password: pgPassword)
    .WithDataVolume();
var db = postgres.AddDatabase("cmsdb");
var api = builder.AddProject<Projects.MojoCMS_API>("api")
    .WithReference(db);

var migrations = builder.AddProject<Projects.MojoCMS_MigrationService>("migrations")
    .WithReference(db);

// TODO: Add conditional for npm run command
builder.AddNpmApp("frontend", "../MojoCMS.App", "dev")
    .WithReference(api)
    .WithExternalHttpEndpoints()
    .PublishAsDockerFile();

builder.Build().Run();
