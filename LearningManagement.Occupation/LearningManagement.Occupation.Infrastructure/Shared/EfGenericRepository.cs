using Framework.Data.SoftDelete;
using Framework.Pagination;
using LearningManagement.Occupation.Application.Shared;

namespace LearningManagement.Occupation.Infrastructure.Shared;

public abstract class EfGenericRepository<TEntity>(ApplicationDbContext context) : IGenericRepository<TEntity>
    where TEntity : BaseEntity, new() {
    protected readonly DbSet<TEntity> DbSet = context.Set<TEntity>();

    public IQueryable<TEntity> GetDbSet(bool asNoTracking) => asNoTracking ? DbSet.AsNoTracking() : DbSet.AsTracking();

    public Task<PaginatedResult<TEntity>> GetAllAsync(bool asNoTracking, PaginationRequest request, CancellationToken cancellationToken = default) =>
        GetDbSet(asNoTracking)
            .OrderBy(e => e.Id)
            .ApplyPagination(request, cancellationToken);

    public Task<PaginatedResult<TEntity>> GetAllWithRelationsAsync(bool asNoTracking, PaginationRequest request,
        CancellationToken cancellationToken = default) => throw new NotImplementedException();

    public Task<TEntity?> GetByIdAsync
        (long id, bool asNoTracking = true, CancellationToken cancellationToken = default) {
        var query = asNoTracking ? context.Set<TEntity>() : context.Set<TEntity>().AsTracking();

        return query.FirstOrDefaultAsync(e => EF.Property<long>(e, nameof(BaseEntity.Id)) == id, cancellationToken);
    }

    public Task<TEntity?> GetByIdWithRelationsAsync(long id, bool asNoTracking, CancellationToken cancellationToken = default) =>
        throw new NotImplementedException();

    public TEntity? GetById(long id, bool asNoTracking) {
        var entity = DbSet.Find(id);
        if (entity == null || !asNoTracking) return entity;

        context.Entry(entity).State = EntityState.Detached;
        return entity;
    }

    public async Task<bool> ExistsAsync(long id, CancellationToken cancellationToken = default) {
        return await DbSet.FindAsync([id], cancellationToken) != null;
    }

    public bool Exists(long id) {
        return DbSet.Find(id) != null;
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

    public int SaveChanges() {
        return context.SaveChanges();
    }

    public static void SetDeleteObject(SoftDeleteInfo deleteInfoObject, long? currentUserId, DateTime? deleteDate) {
        deleteInfoObject.IsDeleted = true;
        deleteInfoObject.DeletedByUserId = currentUserId;
        deleteInfoObject.DeletedAtUtcDateTime = deleteDate;
    }
}