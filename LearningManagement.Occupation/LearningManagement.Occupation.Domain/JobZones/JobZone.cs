using LearningManagement.Occupation.Domain.OccupationJobZones;

namespace LearningManagement.Occupation.Domain.JobZones;

public class JobZone : ApprovableEntity {
    public string? Title { get; set; }

    public long Code { get; set; }

    public string? Description { get; set; }


    public ICollection<OccupationJobZone> OccupationJobZons { get; set; } = default!;
}