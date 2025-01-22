using Framework.Pagination;
using LearningManagement.Occupation.Application.Organizations.Contracts;
using LearningManagement.Occupation.Domain.Organizations.Models;
using LearningManagement.Occupation.Infrastructure.Shared;

namespace LearningManagement.Occupation.Infrastructure.Organizations.EntityFramework.Repositories;

public class OrganizationRepository(ApplicationDbContext context) : EfGenericRepository<Organization>(context: context), IOrganizationRepository {
    public Task<PaginatedResult<Organization>> GetAllWithRelationsAsync(bool asNoTracking, PaginationRequest request,
        CancellationToken cancellationToken = default) {
        return GetDbSet(asNoTracking)
            .Include(c => c.Department)
            .OrderBy(e => e.Id)
            .ApplyPagination(request, cancellationToken);
    }
}