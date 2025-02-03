using LearningManagement.Occupation.Application.Occupations.Dtos.Get;

namespace LearningManagement.Occupation.Application.Occupations.Contracts;

public interface IOccupationRepository {
    Task<PaginatedResult<Domain.Occupations.Occupation>> GetAllAsync(bool asNoTracking, PaginationRequest request,
        OccupationSearchRequest? searchRequest, bool loadRelations, CancellationToken cancellationToken = default);

    Task<Domain.Occupations.Occupation?> GetByIdAsync(Guid id, bool asNoTracking, bool loadRelations, CancellationToken cancellationToken = default);
    void Add(Domain.Occupations.Occupation entity);
    void Update(Domain.Occupations.Occupation entity);
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}