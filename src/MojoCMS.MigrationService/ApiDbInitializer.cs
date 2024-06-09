using System.Diagnostics;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using MojoCMS.Domain.Models;
using OpenTelemetry.Trace;

using MojoCMS.Infrastructure;

namespace MojoCMS.MigrationService;

public class ApiDbInitializer(
    IServiceProvider serviceProvider,
    IHostApplicationLifetime hostApplicationLifetime) : BackgroundService
{
    public const string ActivitySourceName = "Migrations";
    private static readonly ActivitySource s_activitySource = new(ActivitySourceName);

    protected override async Task ExecuteAsync(CancellationToken cancellationToken)
    {
        using var activity = s_activitySource.StartActivity("Migrating database", ActivityKind.Client);

        try
        {
            using var scope = serviceProvider.CreateScope();
            var dbContext = scope.ServiceProvider.GetRequiredService<ApiDbContext>();

            await EnsureDatabaseAsync(dbContext, cancellationToken);
            await RunMigrationAsync(dbContext, cancellationToken);
            // await SeedDataAsync(dbContext, cancellationToken);
        }
        catch (Exception ex)
        {
            activity?.RecordException(ex);
            throw;
        }
        
        hostApplicationLifetime.StopApplication();
    }

    private static async Task EnsureDatabaseAsync(ApiDbContext dbContext, CancellationToken cancellationToken)
    {
        var dbCreator = dbContext.GetService<IRelationalDatabaseCreator>();

        var strategy = dbContext.Database.CreateExecutionStrategy();
        await strategy.ExecuteAsync(async () =>
        {
            if (!await dbCreator.ExistsAsync(cancellationToken))
            {
                await dbCreator.CreateAsync(cancellationToken);
            }
        });
    }
    
    private async Task RunMigrationAsync(ApiDbContext dbContext, CancellationToken cancellationToken)
    {
        var strategy = dbContext.Database.CreateExecutionStrategy();
        await strategy.ExecuteAsync(async () =>
        {
            await using var transaction = await dbContext.Database.BeginTransactionAsync(cancellationToken);
            await dbContext.Database.MigrateAsync(cancellationToken);
            await transaction.CommitAsync(cancellationToken);
        });
    }

    private static async Task SeedDataAsync(ApiDbContext dbContext, CancellationToken cancellationToken)
    {
        Blog firstBlog = new()
        {
            Name = "First Blog"
        };

        var strategy = dbContext.Database.CreateExecutionStrategy();
        await strategy.ExecuteAsync(async () =>
        {
            await using var transaction = await dbContext.Database.BeginTransactionAsync(cancellationToken);
            await dbContext.Blogs.AddAsync(firstBlog, cancellationToken);
            await dbContext.SaveChangesAsync(cancellationToken);
            await transaction.CommitAsync(cancellationToken);
        });
    }
    
}