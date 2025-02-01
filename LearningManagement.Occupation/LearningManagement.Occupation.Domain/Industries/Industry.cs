namespace LearningManagement.Occupation.Domain.Industries;

public class Industry : ApprovableEntity {
    public string? Title { get; set; }

    public long Code { get; set; }

    public string? Description { get; set; }
}