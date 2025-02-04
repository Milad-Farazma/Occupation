using LearningManagement.Occupation.Application.OccupationSimilarities.Dtos.Get;
using LearningManagement.Occupation.Domain.OccupationSimilarities;

namespace LearningManagement.Occupation.Application.OccupationSimilarities.Contracts;

public interface IOccupationSimilarityRepository {
    Task<PaginatedResult<OccupationSimilarity>> GetAllAsync(bool asNoTracking, PaginationRequest request,
        OccupationSimilaritySearchRequest? searchRequest, bool loadRelations, CancellationToken cancellationToken = default);

    Task<OccupationSimilarity?> GetByIdAsync(Guid id, bool asNoTracking, bool loadRelations, CancellationToken cancellationToken = default);
    void Add(OccupationSimilarity entity);
    void Update(OccupationSimilarity entity);
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}