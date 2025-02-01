using Framework.Data.SoftDelete;
using LearningManagement.Occupation.Domain.Abilities;
using LearningManagement.Occupation.Domain.AbilityTypes;
using LearningManagement.Occupation.Domain.Departments;
using LearningManagement.Occupation.Domain.EducationDegrees;
using LearningManagement.Occupation.Domain.EducationFields;
using LearningManagement.Occupation.Domain.Industries;
using LearningManagement.Occupation.Domain.Interests;
using LearningManagement.Occupation.Domain.InterestTypes;
using LearningManagement.Occupation.Domain.JobActivities;
using LearningManagement.Occupation.Domain.Organizations.Models;
using LearningManagement.Occupation.Domain.OrganizationTypes;
using LearningManagement.Occupation.Domain.Personalities;
using LearningManagement.Occupation.Domain.SkillTypes;

namespace LearningManagement.Occupation.Infrastructure.Shared;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options) {
    public DbSet<Ability> Abilities { get; set; }
    public DbSet<AbilityType> AbilityTypes { get; set; }
    public DbSet<Department> Departments { get; set; }
    public DbSet<EducationDegree> EducationDegrees { get; set; }
    public DbSet<EducationField> EducationFields { get; set; }
    public DbSet<Industry> Industries { get; set; }
    public DbSet<Interest> Interests { get; set; }
    public DbSet<InterestType> InterestTypes { get; set; }
    public DbSet<JobActivity> JobActivities { get; set; }
    public DbSet<Organization> Organizations { get; set; }
    public DbSet<OrganizationType> OrganizationTypes { get; set; }
    public DbSet<Personality> Personalities { get; set; }
    public DbSet<SkillType> SkillTypes { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder) {
        base.OnModelCreating(modelBuilder);

        modelBuilder.SetSoftDeleteQueryFilter();
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
    }
}