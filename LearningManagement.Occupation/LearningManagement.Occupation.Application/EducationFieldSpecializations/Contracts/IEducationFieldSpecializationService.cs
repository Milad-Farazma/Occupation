using LearningManagement.Occupation.Application.EducationFieldSpecializations.Dtos;
using LearningManagement.Occupation.Application.EducationFieldSpecializations.Dtos.Create;
using LearningManagement.Occupation.Application.EducationFieldSpecializations.Dtos.Get;
using LearningManagement.Occupation.Application.EducationFieldSpecializations.Dtos.Update;

namespace LearningManagement.Occupation.Application.EducationFieldSpecializations.Contracts;

public interface IEducationFieldSpecializationService {
    Task<CreateEducationFieldSpecializationResponse> CreateAsync(CreateEducationFieldSpecializationRequest request,
        CancellationToken cancellationToken = default);

    Task<PaginatedResult<EducationFieldSpecializationDto>> GetAllAsync(PaginationRequest request,
        EducationFieldSpecializationSearchRequest? searchRequest, bool loadRelations,
        CancellationToken cancellationToken = default);

    Task<EducationFieldSpecializationDto> GetByIdAsync(Guid id, bool loadRelations, CancellationToken cancellationToken = default);
    Task UpdateAsync(Guid id, UpdateEducationFieldSpecializationRequest request, CancellationToken cancellationToken = default);
    Task DeleteAsync(Guid id, CancellationToken cancellationToken = default);
}