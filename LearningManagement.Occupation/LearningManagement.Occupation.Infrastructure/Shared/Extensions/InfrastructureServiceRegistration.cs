using LearningManagement.Occupation.Application.Organizations.Contracts;
using LearningManagement.Occupation.Application.Shared;
using LearningManagement.Occupation.Infrastructure.Organizations.EntityFramework.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace LearningManagement.Occupation.Infrastructure.Shared.Extensions;

public static class InfrastructureServiceRegistration {
    public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration) {
        services.AddEfConfig(configuration, false);
        AddRepositories(services);
        AddMappers();
    }

    private static void AddRepositories(IServiceCollection services) {
        services.AddScoped(typeof(IGenericRepository<>), typeof(EfGenericRepository<>));
        services.AddScoped<IOrganizationRepository, OrganizationRepository>();
    }

    private static void AddMappers() {
        var typeAdapterConfig = TypeAdapterConfig.GlobalSettings;
        typeAdapterConfig.Scan(typeof(InfrastructureServiceRegistration).Assembly);
    }
}