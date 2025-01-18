using Framework.Deletable;

namespace Framework;

public class BaseAuditableAndSoftDeletableEntity<TId> : BaseEntity<TId>, IAuditablity, ISoftDeletable {
    public long CreatorUserId { get; set; }
    public DateTime CreatedAtUtcDateTime { get; set; }
    public long ModifierUserId { get; set; }
    public DateTime ModifiedAtUtcDateTime { get; set; }
    public bool IsDeleted { get; set; }
    public DateTime? DeletedAt { get; }

    public void Delete() {
        DeletionHelper.MarkAsDeleted(this);
    }
}