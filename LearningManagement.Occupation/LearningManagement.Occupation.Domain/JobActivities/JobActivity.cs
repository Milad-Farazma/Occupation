namespace LearningManagement.Occupation.Domain.JobActivities;

public class JobActivity : ApprovableEntity {
    public string? Title { get; set; }
    public long Code { get; set; }
    public string? Description { get; set; }
}