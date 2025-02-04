using LearningManagement.Occupation.Domain.Technologys;

namespace LearningManagement.Occupation.Domain.Occupations;

public class OccupationTechnology {
    public Guid OccupationId { get; set; }
    public Occupation Occupation { get; set; } = default!;

    public Guid SkillId { get; set; }
    public Technology Technology { get; set; } = default!;
}