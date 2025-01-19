namespace Framework.Repositories.Generic;

public interface IGenericRepository<T> {
    Task<List<T>> GetAllAsync(bool asNoTracking = true, CancellationToken cancellationToken = default);
    Task<T?> FindByIdAsync(long id, bool asNoTracking = true, CancellationToken cancellationToken = default);
    void Add(T company);
    void Update(T product);
    void Remove(T product);
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    Task<bool> ExistsAsync(long id, CancellationToken cancellationToken = default);
}