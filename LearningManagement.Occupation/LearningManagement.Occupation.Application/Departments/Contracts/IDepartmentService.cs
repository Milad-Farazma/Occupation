using LearningManagement.Occupation.Application.Departments.Dtos;

namespace LearningManagement.Occupation.Application.Departments.Contracts;

public interface IDepartmentService {
    Task<CreateDepartmentResponse> CreateAsync(CreateDepartmentRequest request, CancellationToken cancellationToken = default);

    Task<PaginatedResult<DepartmentDto>> GetAllAsync(PaginationRequest request, DepartmentSearchRequest? searchRequest, bool loadRelations,
        CancellationToken cancellationToken = default);

    Task<DepartmentDto> GetByIdAsync(long id, bool loadRelations, CancellationToken cancellationToken = default);
    Task UpdateAsync(long id, UpdateDepartmentRequest request, CancellationToken cancellationToken = default);
    Task DeleteAsync(long id, CancellationToken cancellationToken = default);
}