using LearningManagement.Occupation.Domain.Abilities;

namespace LearningManagement.Occupation.Domain.AbilityTypes;

public class AbilityType : ApprovableEntity {
    public string? Title { get; set; }

    public long Code { get; set; }

    public string? Description { get; set; }


    public ICollection<Ability> Abilities { get; set; } = default!;
}