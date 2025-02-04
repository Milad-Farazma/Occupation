namespace LearningManagement.Occupation.Domain.OccupationSimilaritys;

public class OccupationSimilarity : ApprovableEntity {
    public string? Description { get; set; }
    public Guid LeftOccupationId { get; set; }
    public Occupations.Occupation LeftOccupation { get; set; } = default!;
    public Guid RightOccupationId { get; set; }
    public Occupations.Occupation RightOccupation { get; set; } = default!;
}