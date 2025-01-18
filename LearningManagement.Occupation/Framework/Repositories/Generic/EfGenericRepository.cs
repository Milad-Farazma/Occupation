using Framework.Deletable;
using Microsoft.EntityFrameworkCore;

namespace Framework.Repositories.Generic;

public class EfGenericRepository<TEntity, TId>(DbContext context)
    where TEntity : class {
    protected readonly DbSet<TEntity> DbSet = context.Set<TEntity>();

    public Task<List<TEntity>> GetAllAsync(bool asNoTracking = true) {
        var query = asNoTracking ? DbSet.AsNoTracking() : DbSet.AsQueryable();
        return query.ToListAsync();
    }

    public async Task<TEntity?> FindByIdAsync(TId id, bool asNoTracking = true) {
        var entity = await DbSet.FindAsync(id);
        if (entity == null || !asNoTracking) return entity;

        context.Entry(entity).State = EntityState.Detached;
        return entity;
    }

    public async Task AddAsync(TEntity entity) {
        await DbSet.AddAsync(entity);
    }

    public Task AddRangeAsync(IEnumerable<TEntity> entities) {
        return DbSet.AddRangeAsync(entities);
    }

    public void Update(TEntity entity) {
        DbSet.Update(entity);
    }

    public void Remove(TEntity entity) {
        if (entity is IDeletable deletableEntity)
            deletableEntity.Delete();
        DbSet.Remove(entity);
    }

    public void RemoveRange(IEnumerable<TEntity> entities) {
        foreach (var entity in entities) {
            Remove(entity);
        }
    }

    public Task<int> SaveChangesAsync() {
        return context.SaveChangesAsync();
    }
}