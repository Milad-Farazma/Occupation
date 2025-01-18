using Framework.Deletable;
using LearningManagement.Occupation.Infrastructure.Companies;
using LearningManagement.Occupation.Application;
using LearningManagement.Occupation.Domain.Companies;
using Mapster;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace LearningManagement.Occupation.Infrastructure;

public static class InfrastructureServiceRegistration {
    public static void AddServices(IServiceCollection service, string sqlServerConnectionString) {
        service.AddDbContext<AppDbContext>((serviceProvider, options) => {
            options.UseSqlServer(sqlServerConnectionString)
                .AddInterceptors(serviceProvider.GetRequiredService<SoftDeleteInterceptor>());
        });

        service.AddScoped<ICompanyRepository, CompanyRepository>();

        service.AddSingleton<IMapper, Mapper.Mapper>();
        var typeAdapterConfig = TypeAdapterConfig.GlobalSettings;
        typeAdapterConfig.Scan(typeof(InfrastructureServiceRegistration).Assembly);
    }
}