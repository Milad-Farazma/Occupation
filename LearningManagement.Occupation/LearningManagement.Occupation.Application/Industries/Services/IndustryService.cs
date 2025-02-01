using LearningManagement.Occupation.Application.Industries.Contracts;
using LearningManagement.Occupation.Application.Industries.Dtos;
using LearningManagement.Occupation.Domain.Industries;

namespace LearningManagement.Occupation.Application.Industries.Services;

public class IndustriesService(IIndustryRepository repo, IUserService userService) : IIndustryService {
    public async Task<CreateIndustryResponse> CreateAsync(CreateIndustryRequest request, CancellationToken cancellationToken = default) {
        var industry = request.Adapt<Industry>();
        repo.Add(industry);
        await repo.SaveChangesAsync(cancellationToken: cancellationToken);

        return industry.Adapt<CreateIndustryResponse>();
    }

    public async Task<PaginatedResult<IndustryDto>> GetAllAsync(PaginationRequest request,
        IndustrySearchRequest? searchRequest, bool loadRelations,
        CancellationToken cancellationToken = default) => (await repo.GetAllAsync(false, request, searchRequest, loadRelations, cancellationToken))
        .Adapt<PaginatedResult<IndustryDto>>();

    public async Task<IndustryDto> GetByIdAsync(long id, bool loadRelations, CancellationToken cancellationToken = default) {
        var industry = await repo.GetByIdAsync(id, true, loadRelations, cancellationToken);
        if (industry is null) throw new NotFoundException(new NotFoundError(id, nameof(Industry)));
        return industry.Adapt<IndustryDto>();
    }

    public async Task UpdateAsync(long id, UpdateIndustryRequest request, CancellationToken cancellationToken = default) {
        var industry = await repo.GetByIdAsync(id, false, false, cancellationToken: cancellationToken);
        if (industry is null)
            throw new NotFoundException(new NotFoundError(id, nameof(Industry)));

        request.Adapt(industry);
        repo.Update(industry);

        await repo.SaveChangesAsync(cancellationToken: cancellationToken);
    }

    public async Task DeleteAsync(long id, CancellationToken cancellationToken = default) {
        var industry = await repo.GetByIdAsync(id, false, false, cancellationToken: cancellationToken);
        if (industry is null) throw new NotFoundException(new NotFoundError(id, nameof(Industry)));

        industry.SoftDeleteInfo.SetDeleteObject(userService.GetCurrentUserId());
        await repo.SaveChangesAsync(cancellationToken: cancellationToken);
    }
}