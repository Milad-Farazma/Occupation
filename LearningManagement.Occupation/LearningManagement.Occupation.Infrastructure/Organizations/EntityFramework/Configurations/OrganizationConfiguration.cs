using LearningManagement.Occupation.Domain.Organizations.Models;
using LearningManagement.Occupation.Domain.Shared;

namespace LearningManagement.Occupation.Infrastructure.Organizations.EntityFramework.Configurations;

public class OrganizationConfiguration : IEntityTypeConfiguration<Organization> {
    public void Configure(EntityTypeBuilder<Organization> builder) {
        builder.ToTable("Organizations");

        builder.HasKey(entity => entity.Id);

        builder.Property(e => e.CertificateCode).HasMaxLength(50);
        builder.Property(e => e.CityTitle).HasMaxLength(50);
        builder.Property(e => e.Description).HasMaxLength(250);
        builder.Property(e => e.Email).HasMaxLength(50);
        builder.Property(e => e.LogoImg).HasMaxLength(100);
        builder.Property(e => e.ProvinceTitle).HasMaxLength(50);
        builder.Property(e => e.Title).HasMaxLength(50);
        builder.Property(e => e.WebsiteUrl).HasMaxLength(50);

        #region Relations

        builder.HasMany(entity => entity.Departments)
            .WithOne(entity => entity.Organization)
            .HasForeignKey(entity => entity.OrganizationId)
            .IsRequired();

        builder.HasOne(d => d.OrganizationType)
            .WithMany(p => p.Organizations)
            .HasForeignKey(d => d.OrganizationTypeId)
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