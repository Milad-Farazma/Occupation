using Framework;

namespace LMS.Aquamation.Core.Entities;

public class Department : BaseAuditableAndSoftDeletableEntity {
    public long TypeId { get; set; }
    public string Title { get; set; }
    public long CompanyId { get; set; }
    public long? ContactId { get; set; }


    public Company Company { get; set; }
    public DepartmentType Type { get; set; }
    public ContactInfo ContactInfo { get; set; }
}