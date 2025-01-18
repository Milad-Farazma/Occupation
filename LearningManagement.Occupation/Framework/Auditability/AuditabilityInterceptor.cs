using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace Framework.Auditability;

public class AuditabilityInterceptor : SaveChangesInterceptor {
    public override InterceptionResult<int> SavingChanges(DbContextEventData eventData, InterceptionResult<int> result) {
        var context = eventData.Context;
        if (context == null)
            return base.SavingChanges(eventData, result);

        SetAuditFields(context);
        return base.SavingChanges(eventData, result);
    }

    public override ValueTask<InterceptionResult<int>> SavingChangesAsync(
        DbContextEventData eventData,
        InterceptionResult<int> result,
        CancellationToken cancellationToken = default) {
        var context = eventData.Context;
        if (context == null)
            return base.SavingChangesAsync(eventData, result, cancellationToken);

        SetAuditFields(context);
        return base.SavingChangesAsync(eventData, result, cancellationToken: cancellationToken);
    }

    private void SetAuditFields(DbContext context) {
        var entries = context.ChangeTracker.Entries()
            .Where(e => e.Entity is IAuditability && (e.State == EntityState.Added || e.State == EntityState.Modified))
            .ToList();

        foreach (var entry in entries) {
            var auditEntity = (IAuditability)entry.Entity;

            switch (entry.State) {
                case EntityState.Added:
                    auditEntity.CreatedAtUtcDateTime = DateTime.UtcNow;
                    break;
                case EntityState.Modified:
                    auditEntity.ModifiedAtUtcDateTime = DateTime.UtcNow;
                    break;
            }
        }
    }
}