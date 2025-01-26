using LearningManagement.Occupation.Application.OrganizationTypes.Dtos.Get;
using LearningManagement.Occupation.Domain.OrganizationTypes;

namespace LearningManagement.Occupation.Application.OrganizationTypes.Contracts;

public interface IOrganizationTypeRepository {
    Task<PaginatedResult<OrganizationType>> GetAllAsync(bool asNoTracking, PaginationRequest request, OrganizationTypeSearchRequest? searchRequest,
        bool loadRelations, CancellationToken cancellationToken = default);

    Task<OrganizationType?> GetByIdAsync(long id, bool loadRelations, bool asNoTracking, CancellationToken cancellationToken = default);
    void Add(OrganizationType entity);
    void Update(OrganizationType entity);
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}