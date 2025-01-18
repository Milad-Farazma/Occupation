using LearningManagement.Occupation.Application;
using LearningManagement.Occupation.Infrastructure;
using LearningManagement.Occupation.Domain;

namespace LearningManagement.Occupation.WebAPI;

public static class ServiceRegistrations {
    public static void AddServices(IServiceCollection service, string sqlConnectionString) {
        DomainServiceRegistration.AddServices(service);
        ApplicationServiceRegistration.AddServices(service);
        InfrastructureServiceRegistration.AddServices(service, sqlConnectionString);
        AddWebApiServices(service);
    }

    public static void AddWebApiServices(IServiceCollection services) { }
}