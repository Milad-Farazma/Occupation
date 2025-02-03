using LearningManagement.Occupation.Application.OccupationSimilarities.Dtos;
using LearningManagement.Occupation.Application.OccupationSimilarities.Dtos.Create;
using LearningManagement.Occupation.Application.OccupationSimilarities.Dtos.Get;

namespace LearningManagement.Occupation.Application.OccupationSimilarities.Contracts;

public interface IOccupationSimilarityService {
    Task<CreateOccupationSimilarityResponse> CreateAsync(CreateOccupationSimilarityRequest request, CancellationToken cancellationToken = default);

    Task<PaginatedResult<OccupationSimilarityDto>> GetAllAsync(PaginationRequest request, OccupationSimilaritySearchRequest? searchRequest,
        bool loadRelations, CancellationToken cancellationToken = default);

    Task<OccupationSimilarityDto> GetByIdAsync(Guid id, bool loadRelations, CancellationToken cancellationToken = default);
    Task UpdateAsync(Guid id, UpdateOccupationSimilarityRequest request, CancellationToken cancellationToken = default);
    Task DeleteAsync(Guid id, CancellationToken cancellationToken = default);
}