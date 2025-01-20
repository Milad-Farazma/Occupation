using LearningManagement.Occupation.Application.Shared;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace LearningManagement.Occupation.Infrastructure.Shared.Extensions;

public static class InfrastructureServiceRegistration {
    public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration) {
        var connectionString = configuration.GetConnectionString("Occupation")
                               ?? throw new ArgumentException("Can not find database connection string.");

        services.AddEfConfig(connectionString, false);
        AddRepositories(services);
        AddMappers();
    }

    private static void AddRepositories(IServiceCollection services) {
        services.AddScoped(typeof(IGenericRepository<>), typeof(EfGenericRepository<>));
    }

    private static void AddMappers() {
        var typeAdapterConfig = TypeAdapterConfig.GlobalSettings;
        typeAdapterConfig.Scan(typeof(InfrastructureServiceRegistration).Assembly);
    }
}