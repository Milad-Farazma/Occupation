using Framework.Audit;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace LearningManagement.Occupation.Infrastructure.Shared.Extensions;

//TODO: DbName, DbConnectionName, Interceptors
internal static class EfConfigurator {
    internal static IServiceCollection AddEfConfig(this IServiceCollection services,
        IConfiguration configuration, string? assemblyName, bool useInMemoryDb) {
        if (useInMemoryDb) {
            ConfigureInMemoryDb<ApplicationDbContext>(services, "FXPortal");
        }
        else {
            ConfigurePhysicalDb<ApplicationDbContext>(
                services, configuration, assemblyName, "FxPortalDbConnection");
        }

        services.AddScoped<AuditableEntitySaveChangesInterceptor>();

        return services;
    }

    private static void ConfigureInMemoryDb<TDbContext>(IServiceCollection services,
        string dbName) where TDbContext : DbContext
        => services.AddDbContext<TDbContext>(o => { o.UseInMemoryDatabase(dbName); });

    private static void ConfigurePhysicalDb<TDbContext>(
        IServiceCollection services,
        IConfiguration configuration,
        string? assemblyName,
        string dbConnectionName)
        where TDbContext : DbContext
        => services.AddDbContext<TDbContext>(options =>
            options.UseSqlServer(
                    configuration.GetConnectionString(dbConnectionName),
                    sqlServerOptionsAction: sqlOptions => {
                        sqlOptions.MigrationsAssembly(assemblyName);
                        sqlOptions.EnableRetryOnFailure(
                            maxRetryCount: 5,
                            maxRetryDelay: TimeSpan.FromSeconds(10),
                            errorNumbersToAdd: null);
                    }
                )
                .LogTo(Console.WriteLine, LogLevel.Information)
                .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking));
}