using LearningManagement.Occupation.Application.Occupations.Contracts;
using LearningManagement.Occupation.Application.Occupations.Dtos;
using LearningManagement.Occupation.Application.Occupations.Dtos.Create;
using LearningManagement.Occupation.Application.Occupations.Dtos.Get;

namespace LearningManagement.Occupation.Application.Occupations.Services;

public class OccupationService(IOccupationRepository repo, IUserService userService) : IOccupationService {
    public async Task<CreateOccupationResponse> CreateAsync(CreateOccupationRequest request, CancellationToken cancellationToken = default) {
        var occupation = request.Adapt<Domain.Occupations.Occupation>();
        repo.Add(occupation);
        await repo.SaveChangesAsync(cancellationToken: cancellationToken);

        return occupation.Adapt<CreateOccupationResponse>();
    }

    public async Task<PaginatedResult<OccupationDto>> GetAllAsync(PaginationRequest request,
        OccupationSearchRequest? searchRequest, bool loadRelations,
        CancellationToken cancellationToken = default) => (await repo.GetAllAsync(false, request, searchRequest, loadRelations, cancellationToken))
        .Adapt<PaginatedResult<OccupationDto>>();

    public async Task<OccupationDto> GetByIdAsync(long id, bool loadRelations, CancellationToken cancellationToken = default) {
        var occupation = await repo.GetByIdAsync(id, true, loadRelations, cancellationToken);
        if (occupation is null) throw new NotFoundException(new NotFoundError(id, nameof(Occupation)));
        return occupation.Adapt<OccupationDto>();
    }

    public async Task UpdateAsync(long id, UpdateOccupationRequest request, CancellationToken cancellationToken = default) {
        var occupation = await repo.GetByIdAsync(id, false, false, cancellationToken: cancellationToken);
        if (occupation is null)
            throw new NotFoundException(new NotFoundError(id, nameof(Occupation)));

        request.Adapt(occupation);
        repo.Update(occupation);

        await repo.SaveChangesAsync(cancellationToken: cancellationToken);
    }

    public async Task DeleteAsync(long id, CancellationToken cancellationToken = default) {
        var occupation = await repo.GetByIdAsync(id, false, false, cancellationToken: cancellationToken);
        if (occupation is null) throw new NotFoundException(new NotFoundError(id, nameof(Occupation)));

        occupation.SoftDeleteInfo.SetDeleteObject(userService.GetCurrentUserId());
        await repo.SaveChangesAsync(cancellationToken: cancellationToken);
    }
}