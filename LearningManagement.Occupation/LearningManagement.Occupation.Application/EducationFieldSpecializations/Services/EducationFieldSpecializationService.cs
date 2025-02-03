using LearningManagement.Occupation.Application.EducationFieldSpecializations.Contracts;
using LearningManagement.Occupation.Application.EducationFieldSpecializations.Dtos;
using LearningManagement.Occupation.Application.EducationFieldSpecializations.Dtos.Create;
using LearningManagement.Occupation.Application.EducationFieldSpecializations.Dtos.Get;
using LearningManagement.Occupation.Application.EducationFieldSpecializations.Dtos.Update;
using LearningManagement.Occupation.Domain.EducationFieldSpecializations;

namespace LearningManagement.Occupation.Application.EducationFieldSpecializations.Services;

public class EducationFieldSpecializationService(IEducationFieldSpecializationRepository repo, IUserService userService)
    : IEducationFieldSpecializationService {
    public async Task<CreateEducationFieldSpecializationResponse> CreateAsync(CreateEducationFieldSpecializationRequest request,
        CancellationToken cancellationToken = default) {
        var educationFieldSpecialization = request.Adapt<EducationFieldSpecialization>();
        repo.Add(educationFieldSpecialization);
        await repo.SaveChangesAsync(cancellationToken: cancellationToken);

        return educationFieldSpecialization.Adapt<CreateEducationFieldSpecializationResponse>();
    }

    public async Task<PaginatedResult<EducationFieldSpecializationDto>> GetAllAsync(PaginationRequest request,
        EducationFieldSpecializationSearchRequest? searchRequest, bool loadRelations,
        CancellationToken cancellationToken = default) => (await repo.GetAllAsync(false, request, searchRequest, loadRelations, cancellationToken))
        .Adapt<PaginatedResult<EducationFieldSpecializationDto>>();

    public async Task<EducationFieldSpecializationDto> GetByIdAsync(Guid id, bool loadRelations, CancellationToken cancellationToken = default) {
        var educationFieldSpecialization = await repo.GetByIdAsync(id, true, loadRelations, cancellationToken: cancellationToken);
        if (educationFieldSpecialization is null) throw new NotFoundException(new NotFoundError(id, nameof(EducationFieldSpecialization)));
        return educationFieldSpecialization.Adapt<EducationFieldSpecializationDto>();
    }

    public async Task UpdateAsync(Guid id, UpdateEducationFieldSpecializationRequest request, CancellationToken cancellationToken = default) {
        var educationFieldSpecialization = await repo.GetByIdAsync(id, false, false, cancellationToken);
        if (educationFieldSpecialization is null)
            throw new NotFoundException(new NotFoundError(id, nameof(EducationFieldSpecialization)));

        request.Adapt(educationFieldSpecialization);
        repo.Update(educationFieldSpecialization);

        await repo.SaveChangesAsync(cancellationToken: cancellationToken);
    }

    public async Task DeleteAsync(Guid id, CancellationToken cancellationToken = default) {
        var educationFieldSpecialization = await repo.GetByIdAsync(id, false, false, cancellationToken: cancellationToken);
        if (educationFieldSpecialization is null) throw new NotFoundException(new NotFoundError(id, nameof(EducationFieldSpecialization)));

        educationFieldSpecialization.SoftDeleteInfo.SetDeleteObject(userService.GetCurrentUserId());
        await repo.SaveChangesAsync(cancellationToken: cancellationToken);
    }
}