namespace LearningManagement.Occupation.Domain.JobPositions;

public class JobPosition : ApprovableEntity {
    public Guid? ParentId { get; set; }
    public string? Title { get; set; }
    public ushort Capacity { get; set; }
    public Guid OrganizationId { get; set; }

    public Guid OccupationId { get; set; }
    public Occupations.Occupation Occupation { get; set; }
}