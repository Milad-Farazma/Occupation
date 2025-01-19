using LearningManagement.Occupation.Application.Shared;
using LearningManagement.Occupation.Infrastructure.Shared;

namespace LearningManagement.Occupation.WebAPI.Shared;

public static class ServiceRegistrations {
    public static void AddServices(IServiceCollection service, string sqlConnectionString) {
        ApplicationServiceRegistration.AddServices(service);
        InfrastructureServiceRegistration.AddServices(service, sqlConnectionString);
        AddWebApiServices(service);
    }

    public static void AddWebApiServices(IServiceCollection services) { }
}