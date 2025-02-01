using LearningManagement.Occupation.Application.JobActivities.Dtos;
using LearningManagement.Occupation.Domain.JobActivitys;

namespace LearningManagement.Occupation.Application.JobActivities.Contracts;

public interface IJobActivityRepository {
    Task<PaginatedResult<JobActivity>> GetAllAsync(bool asNoTracking, PaginationRequest request, JobActivitySearchRequest? searchRequest,
        bool loadRelations, CancellationToken cancellationToken = default);

    Task<JobActivity?> GetByIdAsync(long id, bool asNoTracking, bool loadRelations, CancellationToken cancellationToken = default);
    void Add(JobActivity entity);
    void Update(JobActivity entity);
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}