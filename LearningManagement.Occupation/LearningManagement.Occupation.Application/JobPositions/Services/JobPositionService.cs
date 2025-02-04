using LearningManagement.Occupation.Application.JobPositions.Contracts;
using LearningManagement.Occupation.Application.JobPositions.Dtos;
using LearningManagement.Occupation.Application.JobPositions.Dtos.Create;
using LearningManagement.Occupation.Application.JobPositions.Dtos.Get;
using LearningManagement.Occupation.Domain.JobPositions;

namespace LearningManagement.Occupation.Application.JobPositions.Services;

public class JobPositionService(IJobPositionRepository repo, IUserService userService) : IJobPositionService {
    public async Task<CreateJobPositionResponse> CreateAsync(CreateJobPositionRequest request, CancellationToken cancellationToken = default) {
        var jobPosition = request.Adapt<JobPosition>();
        repo.Add(jobPosition);
        await repo.SaveChangesAsync(cancellationToken: cancellationToken);

        return jobPosition.Adapt<CreateJobPositionResponse>();
    }

    public async Task<PaginatedResult<JobPositionDto>> GetAllAsync(PaginationRequest request,
        JobPositionSearchRequest? searchRequest, bool loadRelations,
        CancellationToken cancellationToken = default) => (await repo.GetAllAsync(false, request, searchRequest, loadRelations, cancellationToken))
        .Adapt<PaginatedResult<JobPositionDto>>();

    public async Task<JobPositionDto> GetByIdAsync(Guid id, bool loadRelations, CancellationToken cancellationToken = default) {
        var jobPosition = await repo.GetByIdAsync(id, true, loadRelations, cancellationToken);
        if (jobPosition is null) throw new NotFoundException(new NotFoundError(id, nameof(JobPosition)));
        return jobPosition.Adapt<JobPositionDto>();
    }

    public async Task UpdateAsync(Guid id, UpdateJobPositionRequest request, CancellationToken cancellationToken = default) {
        var jobPosition = await repo.GetByIdAsync(id, false, false, cancellationToken: cancellationToken);
        if (jobPosition is null)
            throw new NotFoundException(new NotFoundError(id, nameof(JobPosition)));

        request.Adapt(jobPosition);
        repo.Update(jobPosition);

        await repo.SaveChangesAsync(cancellationToken: cancellationToken);
    }

    public async Task DeleteAsync(Guid id, CancellationToken cancellationToken = default) {
        var jobPosition = await repo.GetByIdAsync(id, false, false, cancellationToken: cancellationToken);
        if (jobPosition is null) throw new NotFoundException(new NotFoundError(id, nameof(JobPosition)));

        jobPosition.SoftDeleteInfo.SetDeleteObject(userService.GetCurrentUserId());
        await repo.SaveChangesAsync(cancellationToken: cancellationToken);
    }
}