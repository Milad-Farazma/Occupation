using LearningManagement.Occupation.Application.Knowledges.Dtos;
using LearningManagement.Occupation.Application.Knowledges.Dtos.Create;
using LearningManagement.Occupation.Application.Knowledges.Dtos.Get;

namespace LearningManagement.Occupation.Application.Knowledges.Contracts;

public interface IKnowledgeService {
    Task<CreateKnowledgeResponse> CreateAsync(CreateKnowledgeRequest request, CancellationToken cancellationToken = default);

    Task<PaginatedResult<KnowledgeDto>> GetAllAsync(PaginationRequest request, KnowledgeSearchRequest? searchRequest, bool loadRelations,
        CancellationToken cancellationToken = default);

    Task<KnowledgeDto> GetByIdAsync(Guid id, bool loadRelations, CancellationToken cancellationToken = default);
    Task UpdateAsync(Guid id, UpdateKnowledgeRequest request, CancellationToken cancellationToken = default);
    Task DeleteAsync(Guid id, CancellationToken cancellationToken = default);
}