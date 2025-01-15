namespace Framework;

public class BaseAuditableEntity : BaseEntity, IAuditablity {
    public long CreaorUserId { get; set; }
    public DateTime CreatedAtUtcDateTime { get; set; }
    public long ModifierUserId { get; set; }
    public DateTime ModifiedAtUtcDateTime { get; set; }
}