using LearningManagement.Occupation.Application.Shared;
using Microsoft.Extensions.DependencyInjection;

namespace LearningManagement.Occupation.Infrastructure.Shared.Extensions;

public static class InfrastructureServiceRegistration {
    public static void AddInfrastructureServices(this IServiceCollection services, string sqlServerConnectionString) {
        services.AddEfConfig(sqlServerConnectionString, true);
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