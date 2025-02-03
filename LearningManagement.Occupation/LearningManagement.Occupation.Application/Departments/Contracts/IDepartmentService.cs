using LearningManagement.Occupation.Application.Departments.Dtos;
using LearningManagement.Occupation.Application.Departments.Dtos.Create;
using LearningManagement.Occupation.Application.Departments.Dtos.Get;

namespace LearningManagement.Occupation.Application.Departments.Contracts;

public interface IDepartmentService {
    Task<CreateDepartmentResponse> CreateAsync(CreateDepartmentRequest request, CancellationToken cancellationToken = default);

    Task<PaginatedResult<DepartmentDto>> GetAllAsync(PaginationRequest request, DepartmentSearchRequest? searchRequest, bool loadRelations,
        CancellationToken cancellationToken = default);

    Task<DepartmentDto> GetByIdAsync(Guid id, bool loadRelations, CancellationToken cancellationToken = default);
    Task UpdateAsync(Guid id, UpdateDepartmentRequest request, CancellationToken cancellationToken = default);
    Task DeleteAsync(Guid id, CancellationToken cancellationToken = default);
}