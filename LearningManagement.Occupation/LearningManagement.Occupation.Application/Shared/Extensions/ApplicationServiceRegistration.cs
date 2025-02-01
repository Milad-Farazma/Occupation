using LearningManagement.Occupation.Application.Abilities.Contracts;
using LearningManagement.Occupation.Application.Abilities.Services;
using LearningManagement.Occupation.Application.AbilityTypes.Contracts;
using LearningManagement.Occupation.Application.AbilityTypes.Services;
using LearningManagement.Occupation.Application.Departments.Contracts;
using LearningManagement.Occupation.Application.Departments.Services;
using LearningManagement.Occupation.Application.EducationDegrees.Contracts;
using LearningManagement.Occupation.Application.EducationDegrees.Services;
using LearningManagement.Occupation.Application.EducationFields.Contracts;
using LearningManagement.Occupation.Application.EducationFields.Services;
using LearningManagement.Occupation.Application.EducationFieldSpecializations.Contracts;
using LearningManagement.Occupation.Application.EducationFieldSpecializations.Services;
using LearningManagement.Occupation.Application.Industries.Contracts;
using LearningManagement.Occupation.Application.Industries.Services;
using LearningManagement.Occupation.Application.Interests.Contracts;
using LearningManagement.Occupation.Application.Interests.Services;
using LearningManagement.Occupation.Application.InterestTypes.Contracts;
using LearningManagement.Occupation.Application.InterestTypes.Services;
using LearningManagement.Occupation.Application.JobActivities.Contracts;
using LearningManagement.Occupation.Application.JobActivities.Services;
using LearningManagement.Occupation.Application.Organizations.Contracts;
using LearningManagement.Occupation.Application.Organizations.Services;
using LearningManagement.Occupation.Application.OrganizationTypes.Contracts;
using LearningManagement.Occupation.Application.OrganizationTypes.Services;
using LearningManagement.Occupation.Application.Personalities.Contracts;
using LearningManagement.Occupation.Application.Personalities.Services;
using LearningManagement.Occupation.Application.Skills.Contracts;
using LearningManagement.Occupation.Application.Skills.Services;
using LearningManagement.Occupation.Application.SkillTypes.Contracts;
using LearningManagement.Occupation.Application.SkillTypes.Services;
using Microsoft.Extensions.DependencyInjection;

namespace LearningManagement.Occupation.Application.Shared.Extensions;

public static class ApplicationServiceRegistration {
    public static void AddApplication(this IServiceCollection service) {
        service.AddScoped<IUserService, UserService>();

        service.AddScoped<IAbilityService, AbilityService>();
        service.AddScoped<IAbilityTypeService, AbilityTypeService>();
        service.AddScoped<IDepartmentService, DepartmentService>();
        service.AddScoped<IEducationDegreeService, EducationDegreeService>();
        service.AddScoped<IEducationFieldSpecializationService, EducationFieldSpecializationService>();
        service.AddScoped<IIndustryService, IndustryService>();
        service.AddScoped<IInterestService, InterestService>();
        service.AddScoped<IInterestTypeService, InterestTypeService>();
        service.AddScoped<IJobActivityService, JobActivityService>();
        service.AddScoped<IOrganizationService, OrganizationService>();
        service.AddScoped<IOrganizationTypeService, OrganizationTypeService>();
        service.AddScoped<IPersonalityService, PersonalityService>();
        service.AddScoped<IEducationFieldService, EducationFieldService>();
        service.AddScoped<ISkillService, SkillService>();
        service.AddScoped<ISkillTypeService, SkillTypeService>();
    }
}