using Framework.Data;
using Framework.Pagination;

namespace LearningManagement.Occupation.Application.Shared;

public interface IGenericRepository<TEntity> where TEntity : BaseEntity {
    Task<PaginatedResult<TEntity>> GetAllAsync(bool asNoTracking, PaginationRequest request, CancellationToken cancellationToken = default);

    Task<PaginatedResult<TEntity>> GetAllWithRelationsAsync(bool asNoTracking, PaginationRequest request,
        CancellationToken cancellationToken = default);

    Task<TEntity?> GetByIdAsync(long id, bool asNoTracking, CancellationToken cancellationToken = default);
    Task<TEntity?> GetByIdWithRelationsAsync(long id, bool asNoTracking, CancellationToken cancellationToken = default);
    void Add(TEntity entity);
    void Update(TEntity entity);
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}