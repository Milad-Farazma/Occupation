using LearningManagement.Occupation.Domain.Occupations;
using LearningManagement.Occupation.Domain.SkillTypes;

namespace LearningManagement.Occupation.Domain.Skills;

public class Skill : ApprovableEntity {
    public string? Title { get; set; }


    public long Code { get; set; }

    public string? Description { get; set; }

    public Guid SkillTypeId { get; set; }

    public SkillType SkillType { get; set; } = default!;
    
    public ICollection<OccupationSkill> OccupationSkills { get; set; } = default!;
}