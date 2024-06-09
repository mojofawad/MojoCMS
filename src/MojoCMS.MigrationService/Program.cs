using Microsoft.EntityFrameworkCore;

using MojoCMS.Infrastructure;
using MojoCMS.MigrationService;

var builder = Host.CreateApplicationBuilder(args);

builder.AddServiceDefaults();

builder.Services.AddOpenTelemetry()
    .WithTracing(tracing => tracing.AddSource(ApiDbInitializer.ActivitySourceName));

builder.Services.AddSingleton<ApiDbInitializer>();
builder.Services.AddHostedService(sp => sp.GetRequiredService<ApiDbInitializer>());

builder.AddNpgsqlDbContext<ApiDbContext>("cmsdb");

var host = builder.Build();
host.Run();