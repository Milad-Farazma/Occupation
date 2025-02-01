namespace LearningManagement.Occupation.Domain.JobActivitys;

public class JobActivity : ApprovableEntity {
    public string? Title { get; set; }
    public long Code { get; set; }
    public string? Description { get; set; }
}