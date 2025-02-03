using LearningManagement.Occupation.Application.JobZones.Dtos;
using LearningManagement.Occupation.Application.JobZones.Dtos.Create;
using LearningManagement.Occupation.Application.JobZones.Dtos.Get;

namespace LearningManagement.Occupation.Application.JobZones.Contracts;

public interface IJobZoneService {
    Task<CreateJobZoneResponse> CreateAsync(CreateJobZoneRequest request, CancellationToken cancellationToken = default);

    Task<PaginatedResult<JobZoneDto>> GetAllAsync(PaginationRequest request, JobZoneSearchRequest? searchRequest, bool loadRelations,
        CancellationToken cancellationToken = default);

    Task<JobZoneDto> GetByIdAsync(long id, bool loadRelations, CancellationToken cancellationToken = default);
    Task UpdateAsync(long id, UpdateJobZoneRequest request, CancellationToken cancellationToken = default);
    Task DeleteAsync(long id, CancellationToken cancellationToken = default);
}