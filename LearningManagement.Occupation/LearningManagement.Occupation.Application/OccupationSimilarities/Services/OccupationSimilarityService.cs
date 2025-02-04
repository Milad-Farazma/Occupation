using LearningManagement.Occupation.Application.OccupationSimilarities.Contracts;
using LearningManagement.Occupation.Application.OccupationSimilarities.Dtos;
using LearningManagement.Occupation.Application.OccupationSimilarities.Dtos.Create;
using LearningManagement.Occupation.Application.OccupationSimilarities.Dtos.Get;
using LearningManagement.Occupation.Domain.OccupationSimilarities;

namespace LearningManagement.Occupation.Application.OccupationSimilarities.Services;

public class OccupationSimilarityService(IOccupationSimilarityRepository repo, IUserService userService) : IOccupationSimilarityService {
    public async Task<CreateOccupationSimilarityResponse> CreateAsync(CreateOccupationSimilarityRequest request,
        CancellationToken cancellationToken = default) {
        var occupationSimilarity = request.Adapt<OccupationSimilarity>();
        repo.Add(occupationSimilarity);
        await repo.SaveChangesAsync(cancellationToken: cancellationToken);

        return occupationSimilarity.Adapt<CreateOccupationSimilarityResponse>();
    }

    public async Task<PaginatedResult<OccupationSimilarityDto>> GetAllAsync(PaginationRequest request,
        OccupationSimilaritySearchRequest? searchRequest, bool loadRelations,
        CancellationToken cancellationToken = default) => (await repo.GetAllAsync(false, request, searchRequest, loadRelations, cancellationToken))
        .Adapt<PaginatedResult<OccupationSimilarityDto>>();

    public async Task<OccupationSimilarityDto> GetByIdAsync(Guid id, bool loadRelations, CancellationToken cancellationToken = default) {
        var occupationSimilarity = await repo.GetByIdAsync(id, true, loadRelations, cancellationToken);
        if (occupationSimilarity is null) throw new NotFoundException(new NotFoundError(id, nameof(OccupationSimilarity)));
        return occupationSimilarity.Adapt<OccupationSimilarityDto>();
    }

    public async Task UpdateAsync(Guid id, UpdateOccupationSimilarityRequest request, CancellationToken cancellationToken = default) {
        var occupationSimilarity = await repo.GetByIdAsync(id, false, false, cancellationToken: cancellationToken);
        if (occupationSimilarity is null)
            throw new NotFoundException(new NotFoundError(id, nameof(OccupationSimilarity)));

        request.Adapt(occupationSimilarity);
        repo.Update(occupationSimilarity);

        await repo.SaveChangesAsync(cancellationToken: cancellationToken);
    }

    public async Task DeleteAsync(Guid id, CancellationToken cancellationToken = default) {
        var occupationSimilarity = await repo.GetByIdAsync(id, false, false, cancellationToken: cancellationToken);
        if (occupationSimilarity is null) throw new NotFoundException(new NotFoundError(id, nameof(OccupationSimilarity)));

        occupationSimilarity.SoftDeleteInfo.SetDeleteObject(userService.GetCurrentUserId());
        await repo.SaveChangesAsync(cancellationToken: cancellationToken);
    }
}