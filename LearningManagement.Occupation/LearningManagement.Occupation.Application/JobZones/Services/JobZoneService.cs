using LearningManagement.Occupation.Application.JobZones.Contracts;
using LearningManagement.Occupation.Application.JobZones.Dtos;
using LearningManagement.Occupation.Application.JobZones.Dtos.Create;
using LearningManagement.Occupation.Application.JobZones.Dtos.Get;
using LearningManagement.Occupation.Domain.JobZones;

namespace LearningManagement.Occupation.Application.JobZones.Services;

public class JobZoneService(IJobZoneRepository repo, IUserService userService) : IJobZoneService {
    public async Task<CreateJobZoneResponse> CreateAsync(CreateJobZoneRequest request, CancellationToken cancellationToken = default) {
        var jobZone = request.Adapt<JobZone>();
        repo.Add(jobZone);
        await repo.SaveChangesAsync(cancellationToken: cancellationToken);

        return jobZone.Adapt<CreateJobZoneResponse>();
    }

    public async Task<PaginatedResult<JobZoneDto>> GetAllAsync(PaginationRequest request,
        JobZoneSearchRequest? searchRequest, bool loadRelations,
        CancellationToken cancellationToken = default) => (await repo.GetAllAsync(false, request, searchRequest, loadRelations, cancellationToken))
        .Adapt<PaginatedResult<JobZoneDto>>();

    public async Task<JobZoneDto> GetByIdAsync(long id, bool loadRelations, CancellationToken cancellationToken = default) {
        var jobZone = await repo.GetByIdAsync(id, true, loadRelations, cancellationToken);
        if (jobZone is null) throw new NotFoundException(new NotFoundError(id, nameof(JobZone)));
        return jobZone.Adapt<JobZoneDto>();
    }

    public async Task UpdateAsync(long id, UpdateJobZoneRequest request, CancellationToken cancellationToken = default) {
        var jobZone = await repo.GetByIdAsync(id, false, false, cancellationToken: cancellationToken);
        if (jobZone is null)
            throw new NotFoundException(new NotFoundError(id, nameof(JobZone)));

        request.Adapt(jobZone);
        repo.Update(jobZone);

        await repo.SaveChangesAsync(cancellationToken: cancellationToken);
    }

    public async Task DeleteAsync(long id, CancellationToken cancellationToken = default) {
        var jobZone = await repo.GetByIdAsync(id, false, false, cancellationToken: cancellationToken);
        if (jobZone is null) throw new NotFoundException(new NotFoundError(id, nameof(JobZone)));

        jobZone.SoftDeleteInfo.SetDeleteObject(userService.GetCurrentUserId());
        await repo.SaveChangesAsync(cancellationToken: cancellationToken);
    }
}