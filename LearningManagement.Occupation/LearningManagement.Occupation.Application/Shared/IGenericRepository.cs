using Framework.Data;

namespace LearningManagement.Occupation.Application.Shared;

public interface IGenericRepository<TEntity> where TEntity : BaseEntity {
    Task<PaginatedResult<TEntity>> GetAllAsync(bool asNoTracking, PaginationRequest request, bool loadRelations,
        CancellationToken cancellationToken = default);

    Task<TEntity?> GetByIdAsync(Guid id, bool asNoTracking, bool loadRelations, CancellationToken cancellationToken = default);
    void Add(TEntity entity);
    void Update(TEntity entity);
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}