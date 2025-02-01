using LearningManagement.Occupation.Domain.Skills;

namespace LearningManagement.Occupation.Domain.SkillTypes;

public class SkillType : ApprovableEntity {
    public string? Title { get; set; }

    public long Code { get; set; }

    public string? Description { get; set; }


    public ICollection<Skill> Skills { get; set; } = default!;
}