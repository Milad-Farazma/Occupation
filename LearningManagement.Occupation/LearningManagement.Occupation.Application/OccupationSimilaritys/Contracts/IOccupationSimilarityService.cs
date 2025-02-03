using LearningManagement.Occupation.Application.OccupationSimilaritys.Dtos;
using LearningManagement.Occupation.Application.OccupationSimilaritys.Dtos.Create;
using LearningManagement.Occupation.Application.OccupationSimilaritys.Dtos.Get;

namespace LearningManagement.Occupation.Application.OccupationSimilaritys.Contracts;

public interface IOccupationSimilarityService {
    Task<CreateOccupationSimilarityResponse> CreateAsync(CreateOccupationSimilarityRequest request, CancellationToken cancellationToken = default);

    Task<PaginatedResult<OccupationSimilarityDto>> GetAllAsync(PaginationRequest request, OccupationSimilaritySearchRequest? searchRequest,
        bool loadRelations, CancellationToken cancellationToken = default);

    Task<OccupationSimilarityDto> GetByIdAsync(long id, bool loadRelations, CancellationToken cancellationToken = default);
    Task UpdateAsync(long id, UpdateOccupationSimilarityRequest request, CancellationToken cancellationToken = default);
    Task DeleteAsync(long id, CancellationToken cancellationToken = default);
}