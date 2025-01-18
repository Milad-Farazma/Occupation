using Framework.Deletable;
using Microsoft.EntityFrameworkCore;

namespace Framework.Repositories.Generic;

public class EfGenericRepository<TEntity, TId>(DbContext context)
    where TEntity : class {
    protected readonly DbSet<TEntity> DbSet = context.Set<TEntity>();

    public Task<List<TEntity>> GetAllAsync(bool asNoTracking = true, CancellationToken cancellationToken = default) {
        var query = asNoTracking ? DbSet.AsNoTracking() : DbSet.AsQueryable();
        return query.ToListAsync(cancellationToken);
    }

    public async Task<TEntity?> FindByIdAsync(TId id, bool asNoTracking = true, CancellationToken cancellationToken = default) {
        var entity = await DbSet.FindAsync([id], cancellationToken);
        if (entity == null || !asNoTracking) return entity;

        context.Entry(entity).State = EntityState.Detached;
        return entity;
    }

    public async Task AddAsync(TEntity entity, CancellationToken cancellationToken = default) {
        await DbSet.AddAsync(entity, cancellationToken: cancellationToken);
    }

    public Task AddRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default) {
        return DbSet.AddRangeAsync(entities, cancellationToken: cancellationToken);
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
}