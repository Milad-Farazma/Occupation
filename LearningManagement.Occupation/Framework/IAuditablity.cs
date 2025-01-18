namespace Framework;

public interface IAuditablity {
    public long CreatorUserId { get; set; }
    public DateTime CreatedAtUtcDateTime { get; set; }
    public long ModifierUserId { get; set; }
    public DateTime ModifiedAtUtcDateTime { get; set; }
}