using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace Framework.Data.SoftDelete;

public static class SoftDeleteExtensions {
    public static void SetSoftDeleteQueryFilter(this ModelBuilder modelBuilder) {
        foreach (var entityType in modelBuilder.Model.GetEntityTypes()) {
            // Check if the entity implements ISoftDeletable
            if (!typeof(ISoftDeletable).IsAssignableFrom(entityType.ClrType))
                continue;

            // Build the lambda expression for the query filter: e => !e.SoftDeleteInfo.IsDeleted
            var parameter = Expression.Parameter(entityType.ClrType, "e");
            var property = Expression.Property(
                Expression.Property(parameter, nameof(ISoftDeletable.SoftDeleteInfo)),
                nameof(SoftDeleteInfo.IsDeleted)
            );
            var filter = Expression.Lambda(
                Expression.Equal(property, Expression.Constant(false)),
                parameter
            );

            // Apply the query filter to the entity
            modelBuilder.Entity(entityType.ClrType).HasQueryFilter(filter);
        }
    }

    public static void SetDeleteObject(this SoftDeleteInfo deleteInfoObject, long? currentUserId) {
        deleteInfoObject.IsDeleted = true;
        deleteInfoObject.DeletedByUserId = currentUserId;
        deleteInfoObject.DeletedAtUtcDateTime = DateTime.UtcNow;
    }
}