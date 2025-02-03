using LearningManagement.Occupation.Application.TechnologyTypes.Contracts;
using LearningManagement.Occupation.Application.TechnologyTypes.Dtos;
using LearningManagement.Occupation.Application.TechnologyTypes.Dtos.Create;
using LearningManagement.Occupation.Application.TechnologyTypes.Dtos.Get;
using LearningManagement.Occupation.Domain.TechnologyTypes;

namespace LearningManagement.Occupation.Application.TechnologyTypes.Services;

public class TechnologyTypeService(ITechnologyTypeRepository repo, IUserService userService) : ITechnologyTypeService {
    public async Task<CreateTechnologyTypeResponse> CreateAsync(CreateTechnologyTypeRequest request, CancellationToken cancellationToken = default) {
        var technologyType = request.Adapt<TechnologyType>();
        repo.Add(technologyType);
        await repo.SaveChangesAsync(cancellationToken: cancellationToken);

        return technologyType.Adapt<CreateTechnologyTypeResponse>();
    }

    public async Task<PaginatedResult<TechnologyTypeDto>> GetAllAsync(PaginationRequest request,
        TechnologyTypeSearchRequest? searchRequest, bool loadRelations,
        CancellationToken cancellationToken = default) => (await repo.GetAllAsync(false, request, searchRequest, loadRelations, cancellationToken))
        .Adapt<PaginatedResult<TechnologyTypeDto>>();

    public async Task<TechnologyTypeDto> GetByIdAsync(Guid id, bool loadRelations, CancellationToken cancellationToken = default) {
        var technologyType = await repo.GetByIdAsync(id, true, loadRelations, cancellationToken);
        if (technologyType is null) throw new NotFoundException(new NotFoundError(id, nameof(TechnologyType)));
        return technologyType.Adapt<TechnologyTypeDto>();
    }

    public async Task UpdateAsync(Guid id, UpdateTechnologyTypeRequest request, CancellationToken cancellationToken = default) {
        var technologyType = await repo.GetByIdAsync(id, false, false, cancellationToken: cancellationToken);
        if (technologyType is null)
            throw new NotFoundException(new NotFoundError(id, nameof(TechnologyType)));

        request.Adapt(technologyType);
        repo.Update(technologyType);

        await repo.SaveChangesAsync(cancellationToken: cancellationToken);
    }

    public async Task DeleteAsync(Guid id, CancellationToken cancellationToken = default) {
        var technologyType = await repo.GetByIdAsync(id, false, false, cancellationToken: cancellationToken);
        if (technologyType is null) throw new NotFoundException(new NotFoundError(id, nameof(TechnologyType)));

        technologyType.SoftDeleteInfo.SetDeleteObject(userService.GetCurrentUserId());
        await repo.SaveChangesAsync(cancellationToken: cancellationToken);
    }
}