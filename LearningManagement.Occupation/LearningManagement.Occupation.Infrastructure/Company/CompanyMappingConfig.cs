using LearningManagement.Occupation.Application.Company.Dto;
using Mapster;

namespace LearningManagement.Aquamation.Infrastructure.Company;

public class CompanyMappingConfig : IRegister {
    public void Register(TypeAdapterConfig config) {
        TypeAdapterConfig<CreateCompanyCommand, Occupation.Domain.Company.Models.Company>.NewConfig()
            .Map(dest => dest.Title, src => src.Title)
            .Map(dest => dest.Description, src => src.Description)
            .Map(dest => dest.LogoUrl, src => src.LogoUrl);

        TypeAdapterConfig<Occupation.Domain.Company.Models.Company, CompanyDto>.NewConfig()
            .Map(dest => dest.Title, src => src.Title)
            .Map(dest => dest.IsApproved, src => src.IsApproved);

        TypeAdapterConfig<UpdateCompanyCommand, Occupation.Domain.Company.Models.Company>.NewConfig()
            .Map(dest => dest.Title, src => src.NewTitle);
    }
}