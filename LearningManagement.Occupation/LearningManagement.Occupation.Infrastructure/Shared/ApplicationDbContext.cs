using LearningManagement.Occupation.Domain.Companies.Models;

namespace LearningManagement.Occupation.Infrastructure.Shared;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options) {
    public DbSet<Company> Companies { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder) {
        base.OnModelCreating(modelBuilder);

        //TODO: Add
        // modelBuilder.SetSoftDeleteQueryFilter();
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
    }
}