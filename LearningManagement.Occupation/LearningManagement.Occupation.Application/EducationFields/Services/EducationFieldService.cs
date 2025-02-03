using LearningManagement.Occupation.Application.EducationFields.Contracts;
using LearningManagement.Occupation.Application.EducationFields.Dtos;
using LearningManagement.Occupation.Application.EducationFields.Dtos.Create;
using LearningManagement.Occupation.Application.EducationFields.Dtos.Get;
using LearningManagement.Occupation.Application.EducationFields.Dtos.Update;
using LearningManagement.Occupation.Domain.EducationFields;

namespace LearningManagement.Occupation.Application.EducationFields.Services;

public class EducationFieldService(IEducationFieldRepository repo, IUserService userService) : IEducationFieldService {
    public async Task<CreateEducationFieldResponse> CreateAsync(CreateEducationFieldRequest request, CancellationToken cancellationToken = default) {
        var educationField = request.Adapt<EducationField>();
        repo.Add(educationField);
        await repo.SaveChangesAsync(cancellationToken: cancellationToken);

        return educationField.Adapt<CreateEducationFieldResponse>();
    }

    public async Task<PaginatedResult<EducationFieldDto>> GetAllAsync(PaginationRequest request,
        EducationFieldSearchRequest? searchRequest, bool loadRelations,
        CancellationToken cancellationToken = default) =>
        (await repo.GetAllAsync(false, request, searchRequest, loadRelations, cancellationToken))
        .Adapt<PaginatedResult<EducationFieldDto>>();

    public async Task<EducationFieldDto> GetByIdAsync(Guid id, bool loadRelations, CancellationToken cancellationToken = default) {
        var educationField = await repo.GetByIdAsync(id, true, loadRelations, cancellationToken: cancellationToken);
        if (educationField is null) throw new NotFoundException(new NotFoundError(id, nameof(EducationField)));
        return educationField.Adapt<EducationFieldDto>();
    }

    public async Task UpdateAsync(Guid id, UpdateEducationFieldRequest request, CancellationToken cancellationToken = default) {
        var educationField = await repo.GetByIdAsync(id, false, false, cancellationToken: cancellationToken);
        if (educationField is null)
            throw new NotFoundException(new NotFoundError(id, nameof(EducationField)));

        request.Adapt(educationField);
        repo.Update(educationField);

        await repo.SaveChangesAsync(cancellationToken: cancellationToken);
    }

    public async Task DeleteAsync(Guid id, CancellationToken cancellationToken = default) {
        var educationField = await repo.GetByIdAsync(id, false, false, cancellationToken: cancellationToken);
        if (educationField is null) throw new NotFoundException(new NotFoundError(id, nameof(EducationField)));

        educationField.SoftDeleteInfo.SetDeleteObject(userService.GetCurrentUserId());
        await repo.SaveChangesAsync(cancellationToken: cancellationToken);
    }
}