namespace Framework.Data.Audit;

public abstract class BaseAuditableEntity : BaseEntity, IAuditability {
    public AuditInfo AuditInfo { get; set; }
}