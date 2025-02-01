using LearningManagement.Occupation.Domain.Interests;

namespace LearningManagement.Occupation.Domain.InterestTypes;

public class InterestType : ApprovableEntity {
    public string Title { get; set; } = default!;

    public string? Description { get; set; }

    public ICollection<Interest> Interests { get; set; } = default!;
}