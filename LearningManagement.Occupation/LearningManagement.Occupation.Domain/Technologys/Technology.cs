using LearningManagement.Occupation.Domain.TechnologyTypes;

namespace LearningManagement.Occupation.Domain.Technologys;

public class Technology : ApprovableEntity {
    public string? Title { get; set; }

    public Guid TechnologyTypeId { get; set; }

    public long Code { get; set; }

    public string? Description { get; set; }
    public TechnologyType TechnologyType { get; set; } = default!;
}