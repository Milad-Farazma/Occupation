using LMS.Aquamation.Application;
using LMS.Aquamation.Core;
using LMS.Aquamation.Infrastructure;

namespace LMS.Aquamation.WebAPI;

public static class ServiceRegistrations {
    public static void AddServices(IServiceCollection service, string sqlConnectionString) {
        ApplicationServiceRegistration.AddServices(service);
        InfrastructureServiceRegistration.AddServices(service, sqlConnectionString);
        DomainServiceRegistration.AddServices(service);
    }
}