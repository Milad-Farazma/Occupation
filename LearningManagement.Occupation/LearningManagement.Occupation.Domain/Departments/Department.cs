using LearningManagement.Occupation.Domain.Organizations.Models;

namespace LearningManagement.Occupation.Domain.Departments;

public class Department : ApprovableEntity {
    public string Title { get; set; }

    public long OrganizationId { get; set; }

    public Organization Organization { get; set; } = default!;
    // public long TypeId { get; set; }
    // public DepartmentType Type { get; set; }
    // public ContactInfo ContactInfo { get; set; }
}