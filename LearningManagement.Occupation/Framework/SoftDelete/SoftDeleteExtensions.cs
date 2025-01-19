using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Framework.SoftDelete;

public static class SoftDeleteExtensions {
    public static void SetSoftDeleteQueryFilter(this ModelBuilder modelBuilder) {
        foreach (var entityType in modelBuilder.Model.GetEntityTypes()) {
            // Check if the entity implements ISoftDeletable
            if (!typeof(ISoftDeletable).IsAssignableFrom(entityType.ClrType))
                continue;

            // Use reflection to get the generic method for Entity<T>
            var method = typeof(ModelBuilder)
                .GetMethod(nameof(ModelBuilder.Entity), [])
                ?.MakeGenericMethod(entityType.ClrType);

            if (method == null)
                continue;

            // Call the Entity<T> method and get the IEntityTypeBuilder
            var entityBuilder = method.Invoke(modelBuilder, null);

            // Now, apply the query filter
            var parameter = Expression.Parameter(entityType.ClrType, "e");
            var isDeletedProperty = Expression.Property(parameter, nameof(ISoftDeletable.SoftDeleteInfo.IsDeleted));
            var notDeleted = Expression.Not(isDeletedProperty);
            var lambda = Expression.Lambda(notDeleted, parameter);

            // Use reflection to call the correct HasQueryFilter method (with LambdaExpression parameter)
            var hasQueryFilterMethod = typeof(EntityTypeBuilder<>)
                .MakeGenericType(entityType.ClrType)
                .GetMethod(nameof(EntityTypeBuilder<object>.HasQueryFilter), [typeof(LambdaExpression)]);

            if (hasQueryFilterMethod != null)
                hasQueryFilterMethod.Invoke(entityBuilder, [lambda]);
        }
    }

    public static void SetDeleteObject(this SoftDeleteInfo deleteInfoObject, long? currentUserId) {
        deleteInfoObject.IsDeleted = true;
        deleteInfoObject.DeletedByUserId = currentUserId;
        deleteInfoObject.DeletedAtUtcDateTime = DateTime.UtcNow;
    }
}