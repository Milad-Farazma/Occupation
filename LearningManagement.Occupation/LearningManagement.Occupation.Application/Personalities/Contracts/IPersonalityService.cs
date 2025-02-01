using LearningManagement.Occupation.Application.Personalities.Dtos;

namespace LearningManagement.Occupation.Application.Personalities.Contracts;

public interface IPersonalityService {
    Task<CreatePersonalityResponse> CreateAsync(CreatePersonalityRequest request, CancellationToken cancellationToken = default);

    Task<PaginatedResult<PersonalityDto>> GetAllAsync(PaginationRequest request, PersonalitySearchRequest? searchRequest, bool loadRelations,
        CancellationToken cancellationToken = default);

    Task<PersonalityDto> GetByIdAsync(long id, bool loadRelations, CancellationToken cancellationToken = default);
    Task UpdateAsync(long id, UpdatePersonalityRequest request, CancellationToken cancellationToken = default);
    Task DeleteAsync(long id, CancellationToken cancellationToken = default);
}