using LearningManagement.Occupation.Application.Shared;
using Microsoft.Extensions.DependencyInjection;

namespace LearningManagement.Occupation.Infrastructure.Shared.Extensions;

public static class InfrastructureServiceRegistration {
    public static void AddInfrastructureServices(this IServiceCollection service, string sqlServerConnectionString) {
        AddRepositories(service);
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