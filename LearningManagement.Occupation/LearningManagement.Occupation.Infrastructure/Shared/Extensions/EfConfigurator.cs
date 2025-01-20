using Framework.Data.Audit;
using Microsoft.Extensions.DependencyInjection;

namespace LearningManagement.Occupation.Infrastructure.Shared.Extensions;

public static class EfConfigurator {
    public static IServiceCollection AddEfConfig(this IServiceCollection services, string connectionString, bool useInMemoryDb) {
        if (useInMemoryDb) {
            ConfigureInMemoryDb<ApplicationDbContext>(services, connectionString);
        }
        else {
            ConfigurePhysicalDb<ApplicationDbContext>(services, connectionString);
        }

        services.AddScoped<AuditableEntitySaveChangesInterceptor>();

        return services;
    }

    private static void ConfigureInMemoryDb<TDbContext>(IServiceCollection services,
        string dbName) where TDbContext : DbContext
        => services.AddDbContext<TDbContext>(o => { o.UseInMemoryDatabase(dbName); });

    private static void ConfigurePhysicalDb<TDbContext>(
        IServiceCollection services,
        string connectionString)
        where TDbContext : DbContext
        => services.AddDbContext<TDbContext>((serviceProvider, options) => {
            options.UseSqlServer(
                connectionString,
                sqlServerOptionsAction: sqlOptions => {
                    sqlOptions.EnableRetryOnFailure(
                        maxRetryCount: 5,
                        maxRetryDelay: TimeSpan.FromSeconds(10),
                        errorNumbersToAdd: null);
                }
            ).UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);

            options.AddInterceptors(serviceProvider.GetRequiredService<AuditableEntitySaveChangesInterceptor>());
        });
}