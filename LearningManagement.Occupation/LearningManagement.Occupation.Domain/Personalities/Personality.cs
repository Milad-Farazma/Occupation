namespace LearningManagement.Occupation.Domain.Personalities;

public class Personality : ApprovableEntity {
    public string? Title { get; set; }

    public long Code { get; set; }

    public string? Description { get; set; }
}