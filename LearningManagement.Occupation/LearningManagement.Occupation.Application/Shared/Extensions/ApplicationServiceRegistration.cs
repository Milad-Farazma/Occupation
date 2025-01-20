using Framework.Services.User;
using LearningManagement.Occupation.Application.Companies.Contracts;
using LearningManagement.Occupation.Application.Companies.Services;
using LearningManagement.Occupation.Application.Departments.Contracts;
using LearningManagement.Occupation.Application.Departments.Services;
using Microsoft.Extensions.DependencyInjection;

namespace LearningManagement.Occupation.Application.Shared.Extensions;

public static class ApplicationServiceRegistration {
    public static void AddApplicationServices(this IServiceCollection service) {
        service.AddScoped<ICompanyService, CompanyService>();
        service.AddScoped<IDepartmentService, DepartmentService>();
        service.AddScoped<IUserService, UserService>();

        //TODO: Is it good idea?!
        service.AddHttpContextAccessor();
    }
}