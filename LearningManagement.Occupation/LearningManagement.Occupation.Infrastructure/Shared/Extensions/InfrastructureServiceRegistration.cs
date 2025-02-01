using Framework.Services.User;
using LearningManagement.Occupation.Application.Abilities.Contracts;
using LearningManagement.Occupation.Application.AbilityTypes.Contracts;
using LearningManagement.Occupation.Application.Departments.Contracts;
using LearningManagement.Occupation.Application.EducationDegrees.Contracts;
using LearningManagement.Occupation.Application.EducationFields.Contracts;
using LearningManagement.Occupation.Application.EducationFieldSpecializations.Contracts;
using LearningManagement.Occupation.Application.Industries.Contracts;
using LearningManagement.Occupation.Application.Interests.Contracts;
using LearningManagement.Occupation.Application.InterestTypes.Contracts;
using LearningManagement.Occupation.Application.JobActivities.Contracts;
using LearningManagement.Occupation.Application.Organizations.Contracts;
using LearningManagement.Occupation.Application.OrganizationTypes.Contracts;
using LearningManagement.Occupation.Application.Personalities.Contracts;
using LearningManagement.Occupation.Application.Skills.Contracts;
using LearningManagement.Occupation.Application.SkillTypes.Contracts;
using LearningManagement.Occupation.Infrastructure.Abilitys.Repositories;
using LearningManagement.Occupation.Infrastructure.AbilityTypes.Repositories;
using LearningManagement.Occupation.Infrastructure.Departments.Repositories;
using LearningManagement.Occupation.Infrastructure.EducationDegrees.Repositories;
using LearningManagement.Occupation.Infrastructure.EducationFields.Repositories;
using LearningManagement.Occupation.Infrastructure.EducationFieldSpecializations.Repositories;
using LearningManagement.Occupation.Infrastructure.Industries.Repositories;
using LearningManagement.Occupation.Infrastructure.Interests.Repositories;
using LearningManagement.Occupation.Infrastructure.InterestTypes.Repositories;
using LearningManagement.Occupation.Infrastructure.JobActivities.Repositories;
using LearningManagement.Occupation.Infrastructure.Organizations.EntityFramework.Repositories;
using LearningManagement.Occupation.Infrastructure.OrganizationTypes.Repositories;
using LearningManagement.Occupation.Infrastructure.Personalities.Repositories;
using LearningManagement.Occupation.Infrastructure.Skills.Repositories;
using LearningManagement.Occupation.Infrastructure.SkillTypes.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace LearningManagement.Occupation.Infrastructure.Shared.Extensions;

public static class InfrastructureServiceRegistration {
    public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration) {
        services.AddEfConfig(configuration, false);
        AddRepositories(services);
        AddMappers();

        services.AddScoped<IUserContextService, HttpContextUserContextService>();
        services.AddHttpContextAccessor();
    }

    private static void AddRepositories(IServiceCollection services) {
        services.AddScoped<IAbilityRepository, AbilityRepository>();
        services.AddScoped<IAbilityTypeRepository, AbilityTypeRepository>();
        services.AddScoped<IDepartmentRepository, DepartmentRepository>();
        services.AddScoped<IEducationDegreeRepository, EducationDegreeRepository>();
        services.AddScoped<IEducationFieldSpecializationRepository, EducationFieldSpecializationRepository>();
        services.AddScoped<IIndustryRepository, IndustryRepository>();
        services.AddScoped<IInterestRepository, InterestRepository>();
        services.AddScoped<IInterestTypeRepository, InterestTypeRepository>();
        services.AddScoped<IJobActivityRepository, JobActivityRepository>();
        services.AddScoped<IOrganizationRepository, OrganizationRepository>();
        services.AddScoped<IOrganizationTypeRepository, OrganizationTypeRepository>();
        services.AddScoped<IPersonalityRepository, PersonalityRepository>();
        services.AddScoped<IEducationFieldRepository, EducationFieldRepository>();
        services.AddScoped<ISkillRepository, SkillRepository>();
        services.AddScoped<ISkillTypeRepository, SkillTypeRepository>();
    }

    private static void AddMappers() {
        var typeAdapterConfig = TypeAdapterConfig.GlobalSettings;
        typeAdapterConfig.Scan(typeof(InfrastructureServiceRegistration).Assembly);
    }
}