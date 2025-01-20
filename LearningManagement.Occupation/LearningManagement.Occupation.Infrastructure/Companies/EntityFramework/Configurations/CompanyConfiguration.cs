using LearningManagement.Occupation.Domain.Companies.Models;
using LearningManagement.Occupation.Domain.Shared;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LearningManagement.Occupation.Infrastructure.Companies.EntityFramework.Configurations;

public class CompanyConfiguration : IEntityTypeConfiguration<Company> {
    public void Configure(EntityTypeBuilder<Company> builder) {
        builder.ToTable("Companies");
        builder.HasKey(b => b.Id);
        builder.HasQueryFilter(b => !b.SoftDeleteInfo.IsDeleted);
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
            .WithOne(p => p.Company)
            .HasForeignKey(p => p.CompanyId)
            .IsRequired();
    }
}