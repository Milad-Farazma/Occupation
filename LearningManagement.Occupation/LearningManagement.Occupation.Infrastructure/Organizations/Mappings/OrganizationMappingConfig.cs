using LearningManagement.Occupation.Application.Organizations.Dto;
using LearningManagement.Occupation.Domain.Organizations.Models;

namespace LearningManagement.Occupation.Infrastructure.Organizations.Mappings;

public class OrganizationMappingConfig : IRegister {
    public void Register(TypeAdapterConfig config) {
        TypeAdapterConfig<UpdateOrganizationRequest, Organization>.NewConfig()
            .Map(dest => dest.Title, src => src.NewTitle);

        config.NewConfig<Organization, OrganizationDto>()
            .Map(dest => dest.Departments,
                src => src.Department);
    }
}