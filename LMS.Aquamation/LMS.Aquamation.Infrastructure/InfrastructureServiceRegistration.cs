using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace LMS.Aquamation.Infrastructure;

public static class InfrastructureServiceRegistration {
    public static void AddServices(IServiceCollection service, string sqlServerConnectionString) {
        service.AddDbContext<AppDbContext>((serviceProvider, options) => {
            options.UseSqlServer(sqlServerConnectionString);
        });
    }
}