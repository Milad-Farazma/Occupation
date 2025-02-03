using LearningManagement.Occupation.Application.Occupations.Dtos;
using LearningManagement.Occupation.Application.Occupations.Dtos.Create;
using LearningManagement.Occupation.Application.Occupations.Dtos.Get;

namespace LearningManagement.Occupation.Application.Occupations.Contracts;

public interface IOccupationService {
    Task<CreateOccupationResponse> CreateAsync(CreateOccupationRequest request, CancellationToken cancellationToken = default);

    Task<PaginatedResult<OccupationDto>> GetAllAsync(PaginationRequest request, OccupationSearchRequest? searchRequest, bool loadRelations,
        CancellationToken cancellationToken = default);

    Task<OccupationDto> GetByIdAsync(Guid id, bool loadRelations, CancellationToken cancellationToken = default);
    Task UpdateAsync(Guid id, UpdateOccupationRequest request, CancellationToken cancellationToken = default);
    Task DeleteAsync(Guid id, CancellationToken cancellationToken = default);
}