namespace Framework.Data.SoftDelete;

public sealed class SoftDeleteInfo {
    public bool IsDeleted { get; set; }
    public DateTime? DeletedAtUtcDateTime { get; set; }
    public Guid? DeletedByUserId { get; set; }
}