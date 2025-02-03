namespace Framework.Data.Audit;

public sealed class AuditInfo {
    public DateTime CreatedAtUtcDateTime { get; set; }
    public DateTime? ModifiedAtUtcDateTime { get; set; }
    public Guid? CreatedByUserId { get; set; }
    public Guid? ModifiedByUserId { get; set; }
}