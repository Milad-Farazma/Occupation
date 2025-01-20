using LearningManagement.Occupation.Application.Companies.Dto;
using LearningManagement.Occupation.Domain.Companies.Models;

namespace LearningManagement.Occupation.Infrastructure.Companies.Mappings;

public class CompanyMappingConfig : IRegister {
    public void Register(TypeAdapterConfig config) {
        TypeAdapterConfig<UpdateCompanyRequest, Company>.NewConfig()
            .Map(dest => dest.Title, src => src.NewTitle);
    }
}