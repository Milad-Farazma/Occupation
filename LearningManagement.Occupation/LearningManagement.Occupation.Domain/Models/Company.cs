using Framework;

namespace LearningManagement.Occupation.Domain.Models;

public class Company : BaseAuditableAndSoftDeletableEntity {
    public long? TypeId { get; set; }
    public string Title { get; set; }

    // If true the entity is searchable and viewable in the system
    public bool IsViewable { get; set; }

    // If true the company registration is validated
    public bool IsApproved { get; set; }
    public long ApprovedByUserId { get; set; }
    public long ApprovedAtUtcDateTime { get; set; }
    public long CertificateCode { get; set; }
    public string Description { get; set; }
    public string LogoUrl { get; set; }

    public CompanyType Type { get; set; }
    public ICollection<Department> Department { get; set; } = [];
}