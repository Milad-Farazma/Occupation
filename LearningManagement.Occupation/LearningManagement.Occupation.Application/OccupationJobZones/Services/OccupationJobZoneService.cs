using LearningManagement.Occupation.Application.OccupationJobZones.Contracts;
using LearningManagement.Occupation.Application.OccupationJobZones.Dtos;
using LearningManagement.Occupation.Application.OccupationJobZones.Dtos.Create;
using LearningManagement.Occupation.Application.OccupationJobZones.Dtos.Get;
using LearningManagement.Occupation.Domain.OccupationJobZones;

namespace LearningManagement.Occupation.Application.OccupationJobZones.Services;

public class OccupationJobZoneService(IOccupationJobZoneRepository repo, IUserService userService) : IOccupationJobZoneService {
    public async Task<CreateOccupationJobZoneResponse> CreateAsync(CreateOccupationJobZoneRequest request,
        CancellationToken cancellationToken = default) {
        var occupationJobZone = request.Adapt<OccupationJobZone>();
        repo.Add(occupationJobZone);
        await repo.SaveChangesAsync(cancellationToken: cancellationToken);

        return occupationJobZone.Adapt<CreateOccupationJobZoneResponse>();
    }

    public async Task<PaginatedResult<OccupationJobZoneDto>> GetAllAsync(PaginationRequest request,
        OccupationJobZoneSearchRequest? searchRequest, bool loadRelations,
        CancellationToken cancellationToken = default) => (await repo.GetAllAsync(false, request, searchRequest, loadRelations, cancellationToken))
        .Adapt<PaginatedResult<OccupationJobZoneDto>>();

    public async Task<OccupationJobZoneDto> GetByIdAsync(Guid id, bool loadRelations, CancellationToken cancellationToken = default) {
        var occupationJobZone = await repo.GetByIdAsync(id, true, loadRelations, cancellationToken);
        if (occupationJobZone is null) throw new NotFoundException(new NotFoundError(id, nameof(OccupationJobZone)));
        return occupationJobZone.Adapt<OccupationJobZoneDto>();
    }

    public async Task UpdateAsync(Guid id, UpdateOccupationJobZoneRequest request, CancellationToken cancellationToken = default) {
        var occupationJobZone = await repo.GetByIdAsync(id, false, false, cancellationToken: cancellationToken);
        if (occupationJobZone is null)
            throw new NotFoundException(new NotFoundError(id, nameof(OccupationJobZone)));

        request.Adapt(occupationJobZone);
        repo.Update(occupationJobZone);

        await repo.SaveChangesAsync(cancellationToken: cancellationToken);
    }

    public async Task DeleteAsync(Guid id, CancellationToken cancellationToken = default) {
        var occupationJobZone = await repo.GetByIdAsync(id, false, false, cancellationToken: cancellationToken);
        if (occupationJobZone is null) throw new NotFoundException(new NotFoundError(id, nameof(OccupationJobZone)));

        occupationJobZone.SoftDeleteInfo.SetDeleteObject(userService.GetCurrentUserId());
        await repo.SaveChangesAsync(cancellationToken: cancellationToken);
    }
}