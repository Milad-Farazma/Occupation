using LearningManagement.Occupation.Domain.AbilityTypes;

namespace LearningManagement.Occupation.Domain.Abilities;

public class Ability : ApprovableEntity {
    public string? Title { get; set; }

    public long Code { get; set; }

    public string? Description { get; set; }

    public long AbilityTypeId { get; set; }

    public AbilityType AbilityType { get; set; } = default!;
}