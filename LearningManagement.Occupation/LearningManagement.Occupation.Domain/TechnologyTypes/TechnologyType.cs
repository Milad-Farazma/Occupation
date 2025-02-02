using LearningManagement.Occupation.Domain.Technologys;

namespace LearningManagement.Occupation.Domain.TechnologyTypes;

public class TechnologyType : ApprovableEntity {
    public string? Title { get; set; }

    public long Code { get; set; }

    public string? Description { get; set; }

    public ICollection<Technology> Technologies { get; set; } = default!;
}