namespace Framework;

public class BaseAuditableEntity : BaseEntity, IAuditability {
    public long CreatorUserId { get; set; }
    public DateTime CreatedAtUtcDateTime { get; set; }
    public long ModifierUserId { get; set; }
    public DateTime ModifiedAtUtcDateTime { get; set; }
}