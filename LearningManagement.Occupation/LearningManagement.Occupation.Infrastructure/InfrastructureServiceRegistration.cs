using Framework.Auditability;
using Framework.Deletable;
using LearningManagement.Occupation.Infrastructure.Companies;
using LearningManagement.Occupation.Application.Contracts;
using LearningManagement.Occupation.Domain.Companies;
using Mapster;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace LearningManagement.Occupation.Infrastructure;

public static class InfrastructureServiceRegistration {
    public static void AddServices(IServiceCollection service, string sqlServerConnectionString) {
        service.AddDbContext<AppDbContext>((serviceProvider, options) => {
            options.UseSqlServer(sqlServerConnectionString)
                .AddInterceptors(serviceProvider.GetRequiredService<SoftDeleteInterceptor>())
                .AddInterceptors(serviceProvider.GetRequiredService<AuditabilityInterceptor>());
        });

        service.AddScoped<ICompanyRepository, CompanyRepository>();
        service.AddScoped<SoftDeleteInterceptor>();
        service.AddScoped<AuditabilityInterceptor>();

        service.AddSingleton<IMapper, Mapper.Mapper>();
        var typeAdapterConfig = TypeAdapterConfig.GlobalSettings;
        typeAdapterConfig.Scan(typeof(InfrastructureServiceRegistration).Assembly);
    }
}