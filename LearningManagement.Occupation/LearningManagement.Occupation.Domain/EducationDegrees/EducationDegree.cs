namespace LearningManagement.Occupation.Domain.EducationDegrees;

public class EducationDegree : ApprovableEntity {
    public string? Title { get; set; }

    public long Code { get; set; }

    public string? Description { get; set; }
}