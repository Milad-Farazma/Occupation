using LearningManagement.Occupation.Domain.Organizations.Models;
using LearningManagement.Occupation.Domain.Shared;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LearningManagement.Occupation.Infrastructure.Organizations.EntityFramework.Configurations;

public class OrganizationConfiguration : IEntityTypeConfiguration<Organization> {
    public void Configure(EntityTypeBuilder<Organization> builder) {
        builder.ToTable("Organizations");

        builder.HasKey(entity => entity.Id);
        builder.Property(entity => entity.Id).ValueGeneratedOnAdd();

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

        builder.HasKey(entity => entity.Id);
        builder.Property(entity => entity.Id)
            .ValueGeneratedOnAdd(); // Configure auto-increment behavior

        builder.Property(entity => entity.Title).IsRequired().HasMaxLength(200);
        builder.Property(entity => entity.IsViewable);
        builder.Property(entity => entity.IsApproved);

        builder.HasMany(entity => entity.Department)
            .WithOne(entity => entity.Organization)
            .HasForeignKey(entity => entity.OrganizationId)
            .IsRequired();
    }
}