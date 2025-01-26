using LearningManagement.Occupation.Application.Organizations.Dto;
using LearningManagement.Occupation.Application.Organizations.Dto.Create;
using LearningManagement.Occupation.Application.Organizations.Dto.Get;
using LearningManagement.Occupation.Application.Organizations.Dto.Update;

namespace LearningManagement.Occupation.Application.Organizations.Contracts;

public interface IOrganizationService {
    Task<CreateOrganizationResponse> CreateAsync(CreateOrganizationRequest request, CancellationToken cancellationToken = default);

    Task<PaginatedResult<OrganizationDto>> GetAllAsync(PaginationRequest request, OrganizationSearchRequest? searchRequest,
        CancellationToken cancellationToken = default);

    Task<PaginatedResult<OrganizationDto>> GetAllWithRelationsAsync(PaginationRequest request, OrganizationSearchRequest? searchRequest,
        CancellationToken cancellationToken = default);

    Task<OrganizationDto> GetByIdAsync(long id, CancellationToken cancellationToken = default);
    Task<OrganizationDto> GetByIdWithRelationsAsync(long id, CancellationToken cancellationToken = default);
    Task UpdateAsync(long id, UpdateOrganizationRequest request, CancellationToken cancellationToken = default);
    Task DeleteAsync(long id, CancellationToken cancellationToken = default);
}