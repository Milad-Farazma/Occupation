using LearningManagement.Occupation.Domain.Abilities;

namespace LearningManagement.Occupation.Domain.Occupations;

public class OccupationAbility {
    public Guid OccupationId { get; set; }
    public Occupation Occupation { get; set; } = default!;

    public Guid SkillId { get; set; }
    public Ability Ability { get; set; } = default!;
}