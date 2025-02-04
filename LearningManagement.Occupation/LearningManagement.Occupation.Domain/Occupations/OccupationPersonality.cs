using LearningManagement.Occupation.Domain.Personalities;

namespace LearningManagement.Occupation.Domain.Occupations;

public class OccupationPersonality {
    public Guid OccupationId { get; set; }
    public Occupation Occupation { get; set; } = default!;

    public Guid PersonalityId { get; set; }
    public Personality Personality { get; set; } = default!;
}