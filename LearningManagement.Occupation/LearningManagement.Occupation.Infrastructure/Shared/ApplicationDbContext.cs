using Framework.Data.SoftDelete;
using LearningManagement.Occupation.Domain.Organizations.Models;

namespace LearningManagement.Occupation.Infrastructure.Shared;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options) {
    public DbSet<Organization> Organizations { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder) {
        base.OnModelCreating(modelBuilder);
        
        modelBuilder.SetSoftDeleteQueryFilter();
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
    }
}