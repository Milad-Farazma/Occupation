using LearningManagement.Occupation.Application.JobOutLooks.Dtos.Get;
using LearningManagement.Occupation.Domain.JobOutLooks;

namespace LearningManagement.Occupation.Application.JobOutLooks.Contracts;

public interface IJobOutLookRepository {
    Task<PaginatedResult<JobOutLook>> GetAllAsync(bool asNoTracking, PaginationRequest request, JobOutLookSearchRequest? searchRequest,
        bool loadRelations, CancellationToken cancellationToken = default);

    Task<JobOutLook?> GetByIdAsync(long id, bool asNoTracking, bool loadRelations, CancellationToken cancellationToken = default);
    void Add(JobOutLook entity);
    void Update(JobOutLook entity);
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}