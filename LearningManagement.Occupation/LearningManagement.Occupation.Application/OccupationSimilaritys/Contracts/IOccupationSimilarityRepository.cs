using LearningManagement.Occupation.Application.OccupationSimilaritys.Dtos.Get;
using LearningManagement.Occupation.Domain.OccupationSimilaritys;

namespace LearningManagement.Occupation.Application.OccupationSimilaritys.Contracts;

public interface IOccupationSimilarityRepository {
    Task<PaginatedResult<OccupationSimilarity>> GetAllAsync(bool asNoTracking, PaginationRequest request,
        OccupationSimilaritySearchRequest? searchRequest, bool loadRelations, CancellationToken cancellationToken = default);

    Task<OccupationSimilarity?> GetByIdAsync(long id, bool asNoTracking, bool loadRelations, CancellationToken cancellationToken = default);
    void Add(OccupationSimilarity entity);
    void Update(OccupationSimilarity entity);
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}