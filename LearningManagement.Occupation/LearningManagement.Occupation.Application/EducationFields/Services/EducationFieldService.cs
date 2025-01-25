using Framework.Data.SoftDelete;
using Framework.Exceptions;
using Framework.Pagination;
using Framework.Services.User;
using LearningManagement.Occupation.Application.EducationFields.Contracts;
using LearningManagement.Occupation.Application.EducationFields.Dtos;
using LearningManagement.Occupation.Domain.EducationFields;
using Mapster;

namespace LearningManagement.Occupation.Application.EducationFields.Services;

public class EducationFieldService(IEducationFieldRepository repo, IUserService userService) : IEducationFieldService {
    public async Task<CreateEducationFieldResponse> CreateAsync(CreateEducationFieldRequest request, CancellationToken cancellationToken = default) {
        var educationField = request.Adapt<EducationField>();
        repo.Add(educationField);
        await repo.SaveChangesAsync(cancellationToken: cancellationToken);

        return educationField.Adapt<CreateEducationFieldResponse>();
    }

    public async Task<PaginatedResult<EducationFieldDto>> GetAllAsync(PaginationRequest request,
        EducationFieldSearchRequest? searchRequest,
        CancellationToken cancellationToken = default) => (await repo.GetAllAsync(false, request, searchRequest, cancellationToken))
        .Adapt<PaginatedResult<EducationFieldDto>>();

    public async Task<PaginatedResult<EducationFieldDto>> GetAllWithRelationsAsync(PaginationRequest request,
        EducationFieldSearchRequest? searchRequest, CancellationToken cancellationToken = default) =>
        (await repo.GetAllWithRelationsAsync(false, request, searchRequest, cancellationToken))
        .Adapt<PaginatedResult<EducationFieldDto>>();

    public async Task<EducationFieldDto> GetByIdAsync(long id, CancellationToken cancellationToken = default) {
        var educationField = await repo.GetByIdAsync(id, asNoTracking: true, cancellationToken: cancellationToken);
        if (educationField is null) throw new NotFoundException(new NotFoundError(id, nameof(EducationField)));
        return educationField.Adapt<EducationFieldDto>();
    }

    public async Task<EducationFieldDto> GetByIdWithRelationsAsync(long id, CancellationToken cancellationToken = default) {
        var educationField = await repo.GetByIdWithRelationsAsync(id, asNoTracking: true, cancellationToken: cancellationToken);
        if (educationField is null) throw new NotFoundException(new NotFoundError(id, nameof(EducationField)));
        return educationField.Adapt<EducationFieldDto>();
    }

    public async Task UpdateAsync(long id, UpdateEducationFieldRequest request, CancellationToken cancellationToken = default) {
        var educationField = await repo.GetByIdAsync(id, false, cancellationToken: cancellationToken);
        if (educationField is null)
            throw new NotFoundException(new NotFoundError(id, nameof(EducationField)));

        request.Adapt(educationField);
        repo.Update(educationField);

        await repo.SaveChangesAsync(cancellationToken: cancellationToken);
    }

    public async Task DeleteAsync(long id, CancellationToken cancellationToken = default) {
        var educationField = await repo.GetByIdAsync(id, false, cancellationToken: cancellationToken);
        if (educationField is null) throw new NotFoundException(new NotFoundError(id, nameof(EducationField)));

        educationField.SoftDeleteInfo.SetDeleteObject(userService.GetCurrentUserId());
        await repo.SaveChangesAsync(cancellationToken: cancellationToken);
    }
}