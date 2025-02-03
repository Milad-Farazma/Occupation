namespace LearningManagement.Occupation.Domain.JobOutLooks;

public class JobOutLook : ApprovableEntity {
    public string? Title { get; set; }

    public long Code { get; set; }

    public string? Description { get; set; }

    public string? Icon { get; set; }

    public string? IconTitle { get; set; }


    public ICollection<Occupations.Occupation> Occupations { get; set; } = default!;
}