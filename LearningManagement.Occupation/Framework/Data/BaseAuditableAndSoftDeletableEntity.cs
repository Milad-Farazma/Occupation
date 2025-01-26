using Framework.Data.Audit;

namespace Framework.Data;

public abstract class BaseAuditableAndSoftDeletableEntity : BaseEntity, IAuditability, ISoftDeletable {
    public AuditInfo AuditInfo { get; set; } = new();
    public SoftDeleteInfo SoftDeleteInfo { get; set; } = new();
}