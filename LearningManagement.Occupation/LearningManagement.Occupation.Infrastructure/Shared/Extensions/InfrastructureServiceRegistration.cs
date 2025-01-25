using Framework.Services.User;
using LearningManagement.Occupation.Application.Departments.Contracts;
using LearningManagement.Occupation.Application.Organizations.Contracts;
using LearningManagement.Occupation.Application.OrganizationTypes.Contracts;
using LearningManagement.Occupation.Infrastructure.Departments.Repositories;
using LearningManagement.Occupation.Infrastructure.Organizations.EntityFramework.Repositories;
using LearningManagement.Occupation.Infrastructure.OrganizationTypes.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace LearningManagement.Occupation.Infrastructure.Shared.Extensions;

public static class InfrastructureServiceRegistration {
    public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration) {
        services.AddEfConfig(configuration, false);
        AddRepositories(services);
        AddMappers();

        services.AddScoped<IUserContextService, HttpContextUserContextService>();
        services.AddHttpContextAccessor();
    }

    private static void AddRepositories(IServiceCollection services) {
        services.AddScoped<IOrganizationRepository, OrganizationRepository>();
        services.AddScoped<IOrganizationTypeRepository, OrganizationTypeRepository>();
        services.AddScoped<IDepartmentRepository, DepartmentRepository>();
    }

    private static void AddMappers() {
        var typeAdapterConfig = TypeAdapterConfig.GlobalSettings;
        typeAdapterConfig.Scan(typeof(InfrastructureServiceRegistration).Assembly);
    }
}