using LearningManagement.Occupation.Application.JobActivities.Contracts;
using LearningManagement.Occupation.Application.JobActivities.Dtos;
using LearningManagement.Occupation.Domain.JobActivities;

namespace LearningManagement.Occupation.Application.JobActivities.Services;

public class JobActivityService(IJobActivityRepository repo, IUserService userService) : IJobActivityService {
    public async Task<CreateJobActivityResponse> CreateAsync(CreateJobActivityRequest request, CancellationToken cancellationToken = default) {
        var jobActivity = request.Adapt<JobActivity>();
        repo.Add(jobActivity);
        await repo.SaveChangesAsync(cancellationToken: cancellationToken);

        return jobActivity.Adapt<CreateJobActivityResponse>();
    }

    public async Task<PaginatedResult<JobActivityDto>> GetAllAsync(PaginationRequest request,
        JobActivitySearchRequest? searchRequest, bool loadRelations,
        CancellationToken cancellationToken = default) => (await repo.GetAllAsync(false, request, searchRequest, loadRelations, cancellationToken))
        .Adapt<PaginatedResult<JobActivityDto>>();

    public async Task<JobActivityDto> GetByIdAsync(long id, bool loadRelations, CancellationToken cancellationToken = default) {
        var jobActivity = await repo.GetByIdAsync(id, true, loadRelations, cancellationToken);
        if (jobActivity is null) throw new NotFoundException(new NotFoundError(id, nameof(JobActivity)));
        return jobActivity.Adapt<JobActivityDto>();
    }

    public async Task UpdateAsync(long id, UpdateJobActivityRequest request, CancellationToken cancellationToken = default) {
        var jobActivity = await repo.GetByIdAsync(id, false, false, cancellationToken: cancellationToken);
        if (jobActivity is null)
            throw new NotFoundException(new NotFoundError(id, nameof(JobActivity)));

        request.Adapt(jobActivity);
        repo.Update(jobActivity);

        await repo.SaveChangesAsync(cancellationToken: cancellationToken);
    }

    public async Task DeleteAsync(long id, CancellationToken cancellationToken = default) {
        var jobActivity = await repo.GetByIdAsync(id, false, false, cancellationToken: cancellationToken);
        if (jobActivity is null) throw new NotFoundException(new NotFoundError(id, nameof(JobActivity)));

        jobActivity.SoftDeleteInfo.SetDeleteObject(userService.GetCurrentUserId());
        await repo.SaveChangesAsync(cancellationToken: cancellationToken);
    }
}