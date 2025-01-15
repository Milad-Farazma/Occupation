using Microsoft.EntityFrameworkCore;

namespace LMS.Aquamation.Infrastructure;

public class AppDbContext(DbContextOptions options) : DbContext(options) {

    protected override void OnModelCreating(ModelBuilder modelBuilder) {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
    }
}