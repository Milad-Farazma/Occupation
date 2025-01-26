using LearningManagement.Occupation.Application.EducationFields.Dtos;
using LearningManagement.Occupation.Application.EducationFields.Dtos.Create;
using LearningManagement.Occupation.Application.EducationFields.Dtos.Get;
using LearningManagement.Occupation.Application.EducationFields.Dtos.Update;

namespace LearningManagement.Occupation.Application.EducationFields.Contracts;

public interface IEducationFieldService {
    Task<CreateEducationFieldResponse> CreateAsync(CreateEducationFieldRequest request, CancellationToken cancellationToken = default);

    Task<PaginatedResult<EducationFieldDto>> GetAllAsync(PaginationRequest request, EducationFieldSearchRequest? searchRequest, bool loadRelations,
        CancellationToken cancellationToken = default);

    Task<EducationFieldDto> GetByIdAsync(long id, bool loadRelations, CancellationToken cancellationToken = default);
    Task UpdateAsync(long id, UpdateEducationFieldRequest request, CancellationToken cancellationToken = default);
    Task DeleteAsync(long id, CancellationToken cancellationToken = default);
}