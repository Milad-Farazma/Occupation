using LearningManagement.Occupation.Application.OccupationJobZones.Dtos.Get;
using LearningManagement.Occupation.Domain.OccupationJobZones;

namespace LearningManagement.Occupation.Application.OccupationJobZones.Contracts;

public interface IOccupationJobZoneRepository {
    Task<PaginatedResult<OccupationJobZone>> GetAllAsync(bool asNoTracking, PaginationRequest request, OccupationJobZoneSearchRequest? searchRequest,
        bool loadRelations, CancellationToken cancellationToken = default);

    Task<OccupationJobZone?> GetByIdAsync(Guid id, bool asNoTracking, bool loadRelations, CancellationToken cancellationToken = default);
    void Add(OccupationJobZone entity);
    void Update(OccupationJobZone entity);
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}