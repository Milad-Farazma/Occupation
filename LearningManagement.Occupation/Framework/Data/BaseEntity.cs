namespace Framework.Data;

public abstract class BaseEntity {
    public Guid Id { get; set; } = new();
}