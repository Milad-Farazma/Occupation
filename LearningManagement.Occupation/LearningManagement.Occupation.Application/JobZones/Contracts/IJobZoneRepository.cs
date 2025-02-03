using LearningManagement.Occupation.Application.JobZones.Dtos.Get;
using LearningManagement.Occupation.Domain.JobZones;

namespace LearningManagement.Occupation.Application.JobZones.Contracts;

public interface IJobZoneRepository {
    Task<PaginatedResult<JobZone>> GetAllAsync(bool asNoTracking, PaginationRequest request, JobZoneSearchRequest? searchRequest, bool loadRelations,
        CancellationToken cancellationToken = default);

    Task<JobZone?> GetByIdAsync(long id, bool asNoTracking, bool loadRelations, CancellationToken cancellationToken = default);
    void Add(JobZone entity);
    void Update(JobZone entity);
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}