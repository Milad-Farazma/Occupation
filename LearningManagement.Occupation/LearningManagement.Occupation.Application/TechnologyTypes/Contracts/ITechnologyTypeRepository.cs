using LearningManagement.Occupation.Application.TechnologyTypes.Dtos.Get;
using LearningManagement.Occupation.Domain.TechnologyTypes;

namespace LearningManagement.Occupation.Application.TechnologyTypes.Contracts;

public interface ITechnologyTypeRepository {
    Task<PaginatedResult<TechnologyType>> GetAllAsync(bool asNoTracking, PaginationRequest request, TechnologyTypeSearchRequest? searchRequest,
        bool loadRelations, CancellationToken cancellationToken = default);

    Task<TechnologyType?> GetByIdAsync(Guid id, bool asNoTracking, bool loadRelations, CancellationToken cancellationToken = default);
    void Add(TechnologyType entity);
    void Update(TechnologyType entity);
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}