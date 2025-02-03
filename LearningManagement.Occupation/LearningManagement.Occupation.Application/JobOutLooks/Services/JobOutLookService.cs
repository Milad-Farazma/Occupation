using LearningManagement.Occupation.Application.JobOutLooks.Contracts;
using LearningManagement.Occupation.Application.JobOutLooks.Dtos;
using LearningManagement.Occupation.Application.JobOutLooks.Dtos.Create;
using LearningManagement.Occupation.Application.JobOutLooks.Dtos.Get;
using LearningManagement.Occupation.Domain.JobOutLooks;

namespace LearningManagement.Occupation.Application.JobOutLooks.Services;

public class JobOutLookService(IJobOutLookRepository repo, IUserService userService) : IJobOutLookService {
    public async Task<CreateJobOutLookResponse> CreateAsync(CreateJobOutLookRequest request, CancellationToken cancellationToken = default) {
        var jobOutLook = request.Adapt<JobOutLook>();
        repo.Add(jobOutLook);
        await repo.SaveChangesAsync(cancellationToken: cancellationToken);

        return jobOutLook.Adapt<CreateJobOutLookResponse>();
    }

    public async Task<PaginatedResult<JobOutLookDto>> GetAllAsync(PaginationRequest request,
        JobOutLookSearchRequest? searchRequest, bool loadRelations,
        CancellationToken cancellationToken = default) => (await repo.GetAllAsync(false, request, searchRequest, loadRelations, cancellationToken))
        .Adapt<PaginatedResult<JobOutLookDto>>();

    public async Task<JobOutLookDto> GetByIdAsync(Guid id, bool loadRelations, CancellationToken cancellationToken = default) {
        var jobOutLook = await repo.GetByIdAsync(id, true, loadRelations, cancellationToken);
        if (jobOutLook is null) throw new NotFoundException(new NotFoundError(id, nameof(JobOutLook)));
        return jobOutLook.Adapt<JobOutLookDto>();
    }

    public async Task UpdateAsync(Guid id, UpdateJobOutLookRequest request, CancellationToken cancellationToken = default) {
        var jobOutLook = await repo.GetByIdAsync(id, false, false, cancellationToken: cancellationToken);
        if (jobOutLook is null)
            throw new NotFoundException(new NotFoundError(id, nameof(JobOutLook)));

        request.Adapt(jobOutLook);
        repo.Update(jobOutLook);

        await repo.SaveChangesAsync(cancellationToken: cancellationToken);
    }

    public async Task DeleteAsync(Guid id, CancellationToken cancellationToken = default) {
        var jobOutLook = await repo.GetByIdAsync(id, false, false, cancellationToken: cancellationToken);
        if (jobOutLook is null) throw new NotFoundException(new NotFoundError(id, nameof(JobOutLook)));

        jobOutLook.SoftDeleteInfo.SetDeleteObject(userService.GetCurrentUserId());
        await repo.SaveChangesAsync(cancellationToken: cancellationToken);
    }
}