namespace Framework.Deletable;

public interface ISoftDeletable : IDeletable {
    bool IsDeleted { get; set; }
    DateTime? DeletedAt { get; set; }
}