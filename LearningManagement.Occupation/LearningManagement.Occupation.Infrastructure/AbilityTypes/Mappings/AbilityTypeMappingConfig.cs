using LearningManagement.Occupation.Application.AbilityTypes.Dtos.Get;
using LearningManagement.Occupation.Domain.AbilityTypes;

namespace LearningManagement.Occupation.Infrastructure.AbilityTypes.Mappings;

public class AbilityTypeMappingConfig : IRegister {
    public void Register(TypeAdapterConfig config) {
        TypeAdapterConfig<AbilityType, AbilityTypeDto>.NewConfig()
            .Map(dest => dest.Abilities, src => src.Abilities);
    }
}