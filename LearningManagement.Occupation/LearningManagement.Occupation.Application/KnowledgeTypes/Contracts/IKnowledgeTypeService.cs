using LearningManagement.Occupation.Application.KnowledgeTypes.Dtos;
using LearningManagement.Occupation.Application.KnowledgeTypes.Dtos.Create;
using LearningManagement.Occupation.Application.KnowledgeTypes.Dtos.Get;

namespace LearningManagement.Occupation.Application.KnowledgeTypes.Contracts;

public interface IKnowledgeTypeService {
    Task<CreateKnowledgeTypeResponse> CreateAsync(CreateKnowledgeTypeRequest request, CancellationToken cancellationToken = default);

    Task<PaginatedResult<KnowledgeTypeDto>> GetAllAsync(PaginationRequest request, KnowledgeTypeSearchRequest? searchRequest, bool loadRelations,
        CancellationToken cancellationToken = default);

    Task<KnowledgeTypeDto> GetByIdAsync(long id, bool loadRelations, CancellationToken cancellationToken = default);
    Task UpdateAsync(long id, UpdateKnowledgeTypeRequest request, CancellationToken cancellationToken = default);
    Task DeleteAsync(long id, CancellationToken cancellationToken = default);
}