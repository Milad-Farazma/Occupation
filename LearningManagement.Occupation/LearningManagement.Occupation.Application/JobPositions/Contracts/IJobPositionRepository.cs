using LearningManagement.Occupation.Application.JobPositions.Dtos.Get;
using LearningManagement.Occupation.Domain.JobPositions;

namespace LearningManagement.Occupation.Application.JobPositions.Contracts;

public interface IJobPositionRepository {
    Task<PaginatedResult<JobPosition>> GetAllAsync(bool asNoTracking, PaginationRequest request, JobPositionSearchRequest? searchRequest,
        bool loadRelations, CancellationToken cancellationToken = default);

    Task<JobPosition?> GetByIdAsync(Guid id, bool asNoTracking, bool loadRelations, CancellationToken cancellationToken = default);
    void Add(JobPosition entity);
    void Update(JobPosition entity);
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}