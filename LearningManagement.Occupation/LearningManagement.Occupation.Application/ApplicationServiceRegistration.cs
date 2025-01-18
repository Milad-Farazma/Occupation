using LearningManagement.Occupation.Application.Company;
using Microsoft.Extensions.DependencyInjection;

namespace LearningManagement.Occupation.Application;

public static class ApplicationServiceRegistration {
    public static void AddServices(IServiceCollection service) {
        service.AddScoped<ICompanyService, CompanyService>();
    }
}