using Framework.Pagination;
using LearningManagement.Occupation.Application.Shared;
using LearningManagement.Occupation.Domain.Organizations.Models;

namespace LearningManagement.Occupation.Application.Organizations.Contracts;

public interface IOrganizationRepository : IGenericRepository<Organization> {
    Task<PaginatedResult<Organization>> GetAllWithRelationsAsync(bool asNoTracking, PaginationRequest request,
        CancellationToken cancellationToken = default);
}