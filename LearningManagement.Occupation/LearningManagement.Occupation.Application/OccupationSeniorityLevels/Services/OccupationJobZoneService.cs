using LearningManagement.Occupation.Application.OccupationSeniorityLevels.Contracts;
using LearningManagement.Occupation.Application.OccupationSeniorityLevels.Dtos;
using LearningManagement.Occupation.Application.OccupationSeniorityLevels.Dtos.Create;
using LearningManagement.Occupation.Application.OccupationSeniorityLevels.Dtos.Get;
using LearningManagement.Occupation.Domain.Occupations;

namespace LearningManagement.Occupation.Application.OccupationSeniorityLevels.Services;

public class OccupationSeniorityLevelService(IOccupationSeniorityLevelRepository repo, IUserService userService) : IOccupationSeniorityLevelService {
    public async Task<CreateOccupationSeniorityLevelResponse> CreateAsync(CreateOccupationSeniorityLevelRequest request,
        CancellationToken cancellationToken = default) {
        var occupationSeniorityLevel = request.Adapt<OccupationSeniorityLevel>();
        repo.Add(occupationSeniorityLevel);
        await repo.SaveChangesAsync(cancellationToken: cancellationToken);

        return occupationSeniorityLevel.Adapt<CreateOccupationSeniorityLevelResponse>();
    }

    public async Task<PaginatedResult<OccupationSeniorityLevelDto>> GetAllAsync(PaginationRequest request,
        OccupationSeniorityLevelSearchRequest? searchRequest, bool loadRelations,
        CancellationToken cancellationToken = default) => (await repo.GetAllAsync(false, request, searchRequest, loadRelations, cancellationToken))
        .Adapt<PaginatedResult<OccupationSeniorityLevelDto>>();

    public async Task<OccupationSeniorityLevelDto> GetByIdAsync(Guid id, bool loadRelations, CancellationToken cancellationToken = default) {
        var occupationSeniorityLevel = await repo.GetByIdAsync(id, true, loadRelations, cancellationToken);
        if (occupationSeniorityLevel is null) throw new NotFoundException(new NotFoundError(id, nameof(OccupationSeniorityLevel)));
        return occupationSeniorityLevel.Adapt<OccupationSeniorityLevelDto>();
    }

    public async Task UpdateAsync(Guid id, UpdateOccupationSeniorityLevelRequest request, CancellationToken cancellationToken = default) {
        var occupationSeniorityLevel = await repo.GetByIdAsync(id, false, false, cancellationToken: cancellationToken);
        if (occupationSeniorityLevel is null)
            throw new NotFoundException(new NotFoundError(id, nameof(OccupationSeniorityLevel)));

        request.Adapt(occupationSeniorityLevel);
        repo.Update(occupationSeniorityLevel);

        await repo.SaveChangesAsync(cancellationToken: cancellationToken);
    }

    public async Task DeleteAsync(Guid id, CancellationToken cancellationToken = default) {
        var occupationSeniorityLevel = await repo.GetByIdAsync(id, false, false, cancellationToken: cancellationToken);
        if (occupationSeniorityLevel is null) throw new NotFoundException(new NotFoundError(id, nameof(OccupationSeniorityLevel)));

        occupationSeniorityLevel.SoftDeleteInfo.SetDeleteObject(userService.GetCurrentUserId());
        await repo.SaveChangesAsync(cancellationToken: cancellationToken);
    }
}