using Framework.Services.User;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace Framework.Audit;

public sealed class AuditableEntitySaveChangesInterceptor(
    IUserService userService) : SaveChangesInterceptor {
    public override InterceptionResult<int> SavingChanges(
        DbContextEventData eventData,
        InterceptionResult<int> result) {
        SetAuditableProperties(eventData.Context);
        return base.SavingChanges(eventData, result);
    }

    public override ValueTask<InterceptionResult<int>> SavingChangesAsync(
        DbContextEventData eventData,
        InterceptionResult<int> result,
        CancellationToken cancellationToken = default) {
        SetAuditableProperties(eventData.Context);
        return base.SavingChangesAsync(eventData, result, cancellationToken);
    }

    public void SetAuditableProperties(DbContext? context) {
        if (context == null) return;

        foreach (var entry in context.ChangeTracker.Entries<IAuditability>()) {
            switch (entry.State) {
                case EntityState.Added:
                    entry.Entity.AuditInfo.CreatedAtUtcDateTime = DateTime.UtcNow;
                    entry.Entity.AuditInfo.CreatedByUserId = userService.GetCurrentUserId();
                    break;
                case EntityState.Modified:
                case EntityState.Unchanged when HasChangedOwnedEntities(entry):
                    entry.Entity.AuditInfo.ModifiedAtUtcDateTime = DateTime.UtcNow;
                    entry.Entity.AuditInfo.ModifiedByUserId = userService.GetCurrentUserId();
                    break;
            }
        }
    }

    private static bool HasChangedOwnedEntities(EntityEntry entry) => entry.References.Any(r =>
        r.TargetEntry != null &&
        r.TargetEntry.Metadata.IsOwned() &&
        r.TargetEntry.State is EntityState.Added or EntityState.Modified);
}