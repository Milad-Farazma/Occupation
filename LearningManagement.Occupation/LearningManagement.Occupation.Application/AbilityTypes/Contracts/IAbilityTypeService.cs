using LearningManagement.Occupation.Application.AbilityTypes.Dtos;
using LearningManagement.Occupation.Application.AbilityTypes.Dtos.Create;
using LearningManagement.Occupation.Application.AbilityTypes.Dtos.Get;

namespace LearningManagement.Occupation.Application.AbilityTypes.Contracts;

public interface IAbilityTypeService {
    Task<CreateAbilityTypeResponse> CreateAsync(CreateAbilityTypeRequest request, CancellationToken cancellationToken = default);

    Task<PaginatedResult<AbilityTypeDto>> GetAllAsync(PaginationRequest request, AbilityTypeSearchRequest? searchRequest, bool loadRelations,
        CancellationToken cancellationToken = default);

    Task<AbilityTypeDto> GetByIdAsync(long id, bool loadRelations, CancellationToken cancellationToken = default);
    Task UpdateAsync(long id, UpdateAbilityTypeRequest request, CancellationToken cancellationToken = default);
    Task DeleteAsync(long id, CancellationToken cancellationToken = default);
}