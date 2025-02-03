using LearningManagement.Occupation.Application.EducationDegrees.Dtos;

namespace LearningManagement.Occupation.Application.EducationDegrees.Contracts;

public interface IEducationDegreeService {
    Task<CreateEducationDegreeResponse> CreateAsync(CreateEducationDegreeRequest request, CancellationToken cancellationToken = default);

    Task<PaginatedResult<EducationDegreeDto>> GetAllAsync(PaginationRequest request, EducationDegreeSearchRequest? searchRequest, bool loadRelations,
        CancellationToken cancellationToken = default);

    Task<EducationDegreeDto> GetByIdAsync(Guid id, bool loadRelations, CancellationToken cancellationToken = default);
    Task UpdateAsync(Guid id, UpdateEducationDegreeRequest request, CancellationToken cancellationToken = default);
    Task DeleteAsync(Guid id, CancellationToken cancellationToken = default);
}