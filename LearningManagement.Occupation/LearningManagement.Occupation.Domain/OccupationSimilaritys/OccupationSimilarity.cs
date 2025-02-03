namespace LearningManagement.Occupation.Domain.OccupationSimilaritys;

public class OccupationSimilarity : ApprovableEntity {
    public string? Description { get; set; }

    public Guid OccupationId1 { get; set; }
    public Occupations.Occupation OccupationId1Navigation { get; set; } = default!;

    public Guid OccupationId2 { get; set; }

    public Occupations.Occupation OccupationId2Navigation { get; set; } = default!;
}