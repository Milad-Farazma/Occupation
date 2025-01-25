using Framework.Pagination;
using LearningManagement.Occupation.Application.Organizations.Dto;

namespace LearningManagement.Occupation.Application.Organizations.Contracts;

public interface IOrganizationService {
    Task<OrganizationDto> CreateAsync(CreateOrganizationRequest request, CancellationToken cancellationToken = default);

    Task<PaginatedResult<OrganizationDto>> GetAllAsync(PaginationRequest request, OrganizationSearchRequest? searchRequest,
        CancellationToken cancellationToken = default);

    Task<OrganizationDto> GetByIdAsync(long id, CancellationToken cancellationToken = default);
    Task<OrganizationDto> GetByIdWithRelationsAsync(long id, CancellationToken cancellationToken = default);
    Task UpdateAsync(long id, UpdateOrganizationRequest request, CancellationToken cancellationToken = default);
    Task DeleteAsync(long id, CancellationToken cancellationToken = default);
}