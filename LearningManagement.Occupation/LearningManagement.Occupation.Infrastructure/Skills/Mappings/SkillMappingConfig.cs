using LearningManagement.Occupation.Application.Skills.Dtos;
using LearningManagement.Occupation.Domain.Skills;

namespace LearningManagement.Occupation.Infrastructure.Skills.Mappings;

public class SkillMappingConfig : IRegister {
    public void Register(TypeAdapterConfig config) {
        TypeAdapterConfig<Skill, SkillDto>.NewConfig()
            .Map(dest => dest.SkillType, src => src.SkillType);
    }
}