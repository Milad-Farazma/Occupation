using LearningManagement.Occupation.Application.Aliases.Dtos.Get;
using LearningManagement.Occupation.Domain.Aliases;

namespace LearningManagement.Occupation.Application.Aliases.Contracts;

public interface IAliasRepository {
    Task<PaginatedResult<Alias>> GetAllAsync(bool asNoTracking, PaginationRequest request, AliasSearchRequest? searchRequest, bool loadRelations,
        CancellationToken cancellationToken = default);

    Task<Alias?> GetByIdAsync(Guid id, bool asNoTracking, bool loadRelations, CancellationToken cancellationToken = default);
    void Add(Alias entity);
    void Update(Alias entity);
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}