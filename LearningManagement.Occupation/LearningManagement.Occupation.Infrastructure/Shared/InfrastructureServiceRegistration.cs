using Framework.Audit;
using Framework.Mappers;
using LearningManagement.Occupation.Application.Companies.Contracts;
using LearningManagement.Occupation.Application.Departments.Contracts;
using LearningManagement.Occupation.Infrastructure.Companies.EntityFramework.Repositories;
using LearningManagement.Occupation.Infrastructure.Departments.EntityFramework.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace LearningManagement.Occupation.Infrastructure.Shared;

public static class InfrastructureServiceRegistration {
    public static void AddServices(IServiceCollection service, string sqlServerConnectionString) {
        AddDatabase(service, sqlServerConnectionString);
        AddRepositories(service);
        AddInterceptors(service);
        AddMapper(service);
    }

    private static void AddDatabase(IServiceCollection service, string sqlServerConnectionString) => service.AddDbContext<ApplicationDbContext>(
        (serviceProvider, options) => {
            options.UseSqlServer(sqlServerConnectionString)
                .AddInterceptors(serviceProvider.GetRequiredService<AuditableEntitySaveChangesInterceptor>());
        });

    private static void AddRepositories(IServiceCollection service) {
        service.AddScoped<ICompanyRepository, EfCompanyRepository>();
        service.AddScoped<IDepartmentRepository, EfDepartmentRepository>();
    }

    private static void AddInterceptors(IServiceCollection service) {
        service.AddScoped<AuditableEntitySaveChangesInterceptor>();
    }

    private static void AddMapper(IServiceCollection service) {
        service.AddSingleton<IMapper, Mapper>();
        var typeAdapterConfig = TypeAdapterConfig.GlobalSettings;
        typeAdapterConfig.Scan(typeof(InfrastructureServiceRegistration).Assembly);
    }
}