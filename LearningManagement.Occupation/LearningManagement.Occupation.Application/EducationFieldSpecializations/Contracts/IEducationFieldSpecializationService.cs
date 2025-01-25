using Framework.Pagination;
using LearningManagement.Occupation.Application.EducationFieldSpecializations.Dtos;

namespace LearningManagement.Occupation.Application.EducationFieldSpecializations.Contracts;

public interface IEducationFieldSpecializationService {
    Task<CreateEducationFieldSpecializationResponse> CreateAsync(CreateEducationFieldSpecializationRequest request,
        CancellationToken cancellationToken = default);

    Task<PaginatedResult<EducationFieldSpecializationDto>> GetAllAsync(PaginationRequest request,
        EducationFieldSpecializationSearchRequest? searchRequest,
        CancellationToken cancellationToken = default);

    Task<PaginatedResult<EducationFieldSpecializationDto>> GetAllWithRelationsAsync(PaginationRequest request,
        EducationFieldSpecializationSearchRequest? searchRequest,
        CancellationToken cancellationToken = default);

    Task<EducationFieldSpecializationDto> GetByIdAsync(long id, CancellationToken cancellationToken = default);
    Task<EducationFieldSpecializationDto> GetByIdWithRelationsAsync(long id, CancellationToken cancellationToken = default);
    Task UpdateAsync(long id, UpdateEducationFieldSpecializationRequest request, CancellationToken cancellationToken = default);
    Task DeleteAsync(long id, CancellationToken cancellationToken = default);
}