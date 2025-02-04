using LearningManagement.Occupation.Application.Aliases.Contracts;
using LearningManagement.Occupation.Application.Aliases.Dtos;
using LearningManagement.Occupation.Application.Aliases.Dtos.Create;
using LearningManagement.Occupation.Application.Aliases.Dtos.Get;
using LearningManagement.Occupation.Domain.Aliases;

namespace LearningManagement.Occupation.Application.Aliases.Services;

public class AliasService(IAliasRepository repo, IUserService userService) : IAliasService {
    public async Task<CreateAliasResponse> CreateAsync(CreateAliasRequest request, CancellationToken cancellationToken = default) {
        var alias = request.Adapt<Alias>();
        repo.Add(alias);
        await repo.SaveChangesAsync(cancellationToken: cancellationToken);

        return alias.Adapt<CreateAliasResponse>();
    }

    public async Task<PaginatedResult<AliasDto>> GetAllAsync(PaginationRequest request,
        AliasSearchRequest? searchRequest, bool loadRelations,
        CancellationToken cancellationToken = default) => (await repo.GetAllAsync(false, request, searchRequest, loadRelations, cancellationToken))
        .Adapt<PaginatedResult<AliasDto>>();

    public async Task<AliasDto> GetByIdAsync(Guid id, bool loadRelations, CancellationToken cancellationToken = default) {
        var alias = await repo.GetByIdAsync(id, true, loadRelations, cancellationToken);
        if (alias is null) throw new NotFoundException(new NotFoundError(id, nameof(Alias)));
        return alias.Adapt<AliasDto>();
    }

    public async Task UpdateAsync(Guid id, UpdateAliasRequest request, CancellationToken cancellationToken = default) {
        var alias = await repo.GetByIdAsync(id, false, false, cancellationToken: cancellationToken);
        if (alias is null)
            throw new NotFoundException(new NotFoundError(id, nameof(Alias)));

        request.Adapt(alias);
        repo.Update(alias);

        await repo.SaveChangesAsync(cancellationToken: cancellationToken);
    }

    public async Task DeleteAsync(Guid id, CancellationToken cancellationToken = default) {
        var alias = await repo.GetByIdAsync(id, false, false, cancellationToken: cancellationToken);
        if (alias is null) throw new NotFoundException(new NotFoundError(id, nameof(Alias)));

        alias.SoftDeleteInfo.SetDeleteObject(userService.GetCurrentUserId());
        await repo.SaveChangesAsync(cancellationToken: cancellationToken);
    }
}