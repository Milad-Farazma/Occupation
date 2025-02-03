using LearningManagement.Occupation.Application.OccupationJobZones.Dtos;
using LearningManagement.Occupation.Application.OccupationJobZones.Dtos.Create;
using LearningManagement.Occupation.Application.OccupationJobZones.Dtos.Get;

namespace LearningManagement.Occupation.Application.OccupationJobZones.Contracts;

public interface IOccupationJobZoneService {
    Task<CreateOccupationJobZoneResponse> CreateAsync(CreateOccupationJobZoneRequest request, CancellationToken cancellationToken = default);

    Task<PaginatedResult<OccupationJobZoneDto>> GetAllAsync(PaginationRequest request, OccupationJobZoneSearchRequest? searchRequest,
        bool loadRelations, CancellationToken cancellationToken = default);

    Task<OccupationJobZoneDto> GetByIdAsync(Guid id, bool loadRelations, CancellationToken cancellationToken = default);
    Task UpdateAsync(Guid id, UpdateOccupationJobZoneRequest request, CancellationToken cancellationToken = default);
    Task DeleteAsync(Guid id, CancellationToken cancellationToken = default);
}