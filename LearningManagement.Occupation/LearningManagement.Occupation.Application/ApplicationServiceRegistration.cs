using LearningManagement.Occupation.Application.Companies;
using Microsoft.Extensions.DependencyInjection;

namespace LearningManagement.Occupation.Application;

public static class ApplicationServiceRegistration {
    public static void AddServices(IServiceCollection service) {
        service.AddScoped<ICompanyService, CompanyService>();
    }
}