using Framework.Services.User;
using LearningManagement.Occupation.Application.Departments.Contracts;
using LearningManagement.Occupation.Application.Departments.Services;
using LearningManagement.Occupation.Application.EducationFields.Contracts;
using LearningManagement.Occupation.Application.EducationFields.Services;
using LearningManagement.Occupation.Application.EducationFieldSpecializations.Contracts;
using LearningManagement.Occupation.Application.EducationFieldSpecializations.Services;
using LearningManagement.Occupation.Application.Organizations.Contracts;
using LearningManagement.Occupation.Application.Organizations.Services;
using LearningManagement.Occupation.Application.OrganizationTypes.Contracts;
using LearningManagement.Occupation.Application.OrganizationTypes.Services;
using Microsoft.Extensions.DependencyInjection;

namespace LearningManagement.Occupation.Application.Shared.Extensions;

public static class ApplicationServiceRegistration {
    public static void AddApplication(this IServiceCollection service) {
        service.AddScoped<IUserService, UserService>();
        service.AddScoped<IOrganizationService, OrganizationService>();
        service.AddScoped<IOrganizationTypeService, OrganizationTypeService>();
        service.AddScoped<IDepartmentService, DepartmentService>();
        
        service.AddScoped<IEducationFieldService, EducationFieldService>();
        service.AddScoped<IEducationFieldSpecializationService, EducationFieldSpecializationService>();
    }
}