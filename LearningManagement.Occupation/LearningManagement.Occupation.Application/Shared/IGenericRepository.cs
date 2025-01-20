using Framework.Data;

namespace LearningManagement.Occupation.Application.Shared;

public interface IGenericRepository<TEntity> where TEntity : BaseEntity {
    Task<List<TEntity>> GetAllAsync(bool asNoTracking, CancellationToken cancellationToken = default);
    Task<TEntity?> GetByIdAsync(long id, bool asNoTracking, CancellationToken cancellationToken = default);
    void Add(TEntity company);
    void Update(TEntity product);
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}