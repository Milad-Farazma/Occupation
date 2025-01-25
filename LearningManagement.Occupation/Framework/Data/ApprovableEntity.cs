namespace Framework.Data;

public abstract class ApprovableEntity : BaseAuditableAndSoftDeletableEntity {
    public bool IsActive { get; set; } = true;
}