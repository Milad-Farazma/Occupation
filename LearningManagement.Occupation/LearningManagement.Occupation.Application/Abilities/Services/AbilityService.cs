using LearningManagement.Occupation.Application.Abilities.Contracts;
using LearningManagement.Occupation.Application.Abilities.Dtos;
using LearningManagement.Occupation.Application.Abilities.Dtos.Create;
using LearningManagement.Occupation.Application.Abilities.Dtos.Get;
using LearningManagement.Occupation.Domain.Abilities;

namespace LearningManagement.Occupation.Application.Abilities.Services;

public class AbilityService(IAbilityRepository repo, IUserService userService) : IAbilityService {
    public async Task<CreateAbilityResponse> CreateAsync(CreateAbilityRequest request, CancellationToken cancellationToken = default) {
        var ability = request.Adapt<Ability>();
        repo.Add(ability);
        await repo.SaveChangesAsync(cancellationToken: cancellationToken);

        return ability.Adapt<CreateAbilityResponse>();
    }

    public async Task<PaginatedResult<AbilityDto>> GetAllAsync(PaginationRequest request,
        AbilitySearchRequest? searchRequest, bool loadRelations,
        CancellationToken cancellationToken = default) => (await repo.GetAllAsync(false, request, searchRequest, loadRelations, cancellationToken))
        .Adapt<PaginatedResult<AbilityDto>>();

    public async Task<AbilityDto> GetByIdAsync(Guid id, bool loadRelations, CancellationToken cancellationToken = default) {
        var ability = await repo.GetByIdAsync(id, true, loadRelations, cancellationToken);
        if (ability is null) throw new NotFoundException(new NotFoundError(id, nameof(Ability)));
        return ability.Adapt<AbilityDto>();
    }

    public async Task UpdateAsync(Guid id, UpdateAbilityRequest request, CancellationToken cancellationToken = default) {
        var ability = await repo.GetByIdAsync(id, false, false, cancellationToken: cancellationToken);
        if (ability is null)
            throw new NotFoundException(new NotFoundError(id, nameof(Ability)));

        request.Adapt(ability);
        repo.Update(ability);

        await repo.SaveChangesAsync(cancellationToken: cancellationToken);
    }

    public async Task DeleteAsync(Guid id, CancellationToken cancellationToken = default) {
        var ability = await repo.GetByIdAsync(id, false, false, cancellationToken: cancellationToken);
        if (ability is null) throw new NotFoundException(new NotFoundError(id, nameof(Ability)));

        ability.SoftDeleteInfo.SetDeleteObject(userService.GetCurrentUserId());
        await repo.SaveChangesAsync(cancellationToken: cancellationToken);
    }
}