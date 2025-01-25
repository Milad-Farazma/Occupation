using LearningManagement.Occupation.Domain.Organizations.Models;

namespace LearningManagement.Occupation.Domain.OrganizationTypes;

public class OrganizationType : ApprovableEntity {
    public string? Title { get; set; }

    public long Code { get; set; }

    public string? Description { get; set; }

    public ICollection<Organization> Organizations { get; set; } = [];
}