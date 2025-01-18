namespace LearningManagement.Aquamation.Infrastructure;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class CompanyConfiguration : IEntityTypeConfiguration<Occupation.Domain.Company.Models.Company> {
    public void Configure(EntityTypeBuilder<Occupation.Domain.Company.Models.Company> builder) {
        builder.HasKey(c => c.Id);
        builder.Property(c => c.Id)
            .ValueGeneratedOnAdd(); // Configure auto-increment behavior

        builder.Property(c => c.Title).IsRequired().HasMaxLength(200);
        builder.Property(c => c.IsViewable);
        builder.Property(c => c.IsApproved);
        builder.HasOne(c => c.Type)
            .WithMany()
            .HasForeignKey(c => c.TypeId);

        builder.HasMany(c => c.Department)
            .WithOne(d => d.Company)
            .HasForeignKey(d => d.CompanyId);
    }
}