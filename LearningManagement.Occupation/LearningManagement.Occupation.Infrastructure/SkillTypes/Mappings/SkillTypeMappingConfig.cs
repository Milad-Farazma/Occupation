using LearningManagement.Occupation.Application.SkillTypes.Dtos;
using LearningManagement.Occupation.Domain.SkillTypes;

namespace LearningManagement.Occupation.Infrastructure.SkillTypes.Mappings;

public class SkillTypeMappingConfig : IRegister {
    public void Register(TypeAdapterConfig config) {
        TypeAdapterConfig<SkillType, SkillTypeDto>.NewConfig()
            .Map(dest => dest.Skills, src => src.Skills);
    }
}