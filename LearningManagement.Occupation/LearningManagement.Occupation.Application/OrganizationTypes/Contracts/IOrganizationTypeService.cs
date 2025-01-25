using Framework.Pagination;
using LearningManagement.Occupation.Application.OrganizationTypes.Dtos;

namespace LearningManagement.Occupation.Application.OrganizationTypes.Contracts;

public interface IOrganizationTypeService {
    Task<OrganizationTypeDto> CreateAsync(CreateOrganizationTypeRequest request, CancellationToken cancellationToken = default);
    Task<PaginatedResult<OrganizationTypeDto>> GetAllAsync(PaginationRequest request, OrganizationTypeSearchRequest? searchRequest,
        CancellationToken cancellationToken = default);
    Task<PaginatedResult<OrganizationTypeDto>> GetAllWithRelationsAsync(PaginationRequest request, OrganizationTypeSearchRequest? searchRequest,
        CancellationToken cancellationToken = default);
    Task<OrganizationTypeDto> GetByIdAsync(long id, CancellationToken cancellationToken = default);
    Task<OrganizationTypeDto> GetByIdWithRelationsAsync(long id, CancellationToken cancellationToken = default);
    Task UpdateAsync(long id, UpdateOrganizationTypeRequest request, CancellationToken cancellationToken = default);
    Task DeleteAsync(long id, CancellationToken cancellationToken = default);
}