using LearningManagement.Occupation.Domain.Shared;

namespace LearningManagement.Occupation.Infrastructure.Occupations.EntityFramework.Configurations;

public class OccupationConfiguration : IEntityTypeConfiguration<Domain.Occupations.Occupation> {
    public void Configure(EntityTypeBuilder<Domain.Occupations.Occupation> builder) {
        builder.ToTable("Occupations");

        builder.HasKey(entity => entity.Id);
        builder.Property(entity => entity.Id).ValueGeneratedOnAdd();

        builder.Property(e => e.BannerUrl).HasMaxLength(250);
        builder.Property(e => e.BriefActivities).HasMaxLength(250);
        builder.Property(e => e.BriefPersonality).HasMaxLength(250);
        builder.Property(e => e.Description).HasMaxLength(250);
        builder.Property(e => e.IntroductionVideoUrl).HasMaxLength(250);
        builder.Property(e => e.Title).HasMaxLength(50);

        builder.Property(o => o.ModeSalary)
            .HasColumnType("decimal(18,4)");

        builder.Property(o => o.MaximumSalary)
            .HasColumnType("decimal(18,4)");

        builder.Property(o => o.MinimumSalary)
            .HasColumnType("decimal(18,4)");

        #region Relations

        builder.HasOne(entity => entity.JobClassification)
            .WithMany(entity => entity.Occupations)
            .HasForeignKey(entity => entity.JobClassificationId)
            .IsRequired();

        builder.HasOne(entity => entity.JobOutlook)
            .WithMany(entity => entity.Occupations)
            .HasForeignKey(entity => entity.JobOutlookId)
            .IsRequired();

        builder.HasMany(entity => entity.OccupationSeniorityLevels)
            .WithOne(entity => entity.Occupation)
            .HasForeignKey(entity => entity.OccupationId)
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