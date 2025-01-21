using Framework.Services.User;
using LearningManagement.Occupation.Application.Departments.Contracts;
using LearningManagement.Occupation.Application.Departments.Services;
using LearningManagement.Occupation.Application.Organizations.Contracts;
using LearningManagement.Occupation.Application.Organizations.Services;
using Microsoft.Extensions.DependencyInjection;

namespace LearningManagement.Occupation.Application.Shared.Extensions;

public static class ApplicationServiceRegistration {
    public static void AddApplication(this IServiceCollection service) {
        service.AddScoped<IOrganizationService, OrganizationService>();
        service.AddScoped<IDepartmentService, DepartmentService>();
        service.AddScoped<IUserService, UserService>();
    }
}