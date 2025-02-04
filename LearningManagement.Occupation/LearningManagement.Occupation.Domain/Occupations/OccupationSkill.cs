using LearningManagement.Occupation.Domain.Skills;

namespace LearningManagement.Occupation.Domain.Occupations;

public class OccupationSkill {
    public Guid OccupationId { get; set; }
    public Occupation Occupation { get; set; } = default!;

    public Guid SkillId { get; set; }
    public Skill Skill { get; set; } = default!;
}