using LearningManagement.Occupation.Application.Technologys.Dtos.Get;
using LearningManagement.Occupation.Domain.Technologys;

namespace LearningManagement.Occupation.Infrastructure.Technologys.Mappings;

public class TechnologyMappingConfig : IRegister {
    public void Register(TypeAdapterConfig config) {
        TypeAdapterConfig<Technology, TechnologyDto>.NewConfig()
            .Map(dest => dest.TechnologyType, src => src.TechnologyType);
    }
}