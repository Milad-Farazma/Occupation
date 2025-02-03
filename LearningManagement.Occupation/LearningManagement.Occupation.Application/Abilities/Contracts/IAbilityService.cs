using LearningManagement.Occupation.Application.Abilities.Dtos;
using LearningManagement.Occupation.Application.Abilities.Dtos.Create;
using LearningManagement.Occupation.Application.Abilities.Dtos.Get;

namespace LearningManagement.Occupation.Application.Abilities.Contracts;

public interface IAbilityService {
    Task<CreateAbilityResponse> CreateAsync(CreateAbilityRequest request, CancellationToken cancellationToken = default);

    Task<PaginatedResult<AbilityDto>> GetAllAsync(PaginationRequest request, AbilitySearchRequest? searchRequest, bool loadRelations,
        CancellationToken cancellationToken = default);

    Task<AbilityDto> GetByIdAsync(Guid id, bool loadRelations, CancellationToken cancellationToken = default);
    Task UpdateAsync(Guid id, UpdateAbilityRequest request, CancellationToken cancellationToken = default);
    Task DeleteAsync(Guid id, CancellationToken cancellationToken = default);
}