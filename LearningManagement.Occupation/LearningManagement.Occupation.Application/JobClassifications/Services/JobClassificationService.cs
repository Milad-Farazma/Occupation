using LearningManagement.Occupation.Application.JobClassifications.Contracts;
using LearningManagement.Occupation.Application.JobClassifications.Dtos;
using LearningManagement.Occupation.Application.JobClassifications.Dtos.Create;
using LearningManagement.Occupation.Application.JobClassifications.Dtos.Get;
using LearningManagement.Occupation.Domain.JobClassifications;

namespace LearningManagement.Occupation.Application.JobClassifications.Services;

public class JobClassificationService(IJobClassificationRepository repo, IUserService userService) : IJobClassificationService {
    public async Task<CreateJobClassificationResponse> CreateAsync(CreateJobClassificationRequest request,
        CancellationToken cancellationToken = default) {
        var jobClassification = request.Adapt<JobClassification>();
        repo.Add(jobClassification);
        await repo.SaveChangesAsync(cancellationToken: cancellationToken);

        return jobClassification.Adapt<CreateJobClassificationResponse>();
    }

    public async Task<PaginatedResult<JobClassificationDto>> GetAllAsync(PaginationRequest request,
        JobClassificationSearchRequest? searchRequest, bool loadRelations,
        CancellationToken cancellationToken = default) => (await repo.GetAllAsync(false, request, searchRequest, loadRelations, cancellationToken))
        .Adapt<PaginatedResult<JobClassificationDto>>();

    public async Task<JobClassificationDto> GetByIdAsync(long id, bool loadRelations, CancellationToken cancellationToken = default) {
        var jobClassification = await repo.GetByIdAsync(id, true, loadRelations, cancellationToken);
        if (jobClassification is null) throw new NotFoundException(new NotFoundError(id, nameof(JobClassification)));
        return jobClassification.Adapt<JobClassificationDto>();
    }

    public async Task UpdateAsync(long id, UpdateJobClassificationRequest request, CancellationToken cancellationToken = default) {
        var jobClassification = await repo.GetByIdAsync(id, false, false, cancellationToken: cancellationToken);
        if (jobClassification is null)
            throw new NotFoundException(new NotFoundError(id, nameof(JobClassification)));

        request.Adapt(jobClassification);
        repo.Update(jobClassification);

        await repo.SaveChangesAsync(cancellationToken: cancellationToken);
    }

    public async Task DeleteAsync(long id, CancellationToken cancellationToken = default) {
        var jobClassification = await repo.GetByIdAsync(id, false, false, cancellationToken: cancellationToken);
        if (jobClassification is null) throw new NotFoundException(new NotFoundError(id, nameof(JobClassification)));

        jobClassification.SoftDeleteInfo.SetDeleteObject(userService.GetCurrentUserId());
        await repo.SaveChangesAsync(cancellationToken: cancellationToken);
    }
}