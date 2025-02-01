using LearningManagement.Occupation.Application.InterestTypes.Contracts;
using LearningManagement.Occupation.Application.InterestTypes.Dtos;
using LearningManagement.Occupation.Application.InterestTypes.Dtos.Create;
using LearningManagement.Occupation.Application.InterestTypes.Dtos.Get;
using LearningManagement.Occupation.Domain.InterestTypes;

namespace LearningManagement.Occupation.Application.InterestTypes.Services;

public class InterestTypeService(IInterestTypeRepository repo, IUserService userService) : IInterestTypeService {
    public async Task<CreateInterestTypeResponse> CreateAsync(CreateInterestTypeRequest request, CancellationToken cancellationToken = default) {
        var interestType = request.Adapt<InterestType>();
        repo.Add(interestType);
        await repo.SaveChangesAsync(cancellationToken: cancellationToken);

        return interestType.Adapt<CreateInterestTypeResponse>();
    }

    public async Task<PaginatedResult<InterestTypeDto>> GetAllAsync(PaginationRequest request,
        InterestTypeSearchRequest? searchRequest, bool loadRelations,
        CancellationToken cancellationToken = default) => (await repo.GetAllAsync(false, request, searchRequest, loadRelations, cancellationToken))
        .Adapt<PaginatedResult<InterestTypeDto>>();

    public async Task<InterestTypeDto> GetByIdAsync(long id, bool loadRelations, CancellationToken cancellationToken = default) {
        var interestType = await repo.GetByIdAsync(id, true, loadRelations, cancellationToken);
        if (interestType is null) throw new NotFoundException(new NotFoundError(id, nameof(InterestType)));
        return interestType.Adapt<InterestTypeDto>();
    }

    public async Task UpdateAsync(long id, UpdateInterestTypeRequest request, CancellationToken cancellationToken = default) {
        var interestType = await repo.GetByIdAsync(id, false, false, cancellationToken: cancellationToken);
        if (interestType is null)
            throw new NotFoundException(new NotFoundError(id, nameof(InterestType)));

        request.Adapt(interestType);
        repo.Update(interestType);

        await repo.SaveChangesAsync(cancellationToken: cancellationToken);
    }

    public async Task DeleteAsync(long id, CancellationToken cancellationToken = default) {
        var interestType = await repo.GetByIdAsync(id, false, false, cancellationToken: cancellationToken);
        if (interestType is null) throw new NotFoundException(new NotFoundError(id, nameof(InterestType)));

        interestType.SoftDeleteInfo.SetDeleteObject(userService.GetCurrentUserId());
        await repo.SaveChangesAsync(cancellationToken: cancellationToken);
    }
}