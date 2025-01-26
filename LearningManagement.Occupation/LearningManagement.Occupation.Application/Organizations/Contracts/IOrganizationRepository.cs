using Framework.Pagination;
using LearningManagement.Occupation.Application.Organizations.Dto.Get;
using LearningManagement.Occupation.Domain.Organizations.Models;

namespace LearningManagement.Occupation.Application.Organizations.Contracts;

public interface IOrganizationRepository {
    Task<PaginatedResult<Organization>> GetAllAsync(bool asNoTracking, PaginationRequest request, OrganizationSearchRequest? searchRequest,
        CancellationToken cancellationToken = default);

    Task<PaginatedResult<Organization>> GetAllWithRelationsAsync(bool asNoTracking, PaginationRequest request,
        OrganizationSearchRequest? searchRequest,
        CancellationToken cancellationToken = default);

    Task<Organization?> GetByIdAsync(long id, bool asNoTracking, CancellationToken cancellationToken = default);
    Task<Organization?> GetByIdWithRelationsAsync(long id, bool asNoTracking, CancellationToken cancellationToken = default);
    void Add(Organization entity);
    void Update(Organization entity);
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}