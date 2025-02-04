using LearningManagement.Occupation.Domain.JobActivities;

namespace LearningManagement.Occupation.Domain.Occupations;

public class OccupationActivity : BaseAuditableAndSoftDeletableEntity {
    public Guid OccupationId { get; set; }
    public Occupation Occupation { get; set; } = default!;

    public Guid SkillId { get; set; }
    public JobActivity JobActivity { get; set; } = default!;
}