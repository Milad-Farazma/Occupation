using LearningManagement.Occupation.Application.Interests.Contracts;
using LearningManagement.Occupation.Application.Interests.Dtos;
using LearningManagement.Occupation.Application.Interests.Dtos.Create;
using LearningManagement.Occupation.Application.Interests.Dtos.Get;
using LearningManagement.Occupation.Domain.Interests;

namespace LearningManagement.Occupation.Application.Interests.Services;

public class InterestService(IInterestRepository repo, IUserService userService) : IInterestService {
    public async Task<CreateInterestResponse> CreateAsync(CreateInterestRequest request, CancellationToken cancellationToken = default) {
        var interest = request.Adapt<Interest>();
        repo.Add(interest);
        await repo.SaveChangesAsync(cancellationToken: cancellationToken);

        return interest.Adapt<CreateInterestResponse>();
    }

    public async Task<PaginatedResult<InterestDto>> GetAllAsync(PaginationRequest request,
        InterestSearchRequest? searchRequest, bool loadRelations,
        CancellationToken cancellationToken = default) => (await repo.GetAllAsync(false, request, searchRequest, loadRelations, cancellationToken))
        .Adapt<PaginatedResult<InterestDto>>();

    public async Task<InterestDto> GetByIdAsync(long id, bool loadRelations, CancellationToken cancellationToken = default) {
        var interest = await repo.GetByIdAsync(id, true, loadRelations, cancellationToken);
        if (interest is null) throw new NotFoundException(new NotFoundError(id, nameof(Interest)));
        return interest.Adapt<InterestDto>();
    }

    public async Task UpdateAsync(long id, UpdateInterestRequest request, CancellationToken cancellationToken = default) {
        var interest = await repo.GetByIdAsync(id, false, false, cancellationToken: cancellationToken);
        if (interest is null)
            throw new NotFoundException(new NotFoundError(id, nameof(Interest)));

        request.Adapt(interest);
        repo.Update(interest);

        await repo.SaveChangesAsync(cancellationToken: cancellationToken);
    }

    public async Task DeleteAsync(long id, CancellationToken cancellationToken = default) {
        var interest = await repo.GetByIdAsync(id, false, false, cancellationToken: cancellationToken);
        if (interest is null) throw new NotFoundException(new NotFoundError(id, nameof(Interest)));

        interest.SoftDeleteInfo.SetDeleteObject(userService.GetCurrentUserId());
        await repo.SaveChangesAsync(cancellationToken: cancellationToken);
    }
}