using LearningManagement.Occupation.Application.KnowledgeTypes.Dtos.Get;
using LearningManagement.Occupation.Domain.KnowledgeTypes;

namespace LearningManagement.Occupation.Application.KnowledgeTypes.Contracts;

public interface IKnowledgeTypeRepository {
    Task<PaginatedResult<KnowledgeType>> GetAllAsync(bool asNoTracking, PaginationRequest request, KnowledgeTypeSearchRequest? searchRequest,
        bool loadRelations, CancellationToken cancellationToken = default);

    Task<KnowledgeType?> GetByIdAsync(Guid id, bool asNoTracking, bool loadRelations, CancellationToken cancellationToken = default);
    void Add(KnowledgeType entity);
    void Update(KnowledgeType entity);
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}