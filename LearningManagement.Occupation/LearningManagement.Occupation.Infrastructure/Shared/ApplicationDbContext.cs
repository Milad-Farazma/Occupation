using Framework.Data.SoftDelete;
using LearningManagement.Occupation.Domain.Abilities;
using LearningManagement.Occupation.Domain.AbilityTypes;
using LearningManagement.Occupation.Domain.Departments;
using LearningManagement.Occupation.Domain.EducationDegrees;
using LearningManagement.Occupation.Domain.EducationFields;
using LearningManagement.Occupation.Domain.EducationFieldSpecializations;
using LearningManagement.Occupation.Domain.Industries;
using LearningManagement.Occupation.Domain.Interests;
using LearningManagement.Occupation.Domain.InterestTypes;
using LearningManagement.Occupation.Domain.JobActivities;
using LearningManagement.Occupation.Domain.JobClassifications;
using LearningManagement.Occupation.Domain.JobOutLooks;
using LearningManagement.Occupation.Domain.JobPositions;
using LearningManagement.Occupation.Domain.Knowledges;
using LearningManagement.Occupation.Domain.KnowledgeTypes;
using LearningManagement.Occupation.Domain.Occupations;
using LearningManagement.Occupation.Domain.OccupationSimilarities;
using LearningManagement.Occupation.Domain.Organizations.Models;
using LearningManagement.Occupation.Domain.OrganizationTypes;
using LearningManagement.Occupation.Domain.Personalities;
using LearningManagement.Occupation.Domain.SeniorityLevels;
using LearningManagement.Occupation.Domain.Skills;
using LearningManagement.Occupation.Domain.SkillTypes;
using LearningManagement.Occupation.Domain.Technologys;
using LearningManagement.Occupation.Domain.TechnologyTypes;

namespace LearningManagement.Occupation.Infrastructure.Shared;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options) {
    public DbSet<Ability> Abilities { get; set; }
    public DbSet<AbilityType> AbilityTypes { get; set; }
    public DbSet<Department> Departments { get; set; }
    public DbSet<EducationDegree> EducationDegrees { get; set; }
    public DbSet<EducationField> EducationFields { get; set; }
    public DbSet<EducationFieldSpecialization> EducationFieldSpecializations { get; set; }
    public DbSet<Industry> Industries { get; set; }
    public DbSet<Interest> Interests { get; set; }
    public DbSet<InterestType> InterestTypes { get; set; }
    public DbSet<JobActivity> JobActivities { get; set; }
    public DbSet<JobClassification> JobClassifications { get; set; }
    public DbSet<JobOutLook> JobOutLooks { get; set; }
    public DbSet<JobPosition> JobPositions { get; set; }
    public DbSet<Knowledge> Knowledge { get; set; }
    public DbSet<KnowledgeType> KnowledgeTypes { get; set; }
    public DbSet<Organization> Organizations { get; set; }
    public DbSet<OrganizationType> OrganizationTypes { get; set; }
    public DbSet<Personality> Personalities { get; set; }
    public DbSet<SeniorityLevel> SeniorityLevels { get; set; }
    public DbSet<Skill> Skills { get; set; }
    public DbSet<SkillType> SkillTypes { get; set; }
    public DbSet<Technology> Technologies { get; set; }
    public DbSet<TechnologyType> TechnologyTypes { get; set; }
    public DbSet<OccupationSimilarity> OccupationSimilarities { get; set; }

    public DbSet<Domain.Occupations.Occupation> Occupations { get; set; }
    public DbSet<OccupationAbility> OccupationAbilities { get; set; }
    public DbSet<OccupationActivity> OccupationActivities { get; set; }
    public DbSet<OccupationKnowledge> OccupationKnowledge { get; set; }
    public DbSet<OccupationPersonality> OccupationPersonality { get; set; }
    public DbSet<OccupationSeniorityLevel> OccupationSeniorityLevel { get; set; }
    public DbSet<OccupationSkill> OccupationSkill { get; set; }
    public DbSet<OccupationTechnology> OccupationTechnologies { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder) {
        base.OnModelCreating(modelBuilder);

        modelBuilder.SetSoftDeleteQueryFilter();
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
    }
}