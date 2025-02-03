using LearningManagement.Occupation.Application.Knowledges.Contracts;
using LearningManagement.Occupation.Application.Knowledges.Dtos;
using LearningManagement.Occupation.Application.Knowledges.Dtos.Create;
using LearningManagement.Occupation.Application.Knowledges.Dtos.Get;
using LearningManagement.Occupation.Domain.Knowledges;

namespace LearningManagement.Occupation.Application.Knowledges.Services;

public class KnowledgeService(IKnowledgeRepository repo, IUserService userService) : IKnowledgeService {
    public async Task<CreateKnowledgeResponse> CreateAsync(CreateKnowledgeRequest request, CancellationToken cancellationToken = default) {
        var knowledge = request.Adapt<Knowledge>();
        repo.Add(knowledge);
        await repo.SaveChangesAsync(cancellationToken: cancellationToken);

        return knowledge.Adapt<CreateKnowledgeResponse>();
    }

    public async Task<PaginatedResult<KnowledgeDto>> GetAllAsync(PaginationRequest request,
        KnowledgeSearchRequest? searchRequest, bool loadRelations,
        CancellationToken cancellationToken = default) => (await repo.GetAllAsync(false, request, searchRequest, loadRelations, cancellationToken))
        .Adapt<PaginatedResult<KnowledgeDto>>();

    public async Task<KnowledgeDto> GetByIdAsync(Guid id, bool loadRelations, CancellationToken cancellationToken = default) {
        var knowledge = await repo.GetByIdAsync(id, true, loadRelations, cancellationToken);
        if (knowledge is null) throw new NotFoundException(new NotFoundError(id, nameof(Knowledge)));
        return knowledge.Adapt<KnowledgeDto>();
    }

    public async Task UpdateAsync(Guid id, UpdateKnowledgeRequest request, CancellationToken cancellationToken = default) {
        var knowledge = await repo.GetByIdAsync(id, false, false, cancellationToken: cancellationToken);
        if (knowledge is null)
            throw new NotFoundException(new NotFoundError(id, nameof(Knowledge)));

        request.Adapt(knowledge);
        repo.Update(knowledge);

        await repo.SaveChangesAsync(cancellationToken: cancellationToken);
    }

    public async Task DeleteAsync(Guid id, CancellationToken cancellationToken = default) {
        var knowledge = await repo.GetByIdAsync(id, false, false, cancellationToken: cancellationToken);
        if (knowledge is null) throw new NotFoundException(new NotFoundError(id, nameof(Knowledge)));

        knowledge.SoftDeleteInfo.SetDeleteObject(userService.GetCurrentUserId());
        await repo.SaveChangesAsync(cancellationToken: cancellationToken);
    }
}