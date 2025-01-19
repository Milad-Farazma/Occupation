namespace Framework.SoftDelete;

public interface ISoftDeletable {
    public SoftDeleteInfo SoftDeleteInfo { get; set; }
}