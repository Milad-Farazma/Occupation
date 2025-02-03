using LearningManagement.Occupation.Application.Organizations.Dto;
using LearningManagement.Occupation.Application.Organizations.Dto.Create;
using LearningManagement.Occupation.Application.Organizations.Dto.Get;
using LearningManagement.Occupation.Application.Organizations.Dto.Update;

namespace LearningManagement.Occupation.Application.Organizations.Contracts;

public interface IOrganizationService {
    Task<CreateOrganizationResponse> CreateAsync(CreateOrganizationRequest request, CancellationToken cancellationToken = default);

    Task<PaginatedResult<OrganizationDto>> GetAllAsync(PaginationRequest request, OrganizationSearchRequest? searchRequest, bool loadRelations,
        CancellationToken cancellationToken = default);

    Task<OrganizationDto> GetByIdAsync(Guid id, bool loadRelations, CancellationToken cancellationToken = default);
    Task UpdateAsync(Guid id, UpdateOrganizationRequest request, CancellationToken cancellationToken = default);
    Task DeleteAsync(Guid id, CancellationToken cancellationToken = default);
}