using LearningManagement.Occupation.Application.SeniorityLevels.Contracts;
using LearningManagement.Occupation.Application.SeniorityLevels.Dtos;
using LearningManagement.Occupation.Application.SeniorityLevels.Dtos.Create;
using LearningManagement.Occupation.Application.SeniorityLevels.Dtos.Get;
using LearningManagement.Occupation.Domain.SeniorityLevels;

namespace LearningManagement.Occupation.Application.SeniorityLevels.Services;

public class SeniorityLevelService(ISeniorityLevelRepository repo, IUserService userService) : ISeniorityLevelService {
    public async Task<CreateSeniorityLevelResponse> CreateAsync(CreateSeniorityLevelRequest request, CancellationToken cancellationToken = default) {
        var seniorityLevel = request.Adapt<SeniorityLevel>();
        repo.Add(seniorityLevel);
        await repo.SaveChangesAsync(cancellationToken: cancellationToken);

        return seniorityLevel.Adapt<CreateSeniorityLevelResponse>();
    }

    public async Task<PaginatedResult<SeniorityLevelDto>> GetAllAsync(PaginationRequest request,
        SeniorityLevelSearchRequest? searchRequest, bool loadRelations,
        CancellationToken cancellationToken = default) => (await repo.GetAllAsync(false, request, searchRequest, loadRelations, cancellationToken))
        .Adapt<PaginatedResult<SeniorityLevelDto>>();

    public async Task<SeniorityLevelDto> GetByIdAsync(Guid id, bool loadRelations, CancellationToken cancellationToken = default) {
        var seniorityLevel = await repo.GetByIdAsync(id, true, loadRelations, cancellationToken);
        if (seniorityLevel is null) throw new NotFoundException(new NotFoundError(id, nameof(seniorityLevel)));
        return seniorityLevel.Adapt<SeniorityLevelDto>();
    }

    public async Task UpdateAsync(Guid id, UpdateSeniorityLevelRequest request, CancellationToken cancellationToken = default) {
        var seniorityLevel = await repo.GetByIdAsync(id, false, false, cancellationToken: cancellationToken);
        if (seniorityLevel is null)
            throw new NotFoundException(new NotFoundError(id, nameof(seniorityLevel)));

        request.Adapt(seniorityLevel);
        repo.Update(seniorityLevel);

        await repo.SaveChangesAsync(cancellationToken: cancellationToken);
    }

    public async Task DeleteAsync(Guid id, CancellationToken cancellationToken = default) {
        var seniorityLevel = await repo.GetByIdAsync(id, false, false, cancellationToken: cancellationToken);
        if (seniorityLevel is null) throw new NotFoundException(new NotFoundError(id, nameof(seniorityLevel)));

        seniorityLevel.SoftDeleteInfo.SetDeleteObject(userService.GetCurrentUserId());
        await repo.SaveChangesAsync(cancellationToken: cancellationToken);
    }
}