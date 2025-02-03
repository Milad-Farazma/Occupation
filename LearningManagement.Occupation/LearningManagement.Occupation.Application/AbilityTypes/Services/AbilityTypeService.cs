using LearningManagement.Occupation.Application.AbilityTypes.Contracts;
using LearningManagement.Occupation.Application.AbilityTypes.Dtos;
using LearningManagement.Occupation.Application.AbilityTypes.Dtos.Create;
using LearningManagement.Occupation.Application.AbilityTypes.Dtos.Get;
using LearningManagement.Occupation.Domain.AbilityTypes;

namespace LearningManagement.Occupation.Application.AbilityTypes.Services;

public class AbilityTypeService(IAbilityTypeRepository repo, IUserService userService) : IAbilityTypeService {
    public async Task<CreateAbilityTypeResponse> CreateAsync(CreateAbilityTypeRequest request, CancellationToken cancellationToken = default) {
        var abilityType = request.Adapt<AbilityType>();
        repo.Add(abilityType);
        await repo.SaveChangesAsync(cancellationToken: cancellationToken);

        return abilityType.Adapt<CreateAbilityTypeResponse>();
    }

    public async Task<PaginatedResult<AbilityTypeDto>> GetAllAsync(PaginationRequest request,
        AbilityTypeSearchRequest? searchRequest, bool loadRelations,
        CancellationToken cancellationToken = default) => (await repo.GetAllAsync(false, request, searchRequest, loadRelations, cancellationToken))
        .Adapt<PaginatedResult<AbilityTypeDto>>();

    public async Task<AbilityTypeDto> GetByIdAsync(Guid id, bool loadRelations, CancellationToken cancellationToken = default) {
        var abilityType = await repo.GetByIdAsync(id, true, loadRelations, cancellationToken);
        if (abilityType is null) throw new NotFoundException(new NotFoundError(id, nameof(AbilityType)));
        return abilityType.Adapt<AbilityTypeDto>();
    }

    public async Task UpdateAsync(Guid id, UpdateAbilityTypeRequest request, CancellationToken cancellationToken = default) {
        var abilityType = await repo.GetByIdAsync(id, false, false, cancellationToken: cancellationToken);
        if (abilityType is null)
            throw new NotFoundException(new NotFoundError(id, nameof(AbilityType)));

        request.Adapt(abilityType);
        repo.Update(abilityType);

        await repo.SaveChangesAsync(cancellationToken: cancellationToken);
    }

    public async Task DeleteAsync(Guid id, CancellationToken cancellationToken = default) {
        var abilityType = await repo.GetByIdAsync(id, false, false, cancellationToken: cancellationToken);
        if (abilityType is null) throw new NotFoundException(new NotFoundError(id, nameof(AbilityType)));

        abilityType.SoftDeleteInfo.SetDeleteObject(userService.GetCurrentUserId());
        await repo.SaveChangesAsync(cancellationToken: cancellationToken);
    }
}