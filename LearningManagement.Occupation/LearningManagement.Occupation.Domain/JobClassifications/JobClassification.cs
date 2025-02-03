namespace LearningManagement.Occupation.Domain.JobClassifications;

public class JobClassification : ApprovableEntity {
    public string? Title { get; set; }

    public long Code { get; set; }

    public string? Description { get; set; }


    public ICollection<Occupations.Occupation> Occupations { get; set; } = default!;
}