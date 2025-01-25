using Framework.Pagination;
using LearningManagement.Occupation.Application.OrganizationTypes.Dtos;
using LearningManagement.Occupation.Domain.OrganizationTypes;

namespace LearningManagement.Occupation.Application.OrganizationTypes.Contracts;

public interface IOrganizationTypeRepository {
    Task<PaginatedResult<OrganizationType>> GetAllAsync(bool asNoTracking, PaginationRequest request, OrganizationTypeSearchRequest? searchRequest,
        CancellationToken cancellationToken = default);
    Task<PaginatedResult<OrganizationType>> GetAllWithRelationsAsync(bool asNoTracking, PaginationRequest request, OrganizationTypeSearchRequest? searchRequest,
        CancellationToken cancellationToken = default);
    Task<OrganizationType?> GetByIdAsync(long id, bool asNoTracking, CancellationToken cancellationToken = default);
    Task<OrganizationType?> GetByIdWithRelationsAsync(long id, bool asNoTracking, CancellationToken cancellationToken = default);
    void Add(OrganizationType entity);
    void Update(OrganizationType entity);
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}