using LearningManagement.Occupation.Application.JobZones.Dtos;
using LearningManagement.Occupation.Application.JobZones.Dtos.Create;
using LearningManagement.Occupation.Application.JobZones.Dtos.Get;

namespace LearningManagement.Occupation.Application.JobZones.Contracts;

public interface IJobZoneService {
    Task<CreateJobZoneResponse> CreateAsync(CreateJobZoneRequest request, CancellationToken cancellationToken = default);

    Task<PaginatedResult<JobZoneDto>> GetAllAsync(PaginationRequest request, JobZoneSearchRequest? searchRequest, bool loadRelations,
        CancellationToken cancellationToken = default);

    Task<JobZoneDto> GetByIdAsync(Guid id, bool loadRelations, CancellationToken cancellationToken = default);
    Task UpdateAsync(Guid id, UpdateJobZoneRequest request, CancellationToken cancellationToken = default);
    Task DeleteAsync(Guid id, CancellationToken cancellationToken = default);
}