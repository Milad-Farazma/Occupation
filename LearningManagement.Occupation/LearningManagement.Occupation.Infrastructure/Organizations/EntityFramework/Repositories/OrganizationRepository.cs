using LearningManagement.Occupation.Application.Organizations.Contracts;
using LearningManagement.Occupation.Domain.Organizations.Models;
using LearningManagement.Occupation.Infrastructure.Shared;

namespace LearningManagement.Occupation.Infrastructure.Organizations.EntityFramework.Repositories;

public class OrganizationRepository(ApplicationDbContext context) : EfGenericRepository<Organization>(context: context), IOrganizationRepository {
    public Task<List<Organization>> GetAllWithRelationsAsync(bool asNoTracking, CancellationToken cancellationToken = default) {
        return DbSet.Include(c => c.Department).ToListAsync(cancellationToken: cancellationToken);
    }
}