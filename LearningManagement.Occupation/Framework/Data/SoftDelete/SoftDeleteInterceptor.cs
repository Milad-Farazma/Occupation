namespace Framework.Data.SoftDelete;

public class SoftDeleteInterceptor(IUserService userService) : SaveChangesInterceptor {
    public override InterceptionResult<int> SavingChanges(
        DbContextEventData eventData,
        InterceptionResult<int> result) {
        HandleSoftDelete(eventData.Context);
        return base.SavingChanges(eventData, result);
    }

    public override ValueTask<InterceptionResult<int>> SavingChangesAsync(
        DbContextEventData eventData,
        InterceptionResult<int> result,
        CancellationToken cancellationToken = default) {
        HandleSoftDelete(eventData.Context);
        return base.SavingChangesAsync(eventData, result, cancellationToken);
    }

    private void HandleSoftDelete(DbContext? context) {
        if (context == null) return;

        var entries = context.ChangeTracker.Entries()
            .Where(entry => entry is { State: EntityState.Deleted, Entity: ISoftDeletable })
            .ToList();

        foreach (var entry in entries) {
            SetSoftDelete(entry);
        }
    }

    private void SetSoftDelete(EntityEntry entry) {
        if (entry.Entity is not ISoftDeletable softDeletable) return;

        // Change state to Modified
        entry.State = EntityState.Modified;

        // Set soft delete properties
        softDeletable.SoftDeleteInfo.SetDeleteObject(userService.GetCurrentUserId());

        // Find related entities that implement ISoftDeletable
        var relatedEntries = entry.References
            .Where(reference => reference.TargetEntry is { Entity: ISoftDeletable })
            .Select(reference => reference.TargetEntry)
            .ToList();

        foreach (var relatedEntry in relatedEntries.OfType<EntityEntry>()) {
            SetSoftDelete(relatedEntry);
        }
    }
}