using Framework;

namespace LearningManagement.Occupation.Domain.Models;

public class Department : BaseAuditableAndSoftDeletableEntity {
    public long TypeId { get; set; }
    public string Title { get; set; }
    public long CompanyId { get; set; }
    public long? ContactId { get; set; }


    public Company.Models.Company Company { get; set; }
    public DepartmentType Type { get; set; }
    public ContactInfo ContactInfo { get; set; }
}