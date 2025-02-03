using LearningManagement.Occupation.Domain.OccupationJobZones;
using LearningManagement.Occupation.Domain.Shared;

namespace LearningManagement.Occupation.Infrastructure.OccupationJobZones.EntityFramework.Configurations;

public class OccupationJobZoneConfiguration : IEntityTypeConfiguration<OccupationJobZone> {
    public void Configure(EntityTypeBuilder<OccupationJobZone> builder) {
        builder.ToTable("OccupationJobZones");

        builder.HasKey(entity => entity.Id);
        builder.Property(entity => entity.Id).ValueGeneratedOnAdd();

        builder.Property(e => e.Description).HasMaxLength(250);

        #region Relations

        builder.HasOne(d => d.JobZone)
            .WithMany(p => p.OccupationJobZons)
            .HasForeignKey(d => d.JobZoneId)
            .OnDelete(DeleteBehavior.ClientSetNull);

        builder.HasOne(d => d.Occupation).WithMany(p => p.OccupationJobZons)
            .HasForeignKey(d => d.OccupationId)
            .OnDelete(DeleteBehavior.ClientSetNull);

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