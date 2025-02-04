using LearningManagement.Occupation.Domain.SeniorityLevels;
using LearningManagement.Occupation.Domain.Shared;

namespace LearningManagement.Occupation.Infrastructure.SeniorityLevels.EntityFramework.Configurations;

public class SeniorityLevelConfiguration : IEntityTypeConfiguration<SeniorityLevel> {
    public void Configure(EntityTypeBuilder<SeniorityLevel> builder) {
        builder.ToTable("SeniorityLevels");

        builder.HasKey(entity => entity.Id);

        builder.Property(e => e.Description).HasMaxLength(250);
        builder.Property(e => e.Title).HasMaxLength(50);

        #region Relations

        builder.HasMany(entity => entity.OccupationSeniorityLevels)
            .WithOne(entity => entity.SeniorityLevel)
            .HasForeignKey(entity => entity.SeniorityLevelId)
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