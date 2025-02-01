using LearningManagement.Occupation.Application.SkillTypes.Contracts;
using LearningManagement.Occupation.Application.SkillTypes.Dtos;
using LearningManagement.Occupation.Domain.SkillTypes;

namespace LearningManagement.Occupation.Application.SkillTypes.Services;

public class SkillTypeService(ISkillTypeRepository repo, IUserService userService) : ISkillTypeService {
    public async Task<CreateSkillTypeResponse> CreateAsync(CreateSkillTypeRequest request, CancellationToken cancellationToken = default) {
        var skillType = request.Adapt<SkillType>();
        repo.Add(skillType);
        await repo.SaveChangesAsync(cancellationToken: cancellationToken);

        return skillType.Adapt<CreateSkillTypeResponse>();
    }

    public async Task<PaginatedResult<SkillTypeDto>> GetAllAsync(PaginationRequest request,
        SkillTypeSearchRequest? searchRequest, bool loadRelations,
        CancellationToken cancellationToken = default) => (await repo.GetAllAsync(false, request, searchRequest, loadRelations, cancellationToken))
        .Adapt<PaginatedResult<SkillTypeDto>>();

    public async Task<SkillTypeDto> GetByIdAsync(long id, bool loadRelations, CancellationToken cancellationToken = default) {
        var skillType = await repo.GetByIdAsync(id, true, loadRelations, cancellationToken);
        if (skillType is null) throw new NotFoundException(new NotFoundError(id, nameof(SkillType)));
        return skillType.Adapt<SkillTypeDto>();
    }

    public async Task UpdateAsync(long id, UpdateSkillTypeRequest request, CancellationToken cancellationToken = default) {
        var skillType = await repo.GetByIdAsync(id, false, false, cancellationToken: cancellationToken);
        if (skillType is null)
            throw new NotFoundException(new NotFoundError(id, nameof(SkillType)));

        request.Adapt(skillType);
        repo.Update(skillType);

        await repo.SaveChangesAsync(cancellationToken: cancellationToken);
    }

    public async Task DeleteAsync(long id, CancellationToken cancellationToken = default) {
        var skillType = await repo.GetByIdAsync(id, false, false, cancellationToken: cancellationToken);
        if (skillType is null) throw new NotFoundException(new NotFoundError(id, nameof(SkillType)));

        skillType.SoftDeleteInfo.SetDeleteObject(userService.GetCurrentUserId());
        await repo.SaveChangesAsync(cancellationToken: cancellationToken);
    }
}