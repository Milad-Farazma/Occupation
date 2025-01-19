namespace LearningManagement.Occupation.Domain.Shared;

public static class WellKnownNames {
    public static class AuditInfo {
        public const string CreatedByUserId = "CreatedByUserId";
        public const string ModifiedByUserId = "ModifiedByUserId";
        public const string CreatedAtUtcDateTime = "CreatedAtUtcDateTime";
        public const string ModifiedAtUtcDateTime = "ModifiedAtUtcDateTime";
    }

    public static class SoftDeleteInfo {
        public const string IsDeleted = "IsDeleted";
        public const string DeletedByUserId = "DeletedByUserId";
        public const string DeletedAtUtcDateTime = "DeletedAtUtcDateTime";
    }
}