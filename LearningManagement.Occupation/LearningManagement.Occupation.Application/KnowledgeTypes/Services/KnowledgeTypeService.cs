using LearningManagement.Occupation.Application.KnowledgeTypes.Contracts;
using LearningManagement.Occupation.Application.KnowledgeTypes.Dtos;
using LearningManagement.Occupation.Application.KnowledgeTypes.Dtos.Create;
using LearningManagement.Occupation.Application.KnowledgeTypes.Dtos.Get;
using LearningManagement.Occupation.Domain.KnowledgeTypes;

namespace LearningManagement.Occupation.Application.KnowledgeTypes.Services;

public class KnowledgeTypeService(IKnowledgeTypeRepository repo, IUserService userService) : IKnowledgeTypeService {
    public async Task<CreateKnowledgeTypeResponse> CreateAsync(CreateKnowledgeTypeRequest request, CancellationToken cancellationToken = default) {
        var knowledgeType = request.Adapt<KnowledgeType>();
        repo.Add(knowledgeType);
        await repo.SaveChangesAsync(cancellationToken: cancellationToken);

        return knowledgeType.Adapt<CreateKnowledgeTypeResponse>();
    }

    public async Task<PaginatedResult<KnowledgeTypeDto>> GetAllAsync(PaginationRequest request,
        KnowledgeTypeSearchRequest? searchRequest, bool loadRelations,
        CancellationToken cancellationToken = default) => (await repo.GetAllAsync(false, request, searchRequest, loadRelations, cancellationToken))
        .Adapt<PaginatedResult<KnowledgeTypeDto>>();

    public async Task<KnowledgeTypeDto> GetByIdAsync(Guid id, bool loadRelations, CancellationToken cancellationToken = default) {
        var knowledgeType = await repo.GetByIdAsync(id, true, loadRelations, cancellationToken);
        if (knowledgeType is null) throw new NotFoundException(new NotFoundError(id, nameof(KnowledgeType)));
        return knowledgeType.Adapt<KnowledgeTypeDto>();
    }

    public async Task UpdateAsync(Guid id, UpdateKnowledgeTypeRequest request, CancellationToken cancellationToken = default) {
        var knowledgeType = await repo.GetByIdAsync(id, false, false, cancellationToken: cancellationToken);
        if (knowledgeType is null)
            throw new NotFoundException(new NotFoundError(id, nameof(KnowledgeType)));

        request.Adapt(knowledgeType);
        repo.Update(knowledgeType);

        await repo.SaveChangesAsync(cancellationToken: cancellationToken);
    }

    public async Task DeleteAsync(Guid id, CancellationToken cancellationToken = default) {
        var knowledgeType = await repo.GetByIdAsync(id, false, false, cancellationToken: cancellationToken);
        if (knowledgeType is null) throw new NotFoundException(new NotFoundError(id, nameof(KnowledgeType)));

        knowledgeType.SoftDeleteInfo.SetDeleteObject(userService.GetCurrentUserId());
        await repo.SaveChangesAsync(cancellationToken: cancellationToken);
    }
}