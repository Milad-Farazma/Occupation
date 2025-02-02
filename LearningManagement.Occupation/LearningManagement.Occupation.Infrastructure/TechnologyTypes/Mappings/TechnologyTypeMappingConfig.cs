using LearningManagement.Occupation.Application.TechnologyTypes.Dtos.Get;
using LearningManagement.Occupation.Domain.TechnologyTypes;

namespace LearningManagement.Occupation.Infrastructure.TechnologyTypes.Mappings;

public class TechnologyTypeMappingConfig : IRegister {
    public void Register(TypeAdapterConfig config) {
        TypeAdapterConfig<TechnologyType, TechnologyTypeDto>.NewConfig()
            .Map(dest => dest.Technologies, src => src.Technologies);
    }
}