using Framework.Data;

namespace Framework.Audit;

public abstract class BaseAuditableEntity : BaseEntity, IAuditability {
    public AuditInfo AuditInfo { get; set; }
}