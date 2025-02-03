using LearningManagement.Occupation.Application.JobActivities.Dtos;

namespace LearningManagement.Occupation.Application.JobActivities.Contracts;

public interface IJobActivityService {
    Task<CreateJobActivityResponse> CreateAsync(CreateJobActivityRequest request, CancellationToken cancellationToken = default);

    Task<PaginatedResult<JobActivityDto>> GetAllAsync(PaginationRequest request, JobActivitySearchRequest? searchRequest, bool loadRelations,
        CancellationToken cancellationToken = default);

    Task<JobActivityDto> GetByIdAsync(Guid id, bool loadRelations, CancellationToken cancellationToken = default);
    Task UpdateAsync(Guid id, UpdateJobActivityRequest request, CancellationToken cancellationToken = default);
    Task DeleteAsync(Guid id, CancellationToken cancellationToken = default);
}