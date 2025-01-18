using System.Reflection;

namespace Framework.Deletable;

public static class DeletionHelper {
    public static void MarkAsDeleted(object deletable) {
        ArgumentNullException.ThrowIfNull(deletable);

        // Check if the object implements IDeletable
        if (deletable is not ISoftDeletable deletableEntity) return;

        // Skip if IsDeleted is already true
        if (deletableEntity.IsDeleted)
            return;

        // Set properties
        SetProperty(deletable, nameof(ISoftDeletable.IsDeleted), true);
        SetProperty(deletable, nameof(ISoftDeletable.DeletedAt), DateTime.UtcNow);
    }

    private static void SetProperty(object target, string propertyName, object value) {
        var property = target.GetType().GetProperty(propertyName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
        if (property == null || !property.CanWrite) {
            throw new InvalidOperationException($"Property '{propertyName}' not found or not writable on type '{target.GetType().Name}'.");
        }

        property.SetValue(target, value);
    }
}