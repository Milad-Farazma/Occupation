namespace LearningManagement.Occupation.Domain.Aliases;

public class Alias : ApprovableEntity {
    public string AlternativeTitle { get; set; } = default!;

    public Guid OccupationId { get; set; }
    public Occupations.Occupation Occupation { get; set; } = default!;
}