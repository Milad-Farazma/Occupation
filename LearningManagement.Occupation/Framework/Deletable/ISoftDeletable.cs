namespace Framework.Deletable;

public interface ISoftDeletable : IDeletable {
    bool IsDeleted { get; }
    DateTime? DeletedAt { get; }
}