using Framework.Deletable;
using LearningManagement.Occupation.Domain.Companies.Models;
using Microsoft.EntityFrameworkCore;

namespace LearningManagement.Occupation.Infrastructure;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options) {
    public DbSet<Company> Companies { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder) {
        base.OnModelCreating(modelBuilder);

        modelBuilder.SetSoftDeleteQueryFilter();
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
    }
}