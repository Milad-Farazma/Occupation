using LearningManagement.Occupation.Domain.JobClassifications;
using LearningManagement.Occupation.Domain.JobOutLooks;
using LearningManagement.Occupation.Domain.OccupationJobZones;
using LearningManagement.Occupation.Domain.OccupationSimilaritys;

namespace LearningManagement.Occupation.Domain.Occupations;

public class Occupation : ApprovableEntity {
    public string? Title { get; set; }

    public long Code { get; set; }

    public string? Description { get; set; }

    public string? BriefActivities { get; set; }

    public string? BannerImage { get; set; }

    public string? VideoDescription { get; set; }

    public string? BriefPersonality { get; set; }

    public decimal? MinimumSalary { get; set; }

    public decimal? MaximumSalary { get; set; }

    public decimal? ModeSalary { get; set; }


    public Guid JobClassificationId { get; set; }
    public JobClassification JobClassification { get; set; } = default!;

    public Guid JobOutlookId { get; set; }
    public JobOutLook JobOutlook { get; set; } = default!;

    public ICollection<OccupationJobZone> OccupationJobZons { get; set; } = default!;

    public ICollection<OccupationSimilarity> OccupationSimilarityOccupationId1Navigations { get; set; } = default!;

    public ICollection<OccupationSimilarity> OccupationSimilarityOccupationId2Navigations { get; set; } = default!;
}