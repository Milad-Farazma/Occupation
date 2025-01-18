using Framework.Deletable;
using Microsoft.EntityFrameworkCore;

namespace Framework.Repositories.Generic;

public class EfGenericRepository<TEntity, TId>(DbContext context)
    where TEntity : BaseEntity {
    protected readonly DbSet<TEntity> DbSet = context.Set<TEntity>();

    private IQueryable<TEntity> GetAsNoTrackingDbSet(bool asNoTracking) => asNoTracking ? DbSet.AsNoTracking() : DbSet.AsQueryable();

    public Task<List<TEntity>> GetAllAsync(bool asNoTracking = true, CancellationToken cancellationToken = default) {
        var query = GetAsNoTrackingDbSet(asNoTracking);
        return query.ToListAsync(cancellationToken);
    }

    public async Task<TEntity?> FindByIdAsync(TId id, bool asNoTracking = true, CancellationToken cancellationToken = default) {
        var entity = await DbSet.FindAsync([id], cancellationToken);
        if (entity == null || !asNoTracking) return entity;

        context.Entry(entity).State = EntityState.Detached;
        return entity;
    }

    public async Task<TEntity?> GetByIdAsync(TId id, bool asNoTracking = true, CancellationToken cancellationToken = default) {
        var entity = await DbSet.FindAsync([id], cancellationToken);
        if (entity == null || !asNoTracking) return entity;

        context.Entry(entity).State = EntityState.Detached;
        return entity;
    }

    public TEntity? GetById(TId id, bool asNoTracking = true) {
        var entity = DbSet.Find(id);
        if (entity == null || !asNoTracking) return entity;

        context.Entry(entity).State = EntityState.Detached;
        return entity;
    }

    public async Task<bool> ExistsAsync(TId id, CancellationToken cancellationToken = default) {
        return await DbSet.FindAsync([id], cancellationToken) != null;
    }

    public bool Exists(TId id) {
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
        if (entity is IDeletable deletableEntity)
            deletableEntity.Delete();
        DbSet.Remove(entity);
    }

    public void RemoveRange(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default) {
        foreach (var entity in entities) {
            // Check for cancellation
            cancellationToken.ThrowIfCancellationRequested();

            // Remove the entity
            Remove(entity);
        }
    }

    public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default) {
        return context.SaveChangesAsync(cancellationToken: cancellationToken);
    }

    public int SaveChanges() {
        return context.SaveChanges();
    }
}