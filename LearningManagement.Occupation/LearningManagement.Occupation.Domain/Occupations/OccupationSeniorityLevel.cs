using LearningManagement.Occupation.Domain.SeniorityLevels;

namespace LearningManagement.Occupation.Domain.Occupations;

public class OccupationSeniorityLevel : BaseAuditableAndSoftDeletableEntity {
    public string? Description { get; set; }

    public Guid SeniorityLevelId { get; set; }

    public SeniorityLevel SeniorityLevel { get; set; } = null!;

    public Guid OccupationId { get; set; }
    public Occupation Occupation { get; set; } = null!;
}