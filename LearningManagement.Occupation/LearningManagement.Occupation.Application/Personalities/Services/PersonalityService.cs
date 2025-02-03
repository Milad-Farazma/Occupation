using LearningManagement.Occupation.Application.Personalities.Contracts;
using LearningManagement.Occupation.Application.Personalities.Dtos;
using LearningManagement.Occupation.Domain.Personalities;

namespace LearningManagement.Occupation.Application.Personalities.Services;

public class PersonalityService(IPersonalityRepository repo, IUserService userService) : IPersonalityService {
    public async Task<CreatePersonalityResponse> CreateAsync(CreatePersonalityRequest request, CancellationToken cancellationToken = default) {
        var personality = request.Adapt<Personality>();
        repo.Add(personality);
        await repo.SaveChangesAsync(cancellationToken: cancellationToken);

        return personality.Adapt<CreatePersonalityResponse>();
    }

    public async Task<PaginatedResult<PersonalityDto>> GetAllAsync(PaginationRequest request,
        PersonalitySearchRequest? searchRequest, bool loadRelations,
        CancellationToken cancellationToken = default) => (await repo.GetAllAsync(false, request, searchRequest, loadRelations, cancellationToken))
        .Adapt<PaginatedResult<PersonalityDto>>();

    public async Task<PersonalityDto> GetByIdAsync(Guid id, bool loadRelations, CancellationToken cancellationToken = default) {
        var personality = await repo.GetByIdAsync(id, true, loadRelations, cancellationToken);
        if (personality is null) throw new NotFoundException(new NotFoundError(id, nameof(Personality)));
        return personality.Adapt<PersonalityDto>();
    }

    public async Task UpdateAsync(Guid id, UpdatePersonalityRequest request, CancellationToken cancellationToken = default) {
        var personality = await repo.GetByIdAsync(id, false, false, cancellationToken: cancellationToken);
        if (personality is null)
            throw new NotFoundException(new NotFoundError(id, nameof(Personality)));

        request.Adapt(personality);
        repo.Update(personality);

        await repo.SaveChangesAsync(cancellationToken: cancellationToken);
    }

    public async Task DeleteAsync(Guid id, CancellationToken cancellationToken = default) {
        var personality = await repo.GetByIdAsync(id, false, false, cancellationToken: cancellationToken);
        if (personality is null) throw new NotFoundException(new NotFoundError(id, nameof(Personality)));

        personality.SoftDeleteInfo.SetDeleteObject(userService.GetCurrentUserId());
        await repo.SaveChangesAsync(cancellationToken: cancellationToken);
    }
}