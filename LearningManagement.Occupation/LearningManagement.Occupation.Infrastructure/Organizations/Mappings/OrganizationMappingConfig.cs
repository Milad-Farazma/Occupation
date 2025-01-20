using LearningManagement.Occupation.Application.Organizations.Dto;
using LearningManagement.Occupation.Domain.Organizations.Models;

namespace LearningManagement.Occupation.Infrastructure.Organizations.Mappings;

public class OrganizationMappingConfig : IRegister {
    public void Register(TypeAdapterConfig config) {
        config.NewConfig<Organization, OrganizationDto>()
            .Map(dest => dest.Departments,
                src => src.Department);
    }
}