using LearningManagement.Occupation.Domain.DepartmentTypes;
using LearningManagement.Occupation.Domain.Organizations.Models;

namespace LearningManagement.Occupation.Domain.Departments;

public class Department : ApprovableEntity {
    public string? Title { get; set; }
    public long Code { get; set; }
    public string? Description { get; set; }

    public string? Address { get; set; }

    public string? Phone { get; set; }

    public string? Fax { get; set; }

    public string? WebSiteUrl { get; set; }

    public string? Email { get; set; }

    public int? EducationCenterId { get; set; }
    public Guid DepartmentTypeId { get; set; }
    public DepartmentType DepartmentType { get; set; } = default!;

    public Organization Organization { get; set; }
    public Guid OrganizationId { get; set; }
}