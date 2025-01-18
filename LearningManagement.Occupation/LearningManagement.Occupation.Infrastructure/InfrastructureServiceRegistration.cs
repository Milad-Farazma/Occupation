using LearningManagement.Aquamation.Infrastructure.Companies;
using LearningManagement.Occupation.Application;
using LearningManagement.Occupation.Domain.Companies;
using Mapster;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

//TODO: Rename .Aquamation to .Occupation
namespace LearningManagement.Aquamation.Infrastructure;

public static class InfrastructureServiceRegistration {
    public static void AddServices(IServiceCollection service, string sqlServerConnectionString) {
        service.AddDbContext<AppDbContext>(options =>
            options.UseSqlServer(sqlServerConnectionString));

        service.AddScoped<ICompanyRepository, CompanyRepository>();

        service.AddSingleton<IMapper, Mapper.Mapper>();
        var typeAdapterConfig = TypeAdapterConfig.GlobalSettings;
        typeAdapterConfig.Scan(typeof(InfrastructureServiceRegistration).Assembly);
    }
}