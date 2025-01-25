using LearningManagement.Occupation.Domain.EducationFieldSpecializations;
using LearningManagement.Occupation.Domain.Shared;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LearningManagement.Occupation.Infrastructure.EducationFieldSpecializations.EntityFramework.Configurations;

public class EducationFieldSpecializationConfiguration : IEntityTypeConfiguration<EducationFieldSpecialization> {
    public void Configure(EntityTypeBuilder<EducationFieldSpecialization> builder) {
        builder.ToTable("EducationFieldSpecializations");

        builder.HasKey(entity => entity.Id);
        builder.Property(entity => entity.Id).ValueGeneratedOnAdd();
        
        builder.Property(e => e.Description).HasMaxLength(250);
        builder.Property(e => e.Title).HasMaxLength(50);

        #region Relations

        builder.HasOne(d => d.EducationField)
            .WithMany(p => p.EducationFieldSpecializations)
            .HasForeignKey(d => d.EducationFieldId)
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