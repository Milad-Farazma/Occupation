using LearningManagement.Occupation.Domain.OccupationSimilarities;
using LearningManagement.Occupation.Domain.Shared;

namespace LearningManagement.Occupation.Infrastructure.OccupationSimilarities.EntityFramework.Configurations;

public class OccupationSimilarityConfiguration : IEntityTypeConfiguration<OccupationSimilarity> {
    public void Configure(EntityTypeBuilder<OccupationSimilarity> builder) {
        builder.ToTable("OccupationSimilarities");

        builder.HasKey(entity => entity.Id);

        builder.Property(e => e.Description).HasMaxLength(250);

        #region Relations

        builder.HasOne(e => e.LeftOccupation)
            .WithMany(o => o.OccupationSimilarity)
            .HasForeignKey(e => e.LeftOccupationId)
            .OnDelete(DeleteBehavior.ClientSetNull);

        builder.HasOne(e => e.RightOccupation)
            .WithMany()
            .HasForeignKey(e => e.RightOccupationId)
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