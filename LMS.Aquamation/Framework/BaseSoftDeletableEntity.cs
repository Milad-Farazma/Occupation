namespace Framework;

public class BaseSoftDeletableEntity : BaseEntity, ISoftDeletablity {
    public bool IsDeleted { get; set; }
}