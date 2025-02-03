using LearningManagement.Occupation.Domain.JobZones;

namespace LearningManagement.Occupation.Domain.OccupationJobZones;

public class OccupationJobZone : ApprovableEntity {
    public string? Description { get; set; }

    public int JobZoneId { get; set; }

    public JobZone JobZone { get; set; } = null!;

    public int OccupationId { get; set; }
    public Occupations.Occupation Occupation { get; set; } = null!;
}