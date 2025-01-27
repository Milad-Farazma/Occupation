using Framework.Data.Audit;
using Framework.Data.SoftDelete;
using Framework.Performance;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace LearningManagement.Occupation.Infrastructure.Shared.Extensions;

public static class EfConfigurator {
    public static IServiceCollection AddEfConfig(this IServiceCollection services, IConfiguration configuration, bool useInMemoryDb) {
        var connectionString = configuration.GetConnectionString("Occupation")
                               ?? throw new ArgumentException("Can not find database connection string.");
        if (useInMemoryDb) {
            ConfigureInMemoryDb<ApplicationDbContext>(services, connectionString);
        }
        else {
            var thresholdMilliseconds = configuration.GetSection("SlowQueryThresholdMilliseconds").Get<int?>() ?? 1000;
            ConfigurePhysicalDb<ApplicationDbContext>(services, connectionString, thresholdMilliseconds);
        }

        services.AddScoped<AuditableEntitySaveChangesInterceptor>();
        services.AddScoped<SoftDeleteInterceptor>();

        return services;
    }

    private static void ConfigureInMemoryDb<TDbContext>(IServiceCollection services,
        string dbName) where TDbContext : DbContext
        => services.AddDbContext<TDbContext>(o => { o.UseInMemoryDatabase(dbName); });

    private static void ConfigurePhysicalDb<TDbContext>(
        IServiceCollection services,
        string connectionString,
        int thresholdMilliseconds)
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
            options.AddInterceptors(serviceProvider.GetRequiredService<SoftDeleteInterceptor>());

            AddSlowQueryInterceptor(serviceProvider, options, thresholdMilliseconds);
        });

    private static void AddSlowQueryInterceptor(IServiceProvider serviceProvider, DbContextOptionsBuilder options, int thresholdMilliseconds) {
        var logger = serviceProvider.GetRequiredService<ILogger<SlowQueryInterceptor>>();
        var threshold = TimeSpan.FromMilliseconds(thresholdMilliseconds);
        options.AddInterceptors(new SlowQueryInterceptor(logger, threshold));
    }
}