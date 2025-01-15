namespace Framework;

public class BaseAuditableAndSoftDeletableEntity : BaseEntity, IAuditablity, ISoftDeletablity {
    public long CreaorUserId { get; set; }
    public DateTime CreatedAtUtcDateTime { get; set; }
    public long ModifierUserId { get; set; }
    public DateTime ModifiedAtUtcDateTime { get; set; }
    public bool IsDeleted { get; set; }
}