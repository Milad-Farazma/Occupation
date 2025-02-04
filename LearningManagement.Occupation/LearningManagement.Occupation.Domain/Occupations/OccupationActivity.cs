using System.Diagnostics;

namespace LearningManagement.Occupation.Domain.Occupations;

public class OccupationActivity {
    public Guid OccupationId { get; set; }
    public Occupation Occupation { get; set; } = default!;

    public Guid SkillId { get; set; }
    public Activity Activity { get; set; } = default!;
}