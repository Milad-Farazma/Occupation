using LearningManagement.Occupation.Application.Interests.Dtos.Get;
using LearningManagement.Occupation.Domain.Interests;

namespace LearningManagement.Occupation.Application.Interests.Contracts;

public interface IInterestRepository {
    Task<PaginatedResult<Interest>> GetAllAsync(bool asNoTracking, PaginationRequest request, InterestSearchRequest? searchRequest,
        bool loadRelations, CancellationToken cancellationToken = default);

    Task<Interest?> GetByIdAsync(Guid id, bool asNoTracking, bool loadRelations, CancellationToken cancellationToken = default);
    void Add(Interest entity);
    void Update(Interest entity);
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}