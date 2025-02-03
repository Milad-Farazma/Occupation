namespace LearningManagement.Occupation.Domain.OccupationSimilaritys;

public class OccupationSimilarity : ApprovableEntity {
    public string? Description { get; set; }

    public int OccupationId1 { get; set; }
    public Occupations.Occupation OccupationId1Navigation { get; set; } = default!;

    public int OccupationId2 { get; set; }

    public Occupations.Occupation OccupationId2Navigation { get; set; } = default!;
}