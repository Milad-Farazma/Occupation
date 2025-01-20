namespace Framework.Data.SoftDelete;

public interface ISoftDeletable {
    public SoftDeleteInfo SoftDeleteInfo { get; set; }
}