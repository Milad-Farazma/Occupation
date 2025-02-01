using LearningManagement.Occupation.Application.Skills.Contracts;
using LearningManagement.Occupation.Application.Skills.Dtos;
using LearningManagement.Occupation.Domain.Skills;

namespace LearningManagement.Occupation.Application.Skills.Services;

public class SkillService(ISkillRepository repo, IUserService userService) : ISkillService {
    public async Task<CreateSkillResponse> CreateAsync(CreateSkillRequest request, CancellationToken cancellationToken = default) {
        var skill = request.Adapt<Skill>();
        repo.Add(skill);
        await repo.SaveChangesAsync(cancellationToken: cancellationToken);

        return skill.Adapt<CreateSkillResponse>();
    }

    public async Task<PaginatedResult<SkillDto>> GetAllAsync(PaginationRequest request,
        SkillSearchRequest? searchRequest, bool loadRelations,
        CancellationToken cancellationToken = default) => (await repo.GetAllAsync(false, request, searchRequest, loadRelations, cancellationToken))
        .Adapt<PaginatedResult<SkillDto>>();

    public async Task<SkillDto> GetByIdAsync(long id, bool loadRelations, CancellationToken cancellationToken = default) {
        var skill = await repo.GetByIdAsync(id, true, loadRelations, cancellationToken);
        if (skill is null) throw new NotFoundException(new NotFoundError(id, nameof(Skill)));
        return skill.Adapt<SkillDto>();
    }

    public async Task UpdateAsync(long id, UpdateSkillRequest request, CancellationToken cancellationToken = default) {
        var skill = await repo.GetByIdAsync(id, false, false, cancellationToken: cancellationToken);
        if (skill is null)
            throw new NotFoundException(new NotFoundError(id, nameof(Skill)));

        request.Adapt(skill);
        repo.Update(skill);

        await repo.SaveChangesAsync(cancellationToken: cancellationToken);
    }

    public async Task DeleteAsync(long id, CancellationToken cancellationToken = default) {
        var skill = await repo.GetByIdAsync(id, false, false, cancellationToken: cancellationToken);
        if (skill is null) throw new NotFoundException(new NotFoundError(id, nameof(Skill)));

        skill.SoftDeleteInfo.SetDeleteObject(userService.GetCurrentUserId());
        await repo.SaveChangesAsync(cancellationToken: cancellationToken);
    }
}