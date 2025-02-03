using LearningManagement.Occupation.Application.InterestTypes.Dtos.Get;
using LearningManagement.Occupation.Domain.InterestTypes;

namespace LearningManagement.Occupation.Application.InterestTypes.Contracts;

public interface IInterestTypeRepository {
    Task<PaginatedResult<InterestType>> GetAllAsync(bool asNoTracking, PaginationRequest request, InterestTypeSearchRequest? searchRequest,
        bool loadRelations, CancellationToken cancellationToken = default);

    Task<InterestType?> GetByIdAsync(Guid id, bool asNoTracking, bool loadRelations, CancellationToken cancellationToken = default);
    void Add(InterestType entity);
    void Update(InterestType entity);
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}