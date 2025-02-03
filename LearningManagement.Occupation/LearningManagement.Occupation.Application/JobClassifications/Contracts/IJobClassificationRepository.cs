using LearningManagement.Occupation.Application.JobClassifications.Dtos.Get;
using LearningManagement.Occupation.Domain.JobClassifications;

namespace LearningManagement.Occupation.Application.JobClassifications.Contracts;

public interface IJobClassificationRepository {
    Task<PaginatedResult<JobClassification>> GetAllAsync(bool asNoTracking, PaginationRequest request, JobClassificationSearchRequest? searchRequest,
        bool loadRelations, CancellationToken cancellationToken = default);

    Task<JobClassification?> GetByIdAsync(Guid id, bool asNoTracking, bool loadRelations, CancellationToken cancellationToken = default);
    void Add(JobClassification entity);
    void Update(JobClassification entity);
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}