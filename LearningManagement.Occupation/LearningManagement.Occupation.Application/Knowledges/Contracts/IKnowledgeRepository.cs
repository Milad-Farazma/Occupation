using LearningManagement.Occupation.Application.Knowledges.Dtos.Get;
using LearningManagement.Occupation.Domain.Knowledges;

namespace LearningManagement.Occupation.Application.Knowledges.Contracts;

public interface IKnowledgeRepository {
    Task<PaginatedResult<Knowledge>> GetAllAsync(bool asNoTracking, PaginationRequest request, KnowledgeSearchRequest? searchRequest,
        bool loadRelations, CancellationToken cancellationToken = default);

    Task<Knowledge?> GetByIdAsync(long id, bool asNoTracking, bool loadRelations, CancellationToken cancellationToken = default);
    void Add(Knowledge entity);
    void Update(Knowledge entity);
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}