using LearningManagement.Occupation.Application.Shared;
using LearningManagement.Occupation.Infrastructure.Shared;

namespace LearningManagement.Occupation.WebAPI.Shared;

public static class ServiceRegistrations {
    public static void AddAllServices(IServiceCollection service, string sqlConnectionString, string[] corsOrigins) {
        ApplicationServiceRegistration.AddServices(service);
        InfrastructureServiceRegistration.AddServices(service, sqlConnectionString);
        AddWebApiServices(service, corsOrigins);
    }

    public static void AddWebApiServices(IServiceCollection services, string[] origins) {
        services.AddAppCors(origins);
    }

    private static void AddAppCors(this IServiceCollection services, string[] origins) {
        // Add CORS services
        services.AddCors(options => {
            options.AddPolicy("AllowSpecificOrigins", builder => {
                builder.WithOrigins(origins)
                    .AllowAnyHeader()
                    .AllowAnyMethod();
            });
        });
    }
}