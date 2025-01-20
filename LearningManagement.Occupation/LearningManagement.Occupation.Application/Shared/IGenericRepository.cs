namespace LearningManagement.Occupation.Application.Shared;

public interface IGenericRepository<T> {
    Task<List<T>> GetAllAsync(bool asNoTracking, CancellationToken cancellationToken = default);
    Task<T?> GetByIdAsync(long id, bool asNoTracking, CancellationToken cancellationToken = default);
    void Add(T company);
    void Update(T product);
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}