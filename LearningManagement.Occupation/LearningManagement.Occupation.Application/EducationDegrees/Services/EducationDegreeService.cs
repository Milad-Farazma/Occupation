using LearningManagement.Occupation.Application.EducationDegrees.Contracts;
using LearningManagement.Occupation.Application.EducationDegrees.Dtos;
using LearningManagement.Occupation.Domain.EducationDegrees;

namespace LearningManagement.Occupation.Application.EducationDegrees.Services;

public class EducationDegreeService(IEducationDegreeRepository repo, IUserService userService) : IEducationDegreeService {
    public async Task<CreateEducationDegreeResponse>
        CreateAsync(CreateEducationDegreeRequest request, CancellationToken cancellationToken = default) {
        var educationDegree = request.Adapt<EducationDegree>();
        repo.Add(educationDegree);
        await repo.SaveChangesAsync(cancellationToken: cancellationToken);

        return educationDegree.Adapt<CreateEducationDegreeResponse>();
    }

    public async Task<PaginatedResult<EducationDegreeDto>> GetAllAsync(PaginationRequest request,
        EducationDegreeSearchRequest? searchRequest, bool loadRelations,
        CancellationToken cancellationToken = default) => (await repo.GetAllAsync(false, request, searchRequest, loadRelations, cancellationToken))
        .Adapt<PaginatedResult<EducationDegreeDto>>();

    public async Task<EducationDegreeDto> GetByIdAsync(Guid id, bool loadRelations, CancellationToken cancellationToken = default) {
        var educationDegree = await repo.GetByIdAsync(id, true, loadRelations, cancellationToken);
        if (educationDegree is null) throw new NotFoundException(new NotFoundError(id, nameof(EducationDegree)));
        return educationDegree.Adapt<EducationDegreeDto>();
    }

    public async Task UpdateAsync(Guid id, UpdateEducationDegreeRequest request, CancellationToken cancellationToken = default) {
        var educationDegree = await repo.GetByIdAsync(id, false, false, cancellationToken: cancellationToken);
        if (educationDegree is null)
            throw new NotFoundException(new NotFoundError(id, nameof(EducationDegree)));

        request.Adapt(educationDegree);
        repo.Update(educationDegree);

        await repo.SaveChangesAsync(cancellationToken: cancellationToken);
    }

    public async Task DeleteAsync(Guid id, CancellationToken cancellationToken = default) {
        var educationDegree = await repo.GetByIdAsync(id, false, false, cancellationToken: cancellationToken);
        if (educationDegree is null) throw new NotFoundException(new NotFoundError(id, nameof(EducationDegree)));

        educationDegree.SoftDeleteInfo.SetDeleteObject(userService.GetCurrentUserId());
        await repo.SaveChangesAsync(cancellationToken: cancellationToken);
    }
}