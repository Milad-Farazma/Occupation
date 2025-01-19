namespace Framework.Audit;

public sealed class AuditInfo {
    public DateTime CreatedAtUtcDateTime { get; set; }
    public DateTime? ModifiedAtUtcDateTime { get; set; }
    public long? CreatedByUserId { get; set; }
    public long? ModifiedByUserId { get; set; }
}