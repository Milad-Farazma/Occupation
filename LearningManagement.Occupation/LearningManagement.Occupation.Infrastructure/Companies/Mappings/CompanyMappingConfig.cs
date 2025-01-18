using LearningManagement.Occupation.Application.Companies.Dto;
using LearningManagement.Occupation.Domain.Companies.Models;
using Mapster;

namespace LearningManagement.Occupation.Infrastructure.Companies.Mappings;

public class CompanyMappingConfig : IRegister {
    public void Register(TypeAdapterConfig config) {
        TypeAdapterConfig<CreateCompanyRequest, Company>.NewConfig()
            .Map(dest => dest.Title, src => src.Title)
            .Map(dest => dest.Description, src => src.Description)
            .Map(dest => dest.LogoUrl, src => src.LogoUrl);

        TypeAdapterConfig<Company, CompanyDto>.NewConfig()
            .Map(dest => dest.Title, src => src.Title)
            .Map(dest => dest.IsApproved, src => src.IsApproved);

        TypeAdapterConfig<UpdateCompanyRequest, Company>.NewConfig()
            .Map(dest => dest.Title, src => src.NewTitle);
    }
}