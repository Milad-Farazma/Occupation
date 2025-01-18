using LearningManagement.Occupation.Application;
using LearningManagement.Occupation.Infrastructure;

namespace LearningManagement.Occupation.WebAPI;

public static class ServiceRegistrations {
    public static void AddServices(IServiceCollection service, string sqlConnectionString) {
        ApplicationServiceRegistration.AddServices(service);
        InfrastructureServiceRegistration.AddServices(service, sqlConnectionString);
        AddWebApiServices(service);
    }

    public static void AddWebApiServices(IServiceCollection services) { }
}