using LearningManagement.Occupation.Domain.Organizations.Models;
using LearningManagement.Occupation.Domain.Shared;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LearningManagement.Occupation.Infrastructure.Organizations.EntityFramework.Configurations;

public class OrganizationConfiguration : IEntityTypeConfiguration<Organization> {
    public void Configure(EntityTypeBuilder<Organization> builder) {
        builder.ToTable("Organizations");
        builder.HasKey(b => b.Id);
        builder.OwnsOne(b => b.AuditInfo, nb => {
            nb.Property(c => c.CreatedByUserId).HasColumnName(WellKnownNames.AuditInfo.CreatedByUserId);
            nb.Property(c => c.ModifiedByUserId).HasColumnName(WellKnownNames.AuditInfo.ModifiedByUserId);
            nb.Property(c => c.CreatedAtUtcDateTime).HasColumnName(WellKnownNames.AuditInfo.CreatedAtUtcDateTime);
            nb.Property(c => c.ModifiedAtUtcDateTime).HasColumnName(WellKnownNames.AuditInfo.ModifiedAtUtcDateTime);
        });
        builder.OwnsOne(b => b.SoftDeleteInfo, nb => {
            nb.Property(c => c.IsDeleted).HasColumnName(WellKnownNames.SoftDeleteInfo.IsDeleted);
            nb.Property(c => c.DeletedAtUtcDateTime).HasColumnName(WellKnownNames.SoftDeleteInfo.DeletedAtUtcDateTime);
            nb.Property(c => c.DeletedByUserId).HasColumnName(WellKnownNames.SoftDeleteInfo.DeletedByUserId);
        });

        builder.HasKey(c => c.Id);
        builder.Property(c => c.Id)
            .ValueGeneratedOnAdd(); // Configure auto-increment behavior

        builder.Property(c => c.Title).IsRequired().HasMaxLength(200);
        builder.Property(c => c.IsViewable);
        builder.Property(c => c.IsApproved);

        builder.HasMany(e => e.Department)
            .WithOne(p => p.Organization)
            .HasForeignKey(p => p.OrganizationId)
            .IsRequired();
    }
}