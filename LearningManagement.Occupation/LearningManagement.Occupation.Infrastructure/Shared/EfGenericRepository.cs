using LearningManagement.Occupation.Application.Shared;

namespace LearningManagement.Occupation.Infrastructure.Shared;

public abstract class EfGenericRepository<TEntity>(ApplicationDbContext context) : IGenericRepository<TEntity>
    where TEntity : BaseEntity, new() {
    protected readonly DbSet<TEntity> DbSet = context.Set<TEntity>();

    public IQueryable<TEntity> GetDbSet(bool asNoTracking) => asNoTracking ? DbSet.AsNoTracking() : DbSet.AsTracking();

    public Task<PaginatedResult<TEntity>> GetAllAsync(bool asNoTracking, PaginationRequest request, bool loadRelations,
        CancellationToken cancellationToken = default) {
        var query = GetDbSet(asNoTracking);

        if (loadRelations) {
            // Include all navigation properties dynamically
            foreach (var navigationProperty in context.Model.FindEntityType(typeof(TEntity))?.GetNavigations() ?? []) {
                query = query.Include(navigationProperty.Name);
            }
        }

        return query
            .OrderBy(e => e.Id)
            .ApplyPagination(request, cancellationToken);
    }

    public Task<TEntity?> GetByIdAsync
        (Guid id, bool asNoTracking, bool loadRelations, CancellationToken cancellationToken = default) {
        var query = GetDbSet(asNoTracking);

        if (loadRelations) {
            // Include all navigation properties dynamically
            foreach (var navigationProperty in context.Model.FindEntityType(typeof(TEntity))?.GetNavigations() ?? []) {
                query = query.Include(navigationProperty.Name);
            }
        }

        return query.FirstOrDefaultAsync(e => EF.Property<Guid>(e, nameof(BaseEntity.Id)) == id, cancellationToken);
    }

    public async Task<bool> ExistsAsync(Guid id, CancellationToken cancellationToken = default) {
        return await DbSet.FindAsync([id], cancellationToken) != null;
    }

    public async Task AddAsync(TEntity entity, CancellationToken cancellationToken = default) {
        await DbSet.AddAsync(entity, cancellationToken: cancellationToken);
    }

    public void Add(TEntity entity) {
        DbSet.Add(entity);
    }

    public Task AddRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default) {
        return DbSet.AddRangeAsync(entities, cancellationToken: cancellationToken);
    }

    public void AddRange(IEnumerable<TEntity> entities) {
        DbSet.AddRange(entities);
    }

    public void Update(TEntity entity) {
        DbSet.Update(entity);
    }

    public void Remove(TEntity entity) {
        DbSet.Remove(entity);
    }

    public void RemoveRange(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default) {
        foreach (var entity in entities) {
            // Check for cancellation
            cancellationToken.ThrowIfCancellationRequested();

            // Remove the entity
            DbSet.Remove(entity);
        }
    }

    public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default) {
        return context.SaveChangesAsync(cancellationToken: cancellationToken);
    }
}