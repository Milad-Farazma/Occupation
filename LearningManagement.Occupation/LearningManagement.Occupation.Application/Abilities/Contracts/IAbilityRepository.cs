using LearningManagement.Occupation.Application.Abilities.Dtos.Get;
using LearningManagement.Occupation.Domain.Abilities;

namespace LearningManagement.Occupation.Application.Abilities.Contracts;

public interface IAbilityRepository {
    Task<PaginatedResult<Ability>> GetAllAsync(bool asNoTracking, PaginationRequest request, AbilitySearchRequest? searchRequest, bool loadRelations,
        CancellationToken cancellationToken = default);

    Task<Ability?> GetByIdAsync(Guid id, bool asNoTracking, bool loadRelations, CancellationToken cancellationToken = default);
    void Add(Ability entity);
    void Update(Ability entity);
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}