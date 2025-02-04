using LearningManagement.Occupation.Domain.Occupations;

namespace LearningManagement.Occupation.Domain.SeniorityLevels;

public class SeniorityLevel : ApprovableEntity {
    public string? Title { get; set; }

    public long Code { get; set; }

    public string? Description { get; set; }


    public ICollection<OccupationSeniorityLevel> OccupationSeniorityLevels { get; set; } = default!;
}