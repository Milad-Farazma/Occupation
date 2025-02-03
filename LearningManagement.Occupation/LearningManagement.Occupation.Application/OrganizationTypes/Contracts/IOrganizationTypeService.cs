using LearningManagement.Occupation.Application.OrganizationTypes.Dtos;
using LearningManagement.Occupation.Application.OrganizationTypes.Dtos.Create;
using LearningManagement.Occupation.Application.OrganizationTypes.Dtos.Get;
using LearningManagement.Occupation.Application.OrganizationTypes.Dtos.Update;

namespace LearningManagement.Occupation.Application.OrganizationTypes.Contracts;

public interface IOrganizationTypeService {
    Task<CreateOrganizationTypeResponse> CreateAsync(CreateOrganizationTypeRequest request, CancellationToken cancellationToken = default);

    Task<PaginatedResult<OrganizationTypeDto>> GetAllAsync(PaginationRequest request, OrganizationTypeSearchRequest? searchRequest,
        bool loadRelations,
        CancellationToken cancellationToken = default);

    Task<OrganizationTypeDto> GetByIdAsync(Guid id, bool loadRelations, CancellationToken cancellationToken = default);
    Task UpdateAsync(Guid id, UpdateOrganizationTypeRequest request, CancellationToken cancellationToken = default);
    Task DeleteAsync(Guid id, CancellationToken cancellationToken = default);
}