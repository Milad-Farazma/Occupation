namespace Framework.Data.SoftDelete;

public sealed class SoftDeleteInfo {
    public bool IsDeleted { get; set; }
    public DateTime? DeletedAtUtcDateTime { get; set; }
    public long? DeletedByUserId { get; set; }
}