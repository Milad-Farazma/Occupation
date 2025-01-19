using Framework.Auditability;
using Framework.Deletable;
using Framework.Mappers;
using LearningManagement.Occupation.Application.Companies.Contracts;
using LearningManagement.Occupation.Infrastructure.Companies.EntityFramework.Repositories;
using Mapster;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace LearningManagement.Occupation.Infrastructure.Shared;

public static class InfrastructureServiceRegistration {
    public static void AddServices(IServiceCollection service, string sqlServerConnectionString) {
        AddDatabase(service, sqlServerConnectionString);
        AddRepositories(service);
        AddInterceptors(service);
        AddMapper(service);
    }

    private static void AddDatabase(IServiceCollection service, string sqlServerConnectionString) => service.AddDbContext<AppDbContext>(
        (serviceProvider, options) => {
            options.UseSqlServer(sqlServerConnectionString)
                .AddInterceptors(serviceProvider.GetRequiredService<SoftDeleteInterceptor>())
                .AddInterceptors(serviceProvider.GetRequiredService<AuditabilityInterceptor>());
        });

    private static void AddRepositories(IServiceCollection service) => service.AddScoped<ICompanyRepository, EfCompanyRepository>();

    private static void AddInterceptors(IServiceCollection service) {
        service.AddScoped<SoftDeleteInterceptor>();
        service.AddScoped<AuditabilityInterceptor>();
    }

    private static void AddMapper(IServiceCollection service) {
        service.AddSingleton<IMapper, Mapper>();
        var typeAdapterConfig = TypeAdapterConfig.GlobalSettings;
        typeAdapterConfig.Scan(typeof(InfrastructureServiceRegistration).Assembly);
    }
}