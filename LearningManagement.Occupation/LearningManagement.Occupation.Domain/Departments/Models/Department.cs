using LearningManagement.Occupation.Domain.Companies.Models;

namespace LearningManagement.Occupation.Domain.Departments.Models;

public class Department : BaseAuditableAndSoftDeletableEntity {
    public long TypeId { get; set; }
    public string Title { get; set; }

    public long CompanyId { get; set; }

    public Company Company { get; set; } = default!;
    // public long? ContactId { get; set; }
    // public DepartmentType Type { get; set; }
    // public ContactInfo ContactInfo { get; set; }
}