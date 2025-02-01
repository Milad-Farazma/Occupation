using LearningManagement.Occupation.Application.Abilities.Dtos.Get;
using LearningManagement.Occupation.Domain.Abilities;

namespace LearningManagement.Occupation.Infrastructure.Abilitys.Mappings;

public class AbilityMappingConfig : IRegister {
    public void Register(TypeAdapterConfig config) {
        TypeAdapterConfig<Ability, AbilityDto>.NewConfig()
            .Map(dest => dest.AbilityType, src => src.AbilityType);
    }
}