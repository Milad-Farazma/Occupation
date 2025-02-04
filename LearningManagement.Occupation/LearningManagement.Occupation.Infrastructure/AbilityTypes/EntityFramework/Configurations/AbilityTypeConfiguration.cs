using LearningManagement.Occupation.Domain.AbilityTypes;
using LearningManagement.Occupation.Domain.Shared;

namespace LearningManagement.Occupation.Infrastructure.AbilityTypes.EntityFramework.Configurations;

public class AbilityTypeConfiguration : IEntityTypeConfiguration<AbilityType> {
    public void Configure(EntityTypeBuilder<AbilityType> builder) {
        builder.ToTable("AbilityTypes");

        builder.HasKey(entity => entity.Id);

        builder.Property(e => e.Description).HasMaxLength(250);

        builder.Property(e => e.Title).HasMaxLength(50);

        #region Relations

        builder.HasMany(entity => entity.Abilities)
            .WithOne(entity => entity.AbilityType)
            .HasForeignKey(entity => entity.AbilityTypeId)
            .IsRequired();

        #endregion

        #region Audit and SoftDelete

        builder.OwnsOne(entity => entity.AuditInfo, nb => {
            nb.Property(auditInfo => auditInfo.CreatedByUserId).HasColumnName(WellKnownNames.AuditInfo.CreatedByUserId);
            nb.Property(auditInfo => auditInfo.ModifiedByUserId).HasColumnName(WellKnownNames.AuditInfo.ModifiedByUserId);
            nb.Property(auditInfo => auditInfo.CreatedAtUtcDateTime).HasColumnName(WellKnownNames.AuditInfo.CreatedAtUtcDateTime);
            nb.Property(auditInfo => auditInfo.ModifiedAtUtcDateTime).HasColumnName(WellKnownNames.AuditInfo.ModifiedAtUtcDateTime);
        });
        builder.OwnsOne(entity => entity.SoftDeleteInfo, nb => {
            nb.Property(softDeleteInfo => softDeleteInfo.IsDeleted).HasColumnName(WellKnownNames.SoftDeleteInfo.IsDeleted);
            nb.Property(softDeleteInfo => softDeleteInfo.DeletedAtUtcDateTime).HasColumnName(WellKnownNames.SoftDeleteInfo.DeletedAtUtcDateTime);
            nb.Property(softDeleteInfo => softDeleteInfo.DeletedByUserId).HasColumnName(WellKnownNames.SoftDeleteInfo.DeletedByUserId);
        });

        #endregion
    }
}