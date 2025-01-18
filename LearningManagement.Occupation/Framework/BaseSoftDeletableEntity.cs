using Framework.Deletable;

namespace Framework;

public class BaseSoftDeletableEntity<TId> : BaseEntity<TId>, ISoftDeletable {
    public bool IsDeleted { get; set; }
    public DateTime? DeletedAt { get; }

    public void Delete() {
        DeletionHelper.MarkAsDeleted(this);
    }
}