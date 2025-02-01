using LearningManagement.Occupation.Application.AbilityTypes.Dtos.Get;
using LearningManagement.Occupation.Domain.AbilityTypes;

namespace LearningManagement.Occupation.Application.AbilityTypes.Contracts;

public interface IAbilityTypeRepository {
    Task<PaginatedResult<AbilityType>> GetAllAsync(bool asNoTracking, PaginationRequest request, AbilityTypeSearchRequest? searchRequest,
        bool loadRelations, CancellationToken cancellationToken = default);

    Task<AbilityType?> GetByIdAsync(long id, bool asNoTracking, bool loadRelations, CancellationToken cancellationToken = default);
    void Add(AbilityType entity);
    void Update(AbilityType entity);
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}