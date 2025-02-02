using LearningManagement.Occupation.Application.Technologys.Contracts;
using LearningManagement.Occupation.Application.Technologys.Dtos;
using LearningManagement.Occupation.Application.Technologys.Dtos.Create;
using LearningManagement.Occupation.Application.Technologys.Dtos.Get;
using LearningManagement.Occupation.Domain.Technologys;

namespace LearningManagement.Occupation.Application.Technologys.Services;

public class TechnologyService(ITechnologyRepository repo, IUserService userService) : ITechnologyService {
    public async Task<CreateTechnologyResponse> CreateAsync(CreateTechnologyRequest request, CancellationToken cancellationToken = default) {
        var technology = request.Adapt<Technology>();
        repo.Add(technology);
        await repo.SaveChangesAsync(cancellationToken: cancellationToken);

        return technology.Adapt<CreateTechnologyResponse>();
    }

    public async Task<PaginatedResult<TechnologyDto>> GetAllAsync(PaginationRequest request,
        TechnologySearchRequest? searchRequest, bool loadRelations,
        CancellationToken cancellationToken = default) => (await repo.GetAllAsync(false, request, searchRequest, loadRelations, cancellationToken))
        .Adapt<PaginatedResult<TechnologyDto>>();

    public async Task<TechnologyDto> GetByIdAsync(long id, bool loadRelations, CancellationToken cancellationToken = default) {
        var technology = await repo.GetByIdAsync(id, true, loadRelations, cancellationToken);
        if (technology is null) throw new NotFoundException(new NotFoundError(id, nameof(Technology)));
        return technology.Adapt<TechnologyDto>();
    }

    public async Task UpdateAsync(long id, UpdateTechnologyRequest request, CancellationToken cancellationToken = default) {
        var technology = await repo.GetByIdAsync(id, false, false, cancellationToken: cancellationToken);
        if (technology is null)
            throw new NotFoundException(new NotFoundError(id, nameof(Technology)));

        request.Adapt(technology);
        repo.Update(technology);

        await repo.SaveChangesAsync(cancellationToken: cancellationToken);
    }

    public async Task DeleteAsync(long id, CancellationToken cancellationToken = default) {
        var technology = await repo.GetByIdAsync(id, false, false, cancellationToken: cancellationToken);
        if (technology is null) throw new NotFoundException(new NotFoundError(id, nameof(Technology)));

        technology.SoftDeleteInfo.SetDeleteObject(userService.GetCurrentUserId());
        await repo.SaveChangesAsync(cancellationToken: cancellationToken);
    }
}