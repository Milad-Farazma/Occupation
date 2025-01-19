using Framework.Auditability;
using Framework.Deletable;
using Framework.Mappers;
using LearningManagement.Occupation.Application.Companies.Contracts;
using LearningManagement.Occupation.Infrastructure.Companies.EntityFramework.Repositories;
using Mapster;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace LearningManagement.Occupation.Infrastructure.Shared;

//TODO: Refactor
public static class InfrastructureServiceRegistration {
    public static void AddServices(IServiceCollection service, string sqlServerConnectionString) {
        service.AddDbContext<AppDbContext>((serviceProvider, options) => {
            options.UseSqlServer(sqlServerConnectionString)
                .AddInterceptors(serviceProvider.GetRequiredService<SoftDeleteInterceptor>())
                .AddInterceptors(serviceProvider.GetRequiredService<AuditabilityInterceptor>());
        });

        service.AddScoped<ICompanyRepository, EfCompanyRepository>();
        service.AddScoped<SoftDeleteInterceptor>();
        service.AddScoped<AuditabilityInterceptor>();

        service.AddSingleton<IMapper, Mapper>();
        var typeAdapterConfig = TypeAdapterConfig.GlobalSettings;
        typeAdapterConfig.Scan(typeof(InfrastructureServiceRegistration).Assembly);
    }
}